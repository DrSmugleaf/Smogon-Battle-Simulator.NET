using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile
{
    public interface INonVolatileStatus : IStatus
    {
        string Name { get; }

        string DisplayName { get; }

        IBattlePokemon Pokemon { get; }

        void OnRemove(IEventBus eventBus);
    }
}
