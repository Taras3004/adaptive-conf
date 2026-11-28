namespace AdaptiveConf.Application.Room
{
    public sealed record Heartbeat
    {
        public required Guid FromParticipantId { get; init; }
        public required long Epoch { get; init; }
        public required DateTimeOffset SentAt { get; init; }
    }
}
