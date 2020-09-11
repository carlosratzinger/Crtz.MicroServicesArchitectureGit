using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.App.EPoint.GenericHost
{
    public static class EndpointConfig
    {
        public static void ConfigureSerialization(EndpointConfiguration endpointCfg)
        {
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
        }

        public static void ConfigureTransport(EndpointConfiguration endpointCfg, string connectionString)
        {
            endpointCfg.EnableInstallers();

            TransportExtensions<AzureServiceBusTransport> transport = endpointCfg.UseTransport<AzureServiceBusTransport>();
            transport.ConnectionString(connectionString);

            //endpointCfg.UseTransport<LearningTransport>();
        }

        public static void ConfigurePersistence(EndpointConfiguration endpointCfg)
        {
            return;
        }
    }
}
