namespace AdaptiveConf.Application.Metrics
{
    public sealed record MetricsReport
    {
        public required Guid ParticipantId { get; init; }
        public required DateTimeOffset MeasuredAt { get; init; }
        public required IReadOnlyList<LinkStats> Links { get; init; }
    }
}
