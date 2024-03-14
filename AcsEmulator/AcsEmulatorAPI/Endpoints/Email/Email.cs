using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcsEmulatorAPI.Endpoints.Email
{
    // https://github.com/Azure/azure-rest-api-specs/blob/7f2488e38b352cf7de3d5c84d0d838fe305cc115/specification/communication/data-plane/Email/stable/2023-03-31/CommunicationServicesEmail.json
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
                return Results.Ok(new EmailSendResult(operationId, EmailStatus.RUNNING));
            }
            return Results.Ok(new EmailSendResult(operationId, EmailStatus.SUCCEEDED));
        }

        // todo: validation, store email in db
        private static async Task<IResult> SendEmailAsync(AcsDbContext db, EmailMessage emailRequest, [FromHeader(Name = "Operation-Id")] string? clientOperationId, HttpContext httpContext)
        {
            var operationId = clientOperationId ?? Guid.NewGuid().ToString();
            httpContext.Response.Headers.Add("retry-after", "2000");
            var location = $"https://{httpContext.Request.Host}/emails/operations/{operationId}";
            httpContext.Response.Headers.Add("Operation-Location", location);

            db.EmailMessages.Add(EmailMessageInternal.FromApiModel(emailRequest, operationId));
            await db.SaveChangesAsync();

            return Results.Accepted(location, new EmailSendResult(operationId, EmailStatus.NOT_STATRED));
        }

        internal record EmailSendResult(string id, string status, string? error = null);

        internal record EmailMessage(Dictionary<string, string> headers, string senderAddress, EmailContent content, EmailRecipients recipients, EmailAttachment[] attachments, EmailAddress[] replyTo, bool userEngagementTrackingDisabled = true);

        internal record EmailContent(string subject, string plainText, string html);

        internal record EmailRecipients(EmailAddress[] to, EmailAddress[] cc, EmailAddress[] bcc);

        internal record EmailAddress(string address, string displayName);

        internal record EmailAttachment(string name, string type, string contentInBase64);

        internal static class EmailStatus
        {
            public const string NOT_STATRED = "NotStarted";
            public const string RUNNING = "Running";
            public const string SUCCEEDED = "Succeeded";
            public const string FAILED = "Failed";
            public const string CANCELED = "Canceled";
        }
    }
}
