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

            EndpointConfig.ConfigureSerialization(endpointCfg);
            EndpointConfig.ConfigureTransport(endpointCfg, ConfigurationManager.ConnectionStrings[ConnectionStringNames.AzureServiceBusTransport].ToString());
            EndpointConfig.ConfigureLearningPersistence(endpointCfg);

            endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.WriteLine($"{endpointName} endpoint started with success");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();

            Console.ReadLine();
            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
