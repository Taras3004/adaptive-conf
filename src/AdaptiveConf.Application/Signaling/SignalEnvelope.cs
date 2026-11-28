namespace AdaptiveConf.Application.Signaling
{
    public sealed record SignalEnvelope
    {
        public required Guid FromParticipantId { get; init; }
        public required Guid ToParticipantId { get; init; }
        public required SignalKind Kind { get; init; }
        public required string Payload { get; init; }
        public required long Epoch { get; init; }
    }
}
