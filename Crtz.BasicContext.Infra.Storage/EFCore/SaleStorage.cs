using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Crtz.BasicContext.Core;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class SaleStorage : ISaleStorage
    {
        //private SqlConnection connection = ConnectionFactory.GetConnection();
        private DbContextOptionsBuilder<BasicEFCoreDbContext> optionsBuilder = new DbContextOptionsBuilder<BasicEFCoreDbContext>();
        private string connectionString = @"Data Source=localhost\SQLEXPRESS; Trusted_Connection=True; Database=DB_BasicContext;";

        public SaleStorage()
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public void Add(Sale sale)
        {
            using (var ctx = new BasicEFCoreDbContext(optionsBuilder.Options))
            {
                ctx.Sales.Add(sale);
                ctx.SaveChanges();
            }
        }

        public List<Sale> GetAll()
        {
            using (var ctx = new BasicEFCoreDbContext(optionsBuilder.Options))
            {
                return ctx.Sales.ToList();
            }
        }

        public Sale GetById(int id)
        {
            using (var ctx = new BasicEFCoreDbContext(optionsBuilder.Options))
            {
                return ctx.Sales.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
