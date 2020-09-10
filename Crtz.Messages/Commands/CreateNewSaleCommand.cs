using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtz.Messages.Commands
{
    public class CreateNewSaleCommand : ICommand
    {
        public DateTime Date { get; private set; }        
        public Dictionary<int, (double, int)> SaleItems { get; private set; }

        public CreateNewSaleCommand()
        {
            this.Date = DateTime.Now;
            this.SaleItems = new Dictionary<int, (double, int)>();
        }

        public void AddSaleItem(int productId, double price, int quantity)
        {   
            SaleItems.Add(productId, (price, quantity));
        }

        public override string ToString()
        {
            return $"Name: {this.Date}; SaleItems: {string.Concat(SaleItems.Values.Select(p => p.ToString()))}";
        }
    }
}
