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

        public ProductListDto GetProductByLevelId(List<ProductListDto> productList, EnumCampaignLevel campaignLevel)
        {
            return null;
            
        }
    }
}
