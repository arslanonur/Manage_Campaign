using App.Basket;
using App.Basket.Dto;
using App.Campaign;
using App.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : AppApiControllerBase, IBasketAppService
    {
        private readonly IBasketAppService _basketAppService;

        public BasketController(IBasketAppService basketAppService)
        {
            _basketAppService = basketAppService;
        }

        [HttpPost]
        public void CreateOrEdit(BasketEditDto editDto)
        {
            _basketAppService.CreateOrEdit(editDto);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _basketAppService.Delete(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _basketAppService.DeleteAll();
        }

        [HttpGet]
        public List<BasketListDto> GetAll()
        {
            return _basketAppService.GetAll();
        }

        [HttpGet("{id:int}")]
        public BasketListDto GetForView(int id)
        {
            return _basketAppService.GetForView(id);
        }
    }
}
