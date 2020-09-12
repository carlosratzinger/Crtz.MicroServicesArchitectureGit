using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.Common;
using Crtz.Messages.Commands;
using Crtz.Messages.Events;
using System.IO;

namespace Crtz.TriggerConsole
{
    public class Program
    {
        private static ILog LOG = LogManager.GetLogger<Program>();

        private static string endpointName = "Sender";
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

            endpointCfg.ConfigureSerialization();
            endpointCfg.ConfigureTransport(configuration.GetConnectionString(ConnectionStringNames.AzureServiceBusTransport));
            endpointCfg.ConfigurePersistence();

            endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);

            await Worker(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        private static Task Worker(IEndpointInstance endpointInstance)
        {
            Console.WriteLine();
            Console.WriteLine("'A' to create a NewProductEvent");
            Console.WriteLine("'B:{int:SagaId},{string:name}' to set just a product name");
            Console.WriteLine("'C:{int:SagaId},{string:description}' to set just a product description");
            Console.WriteLine("'D:{int:SagaId},{double:price}' to set just a product price");
            Console.WriteLine();
            Console.WriteLine("'E: to create a NewSaleCommand");
            Console.WriteLine("Or, 'Q' to Quit");

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                try
                {
                    string typedValue = Console.ReadLine();
                    string command = string.Empty;

                    string[] splitedValues = typedValue.Split(":");
                    command = splitedValues[0].ToUpper();

                    string[] additionalData = null;
                    if (command == "B" || command == "C" || command == "D")
                    {
                        additionalData = splitedValues[1].Split(",");
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
                                NameProductEvent evnt = new NameProductEvent(Convert.ToInt32(additionalData[0]), additionalData[1]);
                                LOG.Info($"\n\n Publishing a {nameof(NameProductEvent)}: {evnt} \n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "C":
                            {
                                DescriptionProductEvent evnt = new DescriptionProductEvent(Convert.ToInt32(additionalData[0]), additionalData[1]);
                                LOG.Info($"\n\n Publishing a {nameof(DescriptionProductEvent)}: {evnt} \n\n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "D":
                            {
                                PriceProductEvent evnt = new PriceProductEvent(Convert.ToInt32(additionalData[0]), Convert.ToDouble(additionalData[1]));
                                LOG.Info($"\n\n Publishing a {nameof(PriceProductEvent)}: {evnt} \n\n");

                                endpointInstance.Publish(evnt).ConfigureAwait(false);
                                continue;
                            }

                        case "E":
                            {
                                CreateNewSaleCommand evnt = new CreateNewSaleCommand();
                                evnt.AddSaleItem(1, 20, 10);
                                evnt.AddSaleItem(2, 21, 11);
                                evnt.AddSaleItem(3, 22, 12);
                                evnt.AddSaleItem(4, 23, 13);

                                LOG.Info($"\n\n Publishing a {nameof(CreateNewSaleCommand)}: {evnt} \n\n");

                                endpointInstance.Send(EndpointNames.BasicContext_EPoint, evnt).ConfigureAwait(false);                                
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
