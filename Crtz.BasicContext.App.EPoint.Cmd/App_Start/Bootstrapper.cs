using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Crtz.BasicContext.App.EPoint.Cmd
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();            
            //--- Others

            Container = builder.Build();
        }
    }
}
