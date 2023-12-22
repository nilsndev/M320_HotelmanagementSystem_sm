using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M320_HotelmanagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string html = System.IO.File.ReadAllText("web/index.html");
            return Content(html, "text/html");
        }
    }
}
