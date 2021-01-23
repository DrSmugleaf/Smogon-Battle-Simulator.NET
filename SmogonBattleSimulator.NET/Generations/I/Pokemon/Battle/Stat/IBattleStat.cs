namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public interface IBattleStat
    {
        BattleStatType StatType { get; }

        int BaseValue { get; }

        int Value { get; set; }
    }
}
