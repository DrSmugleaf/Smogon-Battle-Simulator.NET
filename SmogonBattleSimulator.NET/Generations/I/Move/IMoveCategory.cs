using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;

namespace SmogonBattleSimulator.NET.Generations.I.Move
{
    public interface IMoveCategory
    {
        string Name { get; }

        ISpeciesStat AttackStat { get; }

        ISpeciesStat DefenseStat { get; }
    }
}
