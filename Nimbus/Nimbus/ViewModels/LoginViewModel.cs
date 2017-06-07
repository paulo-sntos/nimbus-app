using Nimbus.Helpers;
using Nimbus.Services;
using Nimbus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nimbus.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private AzureService azureService;

        ICommand loginCommand;

        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        private bool IsBusy;

        public string Title { get; }

        public LoginViewModel()
        {
            try
            {
                azureService = DependencyService.Get<AzureService>();

                Title = "Social Login";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task ExecuteLoginCommandAsync()
        {
            try
            {
                if (IsBusy || !(await LoginASync()))
                    return;
                else
                {
                    await PopMainPageAsync();
                }
                IsBusy = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///     Verifica se o usuário está logado
        /// </summary>
        /// <returns></returns>
        public Task<bool> LoginASync()
        {
            IsBusy = true;
            if (Settings.IsLogged)
            {
                return Task.FromResult(true);
            }

            return azureService.LoginAsync();
        }
    }
}
