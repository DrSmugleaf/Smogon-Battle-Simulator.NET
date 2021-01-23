using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Generation;
using SmogonBattleSimulator.NET.Generations.I.RandomProvider;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public interface IBattle
    {
        IGeneration Generation { get; }

        IReadOnlyIndexedSet<ITrainer> Trainers { get; }

        IRandomProvider RandomProvider { get; }

        IFormula Formula { get; }

        IEventBus EventBus { get; }
    }
}
