using NUnit.Framework;
using SmogonBattleSimulator.NET.Generations.I.Events;
using SmogonBattleSimulator.NET.Generations.I.Move.Effect;

namespace SmogonBattleSimulator.NET.UnitTests.Move.Effect
{
    [TestFixture]
    [TestOf(typeof(BaseEffect))]
    public class EffectEventBusTest : BaseUnitTest
    {
        [Test]
        public void Test()
        {
            var eventBus = new EventBus();
            var effect = new TestEffect();

            effect.OnEventBusCreation(eventBus);

            Assert.False(effect.Handled);

            var @event = new TestEvent();
            eventBus.Raise(@event);

            Assert.True(effect.Handled);

            effect.Handled = false;
            Assert.False(effect.Handled);

            eventBus.Unsubscribe<TestEvent>(effect.TestListener);
            Assert.False(effect.Handled);

            @event = new TestEvent();
            eventBus.Raise(@event);
            Assert.False(effect.Handled);
        }
    }

    public class TestEffect : BaseEffect
    {
        public bool Handled { get; set; }

        [EventHandler]
        public void TestListener(TestEvent @event)
        {
            Handled = true;
        }
    }

    public class TestEvent : IEvent { }
}
