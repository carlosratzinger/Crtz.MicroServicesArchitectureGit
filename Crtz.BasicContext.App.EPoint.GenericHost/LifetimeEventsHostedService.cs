using Crtz.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.GenericHost
{
    public class LifetimeEventsHostedService : IHostedService
    {
        private readonly ILogger<LifetimeEventsHostedService> logger;
        private readonly IHostApplicationLifetime appLifeTime;
        private readonly IConfiguration configuration;

        private IEndpointInstance endpointInstance;

        public LifetimeEventsHostedService(ILogger<LifetimeEventsHostedService> logger, IHostApplicationLifetime appLifeTime, IConfiguration configuration)
        {
            this.logger = logger;
            this.appLifeTime = appLifeTime;
            this.configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.appLifeTime.ApplicationStarted.Register(OnStarted);
            this.appLifeTime.ApplicationStarted.Register(OnStopping);
            this.appLifeTime.ApplicationStarted.Register(OnStopped);

            return Task.CompletedTask;
        }

        #region OnStarted

        private async void OnStarted()
        {
            logger.LogInformation("OnStarted called");

            EndpointConfiguration endpointCfg = new EndpointConfiguration(EndpointNames.BasicContext_EPoint);

            ConfigureSerialization(endpointCfg);
            ConfigureTransport(endpointCfg);
            ConfigurePersistence(endpointCfg);

            endpointInstance = await Endpoint.Start(endpointCfg).ConfigureAwait(false);
        }

        private void ConfigureSerialization(EndpointConfiguration endpointCfg)
        {
            endpointCfg.UseSerialization<NewtonsoftSerializer>();
        }

        private void ConfigureTransport(EndpointConfiguration endpointCfg)
        {
            endpointCfg.EnableInstallers();

            TransportExtensions<AzureServiceBusTransport> transport = endpointCfg.UseTransport<AzureServiceBusTransport>();
            transport.ConnectionString(configuration.GetConnectionString(ConnectionStringNames.AzureServiceBusTransport));

            //endpointCfg.UseTransport<AzureServiceBusTransport>();
        }

        private void ConfigurePersistence(EndpointConfiguration endpointCfg)
        {
            return;
        }

        #endregion

        #region OnStoped

        private void OnStopping()
        {
            logger.LogInformation("OnStopping called");
        }

        private void OnStopped()
        {
            logger.LogInformation("OnStopped called");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("StopAsync called");

            endpointInstance.Stop().ConfigureAwait(false);
            return Task.CompletedTask;
        }

        #endregion
    }
}
