using App.Application.Services.Dto;
using App.Campaign.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Campaign.Dto
{
    public class CampaignListDto : EntityDto
    {
        public EnumCampaignLevel CampaignLevel { get; set; }
        public string CampaignName { get; set; }
        public int DiscountPrice { get; set; }
        public double MinPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public int QuantityPerBasket { get; set; }
        public string CampaignLevelName { get; set; }
    }
}
