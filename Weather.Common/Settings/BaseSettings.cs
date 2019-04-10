using Weather.Services.OpenWeather.DTOs;

namespace Weather.Settings
{
    public abstract class BaseSettings : ISettings
    {
        public abstract string OpenWeatherBaseUri { get; }

        public abstract string OpenWeatherApiKey { get; }

        public Units OpenWeatherDefaultUnit => Units.Metric;

        public string OpenWeatherDefaultLanguage => "en";
    }
}
