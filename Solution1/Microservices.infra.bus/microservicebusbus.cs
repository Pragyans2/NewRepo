using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.infra.bus
{
    public sealed class microservicebusbus : IEventBus
    {
        private readonly IMediator mediator;
        private readonly Dictionary<string, list<Type>> _handlers;
        private readonly list<Type> _eventTypes;
        private object _mediator;

        public object Mmediator { get; }

        public microservicebusbus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, list<Type>>();
            _eventTypes = new list<Type>();

        }
        
        public void publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection()) 
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", eventName, null, body);
            }

        }
        public void subscribe<T,TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlertype = typeof(TH);
            if(!_eventTypes.contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }
            if (! _handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new list<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlertype))
            {
                throw new ArgumentException($"handlertype{handlertype.Name}alredy is registered for'{eventName}'", nameof(handlertype));
            }
            _handlers[eventName].Add(handlertype);
            startbasiconsume<T>();
        }

        private void startbasiconsume<T>() where T : Event
        {
            throw new NotImplementedException();
        }

        public Task SendCommand<T>(T Command) where T : Command
        {
            throw new NotImplementedException();
        }
    }
} 
