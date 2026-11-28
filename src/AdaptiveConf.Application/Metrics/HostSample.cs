namespace AdaptiveConf.Application.Metrics
{
    public sealed record HostSample
    {
        public required DateTimeOffset At { get; init; }
        public required double CpuPercent { get; init; }
        public required double? LinkSpeedMbps { get; init; }
    }
}
