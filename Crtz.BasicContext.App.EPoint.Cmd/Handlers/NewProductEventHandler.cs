using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.Messages.Events;
using Autofac;

namespace Crtz.BasicContext.App.EPoint.Cmd.Handlers
{
    public class NewProductEventHandler : IHandleMessages<NewProductSimpleEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductEventHandler>();
        //private IProductStorage productStorage;

        public NewProductEventHandler()
        {
            //this.productStorage = Bootstrapper.Container.Resolve<IProductStorage>();
        }

        public Task Handle(NewProductSimpleEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incomimng {message}");

            return Task.CompletedTask;
        }
    }
}
