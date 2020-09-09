using Autofac;
using Crtz.BasicContext.Core;
using Crtz.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crtz.BasicContext.App.EPoint.Cmd.Handlers
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

            //SaleRegister saleRegister = new SaleRegister(saleStorage);
            //saleRegister.BeginNewSale();
            //saleRegister.SetItem(null, 10);
            //saleRegister.Save();

            //--- Call some class of Core to perform
            return Task.CompletedTask;
        }
    }
}