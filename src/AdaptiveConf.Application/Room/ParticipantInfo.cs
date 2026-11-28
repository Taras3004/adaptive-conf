using AdaptiveConf.Application.Eligibility;

namespace AdaptiveConf.Application.Room
{
    public sealed record ParticipantInfo
    {
        public required Guid Id { get; init; } // стабільна ідентичність, переживає перепідключення (на відміну від ConnectionId)
        public required string DisplayName { get; init; }
        public required HostEligibility Eligibility { get; init; }
    }
}
