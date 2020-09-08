using Crtz.ProductContext.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage.EF
{
    public class ProductEFDbContext : DbContext
    {
        public ProductEFDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer<ProductEFDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public ProductEFDbContext(IDbConnection connection)
            : base((DbConnection)connection, false)
        {
            Database.SetInitializer<ProductEFDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ProductConfiguration());
        }
    }
}
