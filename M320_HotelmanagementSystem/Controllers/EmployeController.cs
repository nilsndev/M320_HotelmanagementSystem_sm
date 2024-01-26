using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.OtherClasses;

namespace M320_HotelmanagementSystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            return Ok();
        }
    }
}
