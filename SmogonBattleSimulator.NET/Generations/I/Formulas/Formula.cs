using System;
using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;
using SmogonBattleSimulator.NET.Generations.I.RandomProvider;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public class Formula : IDamageFormula, IStatFormula
    {
        public decimal TargetsMultiplier(int targetCount)
        {
            return targetCount > 1 ? 0.75M : 1;
        }

        public decimal WeatherMultiplier(IEffectContext context)
        {
            return 1; // TODO
        }

        public decimal RandomMultiplier(IRandomProvider provider)
        {
            return provider.RandomDecimal(0.85M, 1M);
        }

        public decimal StabMultiplier(IBattlePokemon user, IType moveType)
        {
            return user.HasType(moveType) ? 1.5M : 1;
        }

        public decimal TypeMultiplier(IType moveType, IBattlePokemon target)
        {
            var multiplier = 1M;

            foreach (var targetType in target.Types)
            {
                multiplier *= moveType.GetAttackEffectiveness(targetType);
            }

            return multiplier;
        }

        public decimal Multiplier(IEffectContext context, IBattlePokemon target)
        {
            return TargetsMultiplier(context.Targets.Count) *
                   WeatherMultiplier(context) *
                   RandomMultiplier(context.Battle.RandomProvider) *
                   StabMultiplier(context.User, context.Move.Type) *
                   TypeMultiplier(context.Move.Type, target);
        }

        // TODO OtherMultiplier

        public int DamageDealt(IEffectContext context, IBattlePokemon target, bool canCrit = true)
        {
            var crit = CriticalStrike(context);
            var level = crit ? context.User.Level * 2 : context.User.Level;
            var power = context.Move.Power;
            var attack = context.Move.Category.AttackStat(target);
            var defense = context.Move.Category.DefenseStat(target);
            var modifier = Multiplier(context, target);

            return (int) (((2 * level / 5 + 2) * power * (attack.ModifiedValue / defense.ModifiedValue) / 50 + 2) * modifier);
        }

        public bool CriticalStrike(IEffectContext context)
        {
            var @event = new CriticalRatioEvent();

            context.Battle.EventBus.Raise(@event);

            var multiplier = @event.Multiplier;
            var t = (int) (context.User.Speed.ModifiedValue / 2M * multiplier);
            var tByte = (byte) Math.Clamp(t, byte.MinValue, byte.MaxValue);
            var threshold = context.Battle.RandomProvider.RandomByte();

            return tByte < threshold;
        }

        public int CalculateHp(int baseValue, int iv, int ev, int level)
        {
            // ReSharper disable once ArrangeRedundantParentheses
            return (int) ((((baseValue + iv) * 2 + (Math.Sqrt(ev) / 4) * level) / 100) + level + 10);
        }

        public int CalculateHp(IPermanentStat stat)
        {
            var baseValue = stat.BaseValue;
            var iv = stat.IndividualValue;
            var ev = stat.EffortValue;
            var level = stat.Level;

            return CalculateHp(baseValue, iv, ev, level);
        }

        public int CalculateOtherStat(int baseValue, int iv, int ev, int level)
        {
            return (int) (((baseValue + iv) * 2 + (Math.Sqrt(ev) / 4) * level) / 100 + 5);
        }

        public int CalculateStat(IPermanentStat stat)
        {
            var baseValue = stat.BaseValue;
            var iv = stat.IndividualValue;
            var ev = stat.EffortValue;
            var level = stat.Level;

            return CalculateOtherStat(baseValue, iv, ev, level);
        }

        public int AccuracyThreshold(int moveAccuracy, decimal accuracyStage, decimal evasionStage, bool holdingBrightPowder)
        {
            var brightPowder = holdingBrightPowder ? 20 : 0;
            var t = (int) (moveAccuracy * accuracyStage * evasionStage - brightPowder);

            return Math.Clamp(t, 1, 255);
        }
    }
}
