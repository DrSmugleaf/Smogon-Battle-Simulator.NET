using System;

namespace SmogonBattleSimulator.NET.Extensions
{
    public static class NullableExtensions
    {
        public static T GetOrThrow<T>(this T? nullable) where T : struct
        {
            return nullable!.Value;
        }

        public static T GetOrThrow<T>(this T? nullable) where T : class
        {
            return nullable ?? throw new NullReferenceException();
        }
    }
}
