using NUnit.Framework;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Formulas;
using SmogonBattleSimulator.NET.Generations.I.Move.Effect.Effects;

namespace SmogonBattleSimulator.NET.UnitTests.Moves.Effect.Effects
{
    [TestFixture]
    [TestOf(typeof(HighCriticalRatioEffect))]
    public class HighCriticalRatioTest
    {
        [Test]
        public void Test()
        {
            var effect = new HighCriticalRatioEffect();
            var eventBus = new EventBus();

            effect.OnEventBusCreation(eventBus);

            var @event = new CriticalRatioEvent();

            eventBus.Raise(@event);

            Assert.That(@event.Multiplier, Is.EqualTo(8M));
        }
    }
}
