namespace AdaptiveConf.Application.Eligibility
{
    public interface IEligibilityChecker
    {
        Task<EligibilityReport> CheckAsync(CancellationToken cancellationToken = default);
    }
}