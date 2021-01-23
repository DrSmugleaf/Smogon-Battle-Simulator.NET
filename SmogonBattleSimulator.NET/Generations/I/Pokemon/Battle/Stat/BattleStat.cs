namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat
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
