using Microsoft.EntityFrameworkCore;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class BasicEFCoreDbContext : DbContext
    {
        //public ProductEFDbContext(string connectionStringName)
        //    : base(connectionStringName)
        //{
        //    Database.SetInitializer<ProductEFDbContext>(null);
        //    Configuration.LazyLoadingEnabled = false;
        //}

        //public ProductEFDbContext(IDbConnection connection)
        //    : base((DbConnection)connection, false)
        //{
        //    Database.SetInitializer<ProductEFDbContext>(null);
        //    Configuration.LazyLoadingEnabled = false;
        //}

        //public virtual DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //    builder.Configurations.Add(new ProductConfiguration());
        //}
    }
}
