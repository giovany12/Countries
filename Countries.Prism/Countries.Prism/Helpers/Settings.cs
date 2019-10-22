using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Countries.Prism.Helpers
{
    public static class Settings
    {
        private const string _country = "Country";
        private const string _countries = "Countries";
        private static readonly string _settingsDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Country
        {
            get => AppSettings.GetValueOrDefault(_country, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_country, value);
        }

        public static string Countries
        {
            get => AppSettings.GetValueOrDefault(_countries, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_countries, value);
        }
    }
}
