using System.Linq;
using AutoMapper;
using Weather.Models;
using Weather.Services.OpenWeather.Responses;

namespace Weather.Mappers.Resolvers
{
    public class OpenWeatherIconResolver : IValueResolver<WeatherResponse, Models.Weather, Icons>
    {
        public Icons Resolve(WeatherResponse source, Models.Weather destination, Icons destMember, ResolutionContext context)
        {
            var sourceIcon = source.WeatherInfos.FirstOrDefault()?.Icon ?? Services.OpenWeather.DTOs.Icons.ClearSkyDay;

            switch (sourceIcon)
            {
                case Services.OpenWeather.DTOs.Icons.ClearSkyDay:
                case Services.OpenWeather.DTOs.Icons.ClearSkyNight:
                    return Icons.Sunny;
                case Services.OpenWeather.DTOs.Icons.BrokenCloudsDay:
                case Services.OpenWeather.DTOs.Icons.BrokenCloudsNight:
                case Services.OpenWeather.DTOs.Icons.FewCloudsDay:
                case Services.OpenWeather.DTOs.Icons.FewCloudsNight:
                case Services.OpenWeather.DTOs.Icons.ScatteredCloudsDay:
                case Services.OpenWeather.DTOs.Icons.ScatteredCloudsNight:
                    return Icons.Cloudy;
                case Services.OpenWeather.DTOs.Icons.RainDay:
                case Services.OpenWeather.DTOs.Icons.RainNight:
                case Services.OpenWeather.DTOs.Icons.ShowerRainDay:
                case Services.OpenWeather.DTOs.Icons.ShowerRainNight:
                case Services.OpenWeather.DTOs.Icons.ThunderStormDay:
                case Services.OpenWeather.DTOs.Icons.ThunderStormNight:
                    return Icons.Rainy;
                default:
                    return Icons.Other;
            }
        }
    }
}
