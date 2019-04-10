using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class Snow
    {
        [JsonProperty("1h")]
        public double LastHour { get; set; }

        [JsonProperty("3h")]
        public double Last3Hour { get; set; }
    }
}
