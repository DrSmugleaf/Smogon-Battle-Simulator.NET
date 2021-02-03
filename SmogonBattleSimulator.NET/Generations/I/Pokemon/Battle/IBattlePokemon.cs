using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;
using SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle
{
    public interface IBattlePokemon
    {
        string Name { get; }

        string? Nickname { get; }

        int Level { get; }

        int CurrentHealth { get; }

        IPermanentStat Health { get; }

        IPermanentStat Attack { get; }

        IPermanentStat Defense { get; }

        IPermanentStat Special { get; }

        IPermanentStat Speed { get; }

        IBattleStat Accuracy { get; }

        IBattleStat Evasion { get; }

        decimal Weight { get; }

        decimal Height { get; }

        IReadOnlyIndexedSet<IType> Types { get; }

        IReadOnlyIndexedSet<IMove> Moves { get; }

        ITier Tier { get; }

        INonVolatileStatus? NonVolatileStatus { get; set; }

        bool HasType(IType type);

        IPermanentStat Stat(PermanentStatType ofType);

        IBattleStat Stat(BattleStatType ofType);

        void Damage(int amount);

        void DamagePercentage(decimal percentage);
    }
}
