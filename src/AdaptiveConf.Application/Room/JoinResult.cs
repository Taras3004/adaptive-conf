namespace AdaptiveConf.Application.Room
{
    public sealed record JoinResult
    {
        public required bool Success { get; init; }
        public required JoinFailure? Failure { get; init; }
        public required RoomState? Room { get; init; }

        public static JoinResult Ok(RoomState room) => new() { Success = true, Failure = null, Room = room };

        public static JoinResult Fail(JoinFailure failure) => new() { Success = false, Failure = failure, Room = null };
    }
}
