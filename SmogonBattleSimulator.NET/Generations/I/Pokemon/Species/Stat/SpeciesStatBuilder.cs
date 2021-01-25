using SmogonBattleSimulator.NET.Extensions;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public class SpeciesStatBuilder
    {
        public int? Value { get; set; }

        public ISpeciesStat Build(StatType type)
        {
            return new SpeciesStat(type, Value.GetOrThrow());
        }
    }
}
