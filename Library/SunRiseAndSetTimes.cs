using Innovative.SolarCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library
{
    class SunRiseAndSetTimes
    {
        public static DateTime SunRiseYesterday { get; set; }
        public static DateTime SunSetYesterday { get; set; }
        public static DateTime SunRiseToday { get; set; }
        public static DateTime SunSetToday { get; set; }
        public static DateTime SunRiseTomorrow { get; set; }
        public static DateTime SunSetTomorrow { get; set; }


        public static async Task GetSolarDataForTodayAsync()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            DateTime today = DateTime.Today;
            string lat = (string)settings.Values["Latitude"];
            double latitude = Double.Parse(lat);
            string lon = (string)settings.Values["Longitude"];
            double longitude = Double.Parse(lon);
            SolarTimes solarTimes = new SolarTimes(today, latitude, longitude);
            SunRiseToday = solarTimes.Sunrise;
            SunSetToday = solarTimes.Sunset;
            await Library.IsItNowDayOrNight.DayORNightAsync();
        }
        public static void GetSolarDataForYesterday()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);
            string lat = (string)settings.Values["Latitude"];
            double latitude = Double.Parse(lat);
            string lon = (string)settings.Values["Longitude"];
            double longitude = Double.Parse(lon);
            SolarTimes solarTimes = new SolarTimes(yesterday, latitude, longitude);
            SunRiseYesterday = solarTimes.Sunrise;
            SunSetYesterday = solarTimes.Sunset;
        }
        public static void GetSolarDataForTomorrow()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            string lat = (string)settings.Values["Latitude"];
            double latitude = Double.Parse(lat);
            string lon = (string)settings.Values["Longitude"];
            double longitude = Double.Parse(lon);
            SolarTimes solarTimes = new SolarTimes(tomorrow, latitude, longitude);
            SunRiseTomorrow = solarTimes.Sunrise;
            SunSetTomorrow = solarTimes.Sunset;
        }
    }
}
