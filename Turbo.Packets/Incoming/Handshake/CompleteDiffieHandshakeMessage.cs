﻿namespace Turbo.Packets.Incoming.Handshake
{
    public record CompleteDiffieHandshakeMessage : IMessageEvent
    {
        public string PublicKey { get; init; }
    }
}