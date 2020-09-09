using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class SaleItemsConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            //builder.ToTable("TB_SALE_ITEMS");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantity);
            builder.Property(p => p.Product);            
        }
    }
}
