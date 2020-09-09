using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public interface ISaleStorage
    {
        List<Sale> GetAll();
        void Add(Sale sale);
    }
}
