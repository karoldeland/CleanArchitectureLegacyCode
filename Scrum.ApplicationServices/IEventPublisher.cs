namespace Scrum.ApplicationServices
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventObject);
    }
}