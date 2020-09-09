using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class SaleStorage : ISaleStorage
    {
        //private SqlConnection connection = ConnectionFactory.GetConnection();
        private DbContextOptions<BasicEFCoreDbContext> options;

        public void Add(Sale sale)
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                ctx.Sales.Add(sale);
                ctx.SaveChanges();
            }
        }

        public List<Sale> GetAll()
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                return ctx.Sales.ToList();
            }
        }

        public Sale GetById(int id)
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                return ctx.Sales.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
