using System.Collections.Immutable;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect
{
    public abstract class BaseEffect : IEffect
    {
        public virtual ImmutableHashSet<EffectFlag> EffectFlags { get; } = ImmutableHashSet<EffectFlag>.Empty;

        public void OnEventBusCreation(IEventBus eventBus)
        {
            eventBus.SubscribeEventHandlers(this);
        }

        public virtual void Use(IEffectContext context) { }
    }
}
