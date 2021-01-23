using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Context;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect
{
    public interface IEffect
    {
        string Id { get; }

        void Use(IEffectContext pokemon);
    }
}
