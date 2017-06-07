using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using Gcm.Client;

namespace Nimbus.Droid
{
    [Activity(Label = "Nimbus", Icon = "@drawable/cloud", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static MainActivity instance = null;

        public static MainActivity CurrentActivity
        {
            get
            {
                return instance;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            LoadApplication(new App());

            try
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                System.Diagnostics.Debug.WriteLine("Registering...");
                if (!string.IsNullOrWhiteSpace(Helpers.Settings.AuthToken) && !string.IsNullOrWhiteSpace(Helpers.Settings.UserId))
                {
                    GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
                }
            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog("There was an error creating the client. Verify the URL", "Erro");
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e.Message, "Error");
            }

        }

        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

