using ModernHttpClient;
using Nimbus.Helpers;
using Nimbus.Interfaces;
using Nimbus.Resources;
using Nimbus.Services;
using Plugin.Geolocator.Abstractions;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Nimbus.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            IsCarregando = true;
            IsDadosCarregados = false;
            HttpClient = new WeatherHttpClient();
            Geolocation = new GeolocationService();
            WeatherService = new OpenWeatherService();
            LoginCommand = new Command(ExecuteLoginCommand);
            SettingsCommand = new Command(ExecuteSettingsCommand);
            IsConectado = Settings.IsLogged;
            UsuarioConectado = IsConectado ? $"Conectado como: {Settings.UserName}" : "Desconectado ";

            SetForecastHttpClient();

            GetForecastBasedOnLocation();
        }

        #region Propriedades

        ///Campos em tela
        private string _cidadePais;
        public string CidadePais
        {
            get { return _cidadePais; }
            set
            {
                SetProperty(ref _cidadePais, value);
            }
        }
        private Uri _linkImagem;
        public Uri LinkImagem
        {
            get { return _linkImagem; }
            set
            {
                SetProperty(ref _linkImagem, value);
            }
        }
        private string _temperaturaMinima;
        public string TemperaturaMinima
        {
            get { return _temperaturaMinima; }
            set
            {
                SetProperty(ref _temperaturaMinima, value);
            }
        }
        private string _temperaturaMaxima;
        public string TemperaturaMaxima
        {
            get { return _temperaturaMaxima; }
            set
            {
                SetProperty(ref _temperaturaMaxima, value);
            }
        }
        private string _umidade;
        public string Umidade
        {
            get { return _umidade; }
            set { SetProperty(ref _umidade, value); }
        }
        private string _clima;
        public string Clima
        {
            get { return _clima; }
            set { SetProperty(ref _clima, value); }
        }
        private string _labelLocalizacao;
        public string LabelLocalizacao
        {
            get { return _labelLocalizacao; }
            set { SetProperty(ref _labelLocalizacao, value); }
        }
        private string _horaAtualizacao;
        public string HoraAtualizacao
        {
            get { return _horaAtualizacao; }
            set { SetProperty(ref _horaAtualizacao, value); }
        }
        private string _usuarioConectado;
        public string UsuarioConectado
        {
            get { return _usuarioConectado; }
            set { SetProperty(ref _usuarioConectado, value); }
        }

        /// Indicadores de Carregamento
        private bool _isCarregando;
        public bool IsCarregando
        {
            get { return _isCarregando; }
            set { SetProperty(ref _isCarregando, value); }
        }
        private bool _isDadosCarregados;
        public bool IsDadosCarregados
        {
            get { return _isDadosCarregados; }
            set { SetProperty(ref _isDadosCarregados, value); }
        }
        private bool _isConectado;
        public bool IsConectado
        {
            get { return _isConectado; }
            set { SetProperty(ref _isConectado, value); }
        }

        /// Interfaces
        private IWeatherHttpClient HttpClient;
        private IGeolocationService Geolocation;
        private IOpenWeatherService WeatherService;

        /// Outros
        private Position Position;

        /// Commands
        public Command LoginCommand { get; }
        public Command SettingsCommand { get; }

        #endregion

        #region Comandos
        /// <summary>
        ///     Realiza a chamada da tela de Login
        /// </summary>
        /// <param name="obj"></param>
        async void ExecuteLoginCommand(object obj)
        {
            await PushAsync<LoginViewModel>();
        }

        /// <summary>
        ///     Realiza a chamada da tela de Configurações
        /// </summary>
        async void ExecuteSettingsCommand()
        {
            await PushAsync<SettingsViewModel>();
        }

        #endregion

        #region Métodos

        /// <summary>
        ///     Recupera a Previsão do Tempo.
        /// </summary>
        private async void GetForecastBasedOnLocation()
        {
            bool localizadoComSucesso = false;

            do
            {
                Position = new Position();
                Position = await Geolocation.GetLocationAsync();

                if (Position != null && (Position.Latitude != 0 && Position.Longitude != 0))
                {
                    localizadoComSucesso = true;
                }

            } while (!localizadoComSucesso);

            var latitude = (float)Position.Latitude;
            var longitude = (float)Position.Longitude;

            var previsao = await WeatherService.GetWeather(HttpClient, latitude, longitude);

            if (previsao == null)
            {
                await Application.Current.MainPage.DisplayAlert("Nimbus", "Não foi possível baixar as informações de clima para seu local. Por Favor, tente novamente!", "OK");
                return;
            }

            IsCarregando = false;
            IsDadosCarregados = true;

            HoraAtualizacao = string.Format("{0:HH:mm}", DateTime.Now);
            CidadePais = $"{previsao.OpenWeather.City.Name} - {previsao.OpenWeather.City.Country}";
            LabelLocalizacao = $"(Lat: {latitude.ToString()}, Lon: {longitude.ToString()})";
            foreach (var item in previsao.OpenWeather.List)
            {
                TemperaturaMaxima = item.Temperature.Maximum.ToString("N0");
                TemperaturaMinima = item.Temperature.Minimum.ToString("N0");
                Umidade = item.Humidity.ToString();

                foreach (var item2 in item.Weather)
                {
                    var descricaoClima = item2.Description;
                    Clima = descricaoClima.Substring(0, 1).ToUpper() + descricaoClima.Substring(1, descricaoClima.Length - 1);
                    LinkImagem = new Uri(string.Format(Config.IconWeatherUriString, item2.Icon));
                }
            }


        }

        /// <summary>
        ///     Inicializa o WebService que será usado para recuperar a previsão.
        /// </summary>
        private void SetForecastHttpClient()
        {
            HttpClient.SetHttpMessageHandler(new NativeMessageHandler());
            HttpClient.SetBaseAddress(new Uri(Config.BaseAddress, UriKind.Absolute));
            HttpClient.SetApiPath(Config.ApiPath);
            HttpClient.SetApiKey(Config.ApiKey);

            IOpenWeatherService _weatherService = new OpenWeatherService();
            _weatherService.SetHttpClient(HttpClient);
        }

        #endregion
    }
}
