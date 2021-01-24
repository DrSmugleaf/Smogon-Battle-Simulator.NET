using SmogonBattleSimulator.NET.Generations.I.Events;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public class CriticalRatioEvent : IEvent
    {
        public decimal Multiplier { get; set; } = 1;
    }
}
