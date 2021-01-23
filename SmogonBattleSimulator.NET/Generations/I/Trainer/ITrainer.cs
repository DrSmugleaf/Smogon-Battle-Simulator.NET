using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Trainer
{
    public interface ITrainer
    {
        string Name { get; }

        IReadOnlyIndexedSet<IBattlePokemon> Pokemons { get; }
    }
}
