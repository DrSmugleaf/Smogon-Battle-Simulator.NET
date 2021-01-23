using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SmogonBattleSimulator.NET.Collections.UniqueDictionary;

namespace SmogonBattleSimulator.NET.UnitTests.Collections.UniqueDictionary
{
    [TestFixture]
    [TestOf(typeof(UniqueDictionary<,>))]
    public class UniqueDictionaryTests : BaseUnitTest
    {
        [Test]
        public void GetEnumeratorTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var dictionary = new UniqueDictionary<object, object>();
            using var enumerator = dictionary.GetEnumerator();

            Assert.That(enumerator.Current, Is.EqualTo(default(KeyValuePair<object, object>)));
            Assert.False(enumerator.MoveNext());
        }

        [Test]
        public void GetEnumeratorExplicitTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var dictionary = new UniqueDictionary<object, object>();
            var enumerator = ((IEnumerable) dictionary).GetEnumerator();

            Assert.Throws<InvalidOperationException>(() =>
            {
                var _ = enumerator.Current;
            });
            Assert.False(enumerator.MoveNext());
        }

        [Test]
        public void ClearTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.IsEmpty(dictionary);

            dictionary[0] = "A";

            Assert.That(dictionary.Count, Is.EqualTo(1));

            dictionary.Clear();

            Assert.IsEmpty(dictionary);
        }

        [Test]
        public void CountTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.That(dictionary.Count, Is.EqualTo(0));

            dictionary[0] = "A";

            Assert.That(dictionary.Count, Is.EqualTo(1));

            dictionary[0] = "B";

            Assert.That(dictionary.Count, Is.EqualTo(1));

            dictionary[1] = "C";

            Assert.That(dictionary.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.IsEmpty(dictionary);

            dictionary.Add(0, "A");

            Assert.That(dictionary.Count, Is.EqualTo(1));

            dictionary.Add(1, "B");

            Assert.That(dictionary.Count, Is.EqualTo(2));

            Assert.Throws<ArgumentException>(() =>
            {
                dictionary.Add(0, "C");
            });
        }

        [Test]
        public void ContainsKeyTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.False(dictionary.ContainsKey(default));
            Assert.False(dictionary.ContainsKey(0));

            dictionary.Add(0, "A");

            Assert.True(dictionary.ContainsKey(0));

            dictionary.Remove(0);

            Assert.False(dictionary.ContainsKey(0));

            dictionary.Add(0, "A");

            Assert.True(dictionary.ContainsKey(0));

            dictionary.Clear();

            Assert.False(dictionary.ContainsKey(0));
        }

        [Test]
        public void RemoveTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.False(dictionary.Remove(0));

            dictionary.Add(0, "A");

            Assert.True(dictionary.Remove(0));
            Assert.False(dictionary.Remove(0));
        }

        [Test]
        public void TryGetValueTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.False(dictionary.TryGetValue(0, out var value));
            Assert.Null(value);

            dictionary.Add(0, "A");

            Assert.True(dictionary.TryGetValue(0, out value));
            Assert.NotNull(value);
            Assert.That(value, Is.EqualTo("A"));

            dictionary.Remove(0);

            Assert.False(dictionary.TryGetValue(0, out value));
            Assert.Null(value);
        }

        [Test]
        public void IndexTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = dictionary[0];
            });

            dictionary.Add(0, "A");

            var value = dictionary[0];

            Assert.NotNull(value);
            Assert.That(value, Is.EqualTo("A"));

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = dictionary[1];
            });

            dictionary.Remove(0);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = dictionary[0];
            });
        }

        [Test]
        public void KeysTest()
        {
            var dictionary = new UniqueDictionary<int, string>();

            Assert.IsEmpty(dictionary.Keys);
            Assert.IsEmpty(dictionary.Values);

            dictionary[0] = "A";

            var keys = dictionary.Keys.ToArray();
            var values = dictionary.Values.ToArray();

            Assert.IsNotEmpty(keys);
            Assert.IsNotEmpty(values);

            Assert.That(keys.Length, Is.EqualTo(values.Length));
            Assert.That(keys.Length, Is.EqualTo(1));
            Assert.That(values.Length, Is.EqualTo(1));

            Assert.That(keys[0], Is.EqualTo(0));
            Assert.That(values[0], Is.EqualTo("A"));
        }
    }
}
