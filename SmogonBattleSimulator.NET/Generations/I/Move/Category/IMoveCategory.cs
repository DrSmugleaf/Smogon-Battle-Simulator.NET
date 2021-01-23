using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public interface IMoveCategory
    {
        string Name { get; }

        ISpeciesStat AttackStat { get; }

        ISpeciesStat DefenseStat { get; }
    }
}
