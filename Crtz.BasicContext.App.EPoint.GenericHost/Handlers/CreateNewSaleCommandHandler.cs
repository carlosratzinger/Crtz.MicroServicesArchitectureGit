using Autofac;
using Crtz.BasicContext.Core;
using Crtz.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.GenericHost.Handlers
{
    public class CreateNewSaleCommandHandler : IHandleMessages<CreateNewSaleCommand>
    {
        private static ILog LOG = LogManager.GetLogger<CreateNewSaleCommandHandler>();
        private ISaleStorage saleStorage;

        public CreateNewSaleCommandHandler()
        {
            this.saleStorage = Bootstrapper.Container.Resolve<ISaleStorage>();
        }

        public Task Handle(CreateNewSaleCommand message, IMessageHandlerContext context)
        {
            LOG.Info($"Incomimng {message}");

            SaleRegister saleRegister = new SaleRegister(saleStorage);
            saleRegister.BeginNewSale();

            //foreach (var saleItem in message.SaleItems)
            //{
            //    saleRegister.SetItem(saleItem.Key, saleItem.Value.Item1, saleItem.Value.Item2);
            //}

            //saleRegister.Save();
            return Task.CompletedTask;
        }
    }
}