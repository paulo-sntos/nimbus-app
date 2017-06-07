using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Nimbus.Helpers;
using Nimbus.Interfaces;
using Nimbus.Models;
using Nimbus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace Nimbus.Services
{
    public class AzureService
    {

        static readonly string AppUrl = "https://nimbusapplication.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;

        List<AppServiceIdentity> identities = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }


        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);


            if (user == null)
            {

                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
                });

                return false;
            }
            else
            {
                if (identities == null)
                {
                    identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
                }

                var name = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;

                var userToken = identities[0].AccessToken;

                var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture&access_token={userToken}";

                var httpClient = new HttpClient();

                var userJson = await httpClient.GetStringAsync(requestUrl);

                var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
                Settings.UserName = name;
                Settings.Picture = facebookProfile.Picture.Data.Url;


            }
            return true;
        }

        public async static void LogoffAsync()
        {
            Settings.UserId = string.Empty;
            Settings.AuthToken = string.Empty;
            Settings.UserName = string.Empty;
            Settings.Picture = string.Empty;

            await Application.Current.MainPage.DisplayAlert("Nimbus", "Usuário desconectado com sucesso!", "OK");
        }
    }
}
