using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class BasicEFCoreDbContext : DbContext
    {
        public BasicEFCoreDbContext(DbContextOptions<BasicEFCoreDbContext> options)
        { }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SaleConfiguration());
            builder.ApplyConfiguration(new SaleItemsConfiguration());
        }
    }
}
