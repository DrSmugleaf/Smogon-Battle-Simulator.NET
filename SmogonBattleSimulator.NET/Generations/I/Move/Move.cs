using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Move
{
    public class Move : IMove
    {
        public Move(
            string name,
            IMoveCategory category,
            int power,
            int accuracy,
            int priority,
            int pp,
            string description,
            IType type)
        {
            Name = name;
            Category = category;
            Power = power;
            Accuracy = accuracy;
            Priority = priority;
            Pp = pp;
            Description = description;
            Type = type;
        }

        public string Name { get; }

        public IMoveCategory Category { get; }

        public int Power { get; }

        public int Accuracy { get; }

        public int Priority { get; }

        public int Pp { get; }

        public string Description { get; }

        public IType Type { get; }
    }
}
