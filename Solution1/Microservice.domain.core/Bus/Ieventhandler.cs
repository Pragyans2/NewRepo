using Microservice.domain.core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.domain.core.Bus
{
    public interface Ieventhandler<in Tevent> : Ieventhandler
        where Tevent : Event
    {
        Task Handle(TEvent @event);
    }
    public interface IEventHanler
    {

    }
}
