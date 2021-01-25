using System;
using System.Collections.Generic;
using SmogonBattleSimulator.NET.Extensions;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<System.Type, HashSet<Delegate>> _listeners = new();

        public bool Subscribe<T>(EventListener<T> listener) where T : IEvent
        {
            var type = typeof(T);
            var listeners = _listeners.GetOrCreate(type);

            return listeners.Add(listener);
        }

        public bool Subscribe(System.Type type, Delegate listener)
        {
            if (!listener.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(EventListener<>)))
            {
                throw new ArgumentException($"Listener is not of type {typeof(EventListener<>)}");
            }

            var listeners = _listeners.GetOrCreate(type);
            return listeners.Add(listener);
        }

        public bool Unsubscribe<T>(EventListener<T> listener) where T : IEvent
        {
            var type = typeof(T);

            if (!_listeners.TryGetValue(type, out var listeners))
            {
                return false;
            }

            return listeners.Remove(listener);
        }

        public bool Unsubscribe(System.Type type, Delegate @delegate)
        {
            if (!_listeners.TryGetValue(type, out var listeners))
            {
                return false;
            }

            return listeners.Remove(@delegate);
        }

        public void Clear()
        {
            _listeners.Clear();
        }

        public void Raise(IEvent @event)
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
