using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.Core
{
    public class Payment
    {
        public double Quantity { get; private set; }

        public Payment(double providedQuantity)
        {
            this.Quantity = this.Quantity - providedQuantity;
        }
    }
}
