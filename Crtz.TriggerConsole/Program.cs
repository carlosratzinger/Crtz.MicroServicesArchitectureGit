using Crtz.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crtz.TriggerConsole
{
    public class Program
    {
        const string endpointName = "Sender";
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

            await Worker(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        private static Task Worker(IEndpointInstance endpointInstance)
        {
            Console.WriteLine("---- SALE SYSTEM ----");

            Console.WriteLine();
            Console.WriteLine("Type: N to add a Product, P to Payment F to Finish a Sale and Q to Quit");
            Console.WriteLine();

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                try
                {
                    ConsoleKeyInfo typedKey = Console.ReadKey();

                    switch (typedKey.Key)
                    {
                        case ConsoleKey.N:
                            Console.WriteLine();
                            Console.WriteLine("Publishing a new product event");

                            endpointInstance.Publish(new NewProductEvent("New Product", Guid.NewGuid().ToString()))
                                .ConfigureAwait(false);

                            continue;

                        case ConsoleKey.Q:
                            Console.WriteLine();
                            cancellationToken.Cancel();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error");
                }
            }

            return Task.FromResult(0);
        }
    }
}
