using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.Models;
using M320_HotelmanagementSystem.OtherClasses;  



namespace M320_HotelmanagementSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(User user)
        {
            string query = "Insert into user (userName, password) values ('" + user.userName + "', '" + user.passwort + "')";
       
            connection_class connection = new connection_class();
            connection.executeQuery(query);
            return Ok("wurde gemacht");
        }

        [HttpGet]
        public IActionResult Get(string userName, string password)
        {
            string query = "Select * From user Where userName = '"+userName+"' and password = '"+password+"' ";

            connection_class connection = new connection_class();
            connection.executeSELECTQuery(query);
           DataSettings.ActiveUserName = userName;
            
            Console.WriteLine("wurde ausgefürt");
            
            return Ok("geht");
        }



    }
}