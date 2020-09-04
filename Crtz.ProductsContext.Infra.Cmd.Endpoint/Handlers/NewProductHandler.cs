using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crtz.Messages.Events;
using NServiceBus.Logging;

namespace Crtz.ProductsContext.Infra.Cmd.Endpoint
{
    public class NewProductHandler : IHandleMessages<NewProductEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductHandler>();

        public Task Handle(NewProductEvent message, IMessageHandlerContext context)
        {
            LOG.Info(message + "arrived");
            return Task.CompletedTask;
        }
    }
}
