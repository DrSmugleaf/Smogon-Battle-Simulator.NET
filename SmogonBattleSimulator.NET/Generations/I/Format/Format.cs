using System.Collections.Generic;
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
            IReadOnlySet<IClause> clauses,
            IReadOnlySet<IMod> mods,
            IReadOnlySet<IRestriction> restrictions)
        {
            Name = name;
            Description = description;
            Clauses = clauses;
            Mods = mods;
            Restrictions = restrictions;
        }

        public string Name { get; }

        public string Description { get; }

        public IReadOnlySet<IClause> Clauses { get; }

        public IReadOnlySet<IMod> Mods { get; }

        public IReadOnlySet<IRestriction> Restrictions { get; }
    }
}
