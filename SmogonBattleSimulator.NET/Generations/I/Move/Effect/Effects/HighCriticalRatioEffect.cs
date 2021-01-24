using System.Collections.Immutable;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Formulas;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Effects
{
    [Effect("HighCriticalRatio")]
    public class HighCriticalRatioEffect : BaseEffect
    {
        public override ImmutableHashSet<EffectFlag> EffectFlags { get; } = ImmutableHashSet.Create(
            EffectFlag.UsedMoveModifier
        );

        [EventHandler]
        private void OnCriticalRatio(CriticalRatioEvent @event)
        {
            @event.Multiplier *= 8;
        }
    }
}
