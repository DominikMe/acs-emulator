using Azure.Messaging.EventGrid;

namespace AcsEmulatorAPI.Contracts.Services
{
    public interface IEventPublishingService
    {
        Task SendEvent(EventGridEvent eventToSend);
    }
}
