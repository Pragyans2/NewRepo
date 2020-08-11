using Microservice.domain.core.Events;

namespace Microservice.domain.core.Bus
{
    public interface IEventHandler<T> where T : Event
    {
    }
}