using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library
{
    public class IsItNowDayOrNight
    {
        public static async Task DayORNightAsync()
        {

            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            
            int resultAfterMidnight = DateTime.Compare(DateTime.Now, Library.SunRiseAndSetTimes.SunRiseToday);
            if (resultAfterMidnight < 0)
            {
                settings.Values["DayOrNight"] = "Night";
                Library.SunRiseAndSetTimes.GetSolarDataForYesterday();
                
                if ((string)settings.Values["UseItForDesktop"] == "true")
                {
                    await Library.DynamicWallpaperImageNum.NightImagesAfterMidnightAsync();
                }
                else if ((string)settings.Values["UseItForLockscreen"] == "true")
                {
                    await Library.DynamicWallpaperImageNum.NightImagesAfterMidnightAsync();
                }
                if ((string)settings.Values["UseDynamicColor"] == "true")
                {
                    await Library.ModernWallpaper.ModernAfterMidnightColor();
                }
                else if ((string)settings.Values["UseDynamicAccent"] == "true")
                {
                    await Library.ModernWallpaper.ModernAfterMidnightColor();
                }
            }
            int resultBeforeMidnight = DateTime.Compare(Library.SunRiseAndSetTimes.SunSetToday, DateTime.Now);
            if (resultBeforeMidnight < 0)
            {
                settings.Values["DayOrNight"] = "Night";
                Library.SunRiseAndSetTimes.GetSolarDataForTomorrow();
                
                if ((string)settings.Values["UseItForDesktop"] == "true")
                {
                    await Library.DynamicWallpaperImageNum.NightImagesBeforeMidnightAsync();
                }
                else if ((string)settings.Values["UseItForLockscreen"] == "true")
                {
                    await Library.DynamicWallpaperImageNum.NightImagesBeforeMidnightAsync();
                }
                if ((string)settings.Values["UseDynamicColor"] == "true")
                {
                    await Library.ModernWallpaper.ModernBeforeMidnightColor();
                }
                else if ((string)settings.Values["UseDynamicAccent"] == "true")
                {
                    await Library.ModernWallpaper.ModernBeforeMidnightColor();
                }
            }

            int resultDay1 = DateTime.Compare(Library.SunRiseAndSetTimes.SunRiseToday, DateTime.Now);
            int resultDay2 = DateTime.Compare(DateTime.Now, Library.SunRiseAndSetTimes.SunSetToday);
            if (resultDay1 < 0)
            {
                if (resultDay2 < 0)
                {
                    settings.Values["DayOrNight"] = "Day";
                    if ((string)settings.Values["UseItForDesktop"] == "true")
                    {
                        await Library.DynamicWallpaperImageNum.DayImagesAsync();
                    }
                    else if ((string)settings.Values["UseItForLockscreen"] == "true")
                    {
                        await Library.DynamicWallpaperImageNum.DayImagesAsync();
                    }
                    if ((string)settings.Values["UseDynamicColor"] == "true")
                    {
                        await Library.ModernWallpaper.ModernDayColor();
                    }
                    else if ((string)settings.Values["UseDynamicAccent"] == "true")
                    {
                        await Library.ModernWallpaper.ModernDayColor();
                    }
                }
            }
        }
    }
}
