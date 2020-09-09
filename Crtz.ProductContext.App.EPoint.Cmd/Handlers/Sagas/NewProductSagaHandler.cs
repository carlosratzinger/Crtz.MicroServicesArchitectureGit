using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Crtz.Messages.Events;
using Crtz.ProductContext.Core;
using Autofac;

namespace Crtz.ProductContext.App.EPoint.Cmd.Handlers
{
    public class NewProductSagaHandler : Saga<NewProductSagaData>,
                                       IAmStartedByMessages<NameProductEvent>,
                                       IAmStartedByMessages<DescriptionProductEvent>,
                                       IAmStartedByMessages<PriceProductEvent>
    {
        private static ILog LOG = LogManager.GetLogger<NewProductEventHandler>();
        private IProductStorage productStorage;

        public NewProductSagaHandler()
        {
            this.productStorage = Bootstrapper.Container.Resolve<IProductStorage>();
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<NewProductSagaData> mapper)
        {
            mapper.ConfigureMapping<NameProductEvent>(msg => msg.ProcessId).ToSaga(p => p.ProcessId);
            mapper.ConfigureMapping<DescriptionProductEvent>(msg => msg.ProcessId).ToSaga(p => p.ProcessId);
            mapper.ConfigureMapping<PriceProductEvent>(msg => msg.ProcessId).ToSaga(p => p.ProcessId);
        }

        public Task Handle(NameProductEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incoming '{message}'");
            Data.Name = message.Name;

            if (CreateNewProduct(Data, context))
            {
                this.MarkAsComplete();
                return Task.CompletedTask;
            }
            return Task.FromResult(0);
        }

        public Task Handle(DescriptionProductEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incoming '{message}'");
            Data.Description = message.Description;

            if (CreateNewProduct(Data, context))
            {
                this.MarkAsComplete();
                return Task.CompletedTask;
            }
            return Task.FromResult(0);
        }

        public Task Handle(PriceProductEvent message, IMessageHandlerContext context)
        {
            LOG.Info($"Incoming '{message}'");
            Data.Price = message.Price;

            if (CreateNewProduct(Data, context))
            {
                this.MarkAsComplete();
                return Task.CompletedTask;
            }
            return Task.FromResult(0);
        }

        private bool CreateNewProduct(NewProductSagaData sagaData, IMessageHandlerContext context)
        {
            try
            {
                if (sagaData.HasName && sagaData.HasName && sagaData.HasPrice)
                {
                    LOG.Info($"Saga is complete.");
                    LOG.Info($"Creating a new prroduct '{sagaData}'");

                    ProductsCatalog catalog = new ProductsCatalog(productStorage);

                    Product product = new Product(sagaData.Name, sagaData.Description, sagaData.Price.Value);
                    catalog.AddNewProduct(product);

                    LOG.Info($"Product created");
                    return true;
                }

                LOG.Info($"Saga is not complete yet '{sagaData}'");
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
