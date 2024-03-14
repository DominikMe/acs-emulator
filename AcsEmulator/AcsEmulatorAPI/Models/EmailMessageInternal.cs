#nullable disable

using System.Text.Json;
using System.Text.RegularExpressions;
using static AcsEmulatorAPI.Endpoints.Email.Email;

namespace AcsEmulatorAPI.Models
{
	public class EmailMessageInternal
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

		internal static EmailMessageInternal FromApiModel(EmailMessage emailRequest, string operationId) => EmailMessageExtensions.FromApiModel(emailRequest, operationId);

		internal static EmailMessage ToApiModel(EmailMessageInternal emailMessage) => EmailMessageExtensions.ToApiModel(emailMessage);

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
		internal static EmailMessageInternal FromApiModel(EmailMessage emailRequest, string operationId) => new()
		{
			Id = Guid.NewGuid().ToString(),
			OperationId = operationId,
			OperationStatus = "NotStarted",
			Subject = emailRequest.content.subject,
			PlainText = emailRequest.content.plainText,
			Html = emailRequest.content.html,
			From = emailRequest.senderAddress,
			To = string.Join(",", emailRequest.recipients.to?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Cc = string.Join(",", emailRequest.recipients.cc?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Bcc = string.Join(",", emailRequest.recipients.bcc?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			ReplyTo = string.Join(",", emailRequest.replyTo?.Select(SerializeRecipient) ?? Array.Empty<string>()),
			Headers = JsonSerializer.Serialize(emailRequest.headers),
			DisableUserEngagementTracking = emailRequest.userEngagementTrackingDisabled,
			Attachments = emailRequest.attachments?.Select(x => new EmailMessageAttachment
			{
				Id = Guid.NewGuid().ToString(),
				Name = x.name,
				Type = x.type,
				ContentBytesBase64 = x.contentInBase64
			}).ToArray() ?? Array.Empty<EmailMessageAttachment>()
		};

		// lossy, loses attachment ids
		internal static EmailMessage ToApiModel(EmailMessageInternal emailMessage) => new EmailMessage(
				headers: emailMessage.Headers == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(emailMessage.Headers),
				senderAddress: emailMessage.From,
				content: new EmailContent(emailMessage.Subject, emailMessage.PlainText, emailMessage.Html),
				recipients: new EmailRecipients(
					to: emailMessage.To.Split(",").Select(DeserializeRecipient).ToArray(),
					cc: emailMessage.Cc.Split(",").Select(DeserializeRecipient).ToArray(),
					bcc: emailMessage.Bcc.Split(",").Select(DeserializeRecipient).ToArray()),
				replyTo: emailMessage.ReplyTo.Split(",").Select(DeserializeRecipient).ToArray(),
				attachments: emailMessage.Attachments.Select(x => new EmailAttachment(x.Name, x.Type, x.ContentBytesBase64)).ToArray(),
				userEngagementTrackingDisabled: emailMessage.DisableUserEngagementTracking
				);

		private static string SerializeRecipient(EmailAddress recipient) => $"{recipient.displayName}<{recipient.address}>";

		private static EmailAddress DeserializeRecipient(string recipient)
		{
			var match = RecipientRegex().Match(recipient);
			return new EmailAddress(match.Groups["email"].Value, match.Groups["displayName"].Value);
		}

		[GeneratedRegex("^(?<displayName>[^<]*(?<emailName><.+>))$", RegexOptions.Compiled | RegexOptions.Singleline)]
		private static partial Regex RecipientRegex();
	}
}
