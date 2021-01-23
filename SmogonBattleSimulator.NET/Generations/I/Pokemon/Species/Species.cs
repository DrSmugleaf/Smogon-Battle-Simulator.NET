using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species
{
    public class Species : ISpecies
    {
        public Species(
            string name,
            ISpeciesStat health,
            ISpeciesStat attack,
            ISpeciesStat defense,
            ISpeciesStat special,
            ISpeciesStat speed,
            decimal weight,
            decimal height,
            IReadOnlySet<IType> types,
            IReadOnlySet<IMove> moves,
            ITier tier)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
            Weight = weight;
            Height = height;
            Types = types;
            Moves = moves;
            Tier = tier;
        }

        public string Name { get; }

        public ISpeciesStat Health { get; }

        public ISpeciesStat Attack { get; }

        public ISpeciesStat Defense { get; }

        public ISpeciesStat Special { get; }

        public ISpeciesStat Speed { get; }

        public decimal Weight { get; }

        public decimal Height { get; }

        public IReadOnlySet<IType> Types { get; }

        public IReadOnlySet<IMove> Moves { get; }

        public ITier Tier { get; }
    }
}
