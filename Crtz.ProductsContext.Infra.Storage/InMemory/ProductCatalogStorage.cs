using Crtz.Common;
using Crtz.ProductsContext.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage.InMemory
{
    public class ProductCatalogStorage
    {
        private static ProductsCatalog productsCatalog;

        public ProductCatalogStorage()
        {
            productsCatalog = new ProductsCatalog();

            //Product product1 = new Product(1, 100, nameof(product1));
            //Product product2 = new Product(2, 100, nameof(product2));
            //Product product3 = new Product(3, 100, nameof(product3));
            //Product product4 = new Product(4, 100, nameof(product4));
            //Product product5 = new Product(5, 100, nameof(product5));

            //productsCatalog.AddNewProduct(product1);
            //productsCatalog.AddNewProduct(product2);
            //productsCatalog.AddNewProduct(product3);
            //productsCatalog.AddNewProduct(product4);
            //productsCatalog.AddNewProduct(product5);
        }

        public List<Product> GetProducts()
        {
            return productsCatalog.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productsCatalog.GetProduct(id);
        }
    }
}
