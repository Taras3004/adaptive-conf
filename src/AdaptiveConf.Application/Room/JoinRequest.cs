namespace AdaptiveConf.Application.Room
{
    public sealed record JoinRequest
    {
        public required string RoomCode { get; init; }
        public required string? Token { get; init; }
        public required ParticipantInfo Participant { get; init; }
    }
}
