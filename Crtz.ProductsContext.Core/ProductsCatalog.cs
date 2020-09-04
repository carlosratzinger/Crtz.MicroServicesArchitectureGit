using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.ProductsContext.Core
{
    public class ProductsCatalog : IProductsCatalog
    {
        private List<IProduct> products = new List<IProduct>();

        public ProductsCatalog()
        {
            IProduct product1 = new Product(1, 100, nameof(product1));
            IProduct product2 = new Product(2, 100, nameof(product2));
            IProduct product3 = new Product(3, 100, nameof(product3));
            IProduct product4 = new Product(4, 100, nameof(product4));
            IProduct product5 = new Product(5, 100, nameof(product5));

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
        }

        public List<IProduct> GetAllProducts()
        {
            return products;
        }

        public IProduct GetProduct(int id)
        {
            return products.First(p => p.Id == id);
        }
    }
}
