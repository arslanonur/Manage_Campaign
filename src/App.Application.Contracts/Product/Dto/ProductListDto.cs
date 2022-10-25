using App.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Product.Dto
{
    public class ProductListDto :  EntityDto
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
