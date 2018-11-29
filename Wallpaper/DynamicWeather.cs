using Windows.UI.Xaml.Media.Imaging;

namespace Wallpaper
{
    public class DynamicWeather
    {
        public string DynamicThemeName { get; set; }
        public BitmapImage DynamicIconImgSource { get; set; }

        public DynamicWeather(string nameDynamic, BitmapImage imgSourceDynamic)
        {
            this.DynamicThemeName = nameDynamic;
            this.DynamicIconImgSource = imgSourceDynamic;
        }
    }
}
