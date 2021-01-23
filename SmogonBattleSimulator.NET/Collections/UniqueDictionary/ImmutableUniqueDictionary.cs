using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace SmogonBattleSimulator.NET.Collections.UniqueDictionary
{
    public class ImmutableUniqueDictionary<K, V> : IImmutableUniqueDictionary<K, V>
    {
        private readonly IImmutableDictionary<K, V> _dictionary;

        public ImmutableUniqueDictionary(IImmutableDictionary<K, V> dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _dictionary.Count;

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public V this[K key] => _dictionary[key];

        public IEnumerable<K> Keys => _dictionary.Keys;

        public IEnumerable<V> Values => _dictionary.Values;

        public IImmutableUniqueDictionary<K, V> Add(K key, V value)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.Add(key, value));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.Add(K key, V value)
        {
            return Add(key, value);
        }

        public IImmutableUniqueDictionary<K, V> AddRange(IEnumerable<KeyValuePair<K, V>> pairs)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.AddRange(pairs));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.AddRange(IEnumerable<KeyValuePair<K, V>> pairs)
        {
            return AddRange(pairs);
        }

        public IImmutableUniqueDictionary<K, V> Clear()
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.Clear());
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.Clear()
        {
            return Clear();
        }

        public bool Contains(KeyValuePair<K, V> pair)
        {
            return _dictionary.Contains(pair);
        }

        public IImmutableUniqueDictionary<K, V> Remove(K key)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.Remove(key));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.Remove(K key)
        {
            return Remove(key);
        }

        public IImmutableUniqueDictionary<K, V> RemoveRange(IEnumerable<K> keys)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.RemoveRange(keys));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.RemoveRange(IEnumerable<K> keys)
        {
            return RemoveRange(keys);
        }

        public IImmutableUniqueDictionary<K, V> SetItem(K key, V value)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.SetItem(key, value));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.SetItem(K key, V value)
        {
            return SetItem(key, value);
        }

        public IImmutableUniqueDictionary<K, V> SetItems(IEnumerable<KeyValuePair<K, V>> items)
        {
            return new ImmutableUniqueDictionary<K, V>(_dictionary.SetItems(items));
        }

        IImmutableDictionary<K, V> IImmutableDictionary<K, V>.SetItems(IEnumerable<KeyValuePair<K, V>> items)
        {
            return SetItems(items);
        }

        public bool TryGetKey(K equalKey, out K actualKey)
        {
            return _dictionary.TryGetKey(equalKey, out actualKey);
        }
    }
}
