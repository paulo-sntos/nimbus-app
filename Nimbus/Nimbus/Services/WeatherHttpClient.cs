using Newtonsoft.Json;
using Nimbus.Interfaces;
using Nimbus.Models;
using Nimbus.Resources;
using Nimbus.Utilities;
using OpenWeatherMapDomain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nimbus.Services
{
    public class WeatherHttpClient : IWeatherHttpClient
    {
        private HttpClient _client;
        private bool _messageHandlerSet;
        private Uri _baseAddress;
        private string _apiPath;
        private string _apiKey;

        private Response _response;

        public WeatherHttpClient()
        {
            _response = new Response();
        }

        public void SetHttpMessageHandler(HttpMessageHandler messageHandler)
        {
            _client = new HttpClient(messageHandler);
            _messageHandlerSet = true;
        }

        public void SetBaseAddress(Uri uri)
        {
            _baseAddress = uri;
        }

        public void SetApiPath(string path)
        {
            if (!_messageHandlerSet) throw new Exception(ErrorMessages.HttpMessageHandlerNotSetBeforeApiPath);
            _apiPath = path;
        }

        public void SetApiKey(string key)
        {
            if (!_messageHandlerSet) throw new Exception(ErrorMessages.HttpMessageHandlerNotSetBeforeApiKey);
            _apiKey = key;
        }

        public async Task<Response> GetWeather(Request request)
        {
            try
            {
                if (!_messageHandlerSet) throw new Exception(ErrorMessages.HttpMessageHandlerNotSet);

                if (_baseAddress == null) throw new Exception(ErrorMessages.BaseAddressNotSet);

                if (_apiPath == null) throw new Exception(ErrorMessages.ApiPathNotSet);

                if (_apiKey == null) throw new Exception(ErrorMessages.ApiKeyNotSet);

                _client.BaseAddress = _baseAddress;

                var httpResponse = await _client.GetAsync(string.Format(_apiPath, request.Latitude, request.Longitude, 1, _apiKey));

                _response.StatusCode = httpResponse.StatusCode;

                if (httpResponse.IsSuccessStatusCode)
                {
                    _response.OpenWeather = JsonConvert.DeserializeObject<OpenWeather>(await httpResponse.Content.ReadAsStringAsync(), new UnixDateTimeConverter());
                }
                else
                {
                    _response.Message = "Não foram encontrados dados!";
                }

                return _response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
