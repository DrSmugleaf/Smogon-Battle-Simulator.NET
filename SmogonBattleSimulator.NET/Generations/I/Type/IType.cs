namespace SmogonBattleSimulator.NET.Generations.I.Type
{
    public interface IType
    {
        string Name { get; }

        string Description { get; }

        decimal GetAttackEffectiveness(IType towards);

        decimal GetDefenseEffectiveness(IType against);
    }
}
