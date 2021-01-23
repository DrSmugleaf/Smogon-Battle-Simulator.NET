using SmogonBattleSimulator.NET.Collections.UniqueDictionary;

namespace SmogonBattleSimulator.NET.Generations.I.Format.Registry
{
    public interface IFormatRegistry
    {
        IReadOnlyUniqueDictionary<string, IFormat> Formats { get; }
    }
}
