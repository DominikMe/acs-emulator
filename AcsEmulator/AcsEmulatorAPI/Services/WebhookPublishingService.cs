using Azure.Communication.CallAutomation;

namespace AcsEmulatorAPI.Services;

public class WebhookPublishingService(HttpClient httpClient, ILogger<WebhookPublishingService> logger)
{
    public async Task SendCallConnectedEventAsync(Uri endpoint, string callConnectionId)
    {
        var callConnected = CallAutomationModelFactory.CallConnected(callConnectionId);

        var cloudEvent = new
        {
            id = Guid.NewGuid().ToString(),
            source = $"calling/callConnections/{callConnectionId}",
            type = "Microsoft.Communication.CallConnected",
            data = callConnected,
            time = DateTime.UtcNow,
            specversion = "1.0",
            datacontenttype = "application/json",
            subject = $"calling/callConnections/{callConnectionId}"
        };

        var payload = new List<object> { cloudEvent };

        await httpClient.PostAsJsonAsync(endpoint, payload);
    }
}
