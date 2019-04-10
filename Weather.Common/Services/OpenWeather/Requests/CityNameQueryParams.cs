using Refit;
using Weather.Services.OpenWeather.DTOs;

namespace Weather.Services.OpenWeather.Requests
{
    public class CityNameQueryParams
    {
        [AliasAs("appid")]
        public string AppId { get; set; }

        [AliasAs("q")]
        public string Name { get; set; }

        [AliasAs("lang")]
        public string Lang { get; set; }

        [AliasAs("units")]
        public Units? Units { get; set; }
    }
}
