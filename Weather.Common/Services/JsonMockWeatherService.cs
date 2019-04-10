using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Weather.Models;
using Weather.Services.OpenWeather;
using Weather.Services.OpenWeather.DTOs;
using Weather.Services.OpenWeather.Responses;

namespace Weather.Services
{
    public class JsonMockWeatherService : IWeatherService
    {
        private readonly IMapper _mapper;
        private readonly Assembly _assembly;

        public const string WeatherByLocationFileName = "Weather.Resources.weather_location.json";

        public const string ForecastByLocationFileName = "Weather.Resources.forecast_location.json";

        public const string WeatherByCityFileName = "Weather.Resources.weather_city.json";

        public const string ForecastByCityFileName = "Weather.Resources.forecast_city.json";

        public JsonMockWeatherService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _assembly = typeof(JsonMockWeatherService).GetTypeInfo().Assembly;
        }

        public Task<Models.Weather> GetWeatherByLocationAsync(Coordinate coordinate)
        {
            var result = GetFromFile<WeatherResponse, Models.Weather>(WeatherByLocationFileName);
            return Task.FromResult(result);
        }

        public Task<Forecast> GetForecastByLocationAsync(Coordinate coordinate)
        {
            var result = GetFromFile<WeatherForecastResponse, Forecast>(ForecastByLocationFileName);
            result.Days = result.Days.GroupBy(d => d.Date.DayOfWeek).Select(g => g.First());
            return Task.FromResult(result);
        }

        public Task<Models.Weather> GetWeatherByCityNameAsync(string name)
        {
            var result = GetFromFile<WeatherResponse, Models.Weather>(WeatherByCityFileName);
            return Task.FromResult(result);
        }

        public Task<Forecast> GetForecastByCityNameAsync(string name)
        {
            var result = GetFromFile<WeatherForecastResponse, Forecast>(ForecastByCityFileName);
            result.Days = result.Days.GroupBy(d => d.Date.DayOfWeek).Select(g => g.First());
            return Task.FromResult(result);
        }

        private T GetFromFile<R, T>(string name) where T : class
        {
            using (var stream = _assembly.GetManifestResourceStream(name))
            {
                using (var reader = new StreamReader(stream))
                {
                    var text = reader.ReadToEnd();
                    var rawData = JsonConvert.DeserializeObject<R>(text);
                    var mapped = _mapper.Map<T>(rawData);
                    return mapped;
                }
            }
        }
    }
}
