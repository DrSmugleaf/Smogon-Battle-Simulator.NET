using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public interface IBattleStat
    {
        IStatFormula Formula { get; }

        BattleStatType StatType { get; }

        int BaseValue { get; }

        int Level { get; set; }

        int IndividualValue { get; }

        int EffortValue { get; }

        int ModifiedValue { get; }

        IModifierToken AddMultiplier(decimal multiplier);
    }
}
