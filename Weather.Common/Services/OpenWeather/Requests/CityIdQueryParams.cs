using Refit;
using Weather.Services.OpenWeather.DTOs;

namespace Weather.Services.OpenWeather.Requests
{
    public class CityIdQueryParams
    {
        [AliasAs("appid")]
        public string AppId { get; set; }

        [AliasAs("id")]
        public int Id { get; set; }

        [AliasAs("lang")]
        public string Lang { get; set; }

        [AliasAs("units")]
        public Units? Units { get; set; }
    }
}
