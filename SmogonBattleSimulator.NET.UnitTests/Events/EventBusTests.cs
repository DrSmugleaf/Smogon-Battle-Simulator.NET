using NUnit.Framework;
using SmogonBattleSimulator.NET.Generations.I.Events;

namespace SmogonBattleSimulator.NET.UnitTests.Events
{
    [TestFixture]
    [TestOf(typeof(EventBus))]
    public class EventBusTests
    {
        [Test]
        public void SubscribeTest()
        {
            var bus = new EventBus();
            var listener = new EventListener();

            Assert.False(listener.Handled);

            var @event = new TestEvent();
            bus.Send(@event);

            Assert.False(listener.Handled);
            Assert.True(bus.Subscribe<TestEvent>(listener.Listen));
            Assert.False(listener.Handled);
            Assert.False(bus.Subscribe<TestEvent>(listener.Listen));
            Assert.False(listener.Handled);

            bus.Send(@event);

            Assert.True(listener.Handled);

            listener.Handled = false;

            Assert.False(listener.Handled);

            bus.Send(@event);

            Assert.True(listener.Handled);

            listener.Handled = false;

            Assert.True(bus.Unsubscribe<TestEvent>(listener.Listen));
            Assert.False(listener.Handled);
            Assert.False(bus.Unsubscribe<TestEvent>(listener.Listen));
            Assert.False(listener.Handled);

            bus.Send(@event);

            Assert.False(listener.Handled);
        }
    }

    public class TestEvent : IEvent { }

    public class EventListener
    {
        public bool Handled { get; set; }

        public void Listen(TestEvent @event)
        {
            Handled = true;
        }
    }
}
