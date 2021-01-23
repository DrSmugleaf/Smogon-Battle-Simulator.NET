using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context
{
    public class EffectContext : IEffectContext
    {
        public EffectContext(IBattle battle, IBattlePokemon user, IMove move, IReadOnlySet<IBattlePokemon> targets)
        {
            Battle = battle;
            User = user;
            Move = move;
            Targets = targets;
        }

        public IBattle Battle { get; }

        public IBattlePokemon User { get; }

        public IMove Move { get; }

        public IReadOnlySet<IBattlePokemon> Targets { get; }
    }
}
