using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public interface IStatFormula
    {
        int CalculateStat(IPermanentStat stat);

        int AccuracyThreshold(int moveAccuracy, decimal accuracyStage, decimal evasionStage, bool holdingBrightPowder);
    }
}
