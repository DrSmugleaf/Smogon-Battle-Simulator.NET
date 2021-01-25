using SmogonBattleSimulator.NET.Extensions;
using SmogonBattleSimulator.NET.Generations.I.Formulas;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public class BattleStatBuilder
    {
        public BattleStatBuilder(IStatFormula statFormula)
        {
            StatFormula = statFormula;
        }

        public IStatFormula StatFormula { get; }

        public int? BaseValue { get; set; }

        public int? Level { get; set; }

        public int? IndividualValue { get; set; }

        public int? EffortValue { get; set;  }

        public IBattleStat Build(BattleStatType type)
        {
            return new BattleStat(
                StatFormula,
                type,
                BaseValue.GetOrThrow(),
                Level.GetOrThrow(),
                IndividualValue.GetOrThrow(),
                EffortValue.GetOrThrow());
        }
    }
}
