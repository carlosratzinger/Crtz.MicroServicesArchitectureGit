using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class SaleItem
    {
        public IProduct Product { get; private set; }
        public int Quantity { get; private set; }

        public SaleItem(IProduct product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public double GetSubtotal()
        {
            return this.Product.Price * this.Quantity;
        }
    }
}
