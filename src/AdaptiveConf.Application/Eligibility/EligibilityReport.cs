namespace AdaptiveConf.Application.Eligibility
{
    public sealed record EligibilityReport
    {
        public required HostEligibility Eligibility { get; init; }
        public required NatClass Nat { get; init; }
        public required string? PublicEndpoint { get; init; }
        public required string Details { get; init; }
    }
}
