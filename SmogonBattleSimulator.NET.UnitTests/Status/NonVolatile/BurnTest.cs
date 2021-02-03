using System.Collections.Generic;
using NUnit.Framework;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Collections.UniqueDictionary;
using SmogonBattleSimulator.NET.Generations.I.Battle;
using SmogonBattleSimulator.NET.Generations.I.Format;
using SmogonBattleSimulator.NET.Generations.I.Format.Registry;
using SmogonBattleSimulator.NET.Generations.I.Generation;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Move.Category;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Pokedex;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;
using SmogonBattleSimulator.NET.Generations.I.Status.NonVolatile;
using SmogonBattleSimulator.NET.Generations.I.Trainer;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.UnitTests.Status.NonVolatile
{
    [TestFixture]
    [TestOf(typeof(BurnStatus))]
    public class BurnTest
    {
        [Test]
        public void Test()
        {
            var speciesBuilder = new SpeciesBuilder(1, "Test Species");

            speciesBuilder.SetAllStats(10);
            speciesBuilder.Weight = 10;
            speciesBuilder.Height = 10;

            var type = new Type(
                "Test Type",
                "Test type description",
                new Dictionary<IType, decimal>(),
                new Dictionary<IType, decimal>());

            speciesBuilder.Types = new IndexedSet<IType> {type};

            var category = new MoveCategory("Test Category", PermanentStatType.Attack, PermanentStatType.Defense);
            var move = new Move("Test Move", category, 10, 100, 1, 10, "Test Move Description", type);

            speciesBuilder.Moves = new IndexedSet<IMove> {move};
            speciesBuilder.Tier = new Tier("Test Tier", "Test Tier Description");

            var species = speciesBuilder.Build();
            var pokedex = new Pokedex(new HashSet<ISpecies> {species});
            var formats = new FormatRegistry(new UniqueDictionary<string, IFormat>
            {
                ["TestFormat"] = new Format("TestFormat", "Test Format")
            });
            var generation = new Generation("Test Generation", "TG", pokedex, formats);
            var pokemonBuilder = new BattlePokemonBuilder(generation.StatFormula, "Test Pokemon", 10);

            var pokemon = pokemonBuilder.WithSpecies(species).Build(species);
            var pokemons = new IndexedSet<IBattlePokemon> {pokemon};
            var trainers = new IndexedSet<ITrainer>
            {
                new Trainer("Test Trainer", pokemons)
            };
            var battle = new Battle(generation, trainers);
            var burn = new BurnStatus(pokemon, battle.EventBus);
            var normalAttack = battle.StatFormula.CalculateStat(pokemon.Attack);

            Assert.That(pokemon.Attack.ModifiedValue, Is.EqualTo(normalAttack / 2));
        }
    }
}
