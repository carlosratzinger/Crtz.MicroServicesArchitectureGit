using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.Common;
using System.Configuration;

namespace Crtz.ProductContext.App.EPoint.Cmd
{
    public class Program
    {   
        private static ILog LOG = LogManager.GetLogger<Program>();

        private static string endpointName = EndpointNames.ProductContext_EPoint;
        private static IEndpointInstance endpointInstance;

        public static void Main(string[] args)
        {
            Console.Title = endpointName;

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
            transport.ConnectionString(ConfigurationManager.ConnectionStrings[ConnectionStringNames.AzureServiceBusTransport].ToString());

            //endpointCfg.UseTransport<LearningTransport>();
        }

        private static void ConfigurePersistence(EndpointConfiguration endpointCfg)
        {
            endpointCfg.UsePersistence<LearningPersistence>();
        }
    }
}
