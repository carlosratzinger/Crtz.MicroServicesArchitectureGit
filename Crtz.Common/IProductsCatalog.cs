using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Common
{
    public interface IProductsCatalog
    {
        List<IProduct> GetAllProducts();

        IProduct GetProduct(int id);
    }
}
