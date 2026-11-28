using AdaptiveConf.Application.Metrics;
using AdaptiveConf.Application.Room;
using AdaptiveConf.Application.Signaling;

namespace AdaptiveConf.Application.Node
{
    // Логіка локального вузла (працює на кожному вузлі). UiHub делегує сюди.
    public interface INodeSession
    {
        Task<JoinResult> JoinAsync(Uri entryPoint, JoinRequest request, CancellationToken cancellationToken = default);

        Task LeaveAsync(CancellationToken cancellationToken = default);

        Task HandleLocalSignalAsync(SignalEnvelope signal, CancellationToken cancellationToken = default);

        // MetricsReport (браузер) + HostSample (ОС) -> NodeMetrics -> ретранслятору
        Task HandleLocalMetricsAsync(MetricsReport report, CancellationToken cancellationToken = default);
    }
}
