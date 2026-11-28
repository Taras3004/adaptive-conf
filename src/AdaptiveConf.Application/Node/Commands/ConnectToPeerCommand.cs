namespace AdaptiveConf.Application.Node.Commands
{
    public sealed record ConnectToPeerCommand
    {
        public required Guid PeerId { get; init; }
        public required bool IsInitiator { get; init; } // хто створює offer: призначає бекенд, щоб не було зустрічних offer
        public required NodeRole PeerRole { get; init; }
        public required long Epoch { get; init; }
    }
}
