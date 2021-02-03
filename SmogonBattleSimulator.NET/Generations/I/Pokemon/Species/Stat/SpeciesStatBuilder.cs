using System.Diagnostics;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public class SpeciesStatBuilder
    {
        public int? Value { get; set; }

        public ISpeciesStat Build(StatType type)
        {
            Debug.Assert(Value != null, nameof(Value) + " != null");

            return new SpeciesStat(type, Value.Value);
        }
    }
}
