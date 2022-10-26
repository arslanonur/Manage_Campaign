using App.Domain.Entities;
using App.Campaign.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Campaign
{
    public class Campaign : Entity
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
