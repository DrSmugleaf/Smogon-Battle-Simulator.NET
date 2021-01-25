using System.Collections.Generic;
using System.Linq;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public class BattleStat : IBattleStat
    {
        public BattleStat(IStatFormula formula, BattleStatType statType, int baseValue, int level, int iv, int ev)
        {
            Formula = formula;
            StatType = statType;
            BaseValue = baseValue;
            ModifiedValue = baseValue;
            Level = level;
            IndividualValue = iv;
            EffortValue = ev;
            Modifiers = new List<decimal>();
        }

        public IStatFormula Formula { get; }

        public BattleStatType StatType { get; }

        public int BaseValue { get; }

        public int Level { get; set; }

        public int IndividualValue { get; }

        public int EffortValue { get; }

        public int ModifiedValue { get; private set; }

        private List<decimal> Modifiers { get; }

        private void Recalculate()
        {
            ModifiedValue = (int) (Formula.CalculateStat(this) * Modifiers.Sum());
        }

        public IModifierToken AddMultiplier(decimal multiplier)
        {
            Modifiers.Add(multiplier);
            Recalculate();
            return new ModifierToken(() => Modifiers.Remove(multiplier));
        }
    }
}
