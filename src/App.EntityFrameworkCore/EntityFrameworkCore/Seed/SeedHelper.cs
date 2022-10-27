using App.EntityFrameworkCore.Seed.Basket;
using App.EntityFrameworkCore.Seed.Campaign;
using App.EntityFrameworkCore.Seed.Product;
using App.Product.Dto;
using System.Collections.Generic;

namespace App.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void Seed(AppDbContext context)
        {
            new PrductSeeder(context).Create();
            new CampaignSeeder(context).Create();
            new BasketSeeder(context).Create();
        }
    }
}
