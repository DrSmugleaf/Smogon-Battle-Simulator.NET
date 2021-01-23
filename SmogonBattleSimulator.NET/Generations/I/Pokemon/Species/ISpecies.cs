using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species
{
    public interface ISpecies
    {
        int Id { get; }

        string Name { get; }

        ISpeciesStat Health { get; }

        ISpeciesStat Attack { get; }

        ISpeciesStat Defense { get; }

        ISpeciesStat Special { get; }

        ISpeciesStat Speed { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IReadOnlyIndexedSet<IType> Types { get; }

        IReadOnlyIndexedSet<IMove> Moves { get; }

        ITier Tier { get; }
    }
}
