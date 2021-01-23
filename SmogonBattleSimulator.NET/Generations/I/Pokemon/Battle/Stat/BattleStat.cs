namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public class BattleStat : IBattleStat
    {
        public BattleStat(BattleStatType statType, int baseValue)
        {
            StatType = statType;
            BaseValue = baseValue;
            Value = Value;
        }

        public BattleStatType StatType { get; }

        public int BaseValue { get; }

        public int Value { get; set; }
    }
}
