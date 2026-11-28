using AdaptiveConf.Application.Eligibility;

namespace AdaptiveConf.Application.Metrics
{
    public sealed record NodeMetrics
    {
        public required Guid NodeId { get; init; }
        public required DateTimeOffset MeasuredAt { get; init; }
        public required double CpuPercent { get; init; }
        public required QualityLimitationReason BrowserLimitation { get; init; }
        public required double? AvailableUploadKbps { get; init; }
        public required double? CurrentUploadKbps { get; init; }
        public required double? UplinkRttMs { get; init; }
        public required double? UplinkJitterMs { get; init; }
        public required double? UplinkLossFraction { get; init; }
        public required NatClass Nat { get; init; }
        public required HostEligibility Eligibility { get; init; }
    }
}
