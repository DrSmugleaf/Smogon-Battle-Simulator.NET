using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Events
{
    public class AfterMoveUsedEvent : IEvent
    {
        public AfterMoveUsedEvent(IMove move, IBattlePokemon user)
        {
            Move = move;
            User = user;
        }

        public IMove Move { get; }

        public IBattlePokemon User { get; }
    }
}
