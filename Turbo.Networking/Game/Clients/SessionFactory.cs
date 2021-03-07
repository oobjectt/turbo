﻿using DotNetty.Transport.Channels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Turbo.Packets.Revisions;
using Turbo.Packets.Sessions;

namespace Turbo.Networking.Game.Clients
{
    public class SessionFactory : ISessionFactory
    {
        private readonly IServiceProvider _provider;

        public SessionFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ISession Create(IChannelHandlerContext context, IRevision initialRevision)
        {
            ILogger<Session> logger = _provider.GetService<ILogger<Session>>();
            return new Session(context, initialRevision, logger);
        }
    }
}