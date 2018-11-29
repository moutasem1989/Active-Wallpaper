using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Wallpaper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateDynamicWeather : Page
    {
        public static StorageFile Image01d { get; set; }
        public static StorageFile Image01n { get; set; }
        public static StorageFile Image02d { get; set; }
        public static StorageFile Image02n { get; set; }
        public static StorageFile Image03d { get; set; }
        public static StorageFile Image03n { get; set; }
        public static StorageFile Image04d { get; set; }
        public static StorageFile Image04n { get; set; }
        public static StorageFile Image09d { get; set; }
        public static StorageFile Image09n { get; set; }
        public static StorageFile Image10d { get; set; }
        public static StorageFile Image10n { get; set; }
        public static StorageFile Image11d { get; set; }
        public static StorageFile Image11n { get; set; }
        public static StorageFile Image13d { get; set; }
        public static StorageFile Image13n { get; set; }
        public static StorageFile Image50d { get; set; }
        public static StorageFile Image50n { get; set; }
        public static StorageFile IconThumnail { get; set; }
        public CreateDynamicWeather()
        {
            this.InitializeComponent();
            RemoveFolder();
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
            Button9.IsEnabled = false;
            Button10.IsEnabled = false;
            Button11.IsEnabled = false;
            Button12.IsEnabled = false;
            Button13.IsEnabled = false;
            Button14.IsEnabled = false;
            Button15.IsEnabled = false;
            Button16.IsEnabled = false;
            Button17.IsEnabled = false;
            Button18.IsEnabled = false;
            ThemeTextBox1.IsEnabled = false;
            ThemeTextBox2.IsEnabled = false;
            ThemeTextBox3.IsEnabled = false;
            ThemeTextBox4.IsEnabled = false;
            ThemeTextBox5.IsEnabled = false;
            ThemeLoadedButton.IsEnabled = false;
            FileSaver.IsEnabled = false;
            SaveThame.IsEnabled = false;
            ThemeLoadedIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));

        }
        private async void RemoveFolder()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
            StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
            await temp.DeleteAsync();
        }
        private void CancelDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void CreateDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeName.Text != null)
            {
                ThemeTextBox1.IsEnabled = true;
                ThemeTextBox2.IsEnabled = true;
                ThemeTextBox3.IsEnabled = true;
                ThemeTextBox4.IsEnabled = true;
                ThemeTextBox5.IsEnabled = true;
                ThemeName.IsEnabled = false;
                StartTest.Visibility = Visibility.Collapsed;
                CreateDynamicThemeLocal.Visibility = Visibility.Collapsed;
                CommentText.Visibility = Visibility.Visible;
                ThemeTextBox1.Visibility = Visibility.Visible;
                ThemeTextBox2.Visibility = Visibility.Visible;
                ThemeTextBox3.Visibility = Visibility.Visible;
                ThemeTextBox4.Visibility = Visibility.Visible;
                ThemeTextBox5.Visibility = Visibility.Visible;

                Button1.IsEnabled = true;
                Button2.IsEnabled = true;
                Button3.IsEnabled = true;
                Button4.IsEnabled = true;
                Button5.IsEnabled = true;
                Button6.IsEnabled = true;
                Button7.IsEnabled = true;
                Button8.IsEnabled = true;
                Button9.IsEnabled = true;
                Button10.IsEnabled = true;
                Button11.IsEnabled = true;
                Button12.IsEnabled = true;
                Button13.IsEnabled = true;
                Button14.IsEnabled = true;
                Button15.IsEnabled = true;
                Button16.IsEnabled = true;
                Button17.IsEnabled = true;
                Button18.IsEnabled = true;
                ThemeLoadedButton.IsEnabled = true;
                FileSaver.IsEnabled = true;
                SaveThame.IsEnabled = true;
                ThemeLoadedIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));
            }
        }

        private async void Click01d(object sender, RoutedEventArgs e)
        {
            if (Image01d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image01d = await fileName.CopyAsync(temp, "01d" + fileName.FileType);
                    Button1.Content = fileName.Name;
                }               
            }
            else
            {
                await Image01d.DeleteAsync();
                Image01d = null;
                Button1.Content = "Day";
            }
        }

        private async void Click02d(object sender, RoutedEventArgs e)
        {
            if (Image02d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image02d = await fileName.CopyAsync(temp, "02d" + fileName.FileType);
                    Button3.Content = fileName.Name;
                }
            }
            else
            {
                await Image02d.DeleteAsync();
                Image02d = null;
                Button3.Content = "Day";
            }
        }

        private async void Click03d(object sender, RoutedEventArgs e)
        {
            if (Image03d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image03d = await fileName.CopyAsync(temp, "03d" + fileName.FileType);
                    Button5.Content = fileName.Name;
                }
            }
            else
            {
                await Image03d.DeleteAsync();
                Image03d = null;
                Button5.Content = "Day";
            }
        }

        private async void Click04d(object sender, RoutedEventArgs e)
        {
            if (Image04d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image04d = await fileName.CopyAsync(temp, "04d" + fileName.FileType);
                    Button7.Content = fileName.Name;
                }
            }
            else
            {
                await Image04d.DeleteAsync();
                Image04d = null;
                Button7.Content = "Day";
            }
        }

        private async void Click09d(object sender, RoutedEventArgs e)
        {
            if (Image09d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image09d = await fileName.CopyAsync(temp, "09d" + fileName.FileType);
                    Button9.Content = fileName.Name;
                }
            }
            else
            {
                await Image09d.DeleteAsync();
                Image09d = null;
                Button9.Content = "Day";
            }
        }

        private async void Click10d(object sender, RoutedEventArgs e)
        {
            if (Image10d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image10d = await fileName.CopyAsync(temp, "10d" + fileName.FileType);
                    Button11.Content = fileName.Name;
                }
            }
            else
            {
                await Image10d.DeleteAsync();
                Image10d = null;
                Button11.Content = "Day";
            }
        }

        private async void Click11d(object sender, RoutedEventArgs e)
        {
            if (Image11d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image11d = await fileName.CopyAsync(temp, "11d" + fileName.FileType);
                    Button13.Content = fileName.Name;
                }
            }
            else
            {
                await Image11d.DeleteAsync();
                Image11d = null;
                Button13.Content = "Day";
            }
        }

        private async void Click13d(object sender, RoutedEventArgs e)
        {
            if (Image13d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image13d = await fileName.CopyAsync(temp, "13d" + fileName.FileType);
                    Button15.Content = fileName.Name;
                }
            }
            else
            {
                await Image13d.DeleteAsync();
                Image13d = null;
                Button15.Content = "Day";
            }
        }

        private async void Click50d(object sender, RoutedEventArgs e)
        {
            if (Image50d == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image50d = await fileName.CopyAsync(temp, "50d" + fileName.FileType);
                    Button17.Content = fileName.Name;
                }
            }
            else
            {
                await Image50d.DeleteAsync();
                Image50d = null;
                Button17.Content = "Day";
            }
        }





        private async void Click01n(object sender, RoutedEventArgs e)
        {
            if (Image01n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image01n = await fileName.CopyAsync(temp, "01n" + fileName.FileType);
                    Button2.Content = fileName.Name;
                }
            }
            else
            {
                await Image01n.DeleteAsync();
                Image01n = null;
                Button2.Content = "Night";
            }
        }

        private async void Click02n(object sender, RoutedEventArgs e)
        {
            if (Image02n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image02n = await fileName.CopyAsync(temp, "02n" + fileName.FileType);
                    Button4.Content = fileName.Name;
                }
            }
            else
            {
                await Image02n.DeleteAsync();
                Image02n = null;
                Button4.Content = "Night";
            }
        }

        private async void Click03n(object sender, RoutedEventArgs e)
        {
            if (Image03n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image03n = await fileName.CopyAsync(temp, "03n" + fileName.FileType);
                    Button6.Content = fileName.Name;
                }
            }
            else
            {
                await Image03n.DeleteAsync();
                Image03n = null;
                Button6.Content = "Night";
            }
        }

        private async void Click04n(object sender, RoutedEventArgs e)
        {
            if (Image04n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image04n = await fileName.CopyAsync(temp, "04n" + fileName.FileType);
                    Button8.Content = fileName.Name;
                }
            }
            else
            {
                await Image04n.DeleteAsync();
                Image04n = null;
                Button8.Content = "Night";
            }
        }

        private async void Click09n(object sender, RoutedEventArgs e)
        {
            if (Image09n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image09n = await fileName.CopyAsync(temp, "09n" + fileName.FileType);
                    Button10.Content = fileName.Name;
                }
            }
            else
            {
                await Image09n.DeleteAsync();
                Image09n = null;
                Button10.Content = "Night";
            }
        }

        private async void Click10n(object sender, RoutedEventArgs e)
        {
            if (Image10n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image10n = await fileName.CopyAsync(temp, "10n" + fileName.FileType);
                    Button12.Content = fileName.Name;
                }
            }
            else
            {
                await Image10n.DeleteAsync();
                Image10n = null;
                Button12.Content = "Night";
            }
        }

        private async void Click11n(object sender, RoutedEventArgs e)
        {
            if (Image11n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image11n = await fileName.CopyAsync(temp, "11n" + fileName.FileType);
                    Button14.Content = fileName.Name;
                }
            }
            else
            {
                await Image11n.DeleteAsync();
                Image11n = null;
                Button14.Content = "Night";
            }
        }

        private async void Click13n(object sender, RoutedEventArgs e)
        {
            if (Image13n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image13n = await fileName.CopyAsync(temp, "13n" + fileName.FileType);
                    Button16.Content = fileName.Name;
                }
            }
            else
            {
                await Image13n.DeleteAsync();
                Image13n = null;
                Button16.Content = "Night";
            }
        }

        private async void Click50n(object sender, RoutedEventArgs e)
        {
            if (Image50n == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".jpeg");
                pickerWallpaper.FileTypeFilter.Add(".jpg");
                pickerWallpaper.FileTypeFilter.Add(".png");
                pickerWallpaper.FileTypeFilter.Add(".bmp");
                pickerWallpaper.FileTypeFilter.Add(".jfif");
                pickerWallpaper.FileTypeFilter.Add(".dib");
                pickerWallpaper.FileTypeFilter.Add(".jpe");
                pickerWallpaper.FileTypeFilter.Add(".gif");
                pickerWallpaper.FileTypeFilter.Add(".tif");
                pickerWallpaper.FileTypeFilter.Add(".tiff");
                pickerWallpaper.FileTypeFilter.Add(".wdp");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    Image50n = await fileName.CopyAsync(temp, "50n" + fileName.FileType);
                    Button18.Content = fileName.Name;
                }
            }
            else
            {
                await Image50n.DeleteAsync();
                Image50n = null;
                Button18.Content = "Night";
            }
        }

        private async void LoadThemeIconClick(object sender, RoutedEventArgs e)
        {
            if (IconThumnail == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                pickerWallpaper.FileTypeFilter.Add(".png");
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    IconThumnail = await fileName.CopyAsync(temp, "Thumnail.png");
                    ThemeLoadedButton.Content = fileName.Name;
                    ThemeLoadedIcon.Source = new BitmapImage(new Uri(IconThumnail.Path));
                }
            }
            else
            {
                await IconThumnail.DeleteAsync();
                IconThumnail = null;
                ThemeLoadedButton.Content = "Add Theme Icon";
                ThemeLoadedIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));
            }
        }


        private async void SaveToFile(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
            StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
            StorageFile themeConfiguration = await temp.CreateFileAsync("Theme.Config", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string[] lines = { ThemeName.Text, ThemeTextBox1.Text, ThemeTextBox2.Text, ThemeTextBox3.Text, ThemeTextBox4.Text, ThemeTextBox5.Text };
            File.WriteAllLines(themeConfiguration.Path, lines);

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");


            if (Image01d != null && Image01n != null && Image02d != null && Image02n != null && Image03d != null && Image03n != null && Image04d != null && Image04n != null && Image09d != null && Image09n != null && Image10d != null && Image10n != null && Image11d != null && Image11n != null && Image13d != null && Image13n != null && Image50d != null && Image50n != null && IconThumnail != null)
            {
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder != null)
                {

                    StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                    await Task.Run(() =>
                    {
                        try
                        {
                            ZipFile.CreateFromDirectory(temp.Path, $"{folder.Path}\\{Guid.NewGuid()}.udw");
                            Debug.WriteLine("folder zipped");
                        }
                        catch (Exception w)
                        {
                            Debug.WriteLine(w);
                        }
                    });
                }
            }
        }

        private async void SaveToTheme(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            await localFolder.CreateFolderAsync("9mabt17s", CreationCollisionOption.OpenIfExists);
            StorageFolder temp = await localFolder.GetFolderAsync("9mabt17s");
            StorageFile themeConfiguration = await temp.CreateFileAsync("Theme.Config", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string[] lines = { ThemeName.Text, ThemeTextBox1.Text, ThemeTextBox2.Text, ThemeTextBox3.Text, ThemeTextBox4.Text, ThemeTextBox5.Text };
            File.WriteAllLines(themeConfiguration.Path, lines);
            StorageFolder dynamicFolder = await localFolder.CreateFolderAsync("dw2b8071", CreationCollisionOption.OpenIfExists);
            StorageFolder storage = await dynamicFolder.CreateFolderAsync(ThemeName.Text, CreationCollisionOption.GenerateUniqueName);

            if (Image01d != null && Image01n != null && Image02d != null && Image02n != null && Image03d != null && Image03n != null && Image04d != null && Image04n != null && Image09d != null && Image09n != null && Image10d != null && Image10n != null && Image11d != null && Image11n != null && Image13d != null && Image13n != null && Image50d != null && Image50n != null && IconThumnail != null)
            {
                var storagefiles = await temp.GetFilesAsync();

                foreach (StorageFile storagefile in storagefiles)
                {
                    await storagefile.CopyAsync(storage);
                    SaveThame.IsEnabled = false;
                }
            }
        }
    }
}