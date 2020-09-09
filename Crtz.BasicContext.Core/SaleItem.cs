using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class SaleItem
    {
        public int Id { get; private set; }
        public PurchasedProduct Product { get; private set; }
        public int Quantity { get; private set; }

        public SaleItem(PurchasedProduct product, int quantity)
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
