namespace AdaptiveConf.Application.Election
{
    public sealed record ElectionOptions
    {
        public double MaxCpuPercent { get; init; } = 85;
        public double PerStreamKbps { get; init; } = 1500;

        public double UplinkWeight { get; init; } = 0.4;
        public double QualityWeight { get; init; } = 0.4;
        public double CpuWeight { get; init; } = 0.2;

        public double SwitchThreshold { get; init; } = 0.15;
        public TimeSpan Cooldown { get; init; } = TimeSpan.FromSeconds(10);

        public int SuccessorCount { get; init; } = 2;
    }
}