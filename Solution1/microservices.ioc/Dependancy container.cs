using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace microservices.ioc
{
    public class Dependancy_container
    {
        public void RegisterServices(IServiceCollection services)
        {
            //Domain bus
            services.AddTransient<IEventBus>();
        }
    }

}
