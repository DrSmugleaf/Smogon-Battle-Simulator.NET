using SmogonBattleSimulator.NET.Generations.I.Generation.Registry;

namespace SmogonBattleSimulator.NET.Generations.I.Generation
{
    public interface IGeneration
    {
        string Name { get; }

        string Shorthand { get; }

        IPokedex Pokedex { get; }
    }
}
