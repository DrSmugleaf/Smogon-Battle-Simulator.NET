using System.Collections;
using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Collections.IndexedSet
{
    // ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IIndexedSet<T> : ICollection, IList<T>
    {
        new int Count { get; }
    }
}
