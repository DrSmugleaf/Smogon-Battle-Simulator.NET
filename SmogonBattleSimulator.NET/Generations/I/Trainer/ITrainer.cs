using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Trainer
{
    public interface ITrainer
    {
        string Name { get; }

        IIndexedSet<IBattlePokemon> Pokemons { get; }
    }
}
