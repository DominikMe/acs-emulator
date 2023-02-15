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

            app.MapPost("/sms", dynamic (AcsDbContext db, SendMessageRequest req) =>
            {
                return Results.Accepted(value: new
                {
                    value = new[]
                    {
                        new
                        {
                            to = "+11234567890",
                            messageId = (string?)"Outgoing_20200610203725bfd4ba70-70bf-4f77-925d-c0bdb5161bb3",
                            httpStatusCode = 202,
                            errorMessage = (string?)null,
                            successFull = true
                        },
                        new
                        {
                            to = "+112345678901",
                            messageId = (string?)null,
                            httpStatusCode = 400,
                            errorMessage = (string?)"Invalid To phone number format.",
                            successFull = false
                        }
                    }
                });
            });
        }

        record SendMessageRequest(
            string From,
            List<SmsRecipient> To,
            string Message,
            SmsSendOptions? SmsSendOptions);

        record SmsRecipient(
            string To,
            string? RepeatabilityRequestId,
            DateTimeOffset? RepeatabilityFirstSent);

        record SmsSendOptions(bool EnableDeliveryReport, string Tag);
    }
}
