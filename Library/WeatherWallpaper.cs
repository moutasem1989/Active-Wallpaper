using System;
using System.Threading.Tasks;
using WeatherNet;
using WeatherNet.Clients;
using WeatherNet.Model;
using Windows.Storage;
using Windows.System.UserProfile;

namespace Library
{
    public class WeatherWallpaper
    {
        public static SingleResult<CurrentWeatherResult> result;

        public static async Task GetCurrentWeather()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            ClientSettings.ApiUrl = "http://api.openweathermap.org/data/2.5";
            ClientSettings.ApiKey = "35db326245973bc87974d9158d6aa3cb";
            string lat = (string)settings.Values["Latitude"];
            double latitude = Double.Parse(lat);
            string lon = (string)settings.Values["Longitude"];
            double longitude = Double.Parse(lon);
            result = await CurrentWeather.GetByCoordinatesAsync(latitude, longitude);
            var imageID = result.Item.Icon.ToString();
            if ((string)settings.Values["Weather"] != null && (string)settings.Values["Weather"] != "")
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("dw2b8071");
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Weather"]);
                await GetWallpaperStorageFile(themeFolder, $"{imageID}");
            }
        }


        public static async Task GetWallpaperStorageFile(StorageFolder folder, string name)
        {
            var query = folder.CreateFileQuery();
            var files = await query.GetFilesAsync();
            foreach (StorageFile file in files)
            {
                var fileName = file.Name.ToString();
                if (fileName.Contains(name))
                {
                    await ApplyImagetoWallpaperAsync(file);
                }
            }
        }

        public static async Task ApplyImagetoWallpaperAsync(StorageFile file)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseWeatherForDesktop"] == "true")
            {
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    await profileSettings.TrySetWallpaperImageAsync(file);
                }
            }
            if ((string)settings.Values["UseWeatherForLockscreen"] == "true")
            {
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    await profileSettings.TrySetLockScreenImageAsync(file);
                }
            }
        }
    }
}
