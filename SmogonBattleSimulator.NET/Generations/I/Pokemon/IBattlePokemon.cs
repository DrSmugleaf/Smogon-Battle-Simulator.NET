using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon
{
    public interface IBattlePokemon
    {
        string Name { get; }

        string Nickname { get; }

        ISpeciesStat Health { get; }

        ISpeciesStat Attack { get; }

        ISpeciesStat Defense { get; }

        ISpeciesStat Special { get; }

        ISpeciesStat Speed { get; }

        ISpeciesStat Evasion { get; }

        ISpeciesStat Accuracy { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IIndexedSet<IType> Types { get; }

        IIndexedSet<IMove> Moves { get; }

        ITier Tier { get; }
    }
}
