namespace SmogonBattleSimulator.NET.Generations.I.Format.Restriction
{
    public class Restriction : IRestriction
    {
        public Restriction(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}
