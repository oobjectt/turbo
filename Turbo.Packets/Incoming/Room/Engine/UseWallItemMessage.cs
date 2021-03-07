﻿namespace Turbo.Packets.Incoming.Room.Engine
{
    public record UseWallItemMessage : IMessageEvent
    {
        public int ObjectId { get; init; }
        public int Param { get; init; }
    }
}