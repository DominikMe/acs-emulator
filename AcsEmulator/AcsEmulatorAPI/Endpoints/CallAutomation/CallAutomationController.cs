using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI.Endpoints.CallAutomation
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/CallAutomation/stable/2023-10-15/communicationservicescallautomation.json
    public static class CallAutomationController
    {
        public static void AddCallAutomationEndpoints(this WebApplication app)
        {
            string emulatorDeviceNumber = app.Configuration.GetValue<string>("EmulatorDevicePhoneNumber")!;

            app.MapPost("/calling/callConnections", async (AcsDbContext db, CallAutomationWebSockets sockets, CreateCallRequest req) =>
            {
                // MVP0: PhoneNumber places a call to a CommunicationUser

                var callConnection = CallConnection.CreateNew(req.CallbackUri, req.SourceCallerIdNumber?.Value);

                callConnection.AddTargets(req.Targets);

                await db.CallConnections.AddAsync(callConnection);
                await db.SaveChangesAsync();

                var result = new
                {
                    CallConnectionProperties = new
                    {
                        CallConnectionId = callConnection.Id,
                        callConnection.AnsweredBy,
                        callConnection.CallConnectionState,
                        callConnection.CallbackUri,
                        callConnection.CorrelationId,
                        callConnection.ServerCallId,
                        callConnection.Source,
                        callConnection.SourceCallerIdNumber,
                        callConnection.SourceDisplayName,
                        Targets = callConnection.Targets.Select(x => new CommunicationIdentifier(x.RawId)).ToList()
                    }
                };

                if (ContainsEmulatorDeviceNumber(req.Targets))
                {
                    // place call to Emulator UI client
                    await sockets.MakePhoneCall(emulatorDeviceNumber, req.SourceCallerIdNumber?.Value, req.SourceDisplayName);
                }

                return Results.Created($"/calling/callConnections/{callConnection.Id}", result);
            });

            bool ContainsEmulatorDeviceNumber(IEnumerable<CommunicationIdentifier> targets)
                => targets.Any(x => x.PhoneNumber?.Value == emulatorDeviceNumber);
        }
    }
}
