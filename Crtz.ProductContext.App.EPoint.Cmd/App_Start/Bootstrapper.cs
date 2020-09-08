using Autofac;
using Crtz.ProductContext.Core;
using Crtz.ProductContext.Infra.Storage.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crtz.ProductContext.App.EPoint.Cmd
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            //--- Others

            Container = builder.Build();
        }
    }
}
