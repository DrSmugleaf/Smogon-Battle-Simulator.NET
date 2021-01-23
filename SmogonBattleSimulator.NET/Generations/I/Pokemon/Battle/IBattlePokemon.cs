﻿using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon
{
    public interface IBattlePokemon
    {
        string Name { get; }

        string Nickname { get; }

        int Level { get; }

        IBattleStat Health { get; }

        IBattleStat Attack { get; }

        IBattleStat Defense { get; }

        IBattleStat Special { get; }

        IBattleStat Speed { get; }

        IBattleStat Evasion { get; }

        IBattleStat Accuracy { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IReadOnlyIndexedSet<IType> Types { get; }

        IReadOnlyIndexedSet<IMove> Moves { get; }

        ITier Tier { get; }

        bool HasType(IType type);

        IBattleStat Stat(StatType ofType);

        IBattleStat Stat(BattleStatType ofType);

        void Damage(int amount);
    }
}