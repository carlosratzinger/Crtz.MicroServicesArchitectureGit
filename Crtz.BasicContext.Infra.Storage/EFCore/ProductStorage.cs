using System;
using System.Collections.Generic;
using System.Linq;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    //public class ProductStorage : IProductStorage
    //{
    //    private SqlConnection connection = ConnectionFactory.GetConnection();

    //    public void Add(Product product)
    //    {
    //        using (var ctx = new ProductEFDbContext(connection))
    //        {
    //            ctx.Products.Add(product);
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public List<Product> GetAllProducts()
    //    {
    //        using (var ctx = new ProductEFDbContext(connection))
    //        {
    //            return ctx.Products.ToList();
    //        }
    //    }

    //    public Product GetById(int id)
    //    {
    //        using (var ctx = new ProductEFDbContext(connection))
    //        {
    //            return ctx.Products.FirstOrDefault(p => p.Id == id);
    //        }
    //    }
    //}
}
