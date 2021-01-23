using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Format.Clause;
using SmogonBattleSimulator.NET.Generations.I.Format.Mod;
using SmogonBattleSimulator.NET.Generations.I.Format.Restriction;

namespace SmogonBattleSimulator.NET.Generations.I.Format
{
    public class Format : IFormat
    {
        public Format(
            string name,
            string description,
            IReadOnlyIndexedSet<IClause> clauses,
            IReadOnlyIndexedSet<IMod> mods,
            IReadOnlyIndexedSet<IRestriction> restrictions)
        {
            Name = name;
            Description = description;
            Clauses = clauses;
            Mods = mods;
            Restrictions = restrictions;
        }

        public string Name { get; }

        public string Description { get; }

        public IReadOnlyIndexedSet<IClause> Clauses { get; }

        public IReadOnlyIndexedSet<IMod> Mods { get; }

        public IReadOnlyIndexedSet<IRestriction> Restrictions { get; }
    }
}
