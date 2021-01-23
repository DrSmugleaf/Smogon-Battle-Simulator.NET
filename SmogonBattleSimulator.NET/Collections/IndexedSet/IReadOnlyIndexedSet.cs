using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Collections.IndexedSet
{
    // ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IReadOnlyIndexedSet<T> : IReadOnlySet<T>, IReadOnlyList<T>
    {
        new bool Contains(T item);

        new int Count { get; }
    }
}
