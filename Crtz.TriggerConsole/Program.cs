using Crtz.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serialization;
using System;
using System.Collections.Generic;
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
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
            endpointCfg.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            await Worker(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        private static Task Worker(IEndpointInstance endpointInstance)
        {
            Console.WriteLine();
            Console.WriteLine("TYPE:");
            Console.WriteLine("'A' to add a new default product");
            Console.WriteLine("'B:{int:productId},{string:name}' to set just a product name");
            Console.WriteLine("'C:{int:productId},{string:description}' to set just a product description");
            Console.WriteLine("'D:{int:productId},{double:price}' to set just a product price");            
            Console.WriteLine("Or, 'Q' to Quit");

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                try
                {
                    string typedValue = Console.ReadLine();

                    string command = string.Empty;
                    string[] informedData = null;

                    if (typedValue.StartsWith("A"))
                    {
                        command = "A";
                    }
                    else if (typedValue.StartsWith("B") || typedValue.StartsWith("C") || typedValue.StartsWith("D"))
                    {
                        string[] splitedValues = typedValue.Split(":");

                        command = splitedValues[0];
                        informedData = splitedValues[1].Split(",");
                    }
                    else if (typedValue.StartsWith("Q"))
                    {
                        command = "Q";
                    }            

                    switch (command)
                    {
                        case "A":
                            {
                                NewProductSimpleEvent evnt = new NewProductSimpleEvent("Default Product", "Default Description", DateTime.Now.Millisecond);
                                LOG.Info($"\n\n Publishing a {nameof(NewProductSimpleEvent)}: {evnt} \n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "B":
                            {
                                NameProductEvent evnt = new NameProductEvent(Convert.ToInt32(informedData[0]), informedData[1]);
                                LOG.Info($"\n\n Publishing a {nameof(NameProductEvent)}: {evnt} \n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "C":
                            {
                                DescriptionProductEvent evnt = new DescriptionProductEvent(Convert.ToInt32(informedData[0]), informedData[1]);
                                LOG.Info($"\n\n Publishing a {nameof(DescriptionProductEvent)}: {evnt} \n\n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "D":
                            {
                                PriceProductEvent evnt = new PriceProductEvent(Convert.ToInt32(informedData[0]), Convert.ToDouble(informedData[1]));
                                LOG.Info($"\n\n Publishing a {nameof(PriceProductEvent)}: {evnt} \n\n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "Q":
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Finishing the application");
                                cancellationToken.Cancel();
                                break;
                            }

                        default:
                            continue;
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
