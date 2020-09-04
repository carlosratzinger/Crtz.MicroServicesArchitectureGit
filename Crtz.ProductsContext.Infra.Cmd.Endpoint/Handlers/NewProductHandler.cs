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
    public class NewProductHandler : IHandleMessages<NewProductEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductHandler>();

        public Task Handle(NewProductEvent msg, IMessageHandlerContext context)
        {
            LOG.Info(msg + "arrived");

            using (var ctx = new EntityFrameworkContext())
            {
                List<Product> allProdutcts = ctx.Products.ToList();

                ctx.Add(new Product(msg.Name, msg.Description, msg.Price));
                ctx.SaveChanges();

                allProdutcts = ctx.Products.ToList();
            }

            return Task.CompletedTask;
        }
    }
}
