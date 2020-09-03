using Crtz.Common;
using Crtz.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class Register
    {
        private IProductsCatalog catalog;
        private Sale sale;

        public Register(IProductsCatalog catalog)
        {
            this.catalog = catalog;
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

        public void SetItem(int productId, int quantity)
        {
            IProduct product = catalog.GetProduct(productId);
            sale.CreateSaleItem(product, quantity);

            Console.WriteLine($"New SaleItem: '{product}' created");
        }

        public void DoPayment(double providedQuantity)
        {
            sale.DoPayment(providedQuantity);

            Console.WriteLine("Payment created");
        }
    }
}
