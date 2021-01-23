using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public class Battle : IBattle
    {
        public Battle(IReadOnlyIndexedSet<ITrainer> trainers)
        {
            Trainers = trainers;
        }

        public IReadOnlyIndexedSet<ITrainer> Trainers { get; }
    }
}
