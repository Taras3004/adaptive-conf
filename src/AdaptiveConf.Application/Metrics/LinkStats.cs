namespace AdaptiveConf.Application.Metrics
{
    public sealed record LinkStats
    {
        public required Guid PeerId { get; init; }
        public required CandidateType LocalCandidateType { get; init; }
        public required CandidateType RemoteCandidateType { get; init; }
        public required double? RttMs { get; init; } // candidate-pair.currentRoundTripTime
        public required double? InboundJitterMs { get; init; } // inbound-rtp.jitter (якість того, що вузол приймає)
        public required double? RemoteJitterMs { get; init; } // remote-inbound-rtp.jitter (якість того, що вузол відправляє)
        public required double? FractionLost { get; init; } // remote-inbound-rtp.fractionLost, 0..1
        public required double? OutboundKbps { get; init; }
        public required double? InboundKbps { get; init; }
        public required double? AvailableOutgoingKbps { get; init; } // candidate-pair.availableOutgoingBitrate (лише Chromium)
        public required double? EncodeMsPerFrame { get; init; } // totalEncodeTime / framesEncoded за інтервал
        public required QualityLimitationReason Limitation { get; init; }
    }
}
