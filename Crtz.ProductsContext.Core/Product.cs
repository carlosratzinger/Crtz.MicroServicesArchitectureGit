using Crtz.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductsContext.Core
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Product(int id, double price, string description)
        {
            this.Id = id;
            this.Price = price;
            this.Description = description;
        }

        public override string ToString()
        {
            return string.Format(" ID:{0}; Description:{1}", this.Id, this.Description);
        }

    }
}
