using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using SmogonBattleSimulator.NET.Generations.I.Formulas;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    [PublicAPI]
    public class BattleStatBuilder
    {
        public BattleStatBuilder(IStatFormula formula)
        {
            Formula = formula;
            Modifiers = new List<decimal>();
        }

        public IStatFormula Formula { get; }

        public List<decimal> Modifiers { get; }

        public IBattleStat Build(BattleStatType type)
        {
            return new BattleStat(Formula, type, Modifiers);
        }

        public Dictionary<BattleStatType, IBattleStat> BuildAllStats()
        {
            var stats = new Dictionary<BattleStatType, IBattleStat>();

            foreach (var type in Enum.GetValues<BattleStatType>())
            {
                stats[type] = Build(type);
            }

            return stats;
        }

        public BattleStatCollection BuildCollection()
        {
            return new(BuildAllStats());
        }
    }
}
