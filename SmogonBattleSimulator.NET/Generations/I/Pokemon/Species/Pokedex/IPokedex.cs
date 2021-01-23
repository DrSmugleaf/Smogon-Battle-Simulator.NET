using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.UniqueDictionary;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Pokedex
{
    public interface IPokedex
    {
        IReadOnlyUniqueDictionary<int, ISpecies> SpeciesIds { get; }

        IReadOnlyUniqueDictionary<string, ISpecies> SpeciesNames { get; }

        IReadOnlySet<ISpecies> Species { get; }
    }
}
