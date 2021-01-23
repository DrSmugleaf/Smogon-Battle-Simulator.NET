using SmogonBattleSimulator.NET.Generations.I.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context
{
    public interface IEffectContext
    {
        IBattlePokemon User { get; }

        IBattle Battle { get; }
    }
}
