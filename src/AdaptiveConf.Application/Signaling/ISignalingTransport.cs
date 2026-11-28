using AdaptiveConf.Application.Metrics;
using AdaptiveConf.Application.Room;

namespace AdaptiveConf.Application.Signaling
{
    public interface ISignalingTransport : IAsyncDisposable
    {
        Task ConnectAsync(Uri entryPoint, CancellationToken cancellationToken = default);

        Task<JoinResult> JoinAsync(JoinRequest request, CancellationToken cancellationToken = default);

        Task LeaveAsync(CancellationToken cancellationToken = default);

        Task SendSignalAsync(SignalEnvelope signal, CancellationToken cancellationToken = default);

        Task SendHeartbeatAsync(Heartbeat heartbeat, CancellationToken cancellationToken = default);

        Task SendMetricsAsync(NodeMetrics metrics, CancellationToken cancellationToken = default);

        event Func<SignalEnvelope, Task> SignalReceived;

        event Func<ParticipantInfo, Task> ParticipantJoined;

        event Func<Guid, Task> ParticipantLeft;

        event Func<RoomState, Task> RoomStateChanged;

        event Func<Heartbeat, Task> HeartbeatReceived;

        event Func<Exception?, Task> Disconnected;
    }
}