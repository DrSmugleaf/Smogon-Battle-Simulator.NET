namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
{
    public interface IBattleStat
    {
        BattleStatType StatType { get; }

        int BaseValue { get; }

        int Value { get; set; }
    }
}
