using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public class BattleStatCollection
    {
        public BattleStatCollection(IReadOnlyDictionary<BattleStatType, IBattleStat> stats)
        {
            Accuracy = stats[BattleStatType.Accuracy];
            Evasion = stats[BattleStatType.Evasion];
        }

        public IBattleStat Accuracy { get; }

        public IBattleStat Evasion { get; }
    }
}
