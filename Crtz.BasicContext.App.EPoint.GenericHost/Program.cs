﻿using Crtz.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.IO;

namespace Crtz.BasicContext.App.EPoint.GenericHost
{
    public class Program
    {
        private static IConfigurationRoot configuration;

        public static void Main(string[] args)
        {
            Console.Title = EndpointNames.BasicContext_EPoint;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder.UseConsoleLifetime();

            builder.ConfigureServices((hostContext, services) =>
            {
                Bootstrapper.Initialize();

                //services.AddHostedService<LifetimeEventsHostedService>();
                //services.AddHostedService<Worker>();
            });

            builder.ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile("appsettings.json", optional: false);
                configHost.AddEnvironmentVariables(prefix: "DOTNET_");
                configHost.AddCommandLine(args);

                configuration = configHost.Build();
            });

            builder.UseNServiceBus(hostContext =>
            {
                EndpointConfiguration endpointCfg = new EndpointConfiguration(EndpointNames.BasicContext_EPoint);

                EndpointConfig.ConfigureSerialization(endpointCfg);
                EndpointConfig.ConfigureTransport(endpointCfg, configuration.GetConnectionString(ConnectionStringNames.AzureServiceBusTransport));
                EndpointConfig.ConfigurePersistence(endpointCfg);

                return endpointCfg;
            });

            return builder;
        }
    }
}
