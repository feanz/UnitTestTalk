using UnitTestTalk.Workshop.Models.Events;

namespace UnitTestTalk.Workshop
{
    public interface IEventHandler
    {
        void Publish<T>(T item) where T : BaseEvent;
    }
}