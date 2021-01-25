using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;

namespace SmogonBattleSimulator.NET.Generations.I.Battle.Turn
{
    public interface ITurn
    {
        bool DidPokemonAttack(IBattlePokemon pokemon);
    }
}
