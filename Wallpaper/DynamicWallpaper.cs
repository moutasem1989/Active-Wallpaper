using Windows.UI.Xaml.Media.Imaging;

namespace Wallpaper
{
    public class DynamicWallpaper
    {
        public string DynamicThemeName { get; set; }
        public BitmapImage DynamicIconImgSource { get; set; }

        public DynamicWallpaper(string nameDynamic, BitmapImage imgSourceDynamic)
        {
            this.DynamicThemeName = nameDynamic;
            this.DynamicIconImgSource = imgSourceDynamic;
        }
    }
}
