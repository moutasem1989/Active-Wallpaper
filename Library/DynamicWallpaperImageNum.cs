using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library
{
    public class DynamicWallpaperImageNum
    {
        public static async Task DayImagesAsync()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseNightMode"] == "true")
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
                StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
                string[] lines = System.IO.File.ReadAllLines(themeConfiguration.Path);
                int HowManyDayImages = int.Parse(lines[1]);
                TimeSpan howLongDay = Library.SunRiseAndSetTimes.SunSetToday.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
                TimeSpan timerLingth = new TimeSpan(howLongDay.Ticks / HowManyDayImages);
                TimeSpan dayTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
                int imageNumber = (int)(dayTimeSpan.Ticks / timerLingth.Ticks);
                int imageID = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageNumber)));
                if (imageID == 0)
                {
                    imageID = 1;
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
                else if (HowManyDayImages < imageID)
                {
                    imageID = HowManyDayImages;
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
                else
                {
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
            }
            else
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
                StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
                string[] lines = System.IO.File.ReadAllLines(themeConfiguration.Path);
                int HowManyDayImages = int.Parse(lines[0]);
                TimeSpan howLongDay = Library.SunRiseAndSetTimes.SunSetToday.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
                TimeSpan timerLingth = new TimeSpan(howLongDay.Ticks / HowManyDayImages);
                TimeSpan dayTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunRiseToday);
                int imageNumber = (int)(dayTimeSpan.Ticks / timerLingth.Ticks) + 1;
                int imageID = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageNumber)));
                if (imageID == 0)
                {
                    imageID = 1;
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
                else if (HowManyDayImages < imageID)
                {
                    imageID = HowManyDayImages;
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
                else
                {
                    await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
                }
            }
        }
        public static async Task NightImagesBeforeMidnightAsync()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
            StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
            StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
            string[] lines = File.ReadAllLines(themeConfiguration.Path);
            int HowManyNightImages = int.Parse(lines[1]);
            TimeSpan howLongNight = Library.SunRiseAndSetTimes.SunRiseTomorrow.Subtract(Library.SunRiseAndSetTimes.SunSetToday);
            TimeSpan timerLingthnight = new TimeSpan(howLongNight.Ticks / HowManyNightImages);
            TimeSpan nightTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunSetToday);
            int imageNumber = (int)(nightTimeSpan.Ticks / timerLingthnight.Ticks) + 1;
            int imageID = Convert.ToInt32(Math.Floor(Convert.ToDouble(imageNumber)));
            if (imageID == 0)
            {
                imageID = 1;
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
            else if (HowManyNightImages < imageID)
            {
                imageID = HowManyNightImages;
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
            else
            {
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
        }
        public static async Task NightImagesAfterMidnightAsync()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
            StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
            StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
            string[] lines = System.IO.File.ReadAllLines(themeConfiguration.Path);
            int HowManyNightImages = Int32.Parse(lines[1]);
            TimeSpan howLongNight = Library.SunRiseAndSetTimes.SunRiseToday.Subtract(Library.SunRiseAndSetTimes.SunSetYesterday);
            TimeSpan timerLingthnight = new TimeSpan(howLongNight.Ticks / HowManyNightImages);
            TimeSpan nightTimeSpan = DateTime.Now.Subtract(Library.SunRiseAndSetTimes.SunSetYesterday);
            int imageNumber = (int)(nightTimeSpan.Ticks / timerLingthnight.Ticks) + 1;
            int imageID = Convert.ToInt32(Math.Floor(Convert.ToDouble(imageNumber)));

            if (imageID == 0)
            {
                imageID = 1;
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
            else if (HowManyNightImages < imageID)
            {
                imageID = HowManyNightImages;
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
            else
            {
                await Library.ApplyImageDynamicWall.GetImageUriAsync(imageID);
            }
        }
    }
}
