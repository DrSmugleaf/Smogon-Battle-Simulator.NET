using SmogonBattleSimulator.NET.Generations.I.Pokemon;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public interface IMoveCategory
    {
        string Name { get; }

        IBattleStat AttackStat(IBattlePokemon attacker);

        IBattleStat DefenseStat(IBattlePokemon defender);
    }
}
