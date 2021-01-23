using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;

namespace SmogonBattleSimulator.NET.Generations.I.Move
{
    public class MoveCategory : IMoveCategory
    {
        public MoveCategory(string name, ISpeciesStat attackStat, ISpeciesStat defenseStat)
        {
            Name = name;
            AttackStat = attackStat;
            DefenseStat = defenseStat;
        }

        public string Name { get; }

        public ISpeciesStat AttackStat { get; }

        public ISpeciesStat DefenseStat { get; }
    }
}
