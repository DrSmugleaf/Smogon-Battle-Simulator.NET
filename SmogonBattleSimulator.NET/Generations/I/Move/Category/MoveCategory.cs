using SmogonBattleSimulator.NET.Generations.I.Pokemon;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public class MoveCategory : IMoveCategory
    {
        public MoveCategory(string name, StatType attackStat, StatType defenseStat)
        {
            Name = name;
            AttackStatType = attackStat;
            DefenseStatType = defenseStat;
        }

        public string Name { get; }

        public StatType AttackStatType { get; }

        public StatType DefenseStatType { get; }

        public IBattleStat AttackStat(IBattlePokemon attacker)
        {
            return attacker.Stat(AttackStatType);
        }

        public IBattleStat DefenseStat(IBattlePokemon defender)
        {
            return defender.Stat(DefenseStatType);
        }
    }
}
