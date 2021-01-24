using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Effects
{
    [Effect("DoubleSlap")]
    public class DoubleSlapEffect : BaseEffect
    {
        public override void Use(IEffectContext context)
        {
            foreach (var target in context.Targets)
            {
                var chance = context.Battle.RandomProvider.RandomDouble();

                var hits = chance switch
                {
                    var n when n < 0.375 => 2,
                    var n when n < 0.75 => 3,
                    var n when n < 0.875 => 4,
                    _ => 5
                };

                // Only the first strike can be a critical hit
                var damage = context.Battle.Formula.DamageDealt(context, target);

                target.Damage(damage);

                // Successive hits deal the same amount of damage
                damage = context.Battle.Formula.DamageDealt(context, target, false);

                for (var i = 1; i < hits; i++)
                {
                    target.Damage(damage);
                }
                // TODO: DoubleSlap will end immediately if it breaks a substitute. Bide and Counter will only acknowledge the last strike of this move.
            }
        }
    }
}
