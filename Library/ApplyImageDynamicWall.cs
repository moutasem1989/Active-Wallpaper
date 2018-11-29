using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System.UserProfile;

namespace Library
{
    public class ApplyImageDynamicWall
    {
        public static async Task GetImageUriAsync(int imageID)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
            StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
            if ((string)settings.Values["Theme"] != null)
            {
                if ((string)settings.Values["UseNightMode"] == "true")
                {
                    await GetWallpaperStorageFile(themeFolder, $"Night_{imageID}_Theme");
                }
                else
                {
                    await GetWallpaperStorageFile(themeFolder, $"{(string)settings.Values["DayOrNight"]}_{imageID}_Theme");
                }
            }
        }

        public static async Task GetWallpaperStorageFile (StorageFolder folder, string name)
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

        public static async Task ApplyImagetoWallpaperAsync (StorageFile file)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseItForDesktop"] == "true")
            {
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    await profileSettings.TrySetWallpaperImageAsync(file);
                }
            }
            if ((string)settings.Values["UseItForLockscreen"] == "true")
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
