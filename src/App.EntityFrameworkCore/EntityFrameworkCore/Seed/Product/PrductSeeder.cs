using App.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.EntityFrameworkCore.Seed.Product
{
    public class PrductSeeder
    {
        private readonly AppDbContext _context;

        public PrductSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var productTable = _context.Set<App.Product.Product>();

           var productList =  new List<App.Product.Product>()
            {
                new App.Product.Product()
                {
                    ProductCode = "HALI-001",
                    ProductGroups =  "ev-dekorasyon,halilarda-kampanya",
                    Brand = "MERİNOS",
                    ProductName = "Merinos 001 Halı",
                    CategoryId = 1,
                    CategoryName = "ev-dekorasyon",
                    Price = 100,
                    Quatity = 1
                },

                new App.Product.Product()
                {
                    ProductCode = "SHP-001",
                    ProductGroups =  "ev-dekorasyon,250TL-Uzeri-Ev-Dekorasyon-25TL-Indirim,Sehpa",
                    Brand = "IKEA",
                    ProductName = "Ikea 001 Sehpa",
                    CategoryId = 1,
                    CategoryName = "ev-dekorasyon",
                    Price = 150,
                    Quatity = 1
                },

                new App.Product.Product()
                {
                    ProductCode = "APL-001",
                    ProductGroups =  "cep-telefonu,iphone",
                    Brand = "APPLE",
                    ProductName = "Iphone 12 64GB",
                    CategoryId = 1,
                    CategoryName = "cep-telefonu",
                    Price = 10000,
                    Quatity = 2
                }
            };

            productTable.AddRange(productList);

            _context.SaveChanges();
        }
    }
}
