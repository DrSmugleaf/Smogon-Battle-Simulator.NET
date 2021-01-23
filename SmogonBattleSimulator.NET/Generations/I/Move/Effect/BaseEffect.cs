using System;
using System.Collections.Immutable;
using System.Reflection;
using SmogonBattleSimulator.NET.Extensions;
using SmogonBattleSimulator.NET.Generations.I.Events;

namespace SmogonBattleSimulator.NET.Generations.I.Move.Effect
{
    public abstract class BaseEffect : IEffect
    {
        public virtual ImmutableHashSet<EffectFlag> EffectFlags { get; } = ImmutableHashSet<EffectFlag>.Empty;

        public void OnEventBusCreation(EventBus eventBus)
        {
            var methods = GetType().GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static
            );

            foreach (var method in methods)
            {
                if (!method.HasAttribute<EventHandlerAttribute>())
                {
                    continue;
                }

                var parameters = method.GetParameters();

                if (parameters.Length != 1)
                {
                    throw new TargetParameterCountException(
                        $"Expected 1 parameter, got {parameters.Length} from method {method}");
                }

                var parameter = parameters[0];
                var parameterType = parameter.ParameterType;
                var handlerType = typeof(Events.EventHandler<>).MakeGenericType(parameterType);
                var @delegate = method.CreateDelegate(handlerType, this);
                var subscribeMethod = eventBus.GetType().GetMethod("Subscribe")?.MakeGenericMethod(parameterType) ?? throw new NullReferenceException();

                subscribeMethod.Invoke(eventBus, new object?[] {@delegate});
            }
        }
    }
}
