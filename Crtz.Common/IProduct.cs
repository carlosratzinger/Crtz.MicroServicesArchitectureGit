using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Common
{
    public interface IProduct
    {
        int Id { get; set; }
        double Price { get; set; }
        string Description { get; set; }
    }
}
