using System.Collections.Generic;
using System.Linq;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public class BattleStat : IBattleStat
    {
        public BattleStat(IStatFormula formula, BattleStatType statType, IEnumerable<decimal>? modifiers = null)
        {
            Formula = formula;
            StatType = statType;
            Value = 1;
            Modifiers = modifiers?.ToList() ?? new List<decimal>();
        }

        public IStatFormula Formula { get; }

        public BattleStatType StatType { get; }

        public decimal Value { get; private set; }

        private List<decimal> Modifiers { get; }

        private void Recalculate()
        {
            Value = Modifiers.Aggregate(1M, (x, y) => x * y);
        }

        public IModifierToken AddMultiplier(decimal multiplier)
        {
            Modifiers.Add(multiplier);
            Recalculate();
            return new ModifierToken(() => Modifiers.Remove(multiplier));
        }
    }
}
