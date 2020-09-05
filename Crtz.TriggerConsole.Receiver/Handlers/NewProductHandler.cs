using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crtz.Messages.Events;
using NServiceBus.Logging;

namespace Crtz.TriggerConsole.Receiver
{
    public class NewProductHandler : IHandleMessages<NewProductSimpleEvent>
    {
        static ILog LOG = LogManager.GetLogger<NewProductHandler>();

        public Task Handle(NewProductSimpleEvent message, IMessageHandlerContext context)
        {
            LOG.Info(message + " arrived with success");
            return Task.FromResult(0);
        }
    }
}
