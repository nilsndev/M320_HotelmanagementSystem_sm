using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.OtherClasses;

namespace M320_HotelmanagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ViewRoomsController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string html = "";
            //if(DataSettings.ActiveUserID != 0){
                html = System.IO.File.ReadAllText("web/viewRooms.html");

           // }
           /* else
            {
                html = System.IO.File.ReadAllText("web/login.html");
            }*/
            
            return Content(html, "text/html");
        }
    }
}
