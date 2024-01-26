using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M320_HotelmanagementSystem.OtherClasses;
using M320_HotelmanagementSystem.Models;
using MySql.Data.MySqlClient;

namespace M320_HotelmanagementSystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase {
        [HttpGet]
        public IActionResult Get() {
            string query = "SELECT * from room";
            List<Room> rooms = new List<Room>();
            connection_class conn = new connection_class();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                int x = reader.GetInt32("is_available");
                rooms.Add(new Room() {
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
        public IActionResult Post(Room addedRoom) {
            string query = $"INSERT INTO room(roomName, is_available, price_per_night, personCount) " +
                            $"VALUES('{addedRoom.roomName}', {addedRoom.is_aviable}, {addedRoom.price_per_nigth}, {addedRoom.person_count});";
            connection_class conn = new connection_class();
            conn.executeQuery(query);
            return Ok("Raum Hinzugefügt");
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id){
            string query = $"DELETE FROM room WHERE ID = " + id;
            connection_class conn = new connection_class();
            conn.executeQuery(query);
            return Ok("Raum Deleted");
        }
        [HttpPut]
        public IActionResult Put(Room room){
            string query = $"UPDATE room " +
                           $"SET roomName = '{room.roomName}', " +
                           $"is_available = {room.is_aviable}, " +
                           $"price_per_night = {room.price_per_nigth}, " +
                           $"personCount = {room.person_count} " +
                           $"WHERE ID = {room.Id};";
            connection_class conn = new connection_class();
            conn.executeQuery(query);

            return Ok("Room Updated");
        }
    }
}
