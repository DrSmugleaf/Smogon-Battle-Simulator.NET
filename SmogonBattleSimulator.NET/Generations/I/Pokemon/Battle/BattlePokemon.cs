using System;
using System.Linq;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle
{
    public class BattlePokemon : IBattlePokemon
    {
        public BattlePokemon(
            string name,
            string nickname,
            int level,
            IBattleStat health,
            IBattleStat attack,
            IBattleStat defense,
            IBattleStat special,
            IBattleStat speed,
            IBattleStat evasion,
            IBattleStat accuracy,
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

        public int Level { get; }

        public int CurrentHealth { get; private set; }

        public IBattleStat Health { get; }

        public IBattleStat Attack { get; }

        public IBattleStat Defense { get; }

        public IBattleStat Special { get; }

        public IBattleStat Speed { get; }

        public IBattleStat Evasion { get; }

        public IBattleStat Accuracy { get; }

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

        public IBattleStat Stat(StatType ofType)
        {
            return ofType switch
            {
                StatType.Health => Health,
                StatType.Attack => Attack,
                StatType.Defense => Defense,
                StatType.Special => Special,
                StatType.Speed => Speed,
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
