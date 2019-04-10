using System;
using System.Linq;
using Plugin.Geolocator.Abstractions;
using Weather.Mappers.Resolvers;
using Weather.Services.OpenWeather.DTOs;
using Weather.Services.OpenWeather.Requests;

namespace Weather.Mappers
{
    public class WeatherMapper : AutoMapper.Profile
    {
        public WeatherMapper()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.CreateMap<Services.OpenWeather.Responses.WeatherResponse, Models.Weather>()
                .ForMember(d => d.Description, o => o.MapFrom(s => s.WeatherInfos.FirstOrDefault().Main))
                .ForMember(d => d.Icon, o => o.MapFrom<OpenWeatherIconResolver>())
                .ForMember(d => d.Location, o => o.MapFrom(s => s.CityName))
                .ForMember(d => d.TemperatureMin, o => o.MapFrom(s => s.WeatherData.MinTemperature))
                .ForMember(d => d.Temperature, o => o.MapFrom(s => s.WeatherData.Temperature))
                .ForMember(d => d.TemperatureMax, o => o.MapFrom(s => s.WeatherData.MaxTemperature))
                .ForMember(d => d.Date, o => o.MapFrom(s => epoch.AddSeconds(s.DateTimestamp).ToLocalTime().ToString("g")));

            this.CreateMap<Services.OpenWeather.Responses.WeatherForecastResponse, Models.Forecast>()
                .ForMember(d => d.Days, o => o.MapFrom(s => s.Items));

            this.CreateMap<Position, Coordinate>();

            this.CreateMap<Coordinate, LocationQueryParams>()
                .ForMember(d => d.Lat, o => o.MapFrom(s => s.Latitude))
                .ForMember(d => d.Lon, o => o.MapFrom(s => s.Longitude))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
