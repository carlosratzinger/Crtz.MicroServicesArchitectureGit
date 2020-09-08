using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

using Crtz.ProductContext.Core;
namespace Crtz.ProductsContext.Infra.Storage.EF
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.ToTable("TB_PRODUCTS");
            this.HasKey(p => p.Id);

            this.Property(p => p.Id).HasColumnName(nameof(Product.Id).ToUpper());
            this.Property(p => p.Name).HasColumnName(nameof(Product.Name).ToUpper());
            this.Property(p => p.Description).HasColumnName(nameof(Product.Description).ToUpper());
            this.Property(p => p.Price).HasColumnName(nameof(Product.Price).ToUpper());

        }
    }
}
