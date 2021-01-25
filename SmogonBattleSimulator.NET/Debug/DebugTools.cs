using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace SmogonBattleSimulator.NET.Debug
{
    public static class DebugTools
    {
        [Conditional("DEBUG")]
        [AssertionMethod]
        public static void AssertNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object? arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException();
            }
        }

        [Conditional("DEBUG")]
        [AssertionMethod]
        public static void AssertNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] params object?[] arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
