using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using System;

namespace NsbBug
{
    internal class NServicebusConfiguration
    {
        private IStartableEndpointWithExternallyManagedContainer _endpoint;

        public void Start(IServiceProvider serviceProvider)
        {
            _endpoint.Start(serviceProvider)
                .Wait();
        }

        public NServicebusConfiguration Configure(IServiceCollection serviceCollection)
        {
            var endpointConfiguration = new EndpointConfiguration("Something");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            
            _endpoint = EndpointWithExternallyManagedServiceProvider
                .Create(endpointConfiguration, serviceCollection);

            return this;
        }
    }
}
