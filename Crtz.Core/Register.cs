using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Core
{
    public class Register
    {
        private ProductsCatalog catalog;
        private Sale sale;

        public Register(ProductsCatalog catalog)
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
            Product product = catalog.GetProduct(productId);
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
