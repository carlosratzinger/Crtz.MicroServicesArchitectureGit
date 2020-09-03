using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.Core
{
    public class ProductsCatalog
    {
        private List<Product> products = new List<Product>();

        public ProductsCatalog()
        {
            Product product1 = new Product(1, 100, nameof(product1));
            Product product2 = new Product(2, 100, nameof(product2));
            Product product3 = new Product(3, 100, nameof(product3));
            Product product4 = new Product(4, 100, nameof(product4));
            Product product5 = new Product(5, 100, nameof(product5));

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
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
