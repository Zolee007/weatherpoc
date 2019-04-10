using Weather.Services.OpenWeather.DTOs;

namespace Weather.Settings
{
    public interface ISettings
    {
        string OpenWeatherBaseUri { get; }

        string OpenWeatherApiKey { get; }

        Units OpenWeatherDefaultUnit { get; }

        string OpenWeatherDefaultLanguage { get; }
    }
}
