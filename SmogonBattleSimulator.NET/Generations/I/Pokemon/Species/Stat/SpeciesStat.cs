namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public class SpeciesStat : ISpeciesStat
    {
        public SpeciesStat(StatType type, int value)
        {
            StatType = type;
            Value = value;
        }

        public StatType StatType { get; }

        public int Value { get; }
    }
}
