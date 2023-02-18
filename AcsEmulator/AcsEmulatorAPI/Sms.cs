using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Sms/stable/2021-03-07/communicationservicessms.json
    // https://learn.microsoft.com/en-us/rest/api/communication/sms/send?tabs=HTTP
    public static class Sms
    {
        public static void AddSms(this WebApplication app)
        {
            var resourceId = app.Configuration["ResourceId"];

            app.MapPost("/sms", async (AcsDbContext db, EventPublisher eventPublisher, SendMessageRequest req, ILogger<Program> log) =>
            {
                var messagesToAdd = new List<SmsMessage>();
                foreach (var recipient in req.SmsRecipients)
                {
                    var msg = SmsMessage.CreateNew(req.From, recipient.To, req.Message);
                    msg.EnableDeliveryReport = req.SmsSendOptions?.EnableDeliveryReport ?? false;
                    msg.Tag = req.SmsSendOptions?.Tag;

                    messagesToAdd.Add(msg);
                }

                db.SmsMessages.AddRange(messagesToAdd);
                await db.SaveChangesAsync();

                // Publish delivery reports
                foreach (var message in messagesToAdd.Where(m => m.EnableDeliveryReport))
                {
                    try
                    {
                        await eventPublisher.SendSmsDeliveryReport(message.From, message.To, message.Tag);
                    }
                    catch (Exception e)
                    {
                        log.LogError(e, "Failed to publish delivery report");
                    }
                }

                var messages = messagesToAdd.Select(m => new
                {
                    m.To,
                    messageId = m.Id,
                    httpStatusCode = 202,
                    successful = true
                });

                return Results.Accepted(value: new
                {
                    value = messages
                });
            });

            // "Admin" API for the Emulator UI to be able to display all "sent" SMS
            app.MapGet("/admin/sms", (AcsDbContext db) =>
            {
                return Results.Ok(new
                {
                    value = db.SmsMessages
                });
            });
        }

        record SendMessageRequest(
            string From,
            List<SmsRecipient> SmsRecipients,
            string Message,
            SmsSendOptions? SmsSendOptions);

        record SmsRecipient(
            string To,
            string? RepeatabilityRequestId);
            //DateTimeOffset? RepeatabilityFirstSent); todo: fix date parsing

        record SmsSendOptions(bool EnableDeliveryReport, string Tag);
    }
}
