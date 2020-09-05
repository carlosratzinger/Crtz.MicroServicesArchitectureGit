using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Crtz.ProductsContext.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Crtz.ProductsContext.Infra.Storage.EF
{
    public class EntityFrameworkContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Configuration configuration = new Configuration();
            //Configuration configuration;

            //configuration.GetSection("ConnectionStrings")




            options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PRODUCTS_DB;Trusted_Connection=True;");
            //options.UseSqlServer();
            //options.UseSqlServer(Microsoft.Extensions.Configuration.ConnectionStrings["MainConnection"].ToString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
