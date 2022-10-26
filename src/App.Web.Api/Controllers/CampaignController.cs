using App.Campaign.Dto;
using App.Campaign;
using App.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    public class CampaignController : AppApiControllerBase, ICampaignAppService
    {
        private readonly ICampaignAppService _campaignAppService;

        public CampaignController(ICampaignAppService campaignAppService)
        {
            _campaignAppService = campaignAppService;
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

    }
}
