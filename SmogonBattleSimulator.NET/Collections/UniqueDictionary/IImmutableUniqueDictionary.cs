using System.Collections.Generic;
using System.Collections.Immutable;

namespace SmogonBattleSimulator.NET.Collections.UniqueDictionary
{
    public interface IImmutableUniqueDictionary<K, V> : IImmutableDictionary<K, V>, IReadOnlyUniqueDictionary<K, V>
    {
        new IImmutableUniqueDictionary<K, V> Add(K key, V value);

        new IImmutableUniqueDictionary<K, V> AddRange(IEnumerable<KeyValuePair<K, V>> pairs);

        new IImmutableUniqueDictionary<K, V> Clear();

        new IImmutableUniqueDictionary<K, V> Remove(K key);

        new IImmutableUniqueDictionary<K, V> RemoveRange(IEnumerable<K> key);

        new IImmutableUniqueDictionary<K, V> SetItem(K key, V value);

        new IImmutableUniqueDictionary<K, V> SetItems(IEnumerable<KeyValuePair<K, V>> items);
    }
}
