using SmogonBattleSimulator.NET.Collections.UniqueDictionary;

namespace SmogonBattleSimulator.NET.Generations.I.Format.Registry
{
    public class FormatRegistry : IFormatRegistry
    {
        public FormatRegistry(IReadOnlyUniqueDictionary<string, IFormat> formats)
        {
            Formats = formats;
        }

        public IReadOnlyUniqueDictionary<string, IFormat> Formats { get; }
    }
}
