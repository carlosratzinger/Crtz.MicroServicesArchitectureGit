using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Common
{
    public static class EndpointConfigExtensions
    {
        public static void ConfigureSerialization(this EndpointConfiguration endpointCfg)
        {
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
        }

        public static void ConfigureTransport(this EndpointConfiguration endpointCfg, string connectionString)
        {
            endpointCfg.EnableInstallers();

            TransportExtensions<AzureServiceBusTransport> transport = endpointCfg.UseTransport<AzureServiceBusTransport>();
            transport.ConnectionString(connectionString);

            //endpointCfg.UseTransport<LearningTransport>();
        }

        public static void ConfigureLearningPersistence(this EndpointConfiguration endpointCfg)
        {
            endpointCfg.UsePersistence<LearningPersistence>();
        }

        public static void ConfigurePersistence(this EndpointConfiguration endpointCfg)
        {
            return;
        }
    }
}
