using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.ProductsContext.Core
{
    public class ProductsCatalog
    {
        private List<Product> products = new List<Product>();

        public void AddNewProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProduct(int id)
        {
            return products.First(p => p.Id == id);
        }
    }
}
