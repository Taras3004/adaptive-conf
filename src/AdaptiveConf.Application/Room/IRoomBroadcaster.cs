using AdaptiveConf.Application.Signaling;

namespace AdaptiveConf.Application.Room
{
    // Вихідний порт: як координатор розсилає повідомлення учасникам кімнати. Реалізується в API.
    public interface IRoomBroadcaster
    {
        Task SendSignalAsync(Guid toParticipantId, SignalEnvelope signal, CancellationToken cancellationToken = default);

        Task ParticipantJoinedAsync(ParticipantInfo participant, CancellationToken cancellationToken = default);

        Task ParticipantLeftAsync(Guid participantId, CancellationToken cancellationToken = default);

        Task RoomStateChangedAsync(RoomState state, CancellationToken cancellationToken = default);

        Task HeartbeatAsync(Heartbeat heartbeat, CancellationToken cancellationToken = default);
    }
}
