namespace AdaptiveConf.Application.Election
{
    public sealed record RelayElectionResult
    {
        public required ElectionOutcome Outcome { get; init; }
        public required Guid? RelayId { get; init; }
        public required IReadOnlyList<Guid> Successors { get; init; }
        public required string? Reason { get; init; }
    }
}
