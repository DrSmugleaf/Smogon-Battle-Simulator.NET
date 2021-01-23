using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context
{
    public interface IEffectContext
    {
        IBattle Battle { get; }

        IBattlePokemon User { get; }

        IMove Move { get; }

        IReadOnlySet<IBattlePokemon> Targets { get; }
    }
}
