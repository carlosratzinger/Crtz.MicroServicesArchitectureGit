using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Common
{
    public interface IEndpointCfg
    {

    }

    public abstract class EndpointCfg : IEndpointCfg
    {
        private string endpointName = "";
        private EndpointConfiguration endpointCfg;

        public EndpointCfg()
        {
            endpointCfg = new EndpointConfiguration(endpointName);

            ConfigureSerialization();
            ConfigureTransport();
            ConfigurePersistense();
        }

        public async void Initialize()
        {
            IEndpointInstance endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.WriteLine($"{endpointName} endpoint started with success");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();

            Console.ReadLine();
            await endpointInstance.Stop().ConfigureAwait(false);
        }

        protected virtual void ConfigureSerialization()
        {
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
        }

        protected virtual void ConfigureTransport()
        {
            endpointCfg.UseTransport<LearningTransport>();
        }

        protected virtual void ConfigurePersistense()
        {
            endpointCfg.UsePersistence<LearningPersistence>();
        }
    }
}
