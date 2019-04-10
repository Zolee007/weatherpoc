using System.Collections.Generic;
using Newtonsoft.Json;
using Weather.Services.OpenWeather.DTOs;

namespace Weather.Services.OpenWeather.Responses
{
    public class WeatherResponse
    {
        [JsonProperty("dt")]
        public ulong DateTimestamp { get; set; }

        [JsonProperty("id")]
        public uint CityId { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("coord")]
        public Coordinate Coordinates { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("main")]
        public WeatherData WeatherData { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<WeatherInfo> WeatherInfos { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public MetaInfo MetaInfo { get; set; }
    }
}
