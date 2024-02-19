using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.OtherClasses;
using M320_HotelmanagementSystem.Models;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace M320_HotelmanagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string query = "SELECT * from room";
            List<Room> rooms = new List<Room>();
            connection_class conn = new connection_class();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rooms.Add(new Room()
                {
                    Id = reader.GetInt32("ID"),
                    roomName = reader.GetString("roomName"),
                    is_aviable = reader.GetInt32("is_available") == 1,
                    price_per_nigth = reader.GetDouble("price_per_night"),
                    person_count = reader.GetInt32("personCount")
                });
            }
            return Ok(rooms);
        }
        [HttpPost]
        public IActionResult Post(Room addedRoom)
        {
            try
            {
                string query = $"INSERT INTO room(roomName, is_available, price_per_night, personCount) " +
                                $"VALUES('{addedRoom.roomName}', {addedRoom.is_aviable}, {addedRoom.price_per_nigth.ToString(CultureInfo.InvariantCulture)}, {addedRoom.person_count});";
                connection_class conn = new connection_class();
                int rowsAffected = conn.executeQuery(query);
                if (rowsAffected > 0)
                {
                    return Ok("Raum Hinzugefügt");
                }
            }
            catch { }
            return BadRequest("Fehler beim Hinzufügen");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                string query = $"DELETE FROM room WHERE ID = " + id;
                connection_class conn = new connection_class();
                int rowsAffected = conn.executeQuery(query);
                if (rowsAffected > 0)
                {
                    return Ok("Raum Deleted");
                }
            }
            catch { }
            return BadRequest("Es gab ein fehler");
        }
        [HttpPut]
        public IActionResult Put(Room room)
        {
            try
            {
                string query = $"UPDATE room " +
                                $"SET roomName = '{room.roomName}', " +
                                $"is_available = {room.is_aviable}, " +
                                $"price_per_night = {room.price_per_nigth.ToString(CultureInfo.InvariantCulture)}, " +
                                $"personCount = {room.person_count} " +
                                $"WHERE ID = {room.Id};";
                connection_class conn = new connection_class();
                int rowsEdited = conn.executeQuery(query);
                if (rowsEdited > 0)
                {
                    return Ok("Room Updated");
                }
            }
            catch { }
            return BadRequest("Es gab ein fehler");
        }
    }
}
