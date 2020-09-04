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
        }

        public List<IProduct> GetProducts()
        {
            return productsCatalog.GetAllProducts();
        }

        public IProduct GetProduct(int id)
        {
            return productsCatalog.GetProduct(id);
        }
    }
}
