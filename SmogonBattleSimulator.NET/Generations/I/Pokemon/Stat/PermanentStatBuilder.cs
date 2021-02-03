using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using SmogonBattleSimulator.NET.Extensions;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat
{
    [PublicAPI]
    public class PermanentStatBuilder
    {
        public PermanentStatBuilder(IStatFormula formula)
        {
            Formula = formula;
            BaseValues = new Dictionary<PermanentStatType, int>();
            IndividualValues = new Dictionary<PermanentStatType, int>();
            EffortValues = new Dictionary<PermanentStatType, int>();

            IndividualValues.WithDefaults();
            EffortValues.WithDefaults();
        }

        public IStatFormula Formula { get; }

        public Dictionary<PermanentStatType, int> BaseValues { get; }

        public Dictionary<PermanentStatType, int> IndividualValues { get; }

        public Dictionary<PermanentStatType, int> EffortValues { get; }

        public PermanentStatBuilder Reset()
        {
            BaseValues.Clear();

            foreach (var type in Enum.GetValues<PermanentStatType>())
            {
                IndividualValues[type] = 0;
                EffortValues[type] = 0;
            }

            return this;
        }

        public PermanentStatBuilder Stat(StatType type, ISpeciesStat stat)
        {
            var permanentType = type switch
            {
                StatType.Health => PermanentStatType.Health,
                StatType.Attack => PermanentStatType.Attack,
                StatType.Defense => PermanentStatType.Defense,
                StatType.Special => PermanentStatType.Special,
                StatType.Speed => PermanentStatType.Speed,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            BaseValues[permanentType] = stat.Value;

            return this;
        }

        public PermanentStatBuilder Species(ISpecies species)
        {
            Stat(StatType.Health, species.Health);
            Stat(StatType.Attack, species.Attack);
            Stat(StatType.Defense, species.Defense);
            Stat(StatType.Special, species.Special);
            Stat(StatType.Speed, species.Speed);

            return this;
        }

        public PermanentStatBuilder IndividualValue(int iv)
        {
            foreach (var type in Enum.GetValues<PermanentStatType>())
            {
                IndividualValues[type] = iv;
            }

            return this;
        }

        public PermanentStatBuilder EffortValue(int ev)
        {
            foreach (var type in Enum.GetValues<PermanentStatType>())
            {
                EffortValues[type] = ev;
            }

            return this;
        }

        public IPermanentStat Build(PermanentStatType type, int level)
        {
            return new PermanentStat(
                Formula,
                type,
                BaseValues[type],
                level,
                IndividualValues[type],
                EffortValues[type]);
        }

        public Dictionary<PermanentStatType, IPermanentStat> BuildAllStats(int level)
        {
            var stats = new Dictionary<PermanentStatType, IPermanentStat>();

            foreach (var type in Enum.GetValues<PermanentStatType>())
            {
                stats[type] = Build(type, level);
            }

            return stats;
        }

        public PermanentStatCollection BuildCollection(ISpecies species, int level)
        {
            return new(BuildAllStats(level));
        }
    }
}
