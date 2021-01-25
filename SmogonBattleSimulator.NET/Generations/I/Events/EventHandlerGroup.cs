using System;
using System.Collections;
using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public class EventHandlerGroup : IEnumerable<KeyValuePair<System.Type, Delegate>>
    {
        public EventHandlerGroup(Dictionary<System.Type, Delegate> handlers)
        {
            Handlers = handlers;
        }

        private Dictionary<System.Type, Delegate> Handlers { get; }

        public void UnsubscribeAll(IEventBus eventBus)
        {
            foreach (var (type, handler) in Handlers)
            {
                eventBus.Unsubscribe(type, handler);
            }

            Handlers.Clear();
        }

        public void Deconstruct(out Dictionary<System.Type, Delegate> eventListeners)
        {
            eventListeners = Handlers;
        }

        public IEnumerator<KeyValuePair<System.Type, Delegate>> GetEnumerator()
        {
            return Handlers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
