using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat
{
    public class PermanentStatCollection
    {
        public PermanentStatCollection(Dictionary<PermanentStatType, IPermanentStat> stats)
        {
            Health = stats[PermanentStatType.Health];
            Attack = stats[PermanentStatType.Attack];
            Defense = stats[PermanentStatType.Defense];
            Special = stats[PermanentStatType.Special];
            Speed = stats[PermanentStatType.Speed];
        }

        public IPermanentStat Health { get; }
        public IPermanentStat Attack { get; }
        public IPermanentStat Defense { get; }
        public IPermanentStat Special { get; }
        public IPermanentStat Speed { get; }
    }
}
