using System;
using System.Collections.Generic;
using System.Text;

namespace App.EntityFrameworkCore.Seed.Campaign
{
    public class CampaignSeeder
    {
        private readonly AppDbContext _context;

        public CampaignSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var campaignTable = _context.Set<App.Campaign.Campaign>();

            var campaignList = new List<App.Campaign.Campaign>()
            {
                new App.Campaign.Campaign()
                {
                    CampaignLevel = App.Campaign.Enum.EnumCampaignLevel.Category,
                    CampaignName = "250TL-Uzerine-Ev-Dekorasyon-Kategorisinde-25TL-Indirim",
                    CampaignLevelName = "ev-dekorasyon",
                    DiscountPrice = 25,
                    MinPrice = 250,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    isActive = true,
                    QuantityPerBasket = 1
                },

            };

            campaignTable.AddRange(campaignList);

            _context.SaveChanges();
        }
    }
}
