using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Plugin.Connectivity.Abstractions;
using Refit;
using Weather.Models;
using Weather.Models.Exceptions;
using Weather.Services.OpenWeather.Requests;
using Weather.Services.OpenWeather.Responses;
using Weather.Settings;
using Weather.Factories;

namespace Weather.Services.OpenWeather
{
    public class OpenWeatherService : IWeatherService
    {
        protected IPolicyFactory Factory { get; }
        protected IConnectivity Connectivity { get; }
        protected ISettings Settings { get; }
        protected IMapper Mapper { get; }
        protected IOpenWeatherApi Api { get; }

        public OpenWeatherService(
            IPolicyFactory factory,
            IConnectivity connectivity,
            ISettings settings,
            IMapper mapper)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            Connectivity = connectivity ?? throw new ArgumentNullException(nameof(connectivity));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Api = RestService.For<IOpenWeatherApi>(settings.OpenWeatherBaseUri);
        }

        // I could create a new Coordinate model as well, but the DTO will do just fine here for now
        public Task<Models.Weather> GetWeatherByLocationAsync(DTOs.Coordinate coordinate)
        {
            var queryParams = Mapper.Map(coordinate, InitLocationQuery());
            return Executor(
                cacheKey: $"WeatherByLocation_{coordinate.Latitude}_{coordinate.Longitude}",
                apiCaller: ctx => Api.GetWeatherByCoordinateAsync(queryParams),
                mapper: Mapper.Map<Models.Weather>);

            // Just for reference where does it come from
            /*
            if (this.Connectivity.IsConnected)
            {
                var response =
                    await Factory
                        .Get<Responses.WeatherResponse>()
                        .ExecuteAsync(
                            (ctx) => Api.GetWeatherByCoordinateAsync(queryParams),
                            new Polly.Context($"WeatherByLocation_{coordinate.Latitude}_{coordinate.Longitude}"));

                var result = Mapper.Map<Models.Weather>(response);
                return result;
            }

            throw new NoInternetException();*/
        }

        public Task<Forecast> GetForecastByLocationAsync(DTOs.Coordinate coordinate)
        {
            var queryParams = Mapper.Map(coordinate, InitLocationQuery());
            return Executor(
                cacheKey: $"ForecastByLocation_{coordinate.Latitude}_{coordinate.Longitude}",
                apiCaller: ctx => Api.GetForecastByLocationAsync(queryParams),
                mapper: MapAndFilterForecast);
        }

        public Task<Models.Weather> GetWeatherByCityNameAsync(string name)
        {
            var queryParams = InitCityNameQuery();
            queryParams.Name = name;

            return Executor(
                cacheKey: $"WeatherByCityName_{name}",
                apiCaller: ctx => Api.GetWeatherByCityNameAsync(queryParams),
                mapper: Mapper.Map<Models.Weather>);
        }

        public Task<Forecast> GetForecastByCityNameAsync(string name)
        {
            var queryParams = InitCityNameQuery();
            queryParams.Name = name;

            return Executor(
                cacheKey: $"ForecastByCityName_{name}",
                apiCaller: ctx => Api.GetForecastByCityNameAsync(queryParams),
                mapper: MapAndFilterForecast);
        }

        protected async Task<M> Executor<R, M>(
            string cacheKey,
            Func<Polly.Context, Task<R>> apiCaller,
            Func<R, M> mapper) where R : class
        {
            if (Connectivity.IsConnected)
            {
                var response =
                    await Factory
                        .Get<R>()
                        .ExecuteAsync(
                            apiCaller,
                            new Polly.Context(cacheKey));
                var result = mapper(response);
                return result;
            }

            throw new NoInternetException();
        }

        private LocationQueryParams InitLocationQuery()
        {
            return new LocationQueryParams()
            {
                AppId = Settings.OpenWeatherApiKey,
                Lang = Settings.OpenWeatherDefaultLanguage,
                Units = Settings.OpenWeatherDefaultUnit
            };
        }

        private CityNameQueryParams InitCityNameQuery()
        {
            return new CityNameQueryParams()
            {
                AppId = Settings.OpenWeatherApiKey,
                Lang = Settings.OpenWeatherDefaultLanguage,
                Units = Settings.OpenWeatherDefaultUnit
            };
        }

        private Models.Forecast MapAndFilterForecast(WeatherForecastResponse response)
        {
            var mapped = Mapper.Map<Models.Forecast>(response);
            // Have to filter, since the API gives back too much data (every 3 hours for the upcoming 5 days);
            mapped.Days = mapped.Days.GroupBy(d => d.Date.DayOfWeek).Select(g => g.First());
            return mapped;
        }
    }
}
