﻿namespace Turbo.Core.Game.Rooms.Mapping
{
    public interface IRoomModel
    {
        public int Id { get; }
        public string Name { get; }

        public bool DidGenerate { get; }
    }
}