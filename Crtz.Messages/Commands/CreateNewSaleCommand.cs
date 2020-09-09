using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Messages.Commands
{
    public class CreateNewSaleCommand : ICommand
    {
        public DateTime Date { get; private set; }
        

        //public CreateNewSaleCommand(int productId, int quantity)
        //{
        //    this.Name = name;
        //    this.Description = description;
        //    this.Price = price;
        //}

        //public override string ToString()
        //{
        //    return $"Name: {this.Name}; Description: {this.Description}; Price: {this.Price}";
        //}
    }
}
