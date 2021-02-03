using SmogonBattleSimulator.NET.Generations.I.Battle.Turn.Events;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Move.Events;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;

namespace SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile
{
    public class BurnStatus : BaseNonVolatileStatus
    {
        public BurnStatus(IBattlePokemon pokemon, IEventBus eventBus) : base(pokemon, eventBus)
        {
            pokemon.NonVolatileStatus = this;
            pokemon.Stat(PermanentStatType.Attack).AddMultiplier(0.5M);
        }

        public override string Name => "Burn";

        public override string DisplayName => "BRN";

        private bool Attacked { get; set; }

        [EventHandler]
        private void OnAttack(AfterMoveUsedEvent @event)
        {
            if (@event.User == Pokemon)
            {
                Attacked = true;
            }
        }

        [EventHandler]
        private void OnTurnEnd(TurnEndedEvent @event)
        {
            if (Attacked)
            {
                return;
            }

            Pokemon.DamagePercentage(1 / 16M);
        }
    }
}
