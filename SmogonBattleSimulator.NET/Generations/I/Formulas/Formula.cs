using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;
using SmogonBattleSimulator.NET.Generations.I.Pokemon;
using SmogonBattleSimulator.NET.Generations.I.RandomProvider;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Formulas
{
    public class Formula : IFormula
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

        public int DamageDealt(IEffectContext context, IBattlePokemon target)
        {
            // TODO crit
            var level = context.User.Level;
            var power = context.Move.Power;
            var attack = context.Move.Category.AttackStat(target);
            var defense = context.Move.Category.DefenseStat(target);
            var modifier = Multiplier(context, target);

            return (int) (((2 * level / 5 + 2) * power * (attack.Value / defense.Value) / 50 + 2) * modifier);
        }
    }
}
