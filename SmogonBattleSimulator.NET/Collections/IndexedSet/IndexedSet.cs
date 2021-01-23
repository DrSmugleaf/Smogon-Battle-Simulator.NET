using System.Collections;
using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Collections.IndexedSet
{
    public class IndexedSet<T> : IIndexedSet<T>, IReadOnlyIndexedSet<T>
    {
        private readonly HashSet<T> _set;
        private readonly List<T> _list;

        public IndexedSet(int capacity, IEqualityComparer<T>? comparer = null)
        {
            _set = new HashSet<T>(capacity, comparer);
            _list = new List<T>(capacity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (_set.Remove(item))
            {
                _list.Remove(item);
                return true;
            }

            return false;
        }

        public int Count => _list.Count;

        public bool IsReadOnly => ((ICollection<T>) _set).IsReadOnly;

        public bool Add(T item)
        {
            if (_set.Add(item))
            {
                _list.Add(item);
                return true;
            }

            return false;
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (Count == 0)
            {
                return;
            }

            if (Equals(other, this))
            {
                Clear();
                return;
            }

            foreach (var x in other)
            {
                _set.Remove(x);
                _list.Remove(x);
            }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            _set.Clear();
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return _set.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return _set.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return _set.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return _set.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return _set.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return _set.SetEquals(other);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var x in other)
            {
                Add(x);
            }
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (_set.Add(item))
            {
                _list.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            var element = _list[index];

            if (_set.Remove(element))
            {
                _list.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get => _list[index];
            set
            {
                if (_set.Add(value))
                {
                    var old = _list[index];
                    _list[index] = value;
                    _set.Remove(old);
                }
            }
        }
    }
}
