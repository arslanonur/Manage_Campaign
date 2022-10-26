using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.EntityFrameworkCore.Mapping.Basket
{
    public class BasketMap : AppEntityTypeConfiguration<App.Basket.Basket>
    {
        public override void Configure(EntityTypeBuilder<App.Basket.Basket> builder)
        {
            builder.ToTable(nameof(App.Basket.Basket));
            builder.HasKey(product => product.Id);

            base.Configure(builder);
        }
    }
}
