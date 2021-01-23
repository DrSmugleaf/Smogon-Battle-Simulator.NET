namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species
{
    public class SpeciesStat : ISpeciesStat
    {
        public SpeciesStat(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public int Value { get; }
    }
}
