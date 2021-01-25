using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile
{
    public abstract class BaseNonVolatileStatus : INonVolatileStatus
    {
        public BaseNonVolatileStatus(IBattlePokemon pokemon, IEventBus eventBus)
        {
            Pokemon = pokemon;
            EventHandlers = eventBus.SubscribeEventHandlers(this);
        }

        public abstract string Name { get; }

        public abstract string DisplayName { get; }

        public IBattlePokemon Pokemon { get; }

        private EventHandlerGroup EventHandlers { get; }

        public void OnRemove(IEventBus eventBus)
        {
            EventHandlers.UnsubscribeAll(eventBus);
        }
    }
}
