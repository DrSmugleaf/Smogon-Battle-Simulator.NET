using System.Collections.Generic;
using SmogonBattleSimulator.NET.Generations.I.Format.Clause;
using SmogonBattleSimulator.NET.Generations.I.Format.Mod;
using SmogonBattleSimulator.NET.Generations.I.Format.Restriction;

namespace SmogonBattleSimulator.NET.Generations.I.Format
{
    public interface IFormat
    {
        string Name { get; }

        string Description { get; }

        IReadOnlySet<IClause> Clauses { get; }

        IReadOnlySet<IMod> Mods { get; }

        IReadOnlySet<IRestriction> Restrictions { get; }
    }
}
