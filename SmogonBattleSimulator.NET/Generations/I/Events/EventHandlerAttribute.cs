using System;
using JetBrains.Annotations;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    [AttributeUsage(AttributeTargets.Method)]
    [MeansImplicitUse]
    public class EventHandlerAttribute : Attribute { }
}
