using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;

namespace SmogonBattleSimulator.NET.Generations.I.Trainer
{
    public class Trainer : ITrainer
    {
        public Trainer(string name, IReadOnlyIndexedSet<IBattlePokemon> pokemons)
        {
            Name = name;
            Pokemons = pokemons;
        }

        public string Name { get; }

        public IReadOnlyIndexedSet<IBattlePokemon> Pokemons { get; }
    }
}
