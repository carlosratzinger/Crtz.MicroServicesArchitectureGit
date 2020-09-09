using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Core
{
    public class Sale
    {
        private bool isCompleted;

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public List<SaleItem> SaleItems { get; private set; } = new List<SaleItem>();
        public Payment Payment { get; private set; }

        public Sale()
        {
            this.Date = DateTime.Now;
        }

        public void CreateSaleItem(PurchasedProduct product, int quantity)
        {
            this.SaleItems.Add(new SaleItem(product, quantity));
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (var saleItem in this.SaleItems)
            {
                total += saleItem.GetSubtotal();
            }

            return total;
        }

        public double GetBalance()
        {
            return Payment.Quantity - GetTotal();
        }

        public void MarkAsComplete()
        {
            this.isCompleted = true;
        }

        public bool IsComplete()
        {
            return this.isCompleted;
        }

        public void DoPayment(double providedQuantity)
        {
            this.Payment = new Payment(providedQuantity);
        }
    }
}
