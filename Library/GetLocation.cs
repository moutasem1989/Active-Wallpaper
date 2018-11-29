using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage;

namespace Library
{
    public class GetLocation
    {

        public static async Task GetLocationTask()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();
            var geolocator = new Geolocator { DesiredAccuracyInMeters = 5000 };
            var position = await geolocator.GetGeopositionAsync();
            DateTime currentTime = DateTime.Now;
            await WriteGeolocToAppDataAsync(position);
        }

        public static async Task WriteGeolocToAppDataAsync(Geoposition position)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["Latitude"] = position.Coordinate.Point.Position.Latitude.ToString();
            settings.Values["Longitude"] = position.Coordinate.Point.Position.Longitude.ToString();
            settings.Values["Accuracy"] = position.Coordinate.Accuracy.ToString();
            await Library.SunRiseAndSetTimes.GetSolarDataForTodayAsync();
            if ((string)settings.Values["UseWeatherForDesktop"] == "true")
            {
                await Library.WeatherWallpaper.GetCurrentWeather();
            }
            else if ((string)settings.Values["UseWeatherForLockscreen"] == "true")
            {
                await Library.WeatherWallpaper.GetCurrentWeather();
            }
        }
    }
}
