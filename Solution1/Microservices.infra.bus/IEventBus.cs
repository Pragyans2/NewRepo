using System.Threading.Tasks;

namespace Microservices.infra.bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T Command) where T : Command;
    }
}