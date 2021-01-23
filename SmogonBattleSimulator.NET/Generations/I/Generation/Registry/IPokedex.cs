using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.UniqueDictionary;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;

namespace SmogonBattleSimulator.NET.Generations.I.Generation.Registry
{
    public interface IPokedex
    {
        IReadOnlyUniqueDictionary<int, ISpecies> SpeciesIds { get; }

        IReadOnlyUniqueDictionary<string, ISpecies> SpeciesNames { get; }

        IReadOnlySet<ISpecies> Species { get; }
    }
}
