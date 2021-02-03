using System.Diagnostics;
using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Extensions;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Move;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle.Stat;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Tier;
using SmogonBattleSimulator.NET.Generations.I.Pokemon.Stat;
using SmogonBattleSimulator.NET.Generations.I.Type;

namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Battle
{
    public class BattlePokemonBuilder
    {
        public BattlePokemonBuilder(IStatFormula statFormula, string name, int lvl)
        {
            StatFormula = statFormula;
            Name = name;
            Level = lvl;
            PermanentStatBuilder = new PermanentStatBuilder(statFormula);
            BattleStatBuilder = new BattleStatBuilder(statFormula);
        }

        public IStatFormula StatFormula { get; }

        public string Name { get; set; }

        public string? Nickname { get; set; }

        public int Level { get; set; }

        public PermanentStatBuilder PermanentStatBuilder { get; set; }

        public BattleStatBuilder BattleStatBuilder { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public IndexedSet<IType>? Types { get; set; }

        public IndexedSet<IMove>? Moves { get; set; }

        public ITier? Tier { get; set; }

        public BattlePokemonBuilder WithSpecies(ISpecies species, int iv = 0, int ev = 0)
        {
            PermanentStatBuilder
                .Species(species)
                .IndividualValue(iv)
                .EffortValue(ev);

            Weight = species.Weight;
            Height = species.Height;

            Types = species.Types.ToIndexedSet();
            Moves = species.Moves.ToIndexedSet();
            Tier = species.Tier;

            return this;
        }

        public IBattlePokemon Build(ISpecies species)
        {
            Debug.Assert(Weight != null, nameof(Weight) + " != null");
            Debug.Assert(Height != null, nameof(Height) + " != null");
            Debug.Assert(Types != null, nameof(Types) + " != null");
            Debug.Assert(Moves != null, nameof(Moves) + " != null");
            Debug.Assert(Tier != null, nameof(Tier) + " != null");

            var permanentStats = PermanentStatBuilder.BuildCollection(species, Level);
            var battleStats = BattleStatBuilder.BuildCollection();

            return new BattlePokemon(
                Name,
                Nickname,
                Level,
                permanentStats.Health,
                permanentStats.Attack,
                permanentStats.Defense,
                permanentStats.Special,
                permanentStats.Speed,
                battleStats.Accuracy,
                battleStats.Evasion,
                Weight.Value,
                Height.Value,
                Types,
                Moves,
                Tier);
        }
    }
}
