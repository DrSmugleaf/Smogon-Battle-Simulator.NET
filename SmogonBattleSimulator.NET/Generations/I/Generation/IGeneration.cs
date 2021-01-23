using SmogonBattleSimulator.NET.Generations.I.Format.Registry;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Pokedex;

namespace SmogonBattleSimulator.NET.Generations.I.Generation
{
    public interface IGeneration
    {
        string Name { get; }

        string Shorthand { get; }

        IPokedex Pokedex { get; }

        IFormatRegistry FormatRegistry { get; }
    }
}
