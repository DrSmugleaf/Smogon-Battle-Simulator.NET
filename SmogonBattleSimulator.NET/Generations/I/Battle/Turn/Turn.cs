using System.Collections.Generic;
using System.Linq;
using SmogonBattleSimulator.NET.Generations.I.Move.Events;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Battle.Turn
{
    public class Turn : ITurn
    {
        private List<AfterMoveUsedEvent> MovesUsed { get; } = new();

        public bool DidPokemonAttack(IBattlePokemon pokemon)
        {
            return MovesUsed.Any(m => m.User == pokemon);
        }
    }
}
