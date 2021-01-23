namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier
{
    public class Tier : ITier
    {
        public Tier(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}
