using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species
{
    public interface ISpecies
    {
        string Name { get; }

        ISpeciesStat Health { get; }

        ISpeciesStat Attack { get; }

        ISpeciesStat Defense { get; }

        ISpeciesStat Special { get; }

        ISpeciesStat Speed { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IReadOnlySet<IType> Types { get; }

        IReadOnlySet<IMove> Moves { get; }
    }
}
