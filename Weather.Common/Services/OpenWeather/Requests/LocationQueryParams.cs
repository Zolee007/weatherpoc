using Refit;
using Weather.Services.OpenWeather.DTOs;

namespace Weather.Services.OpenWeather.Requests
{
    public class LocationQueryParams
    {
        [AliasAs("appid")]
        public string AppId { get; set; }

        [AliasAs("lat")]
        public double Lat { get; set; }

        [AliasAs("lon")]
        public double Lon { get; set; }

        [AliasAs("lang")]
        public string Lang { get; set; }

        [AliasAs("units")]
        public Units? Units { get; set; }
    }
}
