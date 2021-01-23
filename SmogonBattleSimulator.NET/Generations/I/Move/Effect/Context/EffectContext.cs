using SmogonBattleSimulator.NET.Generations.I.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context
{
    public class EffectContext : IEffectContext
    {
        public EffectContext(IBattlePokemon user, IBattle battle)
        {
            User = user;
            Battle = battle;
        }

        public IBattlePokemon User { get; }

        public IBattle Battle { get; }
    }
}
