using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models
{
    public class Room
    {
        [JsonPropertyName("Room_Id")]
        string Id { get; set; }
        [JsonPropertyName("Room_Name")]
        string roomName { get; set; }
        [JsonPropertyName("Room_aviable")]
        bool is_aviable { get; set; }

        [JsonPropertyName("Room_price")]
        double price_per_nigth { get; set; }

        [JsonPropertyName("Room_count")]
        double person_count { get; set; }
    }
}
