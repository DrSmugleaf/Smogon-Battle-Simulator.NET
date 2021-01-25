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
            IReadOnlyIndexedSet<IClause>? clauses = null,
            IReadOnlyIndexedSet<IMod>? mods = null,
            IReadOnlyIndexedSet<IRestriction>? restrictions = null)
        {
            Name = name;
            Description = description;
            Clauses = clauses ?? new IndexedSet<IClause>();
            Mods = mods ?? new IndexedSet<IMod>();
            Restrictions = restrictions ?? new IndexedSet<IRestriction>();
        }

        public string Name { get; }

        public string Description { get; }

        public IReadOnlyIndexedSet<IClause> Clauses { get; }

        public IReadOnlyIndexedSet<IMod> Mods { get; }

        public IReadOnlyIndexedSet<IRestriction> Restrictions { get; }
    }
}
