using Nimbus.Helpers;
using Nimbus.Services;
using Xamarin.Forms;

namespace Nimbus.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _usuarioConectado;
        public string UsuarioConectado
        {
            get { return _usuarioConectado; }
            set { SetProperty(ref _usuarioConectado, value); }
        }
        private string _imagemUsuario;
        public string ImagemUsuario
        {
            get { return _imagemUsuario; }
            set { SetProperty(ref _imagemUsuario, value); }
        }
        private string _versaoApp;
        public string VersaoApp
        {
            get { return _versaoApp; }
            set { SetProperty(ref _versaoApp, value); }
        }
        private bool _isUsuarioConectado;
        public bool IsUsuarioConectado
        {
            get { return _isUsuarioConectado; }
            set { SetProperty(ref _isUsuarioConectado, value); }
        }



        public SettingsViewModel()
        {
            IsUsuarioConectado = Settings.IsLogged;

            LogoffCommand = new Command(ExecuteLogoffCommand);
            UsuarioConectado = IsUsuarioConectado ? Settings.UserName: string.Empty;
            ImagemUsuario = IsUsuarioConectado ? Settings.Picture: string.Empty;
            VersaoApp = "1.0.0";
        }

        public Command LogoffCommand;

        async void ExecuteLogoffCommand()
        {
            AzureService.LogoffAsync();

            await PopMainPageAsync();
        }
    }
}