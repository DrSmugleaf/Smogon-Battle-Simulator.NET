using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Extensions;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle
{
    public class BattlePokemonBuilder
    {
        private int _level;

        public BattlePokemonBuilder(IStatFormula statFormula, string name, int lvl)
        {
            StatFormula = statFormula;
            Name = name;
            Level = lvl;
        }

        public IStatFormula StatFormula { get; }

        public string Name { get; set; }

        public string? Nickname { get; set; }

        public int Level
        {
            get => _level;
            set
            {
                if (_level == value)
                {
                    return;
                }

                _level = value;

                foreach (var stat in GetAllStats())
                {
                    stat.Level = value;
                }
            }
        }

        public IBattleStat? Health { get; set; }

        public IBattleStat? Attack { get; set; }

        public IBattleStat? Defense { get; set; }

        public IBattleStat? Special { get; set; }

        public IBattleStat? Speed { get; set; }

        public IBattleStat? Evasion { get; set; }

        public IBattleStat? Accuracy { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public IndexedSet<IType>? Types { get; set; }

        public IndexedSet<IMove>? Moves { get; set; }

        public ITier? Tier { get; set; }

        public IEnumerable<IBattleStat> GetAllStats()
        {
            if (Health != null) yield return Health;
            if (Attack != null) yield return Attack;
            if (Defense != null) yield return Defense;
            if (Special != null) yield return Special;
            if (Speed != null) yield return Speed;
            if (Evasion != null) yield return Evasion;
            if (Accuracy != null) yield return Accuracy;
        }

        public void SetAllStats(int baseValue, int iv, int ev)
        {
            var statBuilder = new BattleStatBuilder(StatFormula)
            {
                BaseValue = baseValue,
                Level = Level,
                IndividualValue = iv,
                EffortValue = ev
            };

            Health = statBuilder.Build(BattleStatType.Health);
            Attack = statBuilder.Build(BattleStatType.Attack);
            Defense = statBuilder.Build(BattleStatType.Defense);
            Special = statBuilder.Build(BattleStatType.Special);
            Speed = statBuilder.Build(BattleStatType.Speed);
            Evasion = statBuilder.Build(BattleStatType.Evasion);
            Accuracy = statBuilder.Build(BattleStatType.Accuracy);
        }

        public IBattlePokemon Build()
        {
            return new BattlePokemon(
                Name,
                Nickname ?? string.Empty,
                Level,
                Health.GetOrThrow(),
                Attack.GetOrThrow(),
                Defense.GetOrThrow(),
                Special.GetOrThrow(),
                Speed.GetOrThrow(),
                Evasion.GetOrThrow(),
                Accuracy.GetOrThrow(),
                Weight.GetOrThrow(),
                Height.GetOrThrow(),
                Types.GetOrThrow(),
                Moves.GetOrThrow(),
                Tier.GetOrThrow());
        }
    }
}
