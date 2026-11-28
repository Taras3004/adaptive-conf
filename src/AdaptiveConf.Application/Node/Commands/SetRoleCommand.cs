namespace AdaptiveConf.Application.Node.Commands
{
    public sealed record SetRoleCommand
    {
        public required NodeRole Role { get; init; }
        public required long Epoch { get; init; }
    }
}
