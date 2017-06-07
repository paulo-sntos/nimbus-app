using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Nimbus.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value); }
        }

        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        const string UserNameKey = "username";
        static readonly string UserNameDefault = string.Empty;
        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
        }

        const string UserPictureKey = "userpicture";
        static readonly string UserPictureDefault = string.Empty;
        public static string Picture
        {
            get { return AppSettings.GetValueOrDefault<string>(UserPictureKey, UserPictureDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserPictureKey, value); }
        }

        public static bool IsLogged => !string.IsNullOrWhiteSpace(UserId);
    }
}