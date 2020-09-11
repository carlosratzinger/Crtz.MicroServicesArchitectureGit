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
   
        private void OnStarted()
        {
            logger.LogInformation("OnStarted called");        
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("StopAsync called");
            return Task.CompletedTask;
        }
 
        private void OnStopping()
        {
            logger.LogInformation("OnStopping called");
        }

        private void OnStopped()
        {
            logger.LogInformation("OnStopped called");
        }
    }
}
