using AdaptiveConf.Application.Metrics;

namespace AdaptiveConf.Application.Election
{
    public sealed record ElectionInput
    {
        public required IReadOnlyList<NodeMetrics> Candidates { get; init; }
        public required Guid? CurrentRelayId { get; init; }
        public required DateTimeOffset? LastSwitchAt { get; init; }
        public required DateTimeOffset Now { get; init; }
    }
}
