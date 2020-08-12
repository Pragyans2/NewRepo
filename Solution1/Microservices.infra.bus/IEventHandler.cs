namespace Microservices.infra.bus
{
    public interface IEventHandler<T> where T : Event
    {
    }
}