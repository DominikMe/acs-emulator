using AcsEmulatorAPI.Contracts.Services;
using Azure.Messaging.EventGrid;

namespace AcsEmulatorAPI.Services
{

    public partial class LogEventPublishingService : IEventPublishingService
    {
        private readonly ILogger<LogEventPublishingService> _logger;
        
        public LogEventPublishingService(ILogger<LogEventPublishingService> logger)
        {
            _logger = logger;
        }

        [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Information,
        Message = "EventId: {id}, Subject:{Subject}, Type:{eventType}\nData:{data}")]
        public partial void LogEventGrid(string id, string subject
                                        ,string eventType, string data);


        public async Task SendEvent(EventGridEvent eventToSend)
        {
            _logger.LogInformation("Sending EventGrid event to Log");
            LogEventGrid(eventToSend.Id, eventToSend.Subject, eventToSend.EventType,
                eventToSend.Data.ToString());

        }
    }
}
