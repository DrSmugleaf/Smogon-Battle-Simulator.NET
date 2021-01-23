using SmogonBattleSimulator.NET.Collections.IndexedSet;
using SmogonBattleSimulator.NET.Generations.I.Format.Clause;
using SmogonBattleSimulator.NET.Generations.I.Format.Mod;
using SmogonBattleSimulator.NET.Generations.I.Format.Restriction;

namespace SmogonBattleSimulator.NET.Generations.I.Format
{
    public interface IFormat
    {
        string Name { get; }

        string Description { get; }

        IReadOnlyIndexedSet<IClause> Clauses { get; }

        IReadOnlyIndexedSet<IMod> Mods { get; }

        IReadOnlyIndexedSet<IRestriction> Restrictions { get; }
    }
}
