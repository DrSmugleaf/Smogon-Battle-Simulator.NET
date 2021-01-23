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
            IIndexedSet<IClause> clauses,
            IIndexedSet<IMod> mods,
            IIndexedSet<IRestriction> restrictions)
        {
            Name = name;
            Description = description;
            Clauses = clauses;
            Mods = mods;
            Restrictions = restrictions;
        }

        public string Name { get; }

        public string Description { get; }

        public IIndexedSet<IClause> Clauses { get; }

        public IIndexedSet<IMod> Mods { get; }

        public IIndexedSet<IRestriction> Restrictions { get; }
    }
}
