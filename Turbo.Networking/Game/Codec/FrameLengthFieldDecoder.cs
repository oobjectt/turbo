﻿using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace Turbo.Networking.Game.Codec
{
    class FrameLengthFieldDecoder : LengthFieldBasedFrameDecoder
    {
        private static readonly int MAX_LENGTH = 500000;
        private static readonly int LENGTH_FIELD_OFFSET = 0;
        private static readonly int LENGTH_FIELD_LENGTH = 4; // 4 byte int
        private static readonly int LENGTH_ADJUSTMENT = 0;
        private static readonly int BYTES_TO_STRIP = 4;

        public FrameLengthFieldDecoder() : base(MAX_LENGTH, LENGTH_FIELD_OFFSET, LENGTH_FIELD_LENGTH, LENGTH_ADJUSTMENT, BYTES_TO_STRIP)
        {
        }

        protected override object Decode(IChannelHandlerContext context, IByteBuffer input)
        {
            return base.Decode(context, input);
        }
    }
}