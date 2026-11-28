using AdaptiveConf.Application.Node.Commands;
using AdaptiveConf.Application.Room;
using AdaptiveConf.Application.Signaling;

namespace AdaptiveConf.Application.Node
{
    public interface IUiHubClient
    {
        Task SignalReceived(SignalEnvelope signal);

        Task ConnectToPeer(ConnectToPeerCommand command);

        Task DisconnectFromPeer(DisconnectFromPeerCommand command);

        Task SetRole(SetRoleCommand command);

        Task RoomStateChanged(RoomState state);
    }
}
