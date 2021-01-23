using System.Collections.Generic;
using SmogonBattleSimulator.NET.Extensions;

namespace SmogonBattleSimulator.NET.Generations.I.Type
{
    public class Type : IType
    {
        public Type(
            string name,
            string description,
            IReadOnlyDictionary<IType, decimal> attackEffectiveness,
            IReadOnlyDictionary<IType, decimal> defenseEffectiveness)
        {
            Name = name;
            Description = description;
            AttackEffectiveness = attackEffectiveness;
            DefenseEffectiveness = defenseEffectiveness;
        }

        public string Name { get; }

        public string Description { get; }

        public IReadOnlyDictionary<IType, decimal> AttackEffectiveness { get; }

        public IReadOnlyDictionary<IType, decimal> DefenseEffectiveness { get; }

        public decimal GetAttackEffectiveness(IType against)
        {
            return AttackEffectiveness.GetValueOrNull(against) ?? 1;
        }

        public decimal GetDefenseEffectiveness(IType against)
        {
            return DefenseEffectiveness.GetValueOrNull(against) ?? 1;
        }
    }
}
