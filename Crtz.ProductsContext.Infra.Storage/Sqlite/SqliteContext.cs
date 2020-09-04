using Crtz.ProductsContext.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage.Sqlite
{
    public class SqliteContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //options.UseSqlite("Data Source=ProductsDB.db");
        

        //options.UseSqlite($"Data Source={_appHost.ContentRootPath}/data.db}");
    }
}
