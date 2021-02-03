using System.Collections.Generic;
using System.Diagnostics;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species
{
    public class SpeciesBuilder
    {
        public SpeciesBuilder(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; }

        public ISpeciesStat? Health { get; set; }

        public ISpeciesStat? Attack { get; set; }

        public ISpeciesStat? Defense { get; set; }

        public ISpeciesStat? Special { get; set; }

        public ISpeciesStat? Speed { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public IndexedSet<IType>? Types { get; set; }

        public IndexedSet<IMove>? Moves { get; set; }

        public ITier? Tier { get; set; }

        public IEnumerable<ISpeciesStat> GetAllStats()
        {
            if (Health != null) yield return Health;
            if (Attack != null) yield return Attack;
            if (Defense != null) yield return Defense;
            if (Special != null) yield return Special;
            if (Speed != null) yield return Speed;
        }

        public SpeciesBuilder SetAllStats(int baseValue)
        {
            var statBuilder = new SpeciesStatBuilder {Value = baseValue};

            Health = statBuilder.Build(StatType.Health);
            Attack = statBuilder.Build(StatType.Attack);
            Defense = statBuilder.Build(StatType.Defense);
            Special = statBuilder.Build(StatType.Special);
            Speed = statBuilder.Build(StatType.Speed);

            return this;
        }

        public ISpecies Build()
        {
            Debug.Assert(Health != null, nameof(Health) + " != null");
            Debug.Assert(Attack != null, nameof(Attack) + " != null");
            Debug.Assert(Defense != null, nameof(Defense) + " != null");
            Debug.Assert(Special != null, nameof(Special) + " != null");
            Debug.Assert(Speed != null, nameof(Speed) + " != null");
            Debug.Assert(Weight != null, nameof(Weight) + " != null");
            Debug.Assert(Height != null, nameof(Height) + " != null");
            Debug.Assert(Types != null, nameof(Types) + " != null");
            Debug.Assert(Moves != null, nameof(Moves) + " != null");
            Debug.Assert(Tier != null, nameof(Tier) + " != null");

            return new Species(
                Id,
                Name,
                Health,
                Attack,
                Defense,
                Special,
                Speed,
                Weight.Value,
                Height.Value,
                Types,
                Moves,
                Tier);
        }
    }
}
