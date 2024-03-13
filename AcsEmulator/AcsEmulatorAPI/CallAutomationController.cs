﻿using AcsEmulatorAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace AcsEmulatorAPI
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/CallAutomation/stable/2023-10-15/communicationservicescallautomation.json
    public static class CallAutomationController
    {
        public static void AddCallAutomationEndpoints(this WebApplication app)
        {
            app.MapPost("/calling/callConnections", async (AcsDbContext db, CreateCallRequest req) =>
            {
                // MVP0: PhoneNumber places a call to a CommunicationUser

                if (req.Targets.IsNullOrEmpty())
                {
                    return Results.Forbid();
                }

                var callConnection = CallConnection.CreateNew(req.CallbackUri, req.SourceCallerIdNumber.Value);

                callConnection.AddTargets(req.Targets);

                await db.CallConnections.AddAsync(callConnection);
                await db.SaveChangesAsync();

                var result = new
                {
                    CallConnectionProperties = new
                    {
                        callConnection.Id,
                        callConnection.CallConnectionState,
                        callConnection.CallbackUri,
                        callConnection.CorrelationId,
                        callConnection.ServerCallId,
                        callConnection.SourceCallerIdNumber,
                        Targets = callConnection.Targets.Select(x => new CommunicationIdentifier(x.RawId)).ToList()
                    }
                };
                return Results.Created($"/calling/callConnections/{callConnection.Id}", result);
            });
        }
    }
}