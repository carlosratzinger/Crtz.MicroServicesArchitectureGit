using Crtz.ProductsContext.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage.EF
{
    public class EntityFrameworkContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PRODUCTS_DB;Trusted_Connection=True;");
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["MainConnection"].ToString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
