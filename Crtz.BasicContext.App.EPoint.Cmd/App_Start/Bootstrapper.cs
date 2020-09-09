using Autofac;
using Crtz.BasicContext.Core;
using Crtz.BasicContext.Infra.Storage.EFCore;

namespace Crtz.BasicContext.App.EPoint.Cmd
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SaleStorage>().As<ISaleStorage>();
            //--- Others

            Container = builder.Build();
        }
    }
}
