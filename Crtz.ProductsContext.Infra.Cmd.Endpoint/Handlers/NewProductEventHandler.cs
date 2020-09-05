using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.Messages.Events;
using Crtz.ProductsContext.Core;
using Crtz.ProductsContext.Infra.Storage.EF;

namespace Crtz.ProductsContext.App.Cmd.EPoint
{
    public class NewProductEventHandler : IHandleMessages<NewProductSimpleEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductEventHandler>();
        private IProductStorage productStorage;

        public NewProductEventHandler(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public Task Handle(NewProductSimpleEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incomimng {message}");

            productStorage.Add(new Product(message.Name, message.Description, message.Price));
            return Task.CompletedTask;
        }
    }
}
