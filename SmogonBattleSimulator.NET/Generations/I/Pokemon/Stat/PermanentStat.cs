using System.Collections.Generic;
using System.Linq;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat
{
    public class PermanentStat : IPermanentStat
    {
        public PermanentStat(
            IStatFormula formula,
            PermanentStatType statType,
            int baseValue,
            int level,
            int individualValue,
            int effortValue)
        {
            Formula = formula;
            StatType = statType;
            BaseValue = baseValue;
            Level = level;
            IndividualValue = individualValue;
            EffortValue = effortValue;
            ModifiedValue = baseValue;
            Modifiers = new List<decimal>();
        }

        public IStatFormula Formula { get; }

        public PermanentStatType StatType { get; }

        public int BaseValue { get; }

        public int Level { get; set; }

        public int IndividualValue { get; }

        public int EffortValue { get; }

        public int ModifiedValue { get; private set; }

        private List<decimal> Modifiers { get; }

        private void Recalculate()
        {
            var modifier = Modifiers.Aggregate(1M, (x, y) => x * y);

            ModifiedValue = (int) (Formula.CalculateStat(this) * modifier);
        }

        public IModifierToken AddMultiplier(decimal multiplier)
        {
            Modifiers.Add(multiplier);
            Recalculate();
            return new ModifierToken(() => Modifiers.Remove(multiplier));
        }
    }
}
