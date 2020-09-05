using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using NServiceBus.Serialization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Crtz.ProductsContext.Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Crtz.ProductsContext.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();                    
            });

        #region NServiceBus configuration to use in WebAPI

        // .UseNServiceBus(context =>
        // {
        //     EndpointConfiguration endpointCfg = new EndpointConfiguration("WebAPI_Entpoint");
        //     endpointCfg.UseSerialization<NewtonsoftSerializer>();
        //     endpointCfg.UseTransport<LearningTransport>().StorageDirectory("~/App_Data");
        //     return endpointCfg;
        // });

        #endregion
    }
}
