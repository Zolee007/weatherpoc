using Acr.UserDialogs;
using AutoMapper;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Weather.Mappers;
using Weather.Factories;
using Weather.ViewModels;

namespace Weather
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<WeatherMapper>());
            Mvx.IoCProvider.RegisterSingleton(Mapper.Instance);

            Mvx.IoCProvider.RegisterSingleton<IPolicyFactory>(Mvx.IoCProvider.IoCConstruct<PolicyFactory>());
            Mvx.IoCProvider.RegisterSingleton<IConnectivity>(() => CrossConnectivity.Current);
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.IoCProvider.RegisterSingleton<IGeolocator>(() => CrossGeolocator.Current);
            Mvx.IoCProvider.RegisterSingleton<IWeatherServiceFactory>(() => Mvx.IoCProvider.IoCConstruct<WeatherServiceFactory>());

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}