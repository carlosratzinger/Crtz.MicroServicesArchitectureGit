using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class SaleRegister
    {
        private ISaleStorage storage;
        private Sale sale;

        public SaleRegister(ISaleStorage storage)
        {
            this.storage = storage;
        }

        public void BeginNewSale()
        {            
            sale = new Sale();
            Console.WriteLine("New Sale initiated");
        }

        public void FinishSale()
        {   
            sale.MarkAsComplete();
            Console.WriteLine("Sale finished");
        }

        public void SetItem(PurchasedProduct product, int quantity)
        {   
            sale.CreateSaleItem(product, quantity);
            Console.WriteLine($"New SaleItem: '{product}' created");
        }

        public void Save()
        {
            storage.Add(sale);
        }

        public List<Sale> GetAllSales()
        {
            return storage.GetAll();
        }

        public void DoPayment(double providedQuantity)
        {
            sale.DoPayment(providedQuantity);
            Console.WriteLine("Payment created");
        }
    }
}
