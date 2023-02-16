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

            app.MapPost("/sms", async (AcsDbContext db, SendMessageRequest req) =>
            {
                foreach (var recipient in req.SmsRecipients)
                {
                    var msg = SmsMessage.CreateNew(req.From, recipient.To, req.Message);
                    msg.EnableDeliveryReport = req.SmsSendOptions?.EnableDeliveryReport ?? false;
                    msg.Tag = req.SmsSendOptions?.Tag;

                    db.SmsMessages.Add(msg);
                }

                await db.SaveChangesAsync();

                var messages = db.SmsMessages.Select(m => new
                {
                    m.To,
                    messageId = m.Id,
                    httpStatusCode = 202,
                    successfull = true
                });

                return Results.Accepted(value: new
                {
                    value = messages
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
