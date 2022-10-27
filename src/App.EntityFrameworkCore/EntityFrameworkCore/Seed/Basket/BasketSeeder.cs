using System;
using System.Collections.Generic;
using System.Text;

namespace App.EntityFrameworkCore.Seed.Basket
{
    public  class BasketSeeder
    {
        private readonly AppDbContext _context;

        public BasketSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var basketTable = _context.Set<App.Basket.Basket>();

            var basketList = new List<App.Basket.Basket>()
            {
                new App.Basket.Basket()
                {
                    ProductCode = "HALI-001",
                    OrderCode = "ORD-001"
                },
                new App.Basket.Basket()
                {
                    ProductCode = "APL-001",
                    OrderCode = "ORD-001"
                },
                new App.Basket.Basket()
                {
                    ProductCode = "SHP-001",
                    OrderCode = "ORD-001"
                }

            };

            basketTable.AddRange(basketList);

            _context.SaveChanges();
        }
    }

}
