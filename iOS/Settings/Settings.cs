using Foundation;
using Weather.Settings;

namespace Weather.iOS.Settings
{
    public class Settings : BaseSettings
    {
        public static class Keys
        {
            public const string OpenWeatherBaseUri = "OpenWeather.BaseUri";
            public const string OpenWeatherApiKey = "OpenWeather.ApiKey";
        }

        public override string OpenWeatherBaseUri =>
            NSBundle.MainBundle.ObjectForInfoDictionary(Keys.OpenWeatherBaseUri).ToString();

        public override string OpenWeatherApiKey =>
            NSBundle.MainBundle.ObjectForInfoDictionary(Keys.OpenWeatherApiKey).ToString();
    }
}
