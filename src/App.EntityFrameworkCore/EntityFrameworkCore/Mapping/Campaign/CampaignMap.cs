using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.EntityFrameworkCore.Mapping.Campaign
{
    public class CampaignMap : AppEntityTypeConfiguration<App.Campaign.Campaign>
    {
        public override void Configure(EntityTypeBuilder<App.Campaign.Campaign> builder)
        {
            builder.ToTable(nameof(App.Campaign.Campaign));
            builder.HasKey(product => product.Id);

            base.Configure(builder);
        }
    }
}
