using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.Cmd
{
    public class Program
    {
        private const string endpointName = "BasicContext_EPoint";
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
