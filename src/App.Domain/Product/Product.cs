using App.Domain.Entities;
using System.Collections.Generic;

namespace App.Product
{
    public class Product : Entity
    {
        public string ProductCode { get; set; }
        public string ProductGroups { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; } = 0;

    }
}
