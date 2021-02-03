using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat
{
    public interface IPermanentStat
    {
        IStatFormula Formula { get; }

        PermanentStatType StatType { get; }

        int BaseValue { get; }

        int Level { get; set; }

        int IndividualValue { get; }

        int EffortValue { get; }

        int ModifiedValue { get; }

        IModifierToken AddMultiplier(decimal multiplier);
    }
}
