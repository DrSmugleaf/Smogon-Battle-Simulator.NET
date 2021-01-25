using SmogonBattleSimulator.NET.Generations.I.Events;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat.Events
{
    public class CalculateStatEvent : IEvent
    {
        public CalculateStatEvent(BattleStatType statType, int value)
        {
            StatType = statType;
            Value = value;
        }

        public BattleStatType StatType { get; }

        public int Value { get; }

        public decimal Multiplier { get; set; } = 1;

        public int CalculateValue()
        {
            return (int) (Value * Multiplier);
        }
    }
}
