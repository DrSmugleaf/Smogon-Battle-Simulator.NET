using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Generation;
using SmogonBattleSimulator.NET.Generations.I.RandomProvider;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public class Battle : IBattle
    {
        public Battle(IGeneration generation, IReadOnlyIndexedSet<ITrainer> trainers)
        {
            RandomProvider = new RandomProvider.RandomProvider();
            Generation = generation;
            Trainers = trainers;
        }

        public IRandomProvider RandomProvider { get; }

        public IFormula Formula { get; } = new Formula();

        public IGeneration Generation { get; }

        public IReadOnlyIndexedSet<ITrainer> Trainers { get; }
    }
}
