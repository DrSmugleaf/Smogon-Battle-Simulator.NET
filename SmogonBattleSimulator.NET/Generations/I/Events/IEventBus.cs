namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public delegate void EventHandler<in T>(T @event);

    public interface IEventBus
    {
        /// <summary>
        ///     Subscribes an event listener.
        /// </summary>
        /// <returns>true if it was added, false if it was already added.</returns>
        bool Subscribe<T>(EventHandler<T> handler) where T : IEvent;

        /// <summary>
        ///     Unsubscribes an event listener.
        /// </summary>
        /// <returns>true if it was removed, false if it was not subscribed.</returns>
        bool Unsubscribe<T>(EventHandler<T> handler) where T : IEvent;

        void Send(IEvent @event);
    }
}
