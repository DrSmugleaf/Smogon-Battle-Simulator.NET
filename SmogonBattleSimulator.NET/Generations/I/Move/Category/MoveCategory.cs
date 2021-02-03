using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Category
{
    public class MoveCategory : IMoveCategory
    {
        public MoveCategory(string name, PermanentStatType attackStat, PermanentStatType defenseStat)
        {
            Name = name;
            AttackStatType = attackStat;
            DefenseStatType = defenseStat;
        }

        public string Name { get; }

        public PermanentStatType AttackStatType { get; }

        public PermanentStatType DefenseStatType { get; }

        public IPermanentStat AttackStat(IBattlePokemon attacker)
        {
            return attacker.Stat(AttackStatType);
        }

        public IPermanentStat DefenseStat(IBattlePokemon defender)
        {
            return defender.Stat(DefenseStatType);
        }
    }
}
