using System;
using MvvmCross.IoC;
using Weather.Services;
using Weather.Services.OpenWeather;

namespace Weather.Factories
{
    public class WeatherServiceFactory : IWeatherServiceFactory
    {
        private readonly IMvxIoCProvider _mvxIoCProvider;

        public WeatherServiceFactory(IMvxIoCProvider mvxIoCProvider)
        {
            _mvxIoCProvider = mvxIoCProvider ?? throw new ArgumentNullException();
        }

        public IWeatherService Get(bool isMock)
        {
            var serviceType = isMock ? typeof(JsonMockWeatherService) : typeof(OpenWeatherService);
            return (IWeatherService)_mvxIoCProvider.IoCConstruct(serviceType);
        }
    }
}
