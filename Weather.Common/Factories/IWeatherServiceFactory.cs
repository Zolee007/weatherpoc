using Weather.Services.OpenWeather;

namespace Weather.Factories
{
    public interface IWeatherServiceFactory
    {
        IWeatherService Get(bool isMock);
    }
}
