using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models
{
    public class Room
    {
        [JsonPropertyName("Room_Id")]
        public int Id { get; set; }
        [JsonPropertyName("Room_Name")]
        public string roomName { get; set; }
        [JsonPropertyName("Room_aviable")]
        public bool is_aviable { get; set; }

        [JsonPropertyName("Room_price")]
        public double price_per_nigth { get; set; }

        [JsonPropertyName("Room_count")]
        public int person_count { get; set; }
    }
}
