using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public interface IMoveCategory
    {
        string Name { get; }

        IPermanentStat AttackStat(IBattlePokemon attacker);

        IPermanentStat DefenseStat(IBattlePokemon defender);
    }
}
