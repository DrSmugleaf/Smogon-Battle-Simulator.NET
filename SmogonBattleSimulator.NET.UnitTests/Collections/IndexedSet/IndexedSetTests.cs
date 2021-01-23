using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SmogonBattleSimulator.NET.Collections.IndexedSet;

namespace SmogonBattleSimulator.NET.UnitTests.Collections.IndexedSet
{
    [TestFixture]
    [TestOf(typeof(IndexedSet<>))]
    public class IndexedSetTests : BaseUnitTest
    {
        [Test]
        public void GetEnumeratorTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var set = new IndexedSet<object>();
            using var enumerator = set.GetEnumerator();

            Assert.Null(enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Test]
        public void GetEnumeratorExplicitTest()
        {
            var set = new IndexedSet<object>();
            var enumerator = ((IEnumerable) set).GetEnumerator();

            Assert.Throws<InvalidOperationException>(() =>
            {
                var _ = enumerator.Current;
            });
            Assert.False(enumerator.MoveNext());
        }

        [Test]
        public void RemoveTest()
        {
            var set = new IndexedSet<string>();

            Assert.False(set.Remove("A"));

            set.Add("A");

            Assert.True(set.Remove("A"));
            Assert.Zero(set.Count);
            Assert.False(set.Contains("A"));
        }

        [Test]
        public void CountTest()
        {
            var set = new IndexedSet<int>();

            Assert.Zero(set.Count);

            for (var i = 0; i < 10; i++)
            {
                Assert.That(set.Count, Is.EqualTo(i));
                set.Add(i);
                Assert.That(set.Count, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void IsReadOnlyTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var set = new IndexedSet<object>();

            Assert.False(((ICollection<object>) set).IsReadOnly);
        }

        [Test]
        public void AddTest()
        {
            var set = new IndexedSet<string>();

            Assert.True(set.Add("A"));
            Assert.Contains("A", set);

            Assert.False(set.Add("A"));
            Assert.Contains("A", set);
        }

        [Test]
        public void ExceptWithTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            firstSet.Add("A");

            secondSet.Add("A");
            secondSet.Add("B");

            secondSet.ExceptWith(firstSet);

            Assert.That(secondSet.Count, Is.EqualTo(1));
            Assert.False(secondSet.Contains("A"));
            Assert.True(secondSet.Contains("B"));
        }

        [Test]
        public void AddCollectionExplicitTest()
        {
            var set = new IndexedSet<string>();

            ((ICollection<string>)set).Add("A");
            ((ICollection<string>)set).Add("A");

            Assert.That(set.Count, Is.EqualTo(1));
        }

        [Test]
        public void ClearTest()
        {
            var set = new IndexedSet<string>();

            set.Clear();
            Assert.Zero(set.Count);

            Assert.True(set.Add("A"));
            Assert.That(set.Count, Is.EqualTo(1));

            set.Clear();
            Assert.Zero(set.Count);
        }

        [Test]
        public void ContainsTest()
        {
            var set = new IndexedSet<string>();

            Assert.False(set.Contains("A"));
            Assert.True(set.Add("A"));
            Assert.True(set.Contains("A"));
            Assert.False(set.Contains("B"));
        }

        [Test]
        public void CopyToTest()
        {
            var set = new IndexedSet<string>();
            var array = new string[2];

            Assert.IsEmpty(set);
            Assert.That(array, Is.All.Null);

            set.CopyTo(array, 0);

            Assert.IsEmpty(set);
            Assert.That(array, Is.All.Null);

            set.Add("A");
            set.Add("B");
            set.CopyTo(array, 0);

            Assert.That(set.Count, Is.EqualTo(2));
            Assert.That(set, Contains.Item("A").And.Contains("B"));
            Assert.That(array.Length, Is.EqualTo(2));
            Assert.That(array, Is.All.Not.Null);
            Assert.That(array, Contains.Item("A").And.Contains("B"));
            Assert.That(array[0], Is.EqualTo("A"));
            Assert.That(array[1], Is.EqualTo("B"));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.False(firstSet.IsProperSubsetOf(secondSet));
            Assert.False(secondSet.IsProperSubsetOf(firstSet));

            firstSet.Add("A");

            Assert.False(firstSet.IsProperSubsetOf(secondSet));
            Assert.True(secondSet.IsProperSubsetOf(firstSet));

            secondSet.Add("A");

            Assert.False(firstSet.IsProperSubsetOf(secondSet));
            Assert.False(secondSet.IsProperSubsetOf(firstSet));

            firstSet.Add("B");

            Assert.False(firstSet.IsProperSubsetOf(secondSet));
            Assert.True(secondSet.IsProperSubsetOf(firstSet));
        }

        [Test]
        public void IsProperSupersetOf()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.False(firstSet.IsProperSupersetOf(secondSet));
            Assert.False(secondSet.IsProperSupersetOf(firstSet));

            firstSet.Add("A");

            Assert.True(firstSet.IsProperSupersetOf(secondSet));
            Assert.False(secondSet.IsProperSupersetOf(firstSet));

            secondSet.Add("A");

            Assert.False(firstSet.IsProperSupersetOf(secondSet));
            Assert.False(secondSet.IsProperSupersetOf(firstSet));

            firstSet.Add("B");

            Assert.True(firstSet.IsProperSupersetOf(secondSet));
            Assert.False(secondSet.IsProperSupersetOf(firstSet));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.True(firstSet.IsSubsetOf(secondSet));
            Assert.True(secondSet.IsSubsetOf(firstSet));

            firstSet.Add("A");

            Assert.False(firstSet.IsSubsetOf(secondSet));
            Assert.True(secondSet.IsSubsetOf(firstSet));

            secondSet.Add("A");

            Assert.True(firstSet.IsSubsetOf(secondSet));
            Assert.True(secondSet.IsSubsetOf(firstSet));

            firstSet.Add("B");

            Assert.False(firstSet.IsSubsetOf(secondSet));
            Assert.True(secondSet.IsSubsetOf(firstSet));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.True(firstSet.IsSupersetOf(secondSet));
            Assert.True(secondSet.IsSupersetOf(firstSet));

            firstSet.Add("A");

            Assert.True(firstSet.IsSupersetOf(secondSet));
            Assert.False(secondSet.IsSupersetOf(firstSet));

            secondSet.Add("A");

            Assert.True(firstSet.IsSupersetOf(secondSet));
            Assert.True(secondSet.IsSupersetOf(firstSet));

            firstSet.Add("B");

            Assert.True(firstSet.IsSupersetOf(secondSet));
            Assert.False(secondSet.IsSupersetOf(firstSet));
        }

        [Test]
        public void OverlapsTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.False(firstSet.Overlaps(secondSet));
            Assert.False(secondSet.Overlaps(firstSet));

            firstSet.Add("A");

            Assert.False(firstSet.Overlaps(secondSet));
            Assert.False(secondSet.Overlaps(firstSet));

            secondSet.Add("A");

            Assert.True(firstSet.Overlaps(secondSet));
            Assert.True(secondSet.Overlaps(firstSet));

            firstSet.Add("B");

            Assert.True(firstSet.Overlaps(secondSet));
            Assert.True(secondSet.Overlaps(firstSet));
        }

        [Test]
        public void SetEqualsTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            Assert.True(firstSet.SetEquals(secondSet));
            Assert.True(secondSet.SetEquals(firstSet));

            firstSet.Add("A");

            Assert.False(firstSet.SetEquals(secondSet));
            Assert.False(secondSet.SetEquals(firstSet));

            secondSet.Add("A");

            Assert.True(firstSet.SetEquals(secondSet));
            Assert.True(secondSet.SetEquals(firstSet));

            firstSet.Add("B");

            Assert.False(firstSet.SetEquals(secondSet));
            Assert.False(secondSet.SetEquals(firstSet));
        }

        [Test]
        public void UnionWithTest()
        {
            var firstSet = new IndexedSet<string>();
            var secondSet = new IndexedSet<string>();

            firstSet.UnionWith(secondSet);

            Assert.IsEmpty(firstSet);
            Assert.IsEmpty(secondSet);

            firstSet.Add("A");
            firstSet.UnionWith(secondSet);

            Assert.That(firstSet.Count, Is.EqualTo(1));
            Assert.That(firstSet[0], Is.EqualTo("A"));

            Assert.IsEmpty(secondSet);

            secondSet.Add("A");

            firstSet.UnionWith(secondSet);

            Assert.That(firstSet.Count, Is.EqualTo(1));
            Assert.That(firstSet[0], Is.EqualTo("A"));

            Assert.That(secondSet.Count, Is.EqualTo(1));
            Assert.That(secondSet[0], Is.EqualTo("A"));

            secondSet.Add("B");

            Assert.That(firstSet.Count, Is.EqualTo(1));
            Assert.That(firstSet[0], Is.EqualTo("A"));

            Assert.That(secondSet.Count, Is.EqualTo(2));
            Assert.That(secondSet[0], Is.EqualTo("A"));
            Assert.That(secondSet[1], Is.EqualTo("B"));

            firstSet.UnionWith(secondSet);

            Assert.That(firstSet.Count, Is.EqualTo(2));
            Assert.That(firstSet[0], Is.EqualTo("A"));
            Assert.That(firstSet[1], Is.EqualTo("B"));

            Assert.That(secondSet.Count, Is.EqualTo(2));
            Assert.That(secondSet[0], Is.EqualTo("A"));
            Assert.That(secondSet[1], Is.EqualTo("B"));
        }

        [Test]
        public void IndexOfTest()
        {
            var set = new IndexedSet<string>();

            Assert.That(set.IndexOf(null), Is.EqualTo(-1));
            Assert.That(set.IndexOf("A"), Is.EqualTo(-1));

            set.Add("A");
            Assert.Zero(set.IndexOf("A"));

            set[0] = "B";
            Assert.Zero(set.IndexOf("B"));
        }

        [Test]
        public void InsertTest()
        {
            var set = new IndexedSet<string>();

            set.Insert(0, "A");
            Assert.That(set[0], Is.EqualTo("A"));
            Assert.That(set.Count, Is.EqualTo(1));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                set.Insert(5, "B");
            });

            Assert.That(set[0], Is.EqualTo("A"));
            Assert.That(set.Count, Is.EqualTo(1));

            set.Insert(1, "B");
            Assert.That(set.Count, Is.EqualTo(2));
            Assert.That(set[0], Is.EqualTo("A"));
            Assert.That(set[1], Is.EqualTo("B"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = set[2];
            });
        }

        [Test]
        public void RemoveAtTest()
        {
            var set = new IndexedSet<string>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                set.RemoveAt(0);
            });

            set.Insert(0, "A");
            Assert.That(set.Count, Is.EqualTo(1));
            Assert.That(set[0], Is.EqualTo("A"));

            set.RemoveAt(0);
            Assert.IsEmpty(set);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                set.RemoveAt(0);
            });
        }

        [Test]
        public void IndexTest()
        {
            var set = new IndexedSet<string>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = set[0];
            });

            set.Add("A");
            Assert.IsNotEmpty(set);
            Assert.That(set.Count, Is.EqualTo(1));
            Assert.That(set[0], Is.EqualTo("A"));
        }
    }
}
