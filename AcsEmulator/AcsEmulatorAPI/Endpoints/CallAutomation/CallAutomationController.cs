using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AcsEmulatorAPI.Endpoints.CallAutomation
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/CallAutomation/stable/2023-10-15/communicationservicescallautomation.json
    public class CallAutomationController: IDisposable
    {
        private readonly IDbContextFactory<AcsDbContext> _dbContextFactory;
        private readonly CallAutomationWebSockets _sockets;
        private readonly ILogger<Program> _logger;
        private Dictionary<string, Guid> _connections = new();

        public CallAutomationController(IDbContextFactory<AcsDbContext> dbContextFactory, CallAutomationWebSockets sockets, ILogger<Program> logger)
        {
            _dbContextFactory = dbContextFactory;
            _sockets = sockets;
            _logger = logger;

            ListenToIncomingMessages();
        }

        public void ListenToIncomingMessages() => _sockets.OnIncomingMessage += HandleIncomingMessage;

        public void Dispose() => _sockets.OnIncomingMessage -= HandleIncomingMessage;

        public void HandleIncomingMessage(object _sender, IncomingMessageEventArgs ev)
        {
            _ = HandleAsync();

            async Task HandleAsync()
            {
                using var dbContext = _dbContextFactory.CreateDbContext();
                switch (ev.Action)
                {
                    case "acceptCall":
                        {
                            if (_connections.TryGetValue(ev.From, out var connectionId))
                            {
                                var connection = await dbContext.CallConnections.FindAsync(connectionId);
                                if (connection != null)
                                {
                                    connection.CallConnectionState = CallConnectionState.Connected;
                                    await dbContext.SaveChangesAsync();
                                }
                            }
                            break;
                        }
                    case "declineCall":
                        {
                            if (_connections.TryGetValue(ev.From, out var connectionId))
                            {
                                var connection = await dbContext.CallConnections.FindAsync(connectionId);
                                if (connection != null)
                                {
                                    connection.CallConnectionState = CallConnectionState.Disconnected;
                                    await dbContext.SaveChangesAsync();
                                }
                            }
                            break;
                        }
                }
            }

            AcsDbContext CreateDbContext() => _dbContextFactory.CreateDbContext();
        }

        public void AddEndpoints(WebApplication app)
        {
            string emulatorDeviceNumber = app.Configuration.GetValue<string>("EmulatorDevicePhoneNumber")!;

            app.MapPost("/calling/callConnections", async (AcsDbContext db, CallAutomationWebSockets sockets, CreateCallRequest req) =>
            {
                // MVP0: PhoneNumber places a call to a CommunicationUser
                var callConnection = CallConnection.CreateNew(req.CallbackUri, req.SourceCallerIdNumber?.Value);

                callConnection.AddTargets(req.Targets);

                await db.CallConnections.AddAsync(callConnection);
                await db.SaveChangesAsync();

                var result = new CallConnectionProperties(
                    callConnection.Id,
                    callConnection.CallbackUri,
                    callConnection.Targets.Select(x => new CommunicationIdentifier(new PhoneNumber(x.PhoneNumber))).ToList(),
                    callConnection.CallConnectionState,
                    callConnection.AnsweredBy != null ? new CommunicationUser(callConnection.AnsweredBy) : null,
                    callConnection.CorrelationId,
                    callConnection.ServerCallId,
                    callConnection.Source != null ? new CommunicationIdentifier(callConnection.Source) : null,
                    callConnection.SourceCallerIdNumber != null ? new PhoneNumber(callConnection.SourceCallerIdNumber) : null,
                    callConnection.SourceDisplayName
                );

                if (ContainsEmulatorDeviceNumber(req.Targets))
                {
                    // place call to Emulator UI client
                    await sockets.MakePhoneCall(emulatorDeviceNumber, req.SourceCallerIdNumber?.Value, req.SourceDisplayName);
                    _connections.Add(emulatorDeviceNumber, callConnection.Id);
                }

                return Results.Created($"/calling/callConnections/{callConnection.Id}", result);
            });

            bool ContainsEmulatorDeviceNumber(IEnumerable<CommunicationIdentifier> targets)
                => targets.Any(x => x.PhoneNumber?.Value == emulatorDeviceNumber);

            app.MapPost("/calling/callConnections/{callConnectionId}:play", async (AcsDbContext db, CallAutomationWebSockets sockets, string callConnectionId, PlayRequest req) =>
            {
                var connection = await db.CallConnections.FindAsync(Guid.Parse(callConnectionId));
                if (connection is null) {
                    // todo: validate what ACS is really returning in this case
                    return Results.NotFound();
                };

                if (connection.CallConnectionState != CallConnectionState.Connected)
                {
                    return Results.StatusCode(412);
                }

                List<TextSource> textSources = req.playSources?.Where(x => x.kind == PlaySourceType.Text && x.text is not null).Select(x => x.text).Cast<TextSource>().ToList();
                if (req.playTo.PhoneNumber?.Value == emulatorDeviceNumber && !textSources.IsNullOrEmpty())
                {
                    // tell Emulator UI client to synthesize text - real ACS will send audio, for our emulator the Browser's built-in speech APIs have to do
                    await sockets.PlayText(emulatorDeviceNumber, connection.SourceCallerIdNumber, textSources!.First().text);
                }

                return Results.Accepted();
            });

            app.MapPost("/calling/callConnections/{callConnectionId}:recognize", async (AcsDbContext db, CallAutomationWebSockets sockets, string callConnectionId, RecognizeRequest req) =>
            {
                var connection = await db.CallConnections.FindAsync(Guid.Parse(callConnectionId));
                if (connection is null)
                {
                    // todo: validate what ACS is really returning in this case
                    return Results.NotFound();
                };

                if (connection.CallConnectionState != CallConnectionState.Connected)
                {
                    return Results.StatusCode(412);
                }

                if (req.recognizeOptions.targetParticipant.PhoneNumber?.Value == emulatorDeviceNumber)
                {
                    string prompt = (req.playPrompt.kind == PlaySourceType.Text)
                        ? req.playPrompt.text.text
                        : "";
                    // tell Emulator UI client to recognize speech - real ACS will receive audio, for our emulator the Browser's built-in speech APIs have to do
                    await sockets.RecognizeSpeech(emulatorDeviceNumber, connection.SourceCallerIdNumber, prompt);
                }

                return Results.Accepted();
            });

            app.MapGet("/calling/callConnections/{callConnectionId}", async (string callConnectionId, AcsDbContext db) =>
            {
                // Retrieve the CallConnection entity from the database based on the callConnectionId
                var callConnection = await db.CallConnections.FindAsync(Guid.Parse(callConnectionId));

                if (callConnection == null)
                {
                    // If the CallConnection entity is not found, return a 404 Not Found response
                    return Results.NotFound("Call connection not found.");
                }

                // Return the CallConnection entity properties as the response
                return Results.Ok(new
                {
                    callConnection.Id,
                    callConnection.AnsweredBy,
                    callConnection.CallConnectionState,
                    callConnection.CallbackUri,
                    callConnection.CorrelationId,
                    callConnection.ServerCallId,
                    callConnection.Source,
                    callConnection.SourceCallerIdNumber,
                    callConnection.SourceDisplayName,
                    Targets = callConnection.Targets.Select(x => new CommunicationIdentifier(x.RawId)).ToArray()
                });
            });
        }
    }
}
