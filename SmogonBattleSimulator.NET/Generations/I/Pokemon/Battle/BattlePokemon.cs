using System;
using System.Linq;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;
using SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle
{
    public class BattlePokemon : IBattlePokemon
    {
        public BattlePokemon(
            string name,
            string? nickname,
            int level,
            IPermanentStat health,
            IPermanentStat attack,
            IPermanentStat defense,
            IPermanentStat special,
            IPermanentStat speed,
            IBattleStat accuracy,
            IBattleStat evasion,
            decimal weight,
            decimal height,
            IReadOnlyIndexedSet<IType> types,
            IReadOnlyIndexedSet<IMove> moves,
            ITier tier)
        {
            Name = name;
            Nickname = nickname;
            Level = level;
            Health = health;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
            Accuracy = accuracy;
            Evasion = evasion;
            Weight = weight;
            Height = height;
            Types = types;
            Moves = moves;
            Tier = tier;
        }

        public string Name { get; }

        public string? Nickname { get; }

        public int Level { get; }

        public int CurrentHealth { get; private set; }

        public IPermanentStat Health { get; }

        public IPermanentStat Attack { get; }

        public IPermanentStat Defense { get; }

        public IPermanentStat Special { get; }

        public IPermanentStat Speed { get; }

        public IBattleStat Accuracy { get; }

        public IBattleStat Evasion { get; }

        public decimal Weight { get; }

        public decimal Height { get; }

        public IReadOnlyIndexedSet<IType> Types { get; }

        public IReadOnlyIndexedSet<IMove> Moves { get; }

        public ITier Tier { get; }

        public INonVolatileStatus? NonVolatileStatus { get; set; }

        public bool HasType(IType type)
        {
            return Types.Any(t => t == type);
        }

        public IPermanentStat Stat(PermanentStatType ofType)
        {
            return ofType switch
            {
                PermanentStatType.Health => Health,
                PermanentStatType.Attack => Attack,
                PermanentStatType.Defense => Defense,
                PermanentStatType.Special => Special,
                PermanentStatType.Speed => Speed,
                _ => throw new ArgumentOutOfRangeException(nameof(ofType), ofType, null)
            };
        }

        public IBattleStat Stat(BattleStatType ofType)
        {
            return ofType switch
            {
                BattleStatType.Evasion => Evasion,
                BattleStatType.Accuracy => Accuracy,
                _ => throw new ArgumentOutOfRangeException(nameof(ofType), ofType, null)
            };
        }

        public void Damage(int amount)
        {
            if (CurrentHealth - amount < 0)
            {
                CurrentHealth = 0;
                return;
            }

            CurrentHealth -= amount;
        }

        public void DamagePercentage(decimal percentage)
        {
            Damage((int) (Health.ModifiedValue * percentage));
        }
    }
}
