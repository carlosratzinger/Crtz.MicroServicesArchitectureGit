using Crtz.BasicContext.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crtz.BasicContext.Infra.Storage.EFCore
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("TB_SALES");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date);
            //builder.Property(p => p.SaleItems);
        }
    }
}
