namespace AdaptiveConf.Application.Election
{
    public interface IRelayElector
    {
        RelayElectionResult Elect(ElectionInput input);
    }
}
