using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Generations.I.Type
{
    public interface IType
    {
        string Name { get; }

        string Description { get; }

        IReadOnlyDictionary<IType, decimal> AttackEffectiveness { get; }

        IReadOnlyDictionary<IType, decimal> DefenseEffectiveness { get; }

        decimal GetAttackEffectiveness(IType against);

        decimal GetDefenseEffectiveness(IType against);
    }
}
