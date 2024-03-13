#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcsEmulatorAPI.Models
{
    public class CallConnection
    {
        [Key]
        public Guid Id { get; set; }

        public string AnsweredBy { get; set; }

        public CallConnectionState CallConnectionState { get; set; }

        [Required]
        public string CallbackUri { get; set; }

        public string CognitiveServicesEndpoint { get; set; }

        public string CorrelationId { get; set; }

        public string ServerCallId { get; set; }

        public string Source { get; set; }

        public string SourceCallerIdNumber { get; set; }

        public string SourceDisplayName { get; set; }

        [Required]
        public virtual ICollection<CallConnectionTarget> Targets { get; set; }

        public static CallConnection CreateNew(
            string callbackUri,
            string sourceCallerIdNumber,
            string source = null,
            string sourceCallerDisplayName = null,
            string cognitiveServicesEndpoint = null)
        {
            return new CallConnection
            {
                Id = Guid.NewGuid(),
                CallConnectionState = CallConnectionState.Connecting,
                CallbackUri = callbackUri,
                CognitiveServicesEndpoint = cognitiveServicesEndpoint,
                CorrelationId = $"{Guid.NewGuid()}",
                ServerCallId = $"{Guid.NewGuid()}",
                Source = source,
                SourceCallerIdNumber = sourceCallerIdNumber,
                SourceDisplayName = sourceCallerDisplayName,
                Targets = new List<CallConnectionTarget>()
            };
        }

        public void AddTargets(IEnumerable<CommunicationIdentifier> targets)
        {
            var callConnectionTargets = targets.Select(x => new CallConnectionTarget
            {
                Id = Guid.NewGuid(),
                RawId = x.CommunicationUser?.Id,
                PhoneNumber = x.PhoneNumber?.Value,
                CallConnection = this
            });

            foreach (var target in callConnectionTargets)
            {
                Targets.Add(target);
            }
        }
    }

    public class CallConnectionTarget
    {
        public Guid Id { get; set; }

        public string RawId { get; set; }

        public string PhoneNumber { get; set; }

        public virtual CallConnection CallConnection { get; set; }
    }
}
