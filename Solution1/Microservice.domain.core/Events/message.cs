using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Microservice.domain.core.Events
{
    public abstract class message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        protected message()
        {
            MessageType = GetType().Name;
        }
    }
}
