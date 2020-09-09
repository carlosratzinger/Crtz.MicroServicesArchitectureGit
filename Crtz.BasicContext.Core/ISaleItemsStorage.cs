using Crtz.BasicContext.Core;
using System.Collections.Generic;

namespace Crtz.BasicContext.Core
{
    public interface ISaleItemsStorage
    {
        void Add(SaleItem saleItem);
        List<SaleItem> GetAll();
        SaleItem GetById(int id);
    }
}