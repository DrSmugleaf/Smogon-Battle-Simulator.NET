using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect.Effects
{
    [Effect("Damage")]
    public class DamageEffect : BaseEffect
    {
        public override void Use(IEffectContext context)
        {
            foreach (var target in context.Targets)
            {
                var damage = context.Battle.Formula.DamageDealt(context, target);
                target.Damage(damage);
            }
        }
    }
}
