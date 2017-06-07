using Nimbus.Interfaces;
using Nimbus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private IWeatherHttpClient _client;

        public async Task<Response> GetWeather(IWeatherHttpClient client, float latitude, float longitude)
        {
            
            try
            {
                SetHttpClient(client);

                if (_client == null) throw new Exception("IWeatherHttpClient is null in EasyWeather.Services.OpenWeatherService");

                return await _client.GetWeather(new Request { Latitude = latitude, Longitude = longitude });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetHttpClient(IWeatherHttpClient client)
        {
            _client = client;
        }
    }
}
