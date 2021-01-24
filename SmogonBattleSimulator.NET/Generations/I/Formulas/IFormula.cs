using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public interface IFormula
    {
        int DamageDealt(IEffectContext context, IBattlePokemon target, bool canCrit = true);
    }
}
