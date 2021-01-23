using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.UniqueDictionary;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;

namespace SmogonBattleSimulator.NET.Generations.I.Generation.Registry
{
    public class Pokedex : IPokedex
    {
        public Pokedex(IReadOnlySet<ISpecies> species)
        {
            Species = species;

            var speciesIds = new UniqueDictionary<int, ISpecies>();
            var speciesNames = new UniqueDictionary<string, ISpecies>();

            foreach (var s in species)
            {
                speciesIds[s.Id] = s;
            }

            foreach (var s in species)
            {
                speciesNames[s.Name] = s;
            }

            SpeciesIds = speciesIds;
            SpeciesNames = speciesNames;
        }

        public IReadOnlyUniqueDictionary<int, ISpecies> SpeciesIds { get; }

        public IReadOnlyUniqueDictionary<string, ISpecies> SpeciesNames { get; }

        public IReadOnlySet<ISpecies> Species { get; }
    }
}
