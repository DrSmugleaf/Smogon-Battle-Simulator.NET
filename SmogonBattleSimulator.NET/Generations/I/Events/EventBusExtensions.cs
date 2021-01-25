using System;
using System.Collections.Generic;
using System.Reflection;
using SmogonBattleSimulator.NET.Extensions;

namespace SmogonBattleSimulator.NET.Generations.I.Events
{
    public static class EventBusExtensions
    {
        public static EventHandlerGroup GetEventHandlers<T>(this T instance) where T : notnull
        {
            var methods = instance.GetType().GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static
            );

            var handlers = new Dictionary<System.Type, Delegate>();

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
                var handlerType = typeof(EventListener<>).MakeGenericType(parameterType);
                var listener = method.CreateDelegate(handlerType, instance);

                handlers.Add(parameterType, listener);
            }

            return new EventHandlerGroup(handlers);
        }

        public static EventHandlerGroup SubscribeEventHandlers<T>(this IEventBus bus, T instance) where T : notnull
        {
            var handlers = instance.GetEventHandlers();

            foreach (var (type, handler) in handlers)
            {
                bus.Subscribe(type, handler);
            }

            return handlers;
        }
    }
}
