using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coord")]
        public Coordinate Coordinate { get; set; }
    }
}
