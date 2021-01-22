using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Move
{
    public interface IMove
    {
        string Name { get; }

        IMoveCategory Category { get; }

        int Power { get; }

        int Accuracy { get; }

        int Priority { get; }

        int Pp { get; }

        string Description { get; }

        IType Type { get; }
    }
}
