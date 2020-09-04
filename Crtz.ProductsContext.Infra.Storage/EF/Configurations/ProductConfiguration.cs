using Crtz.ProductsContext.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.ProductsContext.Infra.Storage.EF
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(nameof(Product.Id)).HasColumnName(nameof(Product.Id).ToUpper());
            builder.Property(nameof(Product.Name)).HasColumnName(nameof(Product.Name).ToUpper());
            builder.Property(nameof(Product.Description)).HasColumnName(nameof(Product.Description).ToUpper());
            builder.Property(nameof(Product.Price)).HasColumnName(nameof(Product.Price).ToUpper());
        }
    }
}
