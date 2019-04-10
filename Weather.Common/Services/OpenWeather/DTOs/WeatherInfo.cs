using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class WeatherInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public Icons Icon { get; set; }
    }
}
