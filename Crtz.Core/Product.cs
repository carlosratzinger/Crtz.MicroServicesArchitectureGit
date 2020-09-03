using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Core
{
    public class Product
    {
        public int Id { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }

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
