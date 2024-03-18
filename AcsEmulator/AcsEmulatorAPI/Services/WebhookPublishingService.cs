using Azure.Communication.CallAutomation;

namespace AcsEmulatorAPI.Services;

public class WebhookPublishingService(HttpClient httpClient, ILogger<WebhookPublishingService> logger)
{
    public async Task SendCallConnectedEventAsync(Uri endpoint, string callConnectionId)
    {
        var data = CallAutomationModelFactory.CallConnected(callConnectionId);
        var payload = CreatePayload(nameof(CallConnected), callConnectionId, data);

        await httpClient.PostAsJsonAsync(endpoint, payload);
    }

    public async Task SendChoiceRecognizeCompletedAsync(Uri endpoint, string callConnectionId, string recognitionResult)
    {
        List<object> payload = CreatePayload(nameof(RecognizeCompleted), callConnectionId, CreateData());

        await httpClient.PostAsJsonAsync(endpoint, payload);

        dynamic CreateData()
        => new
        {
            callConnectionId,
            recognitionType = CallMediaRecognitionType.Choices.ToString().ToLowerInvariant(),
            choiceResult = new
            {
                label = recognitionResult,
                recognizedPhrase = recognitionResult
            },
        };
    }

    private static List<object> CreatePayload(string type, string callConnectionId, dynamic data)
        => [CreateCloudEvent(type, callConnectionId, data)];

    private static dynamic CreateCloudEvent(string type, string callConnectionId, dynamic data)
        => new {
            id = Guid.NewGuid().ToString(),
            source = $"calling/callConnections/{callConnectionId}",
            type = $"Microsoft.Communication.{type}",
            data,
            time = DateTime.UtcNow,
            specversion = "1.0",
            datacontenttype = "application/json",
            subject = $"calling/callConnections/{callConnectionId}"
        };
}
