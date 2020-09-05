using Crtz.ProductsContext.Core;
using Crtz.ProductsContext.Infra.Storage.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage
{
    public class ProductStorage : IProductStorage
    {
        public void Add(Product product)
        {
            using (var ctx = new EntityFrameworkContext())
            {
                ctx.Products.Add(product);
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var ctx = new EntityFrameworkContext())
            {
                return ctx.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var ctx = new EntityFrameworkContext())
            {
                return ctx.Products.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
