using Windows.UI.Xaml.Media.Imaging;

namespace Wallpaper
{
    public class FlatWallpaperGradients
    {
        public BitmapImage Gradient { get; set; }
        public string NameGradient { get; set; }
        public FlatWallpaperGradients(BitmapImage gradient, string nameGradient)
        {
            this.Gradient = gradient;
            this.NameGradient = nameGradient;
        }
    }
}
