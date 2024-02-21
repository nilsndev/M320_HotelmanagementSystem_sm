using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.Models;
using M320_HotelmanagementSystem.OtherClasses;  



namespace M320_HotelmanagementSystem.Controllers{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase{
        [HttpPost]
        public IActionResult Post(User user){
            try{
                string query = "Insert into user (userName, password) values ('" + user.userName + "', '" + user.passwort + "')";
                connection_class connection = new connection_class();
                int rowsAffected = connection.executeQuery(query);
                if(rowsAffected > 0){
                    return Ok("wurde gemacht");
                }
                else{
                    return BadRequest("Fehler beim Registrieren");
                }
            }
            catch{}
            return BadRequest("Fehler beim Registrieren");
        }
        [HttpGet]
        public IActionResult Get(string userName, string password){
            try{
                string query = "Select * From user Where userName = '" + userName + "' and password = '" + password + "' ";
                connection_class connection = new connection_class();
                bool conec = connection.executeSELECTQuery(query);
                if (conec == true){
                    DataSettings.ActiveUserName = userName;
                    return Ok("geht");
                }
                else{
                    return BadRequest("Falscher username oder passwort");
                }
            }
            catch { }
            return BadRequest("Fehler beim Registrieren");
        }
    }
}