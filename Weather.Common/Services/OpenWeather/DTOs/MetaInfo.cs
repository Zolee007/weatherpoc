using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class MetaInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public ulong Sunrise { get; set; }

        [JsonProperty("sunset")]
        public ulong Sunset { get; set; }
    }
}
