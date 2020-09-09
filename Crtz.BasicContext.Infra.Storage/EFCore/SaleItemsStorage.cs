using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class SaleItemsStorage : ISaleItemsStorage
    {
        //private SqlConnection connection = ConnectionFactory.GetConnection();
        private DbContextOptions<BasicEFCoreDbContext> options;

        public void Add(SaleItem saleItem)
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                ctx.SaleItems.Add(saleItem);
                ctx.SaveChanges();
            }
        }

        public List<SaleItem> GetAll()
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                return ctx.SaleItems.ToList();
            }
        }

        public SaleItem GetById(int id)
        {
            using (var ctx = new BasicEFCoreDbContext(options))
            {
                return ctx.SaleItems.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
