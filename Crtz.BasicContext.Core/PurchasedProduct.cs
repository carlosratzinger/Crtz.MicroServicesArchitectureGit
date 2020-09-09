using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class PurchasedProduct
    {
        public int Id { get; private set; }
        public double Price { get; private set; }        

        public PurchasedProduct(int id, double price)
        {
            this.Id = id;
            this.Price = price;            
        }

        public override string ToString()
        {
            return string.Format(" ID:{0}; Price:{1}", this.Id, this.Price);
        }
    }
}
