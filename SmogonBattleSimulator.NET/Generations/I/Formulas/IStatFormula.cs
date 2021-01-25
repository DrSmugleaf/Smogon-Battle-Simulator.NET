using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public interface IStatFormula
    {
        int CalculateStat(IBattleStat stat);
    }
}
