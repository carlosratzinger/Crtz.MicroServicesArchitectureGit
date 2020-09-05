using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductsContext.Core
{
    public interface IProductStorage
    {
        void Add(Product product);

        Product GetById(int id);
        List<Product> GetAllProducts();
    }
}
