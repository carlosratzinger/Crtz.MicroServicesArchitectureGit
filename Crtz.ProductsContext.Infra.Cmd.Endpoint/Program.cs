using System;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serialization;
using Crtz.Messages.Events;
using Crtz.ProductsContext.Core;
using Crtz.ProductsContext.Infra.Storage.EF;

namespace Crtz.ProductsContext.App.Cmd.EPoint
{
    class Program
    {
        private const string endpointName = "ProductsContext_EndPoint";
        private static ILog LOG = LogManager.GetLogger<Program>();

        public static void Main(string[] args)
        {
            Console.Title = endpointName;
            InitializeEndpoint().GetAwaiter().GetResult();
        }

        private static async Task InitializeEndpoint()
        {
            EndpointConfiguration endpointCfg = new EndpointConfiguration(endpointName);
            SerializationExtensions<NewtonsoftSerializer> serialization = endpointCfg.UseSerialization<NewtonsoftSerializer>();
            TransportExtensions<LearningTransport> transport = endpointCfg.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.WriteLine($"{endpointName} endpoint started with success");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();

            Console.ReadLine();
            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
