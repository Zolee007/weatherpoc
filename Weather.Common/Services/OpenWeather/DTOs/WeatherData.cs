using Newtonsoft.Json;

namespace Weather.Services.OpenWeather.DTOs
{
    public class WeatherData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public double HumidityPercentage { get; set; }

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }

        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public double GroundLevel { get; set; }
    }
}
