using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AutoMapper;
using MvvmCross.Commands;
using Plugin.Connectivity.Abstractions;
using Weather.Services;
using Weather.Services.OpenWeather;
using Weather.Services.OpenWeather.DTOs;
using Weather.Factories;
using Weather.Models.Exceptions;

namespace Weather.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Models.Weather _currentWeather;

        private Models.Forecast _forecast;

        public HomeViewModel(
            IWeatherServiceFactory weatherServiceFactory,
            ILocationService locationService,
            IConnectivity connectivity,
            IUserDialogs dialogs,
            IMapper mapper)
            : base(
                connectivity,
                dialogs,
                mapper)
        {
            WeatherServiceFactory = weatherServiceFactory ?? throw new ArgumentNullException(nameof(weatherServiceFactory));
            LocationService = locationService ?? throw new ArgumentNullException(nameof(locationService));

            this.LoadDataCommand = new MvxAsyncCommand(this.LoadDataByLocationAsync);
            this.LoadCityCommand = new MvxAsyncCommand(this.LoadDataByCityNameAsync);
        }

        protected IWeatherServiceFactory WeatherServiceFactory { get; }

        protected IWeatherService WeatherService => WeatherServiceFactory.Get(IsMock);

        protected ILocationService LocationService { get; }

        public IMvxAsyncCommand LoadDataCommand { get; set; }

        public IMvxAsyncCommand LoadCityCommand { get; set; }

        private bool _isMock;
        public bool IsMock
        {
            get
            {
                return _isMock;
            }
            set
            {
                this.SetProperty(ref _isMock, value);
                this.RaisePropertyChanged(() => this.PoweredBy);
            }
        }

        public string CityName => _currentWeather?.Location ?? "Unkown";

        public double CurrentTemperature => _currentWeather?.Temperature ?? 0;

        public double MinTemperature => _currentWeather?.Temperature ?? 0;

        public double MaxTemperature => _currentWeather?.Temperature ?? 0;

        public Models.Icons CurrentImage => _currentWeather?.Icon ?? Models.Icons.Other;

        public string Text => _currentWeather?.Description ?? "-";

        public IEnumerable<Models.Weather> UpcomingWeathers => _forecast?.Days ?? Enumerable.Empty<Models.Weather>();

        public string PoweredBy => $"Powered by {(IsMock ? "JSON files" : "OpenWeatherAPI")}";

        private Task LoadDataByLocationAsync()
        {
            return ExecuteWithLoading(async () =>
            {
                DialogService.ShowLoading("Loading", MaskType.Gradient);

                Coordinate coordinate;
                if (!IsMock)
                {
                    try
                    {
                        var position = await LocationService.GetCurrentLocation();
                        coordinate = Mapper.Map<Coordinate>(position);
                    }
                    catch (NoLocationServiceException)
                    {
                        DialogService.Alert("Please check permissions", "Location not enabled");
                        return;
                    }
                }
                else
                {
                    coordinate = new Coordinate()
                    {
                        Latitude = 0,
                        Longitude = 0
                    };
                }

                await TryExecuteNetworkRequest(async () =>
                {
                    _currentWeather = await WeatherService.GetWeatherByLocationAsync(coordinate);
                    _forecast = await WeatherService.GetForecastByLocationAsync(coordinate);
                }, IsMock);
            });
        }

        private Task LoadDataByCityNameAsync()
        {
            return ExecuteWithLoading(async () =>
            {
                var result = await DialogService.PromptAsync("City name", "Please enter");
                if (result.Ok && !string.IsNullOrEmpty(result.Value))
                {
                    DialogService.ShowLoading("Loading", MaskType.Gradient);

                    await TryExecuteNetworkRequest(async () =>
                    {
                        _currentWeather = await WeatherService.GetWeatherByCityNameAsync(result.Value);
                        _forecast = await WeatherService.GetForecastByCityNameAsync(result.Value);
                    }, IsMock);
                }
            });
        }
    }
}