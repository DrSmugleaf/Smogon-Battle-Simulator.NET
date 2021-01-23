using System.Collections.Generic;

namespace SmogonBattleSimulator.NET.Extensions
{
    public static class DictionaryExtensions
    {
        public static V? GetValueOrNull<K, V>(this IReadOnlyDictionary<K, V> dictionary, K key) where V : struct
        {
            return dictionary.TryGetValue(key, out var value) ? value : null;
        }
    }
}
