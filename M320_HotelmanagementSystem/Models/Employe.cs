using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models{
    public class Employe{
        [JsonPropertyName("Emp_Id")]
        int Id { get; set; }

        [JsonPropertyName("Emp_UseId")]
        int user_id { get; set; }

        [JsonPropertyName("Emp_job")]
        string job { get; set; }

        [JsonPropertyName("Emp_Mail")]
        string Mail { get; set; }
    }
}
