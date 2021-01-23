using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public interface IMoveCategory
    {
        string Name { get; }

        IBattleStat AttackStat(IBattlePokemon attacker);

        IBattleStat DefenseStat(IBattlePokemon defender);
    }
}
