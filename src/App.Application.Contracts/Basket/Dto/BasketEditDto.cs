using App.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Basket.Dto
{
    public class BasketEditDto : EntityDto
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int DiscountPrice { get; set; }
        public int CampaignId { get; set; }
        public double DiscountedPrice { get; set; }
        public double TotalDiscountedPrice { get; set; }
        public string OrderCode { get; set; }

    }
}
