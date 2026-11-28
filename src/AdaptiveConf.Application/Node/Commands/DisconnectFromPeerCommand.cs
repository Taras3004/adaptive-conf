namespace AdaptiveConf.Application.Node.Commands
{
    public sealed record DisconnectFromPeerCommand
    {
        public required Guid PeerId { get; init; }
        public required long Epoch { get; init; }
    }
}
