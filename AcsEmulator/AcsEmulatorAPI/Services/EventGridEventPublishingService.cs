using AcsEmulatorAPI.Contracts.Services;
using Azure;
using Azure.Messaging.EventGrid;

namespace AcsEmulatorAPI.Services
{
    public class EventGridEventPublishingService : IEventPublishingService
    {
        private readonly EventGridPublisherClient _eventGridClient;
        private readonly ILogger<EventGridEventPublishingService> _log;

        public EventGridEventPublishingService(ILogger<EventGridEventPublishingService> logger,
                                               IConfiguration configuration)
        {
            var hostname = configuration["EventGridSimulatorSystemTopicHostname"];
            var key = configuration["EventGridSimulatorSystemTopicCredentials"];

            // This class is only DI if both configuration value are non-null
            _eventGridClient = new EventGridPublisherClient(new System.Uri(hostname!), new AzureKeyCredential(key!));
            _log = logger;
        }

        public async Task SendEvent(EventGridEvent eventToSend)
        {
            _log.LogInformation("Sending event to Event Grid");
            await _eventGridClient.SendEventAsync(eventToSend);
        }
    }
}
