using System;
using System.Collections.Generic;
using System.Linq;

namespace Crtz.ProductContext.Core
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
            if (!AlreadyExists(product.Name))
            {
                productStorage.Add(product);
            }
        }

        public List<Product> GetAllProducts()
        {
            return productStorage.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productStorage.GetById(id);
        }

        public bool AlreadyExists(string name)
        {
            return productStorage.GetAllProducts().Any(p => p.Name == name);
        }
    }
}
