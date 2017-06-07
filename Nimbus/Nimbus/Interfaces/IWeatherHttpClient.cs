using System;
using System.Threading.Tasks;
using OpenWeatherMapDomain;
using System.Net.Http;
using Nimbus.Models;

namespace Nimbus.Interfaces
{
    public interface IWeatherHttpClient
    {
        void SetBaseAddress(Uri uri);
        void SetApiPath(string path);
        void SetApiKey(string key);
        void SetHttpMessageHandler(HttpMessageHandler messageHandler);
        Task<Response> GetWeather(Request request);

    }
}
