using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System.UserProfile;

namespace Library
{
    public class ModernWallpaper
    {
        public static async Task ModernDayColor()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            int HowManyDayImages = 20;
            TimeSpan howLongDay = Library.SunRiseAndSetTimes.SunSetToday.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
            TimeSpan timerLingth = new TimeSpan(howLongDay.Ticks / HowManyDayImages);
            TimeSpan dayTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
            int imageNumber = (int)(dayTimeSpan.Ticks / timerLingth.Ticks) + 1;
            settings.Values["ColorIdNumber"] = Convert.ToString(Math.Ceiling(Convert.ToDouble(imageNumber)));
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                await ChangeWallpaperColors();
            }
            else if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                await ChangeWallpaperColors();
            }
        }
        public static async Task ModernBeforeMidnightColor()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            int HowManyNightImages = 20;
            TimeSpan howLongNight = Library.SunRiseAndSetTimes.SunRiseTomorrow.Subtract(Library.SunRiseAndSetTimes.SunSetToday);
            TimeSpan timerLingthnight = new TimeSpan(howLongNight.Ticks / HowManyNightImages);
            TimeSpan nightTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunSetToday);
            int imageNumber = (int)(nightTimeSpan.Ticks / timerLingthnight.Ticks) + 1;
            settings.Values["ColorIdNumber"] = Convert.ToString(Math.Floor(Convert.ToDouble(imageNumber)));
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                await ChangeWallpaperColors();
            }
            else if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                await ChangeWallpaperColors();
            }
        }
        public static async Task ModernAfterMidnightColor()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            int HowManyNightImages = 20;
            TimeSpan howLongNight = Library.SunRiseAndSetTimes.SunRiseToday.Subtract(Library.SunRiseAndSetTimes.SunSetYesterday);
            TimeSpan timerLingthnight = new TimeSpan(howLongNight.Ticks / HowManyNightImages);
            TimeSpan nightTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunSetYesterday);
            int imageNumber = (int)(nightTimeSpan.Ticks / timerLingthnight.Ticks) + 1;
            settings.Values["ColorIdNumber"] = Convert.ToString(Math.Floor(Convert.ToDouble(imageNumber)));
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                await ChangeWallpaperColors();
            }
            else if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                await ChangeWallpaperColors();
            }
        }



        public static async Task ChangeWallpaperColors()
        {
            await LookUpCurrentColors();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder createFlatUIFolder = await localFolder.CreateFolderAsync("09efe629", CreationCollisionOption.OpenIfExists);
            StorageFolder subFolder = await createFlatUIFolder.CreateFolderAsync($"{(string)settings.Values["SelectedFlatImage"]}", CreationCollisionOption.OpenIfExists);
            IStorageItem file = await subFolder.TryGetItemAsync($"Color-{Library.ChangeImageColors.ModernAcent}-{Library.ChangeImageColors.ModernColor}.png");
            if (file == null)
            {
                await Library.ChangeImageColors.ApplyColor(new Uri($"ms-appx:///ModernWallpaperGrayscale/{(string)settings.Values["SelectedFlatImage"]}.png"), $"Color-{Library.ChangeImageColors.ModernAcent}-{Library.ChangeImageColors.ModernColor}.png", $"{(string)settings.Values["SelectedFlatImage"]}");
                StorageFile image = await subFolder.GetFileAsync($"Color-{Library.ChangeImageColors.ModernAcent}-{Library.ChangeImageColors.ModernColor}.png");
                await ApplyWallpaperModern(image);
            }
            else
            {
                StorageFile image = await subFolder.GetFileAsync($"Color-{Library.ChangeImageColors.ModernAcent}-{Library.ChangeImageColors.ModernColor}.png");
                await ApplyWallpaperModern(image);
            }
        }


        private static async Task LookUpCurrentColors()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseDynamicAccent"] == "true")
            {
                string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
                Library.ChangeImageColors.ModernAcent = flatWallpaperAcent.Replace("#", "");
            }
            else
            {
                string flatWallpaperAcent = (string)settings.Values["FlatWallpaperAcent"];
                Library.ChangeImageColors.ModernAcent = flatWallpaperAcent.Replace("#", "");
            }
            if ((string)settings.Values["UseDynamicColor"] == "true")
            {
                string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
                Library.ChangeImageColors.ModernColor = flatWallpaperAcent.Replace("#", "");
            }
            else
            {
                string flatWallpaperColor = (string)settings.Values["FlatWallpaperColor"];
                Library.ChangeImageColors.ModernColor = flatWallpaperColor.Replace("#", "");
            }
        }

        private static async Task ApplyWallpaperModern(StorageFile file)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    await profileSettings.TrySetLockScreenImageAsync(file);
                }
            }
            if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                if (UserProfilePersonalizationSettings.IsSupported())
                {
                    UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                    await profileSettings.TrySetWallpaperImageAsync(file);
                }
            }
        }
    }
}
