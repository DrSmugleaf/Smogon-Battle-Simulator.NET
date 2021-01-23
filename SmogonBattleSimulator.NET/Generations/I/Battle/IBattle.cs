using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Generation;
using SmogonBattleSimulator.NET.Generations.I.RandomProvider;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public interface IBattle
    {
        IRandomProvider RandomProvider { get; }

        IFormula Formula { get; }

        IGeneration Generation { get; }

        IReadOnlyIndexedSet<ITrainer> Trainers { get; }
    }
}
