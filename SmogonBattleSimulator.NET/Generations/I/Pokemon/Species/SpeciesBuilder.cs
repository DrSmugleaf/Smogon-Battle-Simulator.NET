using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Extensions;
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
            return new Species(
                Id,
                Name,
                Health.GetOrThrow(),
                Attack.GetOrThrow(),
                Defense.GetOrThrow(),
                Special.GetOrThrow(),
                Speed.GetOrThrow(),
                Weight.GetOrThrow(),
                Height.GetOrThrow(),
                Types.GetOrThrow(),
                Moves.GetOrThrow(),
                Tier.GetOrThrow());
        }
    }
}
