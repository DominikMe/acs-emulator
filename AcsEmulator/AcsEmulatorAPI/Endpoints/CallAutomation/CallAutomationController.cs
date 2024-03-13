using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AcsEmulatorAPI.Endpoints.CallAutomation
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/CallAutomation/stable/2023-10-15/communicationservicescallautomation.json
    public static class CallAutomationController
    {
        public static void AddCallAutomationEndpoints(this WebApplication app)
        {
            app.MapPost("/calling/callConnections", [Authorize] async (ClaimsPrincipal principal, AcsDbContext db, CreateCallRequest req) =>
            {
                // todo: generate proper id, save to db
                var callConnectionId = Guid.NewGuid().ToString();
                var result = new
                {
                    CallConnectionProperties = new
                    {
                        AnsweredBy = Guid.NewGuid(),
                        CallConnectionId = callConnectionId,
                        req.CallbackUri
                    }
                };
                return Results.Created($"/calling/callConnections/{callConnectionId}", result);
            });
        }
    }
}
