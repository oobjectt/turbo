﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Rooms.Mapping
{
    public interface IRoomModel
    {
        public int Id { get; }
        public string Name { get; }

        public bool DidGenerate { get; }
    }
}
