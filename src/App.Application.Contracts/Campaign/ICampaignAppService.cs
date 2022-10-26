using App.Campaign.Dto;
using App.Mapper;
using App.Campaign.Dto;
using App.Campaign.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using App.Product.Dto;

namespace App.Campaign
{
    public interface ICampaignAppService
    {
        List<CampaignListDto> GetAll();

        CampaignListDto GetForView(int id);

        void Delete(int id);

        void DeleteAll();

        void CreateOrEdit(CampaignEditDto editDto);

        CampaignListDto CalcCampaign(ProductListDto product);

        //Web socket ile EndDate e göre kontrol edilip passive yapılacak
        void SetPassive(int campaignId);
    }
}

