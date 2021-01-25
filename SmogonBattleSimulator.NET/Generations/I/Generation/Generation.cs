using SmogonBattleSimulator.NET.Generations.I.Format.Registry;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Pokedex;

namespace SmogonBattleSimulator.NET.Generations.I.Generation
{
    public class Generation : IGeneration
    {
        private readonly Formula _formula = new();

        public Generation(string name, string shorthand, IPokedex pokedex, IFormatRegistry formatRegistry)
        {
            Name = name;
            Shorthand = shorthand;
            Pokedex = pokedex;
            FormatRegistry = formatRegistry;
        }

        public string Name { get; }

        public string Shorthand { get; }

        public IPokedex Pokedex { get; }

        public IFormatRegistry FormatRegistry { get; }

        public IDamageFormula DamageFormula => _formula;

        public IStatFormula StatFormula => _formula;
    }
}
