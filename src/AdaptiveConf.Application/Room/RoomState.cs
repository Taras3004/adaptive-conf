namespace AdaptiveConf.Application.Room
{
    public sealed record RoomState
    {
        public required string RoomCode { get; init; }
        public required long Epoch { get; init; }
        public required Guid RelayId { get; init; }
        public required IReadOnlyList<Guid> Successors { get; init; } // упорядкований список: перший живий стає ретранслятором
        public required IReadOnlyList<ParticipantInfo> Participants { get; init; }
        public required Uri? EntryPoint { get; init; } // куди заходять нові учасники; null, якщо вхід зараз неможливий
    }
}
