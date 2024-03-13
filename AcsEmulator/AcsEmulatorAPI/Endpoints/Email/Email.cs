using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcsEmulatorAPI.Endpoints.Email
{
    // https://github.com/Azure/azure-rest-api-specs/blob/7148f91d0d78122daa384af5574f992437b7c8be/specification/communication/data-plane/Email/preview/2023-01-15-preview/CommunicationServicesEmail.json
    public static class Email
    {
        public static RouteGroupBuilder MapEmailsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/emails/operations/{operationId}", GetOperation);
            group.MapPost("/emails:send", SendEmailAsync);

            // "Admin" API for the Emulator UI to be able to display all "sent" Emails
            group.MapGet("/admin/emails", (AcsDbContext db) => Results.Ok(new
            {
                // todo: we're sending down the DB schema because we're lazy. A proper /emails collection would use the API schema
                value = db.EmailMessages
            }));

            return group;
        }

        // todo: read status from db and write succeeded status back to db
        private static IResult GetOperation(string operationId, HttpContext httpContext)
        {
            if (Random.Shared.Next(4) != 0)
            {
                httpContext.Response.Headers.Add("retry-after", "2000");
                return Results.Ok(new OperationStatus(operationId, "Running"));
            }
            return Results.Ok(new OperationStatus(operationId, "Succeeded"));
        }

        // todo: validation, store email in db
        private static async Task<IResult> SendEmailAsync(AcsDbContext db, SendEmailRequest emailRequest, [FromHeader(Name = "Operation-Id")] string? clientOperationId, HttpContext httpContext)
        {
            var operationId = clientOperationId ?? Guid.NewGuid().ToString();
            httpContext.Response.Headers.Add("retry-after", "2000");
            var location = $"https://{httpContext.Request.Host}/emails/operations/{operationId}";
            httpContext.Response.Headers.Add("Operation-Location", location);

            db.EmailMessages.Add(EmailMessage.FromApiModel(emailRequest, operationId));
            await db.SaveChangesAsync();

            return Results.Accepted(location, new OperationStatus(operationId, "NotStarted"));
        }

        internal record OperationStatus(string id, string status);

        internal record SendEmailRequest(Dictionary<string, string> headers, string senderEmail, EmailContent content, EmailRecipients recipients, EmailAttachment[] attachments, EmailRecipient[] replyTo, bool disableUserEngagementTracking = true);

        internal record EmailContent(string subject, string plainText, string html);

        internal record EmailRecipients(EmailRecipient[] to, EmailRecipient[] cc, EmailRecipient[] bcc);

        internal record EmailRecipient(string email, string displayName);

        internal record EmailAttachment(string name, string type, string contentBytesBase64);
    }
}
