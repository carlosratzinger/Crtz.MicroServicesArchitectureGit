using Crtz.Common;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.Cmd
{
    public class Program
    {
        private static ILog LOG = LogManager.GetLogger<Program>();

        private static string endpointName = EntpointNames.BasicContext_EPoint;
        private static IConfigurationRoot configuration;
        private static IEndpointInstance endpointInstance;

        public static void Main(string[] args)
        {
            Console.Title = endpointName;

            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json", false)
               .Build();

            Bootstrapper.Initialize();
            InitializeEndpoint().GetAwaiter().GetResult();
        }

        private static async Task InitializeEndpoint()
        {
            EndpointConfiguration endpointCfg = new EndpointConfiguration(endpointName);

            ConfigureSerialization(endpointCfg);
            ConfigureTransport(endpointCfg);
            ConfigurePersistence(endpointCfg);

            endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.WriteLine($"{endpointName} endpoint started with success");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();

            Console.ReadLine();
            await endpointInstance.Stop().ConfigureAwait(false);
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

            //endpointCfg.UseTransport<LearningTransport>();
        }

        private static void ConfigurePersistence(EndpointConfiguration endpointCfg)
        {
            endpointCfg.UsePersistence<LearningPersistence>();
        }
    }
}
