using App.Application.Services.Dto;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Basket.Dto
{
    public class BasketListDto : EntityDto
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
