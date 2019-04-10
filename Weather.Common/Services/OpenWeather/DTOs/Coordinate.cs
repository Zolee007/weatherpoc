using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class Coordinate
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
