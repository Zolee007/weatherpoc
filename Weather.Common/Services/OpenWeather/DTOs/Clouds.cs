using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int Percentage { get; set; }
    }
}
