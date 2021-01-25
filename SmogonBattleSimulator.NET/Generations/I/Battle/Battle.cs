using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Events;
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
            Generation = generation;
            Trainers = trainers;
        }

        public IGeneration Generation { get; }

        public IReadOnlyIndexedSet<ITrainer> Trainers { get; }

        public IRandomProvider RandomProvider { get; } = new RandomGenerator();

        public IDamageFormula DamageFormula => Generation.DamageFormula;

        public IStatFormula StatFormula => Generation.StatFormula;

        public IEventBus EventBus { get; } = new EventBus();

        public void End()
        {
            EventBus.Clear();
        }
    }
}
