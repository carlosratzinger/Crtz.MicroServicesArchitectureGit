using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class BasicEFCoreDbContext : DbContext
    {
        private string defaultConnectionString = @"Data Source=localhost\SQLEXPRESS; Trusted_Connection=True; Database=DB_BasicContext;";

        public BasicEFCoreDbContext(DbContextOptions<BasicEFCoreDbContext> options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(defaultConnectionString);
        }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SaleConfiguration());
            builder.ApplyConfiguration(new SaleItemsConfiguration());
        }
    }
}
