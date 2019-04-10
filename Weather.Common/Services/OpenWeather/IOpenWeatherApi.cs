using System.Threading.Tasks;
using Refit;
using Weather.Services.OpenWeather.Requests;
using Weather.Services.OpenWeather.Responses;

namespace Weather.Services.OpenWeather
{
    public interface IOpenWeatherApi
    {
        [Get("/weather")]
        Task<WeatherResponse> GetWeatherByCoordinateAsync(LocationQueryParams query);

        [Get("/weather")]
        Task<WeatherResponse> GetWeatherByCityIdAsync(CityIdQueryParams query);

        [Get("/weather")]
        Task<WeatherResponse> GetWeatherByCityNameAsync(CityNameQueryParams query);

        [Get("/forecast")]
        Task<WeatherForecastResponse> GetForecastByLocationAsync(LocationQueryParams query);

        [Get("/forecast")]
        Task<WeatherForecastResponse> GetForecastByCityIdAsync(CityIdQueryParams query);

        [Get("/forecast")]
        Task<WeatherForecastResponse> GetForecastByCityNameAsync(CityNameQueryParams query);
    }
}
