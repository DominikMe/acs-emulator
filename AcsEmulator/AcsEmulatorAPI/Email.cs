namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/7148f91d0d78122daa384af5574f992437b7c8be/specification/communication/data-plane/Email/preview/2023-01-15-preview/CommunicationServicesEmail.json
	public static class Email
	{
		public static RouteGroupBuilder MapEmailsApi(this RouteGroupBuilder group)
		{
			group.MapGet("/emails/operations/{operationId}", GetOperation);
			group.MapPost("/emails:send", SendEmail);
			return group;
		}

		// todo: read status from db and write succeeded status back to db
		private static IResult GetOperation(string operationId, HttpContext http)
		{
			if (Random.Shared.Next(4) != 0)
			{
				http.Response.Headers.Add("retry-after", "2000");
				return Results.Ok(new OperationStatus(operationId, "Running"));
			}
			return Results.Ok(new OperationStatus(operationId, "Succeeded"));
		}

		// todo: validation, store email in db
		private static IResult SendEmail(SendEmailRequest emailRequest, HttpContext http)
		{
			var operationId = Guid.NewGuid().ToString();
			if (http.Request.Headers.TryGetValue("Operation-Id", out var clientOperationId))
			{
				operationId = clientOperationId.ToString();
			}
			http.Response.Headers.Add("retry-after", "2000");
			var location = $"https://{http.Request.Host}/emails/operations/{operationId}";
			http.Response.Headers.Add("Operation-Location", location);
			return Results.Accepted(location, new OperationStatus(operationId, "NotStarted"));
		}

		record OperationStatus(string id, string status);

		record SendEmailRequest(Dictionary<string, string> headers, string senderEmail, EmailContent content, EmailRecipients recipients, EmailAttachment[] attachments, EmailRecipient[] replyTo, bool disableUserEngagementTracking = true);

		record EmailContent(string subject, string plainText, string html);

		record EmailRecipients(EmailRecipient[] to, EmailRecipient[] cc, EmailRecipient[] bcc);

		record EmailRecipient(string email, string displayName);

		record EmailAttachment(string name, string type, string contentBytesBase64);
	}
}
