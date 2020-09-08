using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductContext.Core
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product()
        { }

        public Product(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Id:{0}; Name:{1}; Description:{1}; Price:{2}", this.Id, this.Name, this.Description, this.Price);
        }

    }
}
