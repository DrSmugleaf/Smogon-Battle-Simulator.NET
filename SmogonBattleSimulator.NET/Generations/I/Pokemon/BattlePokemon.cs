using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon
{
    public class BattlePokemon : IBattlePokemon
    {
        public BattlePokemon(
            string name,
            string nickname,
            ISpeciesStat health,
            ISpeciesStat attack,
            ISpeciesStat defense,
            ISpeciesStat special,
            ISpeciesStat speed,
            ISpeciesStat evasion,
            ISpeciesStat accuracy,
            decimal weight,
            decimal height,
            IIndexedSet<IType> types,
            IIndexedSet<IMove> moves,
            ITier tier)
        {
            Name = name;
            Nickname = nickname;
            Health = health;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
            Evasion = evasion;
            Accuracy = accuracy;
            Weight = weight;
            Height = height;
            Types = types;
            Moves = moves;
            Tier = tier;
        }

        public string Name { get; }

        public string Nickname { get; }

        public ISpeciesStat Health { get; }

        public ISpeciesStat Attack { get; }

        public ISpeciesStat Defense { get; }

        public ISpeciesStat Special { get; }

        public ISpeciesStat Speed { get; }

        public ISpeciesStat Evasion { get; }

        public ISpeciesStat Accuracy { get; }

        public decimal Weight { get; }

        public decimal Height { get; }

        public IIndexedSet<IType> Types { get; }

        public IIndexedSet<IMove> Moves { get; }

        public ITier Tier { get; }
    }
}
