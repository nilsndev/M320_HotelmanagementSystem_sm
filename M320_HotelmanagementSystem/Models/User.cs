using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models{
    public class User{
        [JsonPropertyName("User_Id")]
        public int Id { get; set; }
        [JsonPropertyName("User_Name")]
        public string userName { get; set; }
        [JsonPropertyName("Passwort")]
        public string passwort { get; set; }
    }
}
