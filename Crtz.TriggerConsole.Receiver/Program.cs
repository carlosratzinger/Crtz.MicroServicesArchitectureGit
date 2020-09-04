using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serialization;
using System;
using System.Threading.Tasks;

namespace Crtz.TriggerConsole.Receiver
{
    public class Program
    {
        const string endpointName = "Receiver";
        static ILog LOG = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            Console.Title = endpointName;
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            EndpointConfiguration endpointCfg = new EndpointConfiguration(endpointName);
            SerializationExtensions<NewtonsoftSerializer> serialization = endpointCfg.UseSerialization<NewtonsoftSerializer>();
            TransportExtensions<LearningTransport> transport = endpointCfg.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            Console.WriteLine($"{endpointName} endpoint started with success");
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.WriteLine();
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
