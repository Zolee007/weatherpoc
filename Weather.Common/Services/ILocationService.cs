using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;

namespace Weather.Services
{
    public interface ILocationService
    {
        Task<Position> GetCurrentLocation();
    }
}
