using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M320_HotelmanagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            string html = System.IO.File.ReadAllText("web/login.html");
            return Content(html, "text/html");
        }

       
    }
}
