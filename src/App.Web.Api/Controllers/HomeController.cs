using App.Application.Services;
using App.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : AppApiControllerBase
    {
        [HttpGet]
        public string Get()
        {
            
            return "Api works!";
        }
    }
}
