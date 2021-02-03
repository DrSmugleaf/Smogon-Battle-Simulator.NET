using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Modifier;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public interface IBattleStat
    {
        IStatFormula Formula { get; }

        BattleStatType StatType { get; }

        decimal Value { get; }

        IModifierToken AddMultiplier(decimal multiplier);
    }
}
