using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Degrees { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}
