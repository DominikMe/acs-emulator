using Azure.Communication.CallAutomation;

namespace AcsEmulatorAPI.Services;

public class WebhookPublishingService(ILogger<WebhookPublishingService> logger, HttpClient httpClient)
{
    public async Task SendCallConnectedEventAsync(Uri endpoint, string callConnectionId)
    {
        // TODO: add proper payload

        var payload = CallAutomationModelFactory.CallConnected(callConnectionId);

        await httpClient.PostAsJsonAsync(endpoint, payload);
    }
}
