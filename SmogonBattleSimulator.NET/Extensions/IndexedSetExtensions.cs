using System.Collections.Generic;
using SmogonBattleSimulator.NET.Collections.IndexedSet;

namespace SmogonBattleSimulator.NET.Extensions
{
    public static class IndexedSetExtensions
    {
        public static IndexedSet<T> ToIndexedSet<T>(this IEnumerable<T> enumerable)
        {
            return new(enumerable);
        }
    }
}
