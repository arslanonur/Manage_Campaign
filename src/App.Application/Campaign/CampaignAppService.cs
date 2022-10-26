using App.Campaign.Dto;
using App.Domain.Repositories;
using App.Mapper;
using App.Campaign.Dto;
using App.Campaign.Enum;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Product.Dto;
using App.Product;

namespace App.Campaign
{
    public class CampaignAppService : ICampaignAppService
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignAppService(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public void CreateOrEdit(CampaignEditDto editDto)
        {
            if (editDto.Id <= 0)
            {
                var entity = editDto.ToEntity<Campaign>();
                _campaignRepository.Insert(entity);
            }
            else
            {
                var entity = _campaignRepository.Get(editDto.Id);

                editDto.ToEntity(entity);
                _campaignRepository.Update(entity);
            }
        }

        public void Delete(int id)
        {
            _campaignRepository.Delete(id);
        }

        public void DeleteAll()
        {
            var entities = _campaignRepository.GetAllList();
            foreach (var entity in entities)
            {
                _campaignRepository.Delete(entity);
            }
        }

        public List<CampaignListDto> GetAll()
        {
            var entities = _campaignRepository.GetAllList();

            return entities.Select(entity => entity.ToModel<CampaignListDto>()).ToList();
        }

        public CampaignListDto GetForView(int id)
        {
            var entity = _campaignRepository.Get(id);

            return entity.ToModel<CampaignListDto>();
        }

        public CampaignListDto CalcCampaign(ProductListDto product)
        {

            if (!string.IsNullOrEmpty(product.ProductCode))
            {
                var item = GetCampaignByLevelAndLevelName(EnumCampaignLevel.Product, product.ProductCode);

                if (item != null)
                {
                    return item;
                }
            }

            if (!string.IsNullOrEmpty(product.Brand))
            {
                var item = GetCampaignByLevelAndLevelName(EnumCampaignLevel.Brand, product.Brand);

                if (item != null)
                {
                    return item;
                }
            }
            if (!string.IsNullOrEmpty(product.CategoryName))
            {
                foreach (var categoryName in product.CategoryName.Split(','))
                {
                    var item = GetCampaignByLevelAndLevelName(EnumCampaignLevel.Category, categoryName);

                    if (item != null)
                    {
                        return item;
                    }
                }

            }
            if (!string.IsNullOrEmpty(product.ProductGroups))
            {
                foreach (var productGroup in product.ProductGroups.Split(','))
                {
                    var item = GetCampaignByLevelAndLevelName(EnumCampaignLevel.ProductGroup, productGroup);

                    if (item != null)
                    {
                        return item;
                    }
                }

            }

            return null;

        }

        private CampaignListDto GetCampaignByLevelAndLevelName(EnumCampaignLevel level, string levelName)
        {
            var item = GetAll().Where(x => x.CampaignLevel == level && x.CampaignLevelName.ToLower() == levelName.ToLower() && x.EndDate > DateTime.Now).FirstOrDefault();

            return item;
        }

        public void SetPassive(int campaignId)
        {
            var entity = _campaignRepository.Get(campaignId);
            entity.isActive = false;

            _campaignRepository.Update(entity);
        }
    }
}
