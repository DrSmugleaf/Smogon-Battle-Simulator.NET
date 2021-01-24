using System.Collections.Immutable;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect
{
    public interface IEffect
    {
        void OnEventBusCreation(EventBus eventBus);

        ImmutableHashSet<EffectFlag> EffectFlags { get; }

        void Use(IEffectContext context);
    }
}
