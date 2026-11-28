namespace AdaptiveConf.Application.Metrics
{
    public interface IHostMetricsSource
    {
        Task<HostSample> SampleAsync(CancellationToken cancellationToken = default);
    }
}
