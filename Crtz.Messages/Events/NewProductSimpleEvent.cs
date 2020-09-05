using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Messages.Events
{
    public class NewProductSimpleEvent : IEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public NewProductSimpleEvent(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}; Description: {this.Description}; Price: {this.Price}";
        }
    }
}
