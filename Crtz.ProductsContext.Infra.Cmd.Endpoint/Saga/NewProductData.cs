using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductsContext.App.Cmd.EPoint.Saga
{
    public class NewProductSagaData : ContainSagaData
    {
        public int ProcessId { get; set; }

        public string Name { get; set; }
        public bool HasName { get { return !string.IsNullOrEmpty(this.Name); } }

        public string Description { get; set; }
        public bool HasDescription { get { return !string.IsNullOrEmpty(this.Description); } }

        public double? Price { get; set; }
        public bool HasPrice { get { return Price != null; } }

        public override string ToString()
        {
            return @$"{nameof(NewProductSagaData.Name)}:{this.Name}
                      {nameof(NewProductSagaData.HasName)}:{ this.HasName}
                      {nameof(NewProductSagaData.Description)}:{ this.Description}
                      {nameof(NewProductSagaData.HasDescription)}:{ this.HasDescription}
                      {nameof(NewProductSagaData.Price)}:{ this.Price}
                      {nameof(NewProductSagaData.HasPrice)}:{ this.HasPrice}
                    ".Trim();
        }
    }
}
