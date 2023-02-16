#nullable disable

using System.Text.Json;
using System.Text.RegularExpressions;
using static AcsEmulatorAPI.Email;

namespace AcsEmulatorAPI.Models
{
	public class EmailMessage
	{
		public string Id { get; set; }

		public string OperationId { get; set; }

		public string OperationStatus { get; set; }

		public string Subject { get; set; }

		public string PlainText { get; set; }

		public string Html { get; set; }

		public string From { get; set; }

		public string To { get; set; }
		
		public string Cc { get; set; }

		public string Bcc { get; set; }

		public string ReplyTo { get; set; }

		public string Headers { get; set; }

		public bool DisableUserEngagementTracking { get; set; }

		public virtual ICollection<EmailMessageAttachment> Attachments { get; set; }

		internal static EmailMessage FromApiModel(SendEmailRequest emailRequest, string operationId) => EmailMessageExtensions.FromApiModel(emailRequest, operationId);

		internal static SendEmailRequest ToApiModel(EmailMessage emailMessage) => EmailMessageExtensions.ToApiModel(emailMessage);

	}

	public class EmailMessageAttachment
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string ContentBytesBase64 { get; set; }
	}

	static partial class EmailMessageExtensions
	{
		internal static EmailMessage FromApiModel(SendEmailRequest emailRequest, string operationId) => new()
		{
			Id = Guid.NewGuid().ToString(),
			OperationId = operationId,
			OperationStatus = "NotStarted",
			Subject = emailRequest.content.subject,
			PlainText = emailRequest.content.plainText,
			Html = emailRequest.content.html,
			From = emailRequest.senderEmail,
			To = string.Join(",", emailRequest.recipients.to?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Cc = string.Join(",", emailRequest.recipients.cc?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Bcc = string.Join(",", emailRequest.recipients.bcc?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			ReplyTo = string.Join(",", emailRequest.replyTo?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Headers = JsonSerializer.Serialize(emailRequest.headers),
			DisableUserEngagementTracking = emailRequest.disableUserEngagementTracking,
			Attachments = emailRequest.attachments?.Select(x => new EmailMessageAttachment
			{
				Id = Guid.NewGuid().ToString(),
				Name = x.name,
				Type = x.type,
				ContentBytesBase64 = x.contentBytesBase64
			}).ToArray() ?? Array.Empty<EmailMessageAttachment>()
		};

		// lossy, loses attachment ids
		internal static SendEmailRequest ToApiModel(EmailMessage emailMessage) => new SendEmailRequest(
				headers: emailMessage.Headers == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(emailMessage.Headers),
				senderEmail: emailMessage.From,
				content: new EmailContent(emailMessage.Subject, emailMessage.PlainText, emailMessage.Html),
				recipients: new EmailRecipients(
					to: emailMessage.To.Split(",").Select(DeserializeRecipient).ToArray(),
					cc: emailMessage.Cc.Split(",").Select(DeserializeRecipient).ToArray(),
					bcc: emailMessage.Bcc.Split(",").Select(DeserializeRecipient).ToArray()),
				replyTo: emailMessage.ReplyTo.Split(",").Select(DeserializeRecipient).ToArray(),
				attachments: emailMessage.Attachments.Select(x => new EmailAttachment(x.Name, x.Type, x.ContentBytesBase64)).ToArray(),
				disableUserEngagementTracking: emailMessage.DisableUserEngagementTracking
				);

		private static string SerializeRecipient(EmailRecipient recipient) => $"{recipient.displayName}<{recipient.email}>";

		private static EmailRecipient DeserializeRecipient(string recipient)
		{
			var match = RecipientRegex().Match(recipient);
			return new EmailRecipient(match.Groups["email"].Value, match.Groups["displayName"].Value);
		}

		[GeneratedRegex("^(?<displayName>[^<]*(?<emailName><.+>))$", RegexOptions.Compiled | RegexOptions.Singleline)]
		private static partial Regex RecipientRegex();
	}
}
