using AdaptiveConf.Application.Signaling;

namespace AdaptiveConf.Application.Room
{
    public interface IConferenceHubClient
    {
        Task SignalReceived(SignalEnvelope signal);

        Task ParticipantJoined(ParticipantInfo participant);

        Task ParticipantLeft(Guid participantId);

        Task RoomStateChanged(RoomState state);

        Task HeartbeatReceived(Heartbeat heartbeat);
    }
}