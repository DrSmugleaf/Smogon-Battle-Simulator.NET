using System;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public delegate void EventListener<in T>(T @event);

    public interface IEventBus
    {
        /// <summary>
        ///     Subscribes an event listener.
        /// </summary>
        /// <returns>true if it was added, false if it was already added.</returns>
        bool Subscribe<T>(EventListener<T> listener) where T : IEvent;

        bool Subscribe(System.Type type, Delegate listener);

        /// <summary>
        ///     Unsubscribes an event listener.
        /// </summary>
        /// <returns>true if it was removed, false if it was not subscribed.</returns>
        bool Unsubscribe<T>(EventListener<T> listener) where T : IEvent;

        bool Unsubscribe(System.Type type, Delegate listener);

        void Clear();

        void Raise(IEvent @event);
    }
}
