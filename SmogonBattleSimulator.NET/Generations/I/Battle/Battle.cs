using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Trainer;

namespace SmogonBattleSimulator.NET.Generations.I.Battle
{
    public class Battle : IBattle
    {
        public Battle(IIndexedSet<ITrainer> trainers)
        {
            Trainers = trainers;
        }

        public IIndexedSet<ITrainer> Trainers { get; }
    }
}
