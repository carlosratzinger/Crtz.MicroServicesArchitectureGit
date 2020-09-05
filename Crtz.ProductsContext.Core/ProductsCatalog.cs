using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.ProductsContext.Core
{
    public class ProductsCatalog
    {
        private IProductStorage productStorage;        

        public ProductsCatalog(IProductStorage productStorage)
        {
            this.productStorage = productStorage;            
        }

        public void AddNewProduct(Product product)
        {
            productStorage.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return productStorage.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productStorage.GetById(id);
        }
    }
}
