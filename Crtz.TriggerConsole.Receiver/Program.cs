using Crtz.Common;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Crtz.TriggerConsole.Receiver
{
    public class Program
    {
        private static ILog LOG = LogManager.GetLogger<Program>();

        private static string endpointName = "Receiver";        
        private static IConfigurationRoot configuration;
        private static IEndpointInstance endpointInstance;

        static void Main(string[] args)
        {
            Console.Title = endpointName;

            configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                 .AddJsonFile("appsettings.json", false)
                 .Build();

            InitializeEndpoint().GetAwaiter().GetResult();
        }

        private static async Task InitializeEndpoint()
        {
            EndpointConfiguration endpointCfg = new EndpointConfiguration(endpointName);

            ConfigureSerialization(endpointCfg);
            ConfigureTransport(endpointCfg);
            ConfigurePersistence(endpointCfg);

            endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        private static void ConfigureSerialization(EndpointConfiguration endpointCfg)
        {
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
        }

        private static void ConfigureTransport(EndpointConfiguration endpointCfg)
        {
            endpointCfg.EnableInstallers();

            TransportExtensions<AzureServiceBusTransport> transport = endpointCfg.UseTransport<AzureServiceBusTransport>();
            transport.ConnectionString(configuration.GetConnectionString(ConnectionStringNames.AzureServiceBusTransport));

            //endpointCfg.UseTransport<AzureServiceBusTransport>();
        }

        private static void ConfigurePersistence(EndpointConfiguration endpointCfg)
        {
            return;
        }
    }
}
