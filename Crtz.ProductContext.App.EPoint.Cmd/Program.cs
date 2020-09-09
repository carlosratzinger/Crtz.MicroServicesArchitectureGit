using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.ProductContext.Core;
using Crtz.ProductContext.Infra.Storage.EF;
using Crtz.Common;

namespace Crtz.ProductContext.App.EPoint.Cmd
{
    public class Program
    {
        private const string endpointName = EntpointNames.ProductContext_EPoint;
        private static ILog LOG = LogManager.GetLogger<Program>();

        public static void Main(string[] args)
        {
            Console.Title = endpointName;

            Bootstrapper.Initialize();
            InitializeEndpoint().GetAwaiter().GetResult();
        }

        private static async Task InitializeEndpoint()
        {
            EndpointConfiguration endpointCfg = new EndpointConfiguration(endpointName);
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
            endpointCfg.UseTransport<LearningTransport>();
            endpointCfg.UsePersistence<LearningPersistence>();

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
