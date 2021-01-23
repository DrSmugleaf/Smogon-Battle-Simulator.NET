using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SmogonBattleSimulator.NET.Collections.UniqueDictionary
{
    public class UniqueDictionary<K, V> :
        IUniqueDictionary<K, V>,
        IReadOnlyUniqueDictionary<K, V>,
        IDictionary
        where K : notnull
    {
        private readonly Dictionary<K, V> _dictionary;
        private readonly HashSet<V> _set;

        public UniqueDictionary()
        {
            _dictionary = new Dictionary<K, V>();
            _set = new HashSet<V>();
        }

        bool IDictionary.Contains(object key)
        {
            return ((IDictionary) _dictionary).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary) _dictionary).GetEnumerator();
        }

        void IDictionary.Remove(object key)
        {
            Remove((K) key);
        }

        bool IDictionary.IsFixedSize => ((IDictionary) _dictionary).IsFixedSize;

        public bool IsReadOnly => ((IDictionary) _dictionary).IsReadOnly;

        object? IDictionary.this[object key]
        {
            get => this[(K) key];
            set => this[(K) key] = (V) (value ?? throw new ArgumentNullException(nameof(value)));
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<KeyValuePair<K, V>>.Add(KeyValuePair<K, V> item)
        {
            Add(item.Key, item.Value);
        }

        void IDictionary.Add(object key, object? value)
        {
            Add((K) key, (V) (value ?? throw new ArgumentNullException(nameof(value))));
        }

        public void Clear()
        {
            _dictionary.Clear();
            _set.Clear();
        }

        bool ICollection<KeyValuePair<K, V>>.Contains(KeyValuePair<K, V> item)
        {
            return ((ICollection<KeyValuePair<K, V>>) _dictionary).Contains(item);
        }

        void ICollection<KeyValuePair<K, V>>.CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<K, V>>) _dictionary).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<K, V>>.Remove(KeyValuePair<K, V> item)
        {
            if (((ICollection<KeyValuePair<K, V>>) _dictionary).Remove(item))
            {
                _set.Remove(item.Value);
                return true;
            }

            return false;
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((IDictionary) _dictionary).CopyTo(array, index);
        }

        public int Count => _dictionary.Count;

        bool ICollection.IsSynchronized => ((ICollection) _dictionary).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection) _dictionary).SyncRoot;

        bool ICollection<KeyValuePair<K, V>>.IsReadOnly => ((ICollection<KeyValuePair<K, V>>) _dictionary).IsReadOnly;

        public void Add(K key, V value)
        {
            if (!_set.Contains(value))
            {
                _dictionary.Add(key, value);
                _set.Add(value);
            }
        }

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(K key)
        {
            if (_dictionary.Remove(key, out var value))
            {
                _set.Remove(value);
                return true;
            }

            return false;
        }

        public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public V this[K key]
        {
            get => _dictionary[key];
            set
            {
                if (!_set.Contains(value))
                {
                    _dictionary[key] = value;
                    _set.Add(value);
                }
            }
        }

        IEnumerable<K> IReadOnlyDictionary<K, V>.Keys => Keys;

        ICollection IDictionary.Keys => ((IDictionary) _dictionary).Keys;

        ICollection IDictionary.Values => ((IDictionary) _dictionary).Values;

        IEnumerable<V> IReadOnlyDictionary<K, V>.Values => Values;

        public ICollection<K> Keys => _dictionary.Keys;

        public ICollection<V> Values => _dictionary.Values;
    }
}
