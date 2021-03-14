﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Turbo.Core.Networking.Game.Clients;
using Turbo.Core.Packets;
using Turbo.Core.Packets.Messages;

namespace Turbo.Packets
{
    public class PacketMessageHub : IPacketMessageHub
    {
        private readonly ILogger<PacketMessageHub> _logger;

        internal List<IListener> _listeners;
        internal List<object> _callables;
        internal object _listenerLock;
        internal object _callableLock;


        public PacketMessageHub(ILogger<PacketMessageHub> logger)
        {
            this._logger = logger;
            this._listenerLock = new object();
            this._callableLock = new object();
            this._listeners = new List<IListener>();
            this._callables = new List<object>();
        }

        public void Publish<T>(T message, ISession session) where T : IMessageEvent
        {
            bool cancelled = false;
            foreach (ICallable<T> callable in GetCallables<T>())
            {
                if (!callable.Call(message, session))
                {
                    cancelled = true;
                }
            }

            if (!cancelled)
            {
                foreach (IListener listener in GetAliveHandlers<T>())
                {
                    switch (listener.Action)
                    {
                        case Action<T, ISession> action:
                            action(message, session);
                            break;
                        case Func<T, ISession, Task> func:
                            func(message, session);
                            break;
                    }
                }
            }
        }

        public async Task PublishAsync<T>(T message, ISession session) where T : IMessageEvent
        {
            bool cancelled = false;
            foreach (ICallable<T> callable in GetCallables<T>())
            {
                if (!callable.Call(message, session))
                {
                    cancelled = true;
                }
            }

            if (!cancelled)
            {
                foreach (IListener listener in GetAliveHandlers<T>())
                {
                    switch (listener.Action)
                    {
                        case Action<T, ISession> action:
                            action(message, session);
                            break;
                        case Func<T, ISession, Task> func:
                            await func(message, session);
                            break;
                    }
                }
            }
        }

        public void Subscribe<T>(object subscriber, Action<T, ISession> handler) where T : IMessageEvent
        {
            SubscribeDelegate<T>(subscriber, handler);
        }

        public void Subscribe<T>(object subscriber, Func<T, ISession, Task> handler) where T : IMessageEvent
        {
            SubscribeDelegate<T>(subscriber, handler);
        }

        public void RegisterCallable<T>(ICallable<T> callable) where T : IMessageEvent
        {
            lock (_callableLock)
            {
                _callables.Add(callable);
            }
        }

        public void UnRegisterCallable<T>(ICallable<T> callable) where T : IMessageEvent
        {
            lock (_callableLock)
            {
                _callables.Remove(callable);
            }
        }

        public void Unsubscribe(object subscriber)
        {
            lock (_listenerLock)
            {
                _listeners.RemoveAll(x => !x.Sender.IsAlive || x.Sender.Target.Equals(subscriber));
            }
        }

        public void Unsubscribe<T>(object subscriber, Action<T, ISession> handler = null) where T : IMessageEvent
        {
            lock (_listenerLock)
            {
                IEnumerable<IListener> query = _listeners.Where(a => !a.Sender.IsAlive ||
                                                a.Sender.Target.Equals(subscriber) && a.Type == typeof(T));

                if (handler != null)
                    query = query.Where(a => a.Action.Equals(handler));

                foreach (IListener h in query)
                    _listeners.Remove(h);
            }
        }

        public void Unsubscribe<T>(object subscriber, Func<T, ISession, Task> handler) where T : IMessageEvent
        {
            lock (_listenerLock)
            {
                IEnumerable<IListener> query = _listeners.Where(a => !a.Sender.IsAlive ||
                                                a.Sender.Target.Equals(subscriber) && a.Type == typeof(T));

                if (handler != null)
                    query = query.Where(a => a.Action.Equals(handler));

                foreach (IListener h in query)
                    _listeners.Remove(h);
            }
        }

        private void SubscribeDelegate<T>(object subscriber, Delegate handler) where T : IMessageEvent
        {
            IListener item = new Listener
            {
                Action = handler,
                Sender = new WeakReference(subscriber),
                Type = typeof(T)
            };

            lock (_listenerLock)
            {
                _listeners.Add(item);
            }
        }

        private List<IListener> GetAliveHandlers<T>() where T : IMessageEvent
        {
            PruneHandlers();
            return _listeners.Where(h => h.Type.GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo())).ToList();
        }

        public List<ICallable<T>> GetCallables<T>() where T : IMessageEvent
        {
            return _callables.Where(c => c.GetType().IsAssignableTo(typeof(ICallable<T>))).Cast<ICallable<T>>().ToList();
        }

        private void PruneHandlers()
        {
            lock (_listenerLock)
            {
                _listeners.RemoveAll(x => !x.Sender.IsAlive);
            }
        }

        public bool Exists(object subscriber)
        {
            lock (_listenerLock)
            {
                return _listeners.Any(x => Equals(x.Sender.Target, subscriber));
            }
        }

        public bool Exists<T>(object subscriber) where T : IMessageEvent
        {
            lock (_listenerLock)
            {
                return _listeners.Any(x => Equals(x.Sender.Target, subscriber) && typeof(T).Equals(x.Type));
            }
        }

        public bool Exists<T>(object subscriber, Action<T, ISession> handler) where T : IMessageEvent
        {
            lock (_listenerLock)
            {
                return _listeners.Any(x => Equals(x.Sender, subscriber) && typeof(T).Equals(x.Type) && x.Action.Equals(handler));
            }
        }

        public bool Exists<T>(object subscriber, Func<T, ISession, Task> handler) where T : IMessageEvent
        {
            lock (_listenerLock)
            {
                return _listeners.Any(x => Equals(x.Sender, subscriber) && typeof(T).Equals(x.Type) && x.Action.Equals(handler));
            }
        }

        internal class Listener : IListener
        {
            public Delegate Action { get; set; }
            public WeakReference Sender { get; set; }
            public Type Type { get; set; }
        }
    }
}
