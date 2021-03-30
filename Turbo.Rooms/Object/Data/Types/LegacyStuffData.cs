﻿using System;
using Turbo.Core.Packets.Messages;

namespace Turbo.Rooms.Object.Data.Types
{
    public class LegacyStuffData : StuffDataBase
    {
        public string Data { get; set; }

        public LegacyStuffData()
        {
            if((Data == null) || Data.Equals("")) Data = "0";

            Console.WriteLine(Data);
        }

        public override string GetLegacyString()
        {
            return Data;
        }

        public override void SetState(string state)
        {
            Data = state;
        }
    }
}
