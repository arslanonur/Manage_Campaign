using App.Product;
using App.Product.Dto;
using App.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : AppApiControllerBase, IProductAppService
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public List<ProductListDto> GetAll()
        {
            return _productAppService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ProductListDto GetForView(int id)
        {
            return _productAppService.GetForView(id);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _productAppService.Delete(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _productAppService.DeleteAll();
        }

        [HttpPost]
        public void CreateOrEdit(ProductEditDto editDto)
        {
            _productAppService.CreateOrEdit(editDto);
        }
    }
}
