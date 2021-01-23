using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public interface IFormula
    {
        int DamageDealt(IEffectContext context, IBattlePokemon target);
    }
}
