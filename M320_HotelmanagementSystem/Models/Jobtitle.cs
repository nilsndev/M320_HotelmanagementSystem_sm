using System.Text.Json.Serialization;

namespace M320_HotelmanagementSystem.Models
{
    public class Jobtitle{
        [JsonPropertyName("job_nam")]
        string JobName { get; set; }
        [JsonPropertyName("job_desc")]
        string Jobdescribtion { get; set; }
    }
}
