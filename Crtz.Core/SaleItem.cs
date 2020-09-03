using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Core
{
    public class SaleItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public SaleItem(Product product, int quantity)
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
