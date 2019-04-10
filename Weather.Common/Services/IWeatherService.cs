using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Services.OpenWeather
{
    public interface IWeatherService
    {
        Task<Models.Weather> GetWeatherByLocationAsync(DTOs.Coordinate coordinate);

        Task<Models.Weather> GetWeatherByCityNameAsync(string name);

        Task<Forecast> GetForecastByLocationAsync(DTOs.Coordinate coordinate);

        Task<Forecast> GetForecastByCityNameAsync(string name);
    }
}