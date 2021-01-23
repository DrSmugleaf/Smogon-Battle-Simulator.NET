namespace SmogonBattleSimulator.NET.Generations.I.Format.Clause
{
    public class Clause : IClause
    {
        public Clause(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }
    }
}
