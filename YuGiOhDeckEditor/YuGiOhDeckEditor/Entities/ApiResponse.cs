using System.Text.Json.Serialization;

namespace YuGiOhDeckEditor.Entities
{
    public class ApiResponse
    {
        [JsonPropertyName("data")]
        public List<CardsInfo> Data { get; set; } = new List<CardsInfo>();
    }
}
