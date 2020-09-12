using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Messages.Events
{
    public class NameProductEvent : IEvent
    {
        public int ProcessId { get; private set; }
        public string Name { get; private set; }

        public NameProductEvent(int processId, string name)
        {
            this.ProcessId = processId;
            this.Name = name;            
        }

        public override string ToString()
        {
            return $"(Name: {this.Name})";
        }
    }

    public class DescriptionProductEvent : IEvent
    {
        public int ProcessId { get; private set; }
        public string Description { get; private set; }

        public DescriptionProductEvent(int processId, string description)
        {
            this.ProcessId = processId;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"Description: {this.Description}";
        }
    }

    public class PriceProductEvent : IEvent
    {
        public int ProcessId { get; private set; }
        public double Price { get; private set; }

        public PriceProductEvent(int processId, double price)
        {
            this.ProcessId = processId;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Price: {this.Price}";
        }
    }
}
