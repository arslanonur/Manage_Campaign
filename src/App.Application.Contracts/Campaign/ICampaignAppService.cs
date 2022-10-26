using App.Campaign.Dto;
using App.Mapper;
using App.Campaign.Dto;
using App.Campaign.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Campaign
{
    public interface ICampaignAppService
    {
        List<CampaignListDto> GetAll();

        CampaignListDto GetForView(int id);

        void Delete(int id);

        void DeleteAll();

        void CreateOrEdit(CampaignEditDto editDto);

        //ProductListDto GetProductByLevelId(List<ProductListDto> productList, EnumCampaignLevel campaignLevel);
    }
}

