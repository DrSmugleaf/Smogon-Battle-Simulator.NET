using System;
using JetBrains.Annotations;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect
{
    [AttributeUsage(AttributeTargets.Class)]
    [BaseTypeRequired(typeof(IEffect))]
    [MeansImplicitUse]
    public class EffectAttribute : Attribute
    {
        public EffectAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
