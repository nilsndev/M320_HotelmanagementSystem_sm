using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models
{
    public class User
    {
        [JsonPropertyName("User_Id")]
        string Id { get; set; }

        [JsonPropertyName("User_Name")]
        string userName { get; set; }

        [JsonPropertyName("Passwort")]

        string passwort { get; set; }
    }
}
