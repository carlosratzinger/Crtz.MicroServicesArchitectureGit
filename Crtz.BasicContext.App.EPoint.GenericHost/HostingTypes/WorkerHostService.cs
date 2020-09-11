using Crtz.Common;
using Crtz.Messages.Commands;
using Crtz.Messages.Events;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.GenericHost
{
    public class WorkerHostService : BackgroundService
    {
        private ILog LOG = LogManager.GetLogger<WorkerHostService>();
        private IMessageSession messageSession;

        public WorkerHostService(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {   

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    //--- Eternal work here
                    await messageSession.SendLocal(null).ConfigureAwait(false);
                }
                catch (OperationCanceledException oEx)
                {
                    LOG.Info("Unexpected cancellation", oEx);
                }
            }
        }
    }
}
