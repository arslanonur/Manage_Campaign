using System;
using System.Collections.Generic;
using System.Text;
using App.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.EntityFrameworkCore.Mapping.Product
{
    public class ProductMap : AppEntityTypeConfiguration<App.Product.Product>
    {
        public override void Configure(EntityTypeBuilder<App.Product.Product> builder)
        {
            builder.ToTable(nameof(App.Product.Product));
            builder.HasKey(product => product.Id);

            base.Configure(builder);
        }
    }
}
