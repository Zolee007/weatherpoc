using System.Collections.Generic;
using Newtonsoft.Json;
using Weather.Services.OpenWeather.DTOs;

namespace Weather.Services.OpenWeather.Responses
{
    public class WeatherForecastResponse
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cnt")]
        public uint Count { get; set; }

        [JsonProperty("list")]
        public IEnumerable<WeatherResponse> Items { get; set; }
    }
}
