using Autofac;

namespace Crtz.BasicContext.App.EPoint.Cmd
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<ProductStorage>().As<IProductStorage>();
            //--- Others

            Container = builder.Build();
        }
    }
}
