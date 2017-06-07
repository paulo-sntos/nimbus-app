using Nimbus.Models;
using System.Threading.Tasks;

namespace Nimbus.Interfaces
{
    public interface IOpenWeatherService
    {
        void SetHttpClient(IWeatherHttpClient client);
        Task<Response> GetWeather(IWeatherHttpClient client, float latitude, float longitude);
    }
}
