﻿using Turbo.Core.Packets.Messages;

namespace Turbo.Packets.Outgoing.Handshake
{
    public record UserRightsMessage : IComposer
    {
        public int ClubLevel { get; init; }
        public int SecurityLevel { get; init; }
        public bool IsAmbassador { get; init; }
    }
}