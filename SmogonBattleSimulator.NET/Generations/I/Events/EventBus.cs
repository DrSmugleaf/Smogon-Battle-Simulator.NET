using System;
using System.Collections.Generic;
using SmogonBattleSimulator.NET.Extensions;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<System.Type, HashSet<Delegate>> _listeners = new();

        public bool Subscribe<T>(EventHandler<T> handler) where T : IEvent
        {
            var type = typeof(T);
            var listeners = _listeners.GetOrCreate(type);

            return listeners.Add(handler);
        }

        public bool Unsubscribe<T>(EventHandler<T> handler) where T : IEvent
        {
            var type = typeof(T);

            if (!_listeners.TryGetValue(type, out var listeners))
            {
                return false;
            }

            return listeners.Remove(handler);
        }

        public void Clear()
        {
            _listeners.Clear();
        }

        public void Send(IEvent @event)
        {
            if (_listeners.TryGetValue(@event.GetType(), out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.DynamicInvoke(@event);
                }
            }
        }
    }
}
