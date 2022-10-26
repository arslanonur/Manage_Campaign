using App.Campaign.Dto;
using App.Campaign;
using App.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using App.Product.Dto;

namespace App.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CampaignController : AppApiControllerBase, ICampaignAppService
    {
        private readonly ICampaignAppService _campaignAppService;

        public CampaignController(ICampaignAppService campaignAppService)
        {
            _campaignAppService = campaignAppService;
        }

        [HttpPost]
        public CampaignListDto CalcCampaign(ProductListDto product)
        {
            return _campaignAppService.CalcCampaign(product);
        }

        [HttpPost]
        public void CreateOrEdit(CampaignEditDto editDto)
        {
            _campaignAppService.CreateOrEdit(editDto);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _campaignAppService.Delete(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _campaignAppService.DeleteAll();
        }

        [HttpGet]
        public List<CampaignListDto> GetAll()
        {
            return _campaignAppService.GetAll();
        }

        [HttpGet("{id:int}")]
        public CampaignListDto GetForView(int id)
        {
            return _campaignAppService.GetForView(id);
        }

        [HttpPost]
        public void SetPassive(int campaignId)
        {
            _campaignAppService.SetPassive(campaignId);
        }
    }
}
