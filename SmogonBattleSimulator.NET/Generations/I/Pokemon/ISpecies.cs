using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon
{
    public interface ISpecies
    {
        string Name { get; }

        int Health { get; }

        int Attack { get; }

        int Defense { get; }

        int Special { get; }

        int Speed { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IReadOnlySet<IType> Types { get; }
    }
}
