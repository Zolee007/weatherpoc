using System;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using Weather.Models.Exceptions;

namespace Weather.Services
{
    public class LocationService : ILocationService
    {
        protected IGeolocator Geolocator { get; }

        public LocationService(IGeolocator geoLocator)
        {
            Geolocator = geoLocator ?? throw new ArgumentNullException(nameof(geoLocator));
        }

        public async Task<Position> GetCurrentLocation()
        {
            try
            {
                Geolocator.DesiredAccuracy = 100;
                var position = await Geolocator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cached position, so let's use it.
                    return position;
                }

                if (!Geolocator.IsGeolocationAvailable || !Geolocator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    throw new NoLocationServiceException();
                }

                position = await Geolocator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

                return position;
            }
            catch
            {
                throw new NoLocationServiceException();
            }
        }
    }
}
