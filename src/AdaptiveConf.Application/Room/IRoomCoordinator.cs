using AdaptiveConf.Application.Metrics;
using AdaptiveConf.Application.Signaling;

namespace AdaptiveConf.Application.Room
{
    // Активний лише на вузлі, що хостить кімнату (ретранслятор). ConferenceHub делегує сюди.
    public interface IRoomCoordinator
    {
        Task<JoinResult> AdmitAsync(JoinRequest request, CancellationToken cancellationToken = default);

        Task RemoveAsync(Guid participantId, CancellationToken cancellationToken = default);

        // senderId береться з підключення, а не з SignalEnvelope.FromParticipantId (йому не довіряємо)
        Task RouteSignalAsync(Guid senderId, SignalEnvelope signal, CancellationToken cancellationToken = default);

        Task AcceptMetricsAsync(Guid senderId, NodeMetrics metrics, CancellationToken cancellationToken = default);

        Task AcceptHeartbeatAsync(Heartbeat heartbeat, CancellationToken cancellationToken = default);

        // Наступник (Successors) переймає хостинг кімнати після падіння ретранслятора
        Task StartHostingAsync(RoomState handover, CancellationToken cancellationToken = default);
    }
}
