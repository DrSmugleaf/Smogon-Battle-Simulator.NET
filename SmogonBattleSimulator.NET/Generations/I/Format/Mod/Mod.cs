namespace SmogonBattleSimulator.NET.Generations.I.Format.Mod
{
    public class Mod : IMod
    {
        public Mod(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}
