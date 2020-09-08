using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.ProductContext.Core;
using Crtz.Messages.Events;
using Autofac;

namespace Crtz.ProductContext.App.EPoint.Cmd.Handlers
{
    public class NewProductEventHandler : IHandleMessages<NewProductSimpleEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductEventHandler>();
        private IProductStorage productStorage;

        public NewProductEventHandler()
        {
            this.productStorage = Bootstrapper.Container.Resolve<IProductStorage>();
        }

        public Task Handle(NewProductSimpleEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incomimng {message}");

            ProductsCatalog catalog = new ProductsCatalog(productStorage);
            catalog.AddNewProduct(new Product(message.Name, message.Description, message.Price));

            return Task.CompletedTask;
        }
    }
}
