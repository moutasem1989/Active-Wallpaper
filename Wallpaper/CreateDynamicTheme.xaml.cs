using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Wallpaper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateDynamicTheme : Page
    {
        private QueryOptions queryOption;

        public static string nightNumber { get; set; }
        public static string dayNumber { get; set; }
        public static StorageFile DayImage1 { get; set; }
        public static StorageFile DayImage2 { get; set; }
        public static StorageFile DayImage3 { get; set; }
        public static StorageFile DayImage4 { get; set; }
        public static StorageFile DayImage5 { get; set; }
        public static StorageFile DayImage6 { get; set; }
        public static StorageFile DayImage7 { get; set; }
        public static StorageFile DayImage8 { get; set; }
        public static StorageFile DayImage9 { get; set; }
        public static StorageFile DayImage10 { get; set; }
        public static StorageFile DayImage11 { get; set; }
        public static StorageFile DayImage12 { get; set; }
        public static StorageFile DayImage13 { get; set; }
        public static StorageFile DayImage14 { get; set; }
        public static StorageFile DayImage15 { get; set; }
        public static StorageFile DayImage16 { get; set; }
        public static StorageFile DayImage17 { get; set; }
        public static StorageFile DayImage18 { get; set; }
        public static StorageFile DayImage19 { get; set; }
        public static StorageFile DayImage20 { get; set; }
        public static StorageFile NightImage1 { get; set; }
        public static StorageFile NightImage2 { get; set; }
        public static StorageFile NightImage3 { get; set; }
        public static StorageFile NightImage4 { get; set; }
        public static StorageFile NightImage5 { get; set; }
        public static StorageFile NightImage6 { get; set; }
        public static StorageFile NightImage7 { get; set; }
        public static StorageFile NightImage8 { get; set; }
        public static StorageFile NightImage9 { get; set; }
        public static StorageFile NightImage10 { get; set; }
        public static StorageFile NightImage11 { get; set; }
        public static StorageFile NightImage12 { get; set; }
        public static StorageFile NightImage13 { get; set; }
        public static StorageFile NightImage14 { get; set; }
        public static StorageFile NightImage15 { get; set; }
        public static StorageFile NightImage16 { get; set; }
        public static StorageFile NightImage17 { get; set; }
        public static StorageFile NightImage18 { get; set; }
        public static StorageFile NightImage19 { get; set; }
        public static StorageFile NightImage20 { get; set; }
        public static StorageFile DayIcon { get; set; }
        public static StorageFile NightIcon { get; set; }



        public CreateDynamicTheme()
        {
            this.InitializeComponent();

            dayNumber = null;
            nightNumber = null;

            StartTest.Visibility = Visibility.Visible;
            ThemeName.Visibility = Visibility.Visible;
            ThemeName.IsEnabled = true;
            CreateDynamicThemeLocal.Visibility = Visibility.Visible;
            CommentText.Visibility = Visibility.Collapsed;
            ThemeTextBox1.Visibility = Visibility.Visible;
            ThemeTextBox1.IsEnabled = false;
            ThemeTextBox2.Visibility = Visibility.Visible;
            ThemeTextBox2.IsEnabled = false;
            ThemeTextBox3.Visibility = Visibility.Visible;
            ThemeTextBox3.IsEnabled = false;
            ThemeTextBox4.Visibility = Visibility.Visible;
            ThemeTextBox4.IsEnabled = false;
            ThemeTextBox5.Visibility = Visibility.Visible;
            ThemeTextBox5.IsEnabled = false;
            AddDayImage_01.IsEnabled = false;
            AddDayImage_01.Visibility = Visibility.Visible;
            AddDayImage_02.IsEnabled = false;
            AddDayImage_02.Visibility = Visibility.Visible;
            AddDayImage_03.IsEnabled = false;
            AddDayImage_03.Visibility = Visibility.Visible;
            AddDayImage_04.IsEnabled = false;
            AddDayImage_04.Visibility = Visibility.Visible;
            AddDayImage_05.IsEnabled = false;
            AddDayImage_05.Visibility = Visibility.Visible;
            AddDayImage_06.IsEnabled = false;
            AddDayImage_06.Visibility = Visibility.Visible;
            AddDayImage_07.IsEnabled = false;
            AddDayImage_07.Visibility = Visibility.Visible;
            AddDayImage_08.IsEnabled = false;
            AddDayImage_08.Visibility = Visibility.Visible;
            AddDayImage_09.IsEnabled = false;
            AddDayImage_09.Visibility = Visibility.Visible;
            AddDayImage_10.IsEnabled = false;
            AddDayImage_10.Visibility = Visibility.Visible;
            AddDayImage_11.IsEnabled = false;
            AddDayImage_11.Visibility = Visibility.Visible;
            AddDayImage_12.IsEnabled = false;
            AddDayImage_12.Visibility = Visibility.Visible;
            AddDayImage_13.IsEnabled = false;
            AddDayImage_13.Visibility = Visibility.Visible;
            AddDayImage_14.IsEnabled = false;
            AddDayImage_14.Visibility = Visibility.Visible;
            AddDayImage_15.IsEnabled = false;
            AddDayImage_15.Visibility = Visibility.Visible;
            AddDayImage_16.IsEnabled = false;
            AddDayImage_16.Visibility = Visibility.Visible;
            AddDayImage_17.IsEnabled = false;
            AddDayImage_17.Visibility = Visibility.Visible;
            AddDayImage_18.IsEnabled = false;
            AddDayImage_18.Visibility = Visibility.Visible;
            AddDayImage_19.IsEnabled = false;
            AddDayImage_19.Visibility = Visibility.Visible;
            AddDayImage_20.IsEnabled = false;
            AddDayImage_20.Visibility = Visibility.Visible;
            AddNightImage_01.IsEnabled = false;
            AddNightImage_01.Visibility = Visibility.Visible;
            AddNightImage_02.IsEnabled = false;
            AddNightImage_02.Visibility = Visibility.Visible;
            AddNightImage_03.IsEnabled = false;
            AddNightImage_03.Visibility = Visibility.Visible;
            AddNightImage_04.IsEnabled = false;
            AddNightImage_04.Visibility = Visibility.Visible;
            AddNightImage_05.IsEnabled = false;
            AddNightImage_05.Visibility = Visibility.Visible;
            AddNightImage_06.IsEnabled = false;
            AddNightImage_06.Visibility = Visibility.Visible;
            AddNightImage_07.IsEnabled = false;
            AddNightImage_07.Visibility = Visibility.Visible;
            AddNightImage_08.IsEnabled = false;
            AddNightImage_08.Visibility = Visibility.Visible;
            AddNightImage_09.IsEnabled = false;
            AddNightImage_09.Visibility = Visibility.Visible;
            AddNightImage_10.IsEnabled = false;
            AddNightImage_10.Visibility = Visibility.Visible;
            AddNightImage_11.IsEnabled = false;
            AddNightImage_11.Visibility = Visibility.Visible;
            AddNightImage_12.IsEnabled = false;
            AddNightImage_12.Visibility = Visibility.Visible;
            AddNightImage_13.IsEnabled = false;
            AddNightImage_13.Visibility = Visibility.Visible;
            AddNightImage_14.IsEnabled = false;
            AddNightImage_14.Visibility = Visibility.Visible;
            AddNightImage_15.IsEnabled = false;
            AddNightImage_15.Visibility = Visibility.Visible;
            AddNightImage_16.IsEnabled = false;
            AddNightImage_16.Visibility = Visibility.Visible;
            AddNightImage_17.IsEnabled = false;
            AddNightImage_17.Visibility = Visibility.Visible;
            AddNightImage_18.IsEnabled = false;
            AddNightImage_18.Visibility = Visibility.Visible;
            AddNightImage_19.IsEnabled = false;
            AddNightImage_19.Visibility = Visibility.Visible;
            AddNightImage_20.IsEnabled = false;
            AddNightImage_20.Visibility = Visibility.Visible;
            AddDayIcon.Visibility = Visibility.Visible;
            AddDayIcon.IsEnabled = false;
            AddNightIcon.Visibility = Visibility.Visible;
            AddNightIcon.IsEnabled = false;

            DayImageIcon.Visibility = Visibility.Visible;
            
            NightImageIcon.Visibility = Visibility.Visible;
            SaveFile.Visibility = Visibility.Visible;
            SaveFile.IsEnabled = false;
            SaveThame.Visibility = Visibility.Visible;
            SaveThame.IsEnabled = false;
            DayImageIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));
            NightImageIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/NightPlaceHolder.png"));
        }
        private void CancelDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void CreateDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
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
                AddDayImage_01.IsEnabled = true;
                AddDayImage_01.Visibility = Visibility.Visible;
                AddDayImage_02.IsEnabled = false;
                AddDayImage_02.Visibility = Visibility.Visible;
                AddDayImage_03.IsEnabled = false;
                AddDayImage_03.Visibility = Visibility.Visible;
                AddDayImage_04.IsEnabled = false;
                AddDayImage_04.Visibility = Visibility.Visible;
                AddDayImage_05.IsEnabled = false;
                AddDayImage_05.Visibility = Visibility.Visible;
                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;

                AddNightImage_01.IsEnabled = true;
                AddNightImage_01.Visibility = Visibility.Visible;
                AddNightImage_02.IsEnabled = false;
                AddNightImage_02.Visibility = Visibility.Visible;
                AddNightImage_03.IsEnabled = false;
                AddNightImage_03.Visibility = Visibility.Visible;
                AddNightImage_04.IsEnabled = false;
                AddNightImage_04.Visibility = Visibility.Visible;
                AddNightImage_05.IsEnabled = false;
                AddNightImage_05.Visibility = Visibility.Visible;
                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_04.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;

                AddDayIcon.Visibility = Visibility.Visible;
                AddDayIcon.IsEnabled = true;
                AddNightIcon.Visibility = Visibility.Visible;
                AddNightIcon.IsEnabled = true;

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                await temp.DeleteAsync();
                DayImageIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));
                NightImageIcon.Source =new BitmapImage(new Uri("ms-appx:///Assets/NightPlaceHolder.png"));
            }
        }

        private async void AddDayImage_01_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage1 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage1 = await fileName.CopyAsync(temp, "Theme_Day_1_Theme" + fileName.FileType);
                    AddDayImage_02.IsEnabled = true;
                    AddDayImage_01.Content = fileName.Name;

                    dayNumber = "1";
                    AddDayIcon.Visibility = Visibility.Visible;
                    AddDayIcon.IsEnabled = false;
                    DayImageIcon.Visibility = Visibility.Visible;
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = false;
                    NightImageIcon.Visibility = Visibility.Visible;
                    SaveFile.Visibility = Visibility.Visible;
                    SaveFile.IsEnabled = false;
                    SaveThame.Visibility = Visibility.Visible;
                    SaveThame.IsEnabled = false;
                }
            }
            else
            {
                if (DayImage1 != null)
                {
                    await DayImage1.DeleteAsync();
                    DayImage1 = null;
                }
                if (DayImage2 != null)
                {
                    await DayImage2.DeleteAsync();
                    DayImage2 = null;
                }
                if (DayImage3 != null)
                {
                    await DayImage3.DeleteAsync();
                    DayImage3 = null;
                }
                if (DayImage4 != null)
                {
                    await DayImage4.DeleteAsync();
                    DayImage4 = null;
                }
                if (DayImage5 != null)
                {
                    await DayImage5.DeleteAsync();
                    DayImage5 = null;
                }
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = null;
                AddDayImage_01.Content = "Add 1.st Day Image";
                AddDayImage_02.Content = "Add 2.nd Day Image";
                AddDayImage_03.Content = "Add 3.rd Day Image";
                AddDayImage_04.Content = "Add 4.th Day Image";
                AddDayImage_05.Content = "Add 5.th Day Image";
                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_02.IsEnabled = false;
                AddDayImage_02.Visibility = Visibility.Visible;
                AddDayImage_03.IsEnabled = false;
                AddDayImage_03.Visibility = Visibility.Visible;
                AddDayImage_04.IsEnabled = false;
                AddDayImage_04.Visibility = Visibility.Visible;
                AddDayImage_05.IsEnabled = false;
                AddDayImage_05.Visibility = Visibility.Visible;
                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }

        private async void AddDayImage_02_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage2 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage2 = await fileName.CopyAsync(temp, "Theme_Day_2_Theme" + fileName.FileType);
                    AddDayImage_03.IsEnabled = true;

                    AddDayImage_02.Content = fileName.Name;
                    dayNumber = "2";
                    AddDayIcon.Visibility = Visibility.Visible;
                    AddDayIcon.IsEnabled = true;

                    DayImageIcon.Visibility = Visibility.Visible;
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = true;

                    NightImageIcon.Visibility = Visibility.Visible;
                    SaveFile.Visibility = Visibility.Visible;
                    SaveFile.IsEnabled = true;
                    SaveThame.Visibility = Visibility.Visible;
                    SaveThame.IsEnabled = true;
                }
            }
            else
            {
                if (DayImage2 != null)
                {
                    await DayImage2.DeleteAsync();
                    DayImage2 = null;
                }
                if (DayImage3 != null)
                {
                    await DayImage3.DeleteAsync();
                    DayImage3 = null;
                }
                if (DayImage4 != null)
                {
                    await DayImage4.DeleteAsync();
                    DayImage4 = null;
                }
                if (DayImage5 != null)
                {
                    await DayImage5.DeleteAsync();
                    DayImage5 = null;
                }
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "1";

                AddDayImage_02.Content = "Add 2.nd Day Image";
                AddDayImage_03.Content = "Add 3.rd Day Image";
                AddDayImage_04.Content = "Add 4.th Day Image";
                AddDayImage_05.Content = "Add 5.th Day Image";
                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_03.IsEnabled = false;
                AddDayImage_03.Visibility = Visibility.Visible;
                AddDayImage_04.IsEnabled = false;
                AddDayImage_04.Visibility = Visibility.Visible;
                AddDayImage_05.IsEnabled = false;
                AddDayImage_05.Visibility = Visibility.Visible;
                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }

        private async void AddDayImage_03_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage3 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage3 = await fileName.CopyAsync(temp, "Theme_Day_3_Theme" + fileName.FileType);
                    AddDayImage_04.IsEnabled = true;

                    AddDayImage_03.Content = fileName.Name;
                    dayNumber = "3";
                }
            }
            else
            {
                if (DayImage3 != null)
                {
                    await DayImage3.DeleteAsync();
                    DayImage3 = null;
                }
                if (DayImage4 != null)
                {
                    await DayImage4.DeleteAsync();
                    DayImage4 = null;
                }
                if (DayImage5 != null)
                {
                    await DayImage5.DeleteAsync();
                    DayImage5 = null;
                }
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "2";

                AddDayImage_03.Content = "Add 3.rd Day Image";
                AddDayImage_04.Content = "Add 4.th Day Image";
                AddDayImage_05.Content = "Add 5.th Day Image";
                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_04.IsEnabled = false;
                AddDayImage_04.Visibility = Visibility.Visible;
                AddDayImage_05.IsEnabled = false;
                AddDayImage_05.Visibility = Visibility.Visible;
                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }

        private async void AddDayImage_04_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage4 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage4 = await fileName.CopyAsync(temp, "Theme_Day_4_Theme" + fileName.FileType);
                    AddDayImage_05.IsEnabled = true;

                    AddDayImage_04.Content = fileName.Name;
                    dayNumber = "4";
                }
            }
            else
            {
                if (DayImage4 != null)
                {
                    await DayImage4.DeleteAsync();
                    DayImage4 = null;
                }
                if (DayImage5 != null)
                {
                    await DayImage5.DeleteAsync();
                    DayImage5 = null;
                }
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "3";

                AddDayImage_04.Content = "Add 4.th Day Image";
                AddDayImage_05.Content = "Add 5.th Day Image";
                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_05.IsEnabled = false;
                AddDayImage_05.Visibility = Visibility.Visible;
                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_05_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage5 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage5 = await fileName.CopyAsync(temp, "Theme_Day_5_Theme" + fileName.FileType);
                    AddDayImage_06.IsEnabled = true;

                    AddDayImage_05.Content = fileName.Name;
                    dayNumber = "5";
                }
            }
            else
            {
                if (DayImage5 != null)
                {
                    await DayImage5.DeleteAsync();
                    DayImage5 = null;
                }
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "4";

                AddDayImage_05.Content = "Add 5.th Day Image";
                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_06.IsEnabled = false;
                AddDayImage_06.Visibility = Visibility.Visible;
                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_06_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage6 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage6 = await fileName.CopyAsync(temp, "Theme_Day_6_Theme" + fileName.FileType);
                    AddDayImage_07.IsEnabled = true;
                    AddDayImage_06.Content = fileName.Name;
                    dayNumber = "6";
                }
            }
            else
            {
                if (DayImage6 != null)
                {
                    await DayImage6.DeleteAsync();
                    DayImage6 = null;
                }
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "5";

                AddDayImage_06.Content = "Add 6.th Day Image";
                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_07.IsEnabled = false;
                AddDayImage_07.Visibility = Visibility.Visible;
                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_07_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage7 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage7 = await fileName.CopyAsync(temp, "Theme_Day_7_Theme" + fileName.FileType);
                    AddDayImage_08.IsEnabled = true;
                    AddDayImage_07.Content = fileName.Name;
                    dayNumber = "7";
                }
            }
            else
            {
                if (DayImage7 != null)
                {
                    await DayImage7.DeleteAsync();
                    DayImage7 = null;
                }
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "6";

                AddDayImage_07.Content = "Add 7.th Day Image";
                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_08.IsEnabled = false;
                AddDayImage_08.Visibility = Visibility.Visible;
                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_08_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage8 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage8 = await fileName.CopyAsync(temp, "Theme_Day_8_Theme" + fileName.FileType);
                    AddDayImage_09.IsEnabled = true;
                    AddDayImage_08.Content = fileName.Name;
                    dayNumber = "8";
                }
            }
            else
            {
                if (DayImage8 != null)
                {
                    await DayImage8.DeleteAsync();
                    DayImage8 = null;
                }
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "7";

                AddDayImage_08.Content = "Add 8.th Day Image";
                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_09.IsEnabled = false;
                AddDayImage_09.Visibility = Visibility.Visible;
                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_09_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage9 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage9 = await fileName.CopyAsync(temp, "Theme_Day_9_Theme" + fileName.FileType);
                    AddDayImage_10.IsEnabled = true;
                    AddDayImage_09.Content = fileName.Name;
                    dayNumber = "9";
                }
            }
            else
            {
                if (DayImage9 != null)
                {
                    await DayImage9.DeleteAsync();
                    DayImage9 = null;
                }
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "8";

                AddDayImage_09.Content = "Add 9.th Day Image";
                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_10.IsEnabled = false;
                AddDayImage_10.Visibility = Visibility.Visible;
                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_10_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage10 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage10 = await fileName.CopyAsync(temp, "Theme_Day_10_Theme" + fileName.FileType);
                    AddDayImage_11.IsEnabled = true;

                    AddDayImage_10.Content = fileName.Name;
                    dayNumber = "10";
                }
            }
            else
            {
                if (DayImage10 != null)
                {
                    await DayImage10.DeleteAsync();
                    DayImage10 = null;
                }
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "9";

                AddDayImage_10.Content = "Add 10.th Day Image";
                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_11.IsEnabled = false;
                AddDayImage_11.Visibility = Visibility.Visible;
                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
            
        }
        private async void AddDayImage_11_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage11 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage11 = await fileName.CopyAsync(temp, "Theme_Day_11_Theme" + fileName.FileType);
                    AddDayImage_12.IsEnabled = true;
                    AddDayImage_11.Content = fileName.Name;
                    dayNumber = "11";
                }
            }
            else
            {
                if (DayImage11 != null)
                {
                    await DayImage11.DeleteAsync();
                    DayImage11 = null;
                }
                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "10";


                AddDayImage_11.Content = "Add 11.th Day Image";
                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_12.IsEnabled = false;
                AddDayImage_12.Visibility = Visibility.Visible;
                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_12_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage12 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage12 = await fileName.CopyAsync(temp, "Theme_Day_12_Theme" + fileName.FileType);
                    AddDayImage_13.IsEnabled = true;
                    AddDayImage_12.Content = fileName.Name;
                    dayNumber = "12";
                }
            }
            else
            {

                if (DayImage12 != null)
                {
                    await DayImage12.DeleteAsync();
                    DayImage12 = null;
                }
                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "11";

                AddDayImage_12.Content = "Add 12.th Day Image";
                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_13.IsEnabled = false;
                AddDayImage_13.Visibility = Visibility.Visible;
                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_13_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage13 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage13 = await fileName.CopyAsync(temp, "Theme_Day_13_Theme" + fileName.FileType);
                    AddDayImage_14.IsEnabled = true;
                    AddDayImage_13.Content = fileName.Name;
                    dayNumber = "13";
                }
            }
            else
            {

                if (DayImage13 != null)
                {
                    await DayImage13.DeleteAsync();
                    DayImage13 = null;
                }
                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "12";

                AddDayImage_13.Content = "Add 13.th Day Image";
                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_14.IsEnabled = false;
                AddDayImage_14.Visibility = Visibility.Visible;
                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_14_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage14 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage14 = await fileName.CopyAsync(temp, "Theme_Day_14_Theme" + fileName.FileType);
                    AddDayImage_15.IsEnabled = true;
                    AddDayImage_14.Content = fileName.Name;
                    dayNumber = "14";
                }
            }
            else
            {

                if (DayImage14 != null)
                {
                    await DayImage14.DeleteAsync();
                    DayImage14 = null;
                }
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "13";

                AddDayImage_14.Content = "Add 14.th Day Image";
                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_15.IsEnabled = false;
                AddDayImage_15.Visibility = Visibility.Visible;
                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_15_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage15 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage15 = await fileName.CopyAsync(temp, "Theme_Day_15_Theme" + fileName.FileType);
                    AddDayImage_16.IsEnabled = true;
                    AddDayImage_15.Content = fileName.Name;
                    dayNumber = "15";
                }
            }
            else
            {
                if (DayImage15 != null)
                {
                    await DayImage15.DeleteAsync();
                    DayImage15 = null;
                }
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "14";

                AddDayImage_15.Content = "Add 15.th Day Image";
                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_16.IsEnabled = false;
                AddDayImage_16.Visibility = Visibility.Visible;
                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_16_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage16 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage16 = await fileName.CopyAsync(temp, "Theme_Day_16_Theme" + fileName.FileType);
                    AddDayImage_17.IsEnabled = true;
                    AddDayImage_16.Content = fileName.Name;
                    dayNumber = "16";
                }
            }
            else
            {
                if (DayImage16 != null)
                {
                    await DayImage16.DeleteAsync();
                    DayImage16 = null;
                }
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "15";

                AddDayImage_16.Content = "Add 16.th Day Image";
                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_17.IsEnabled = false;
                AddDayImage_17.Visibility = Visibility.Visible;
                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_17_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage17 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage17 = await fileName.CopyAsync(temp, "Theme_Day_17_Theme" + fileName.FileType);
                    AddDayImage_18.IsEnabled = true;
                    AddDayImage_17.Content = fileName.Name;
                    dayNumber = "17";
                }
            }
            else
            {
                if (DayImage17 != null)
                {
                    await DayImage17.DeleteAsync();
                    DayImage17 = null;
                }
                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "16";

                AddDayImage_17.Content = "Add 17.th Day Image";
                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_18.IsEnabled = false;
                AddDayImage_18.Visibility = Visibility.Visible;
                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_18_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage18 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage18 = await fileName.CopyAsync(temp, "Theme_Day_18_Theme" + fileName.FileType);
                    AddDayImage_19.IsEnabled = true;
                    AddDayImage_18.Content = fileName.Name;
                    dayNumber = "18";
                }
            }
            else
            {

                if (DayImage18 != null)
                {
                    await DayImage18.DeleteAsync();
                    DayImage18 = null;
                }
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "17";

                AddDayImage_18.Content = "Add 18.th Day Image";
                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_19_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage19 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage19 = await fileName.CopyAsync(temp, "Theme_Day_19_Theme" + fileName.FileType);
                    AddDayImage_20.IsEnabled = true;
                    AddDayImage_19.Content = fileName.Name;
                    dayNumber = "19";
                }
            }
            else
            {
                if (DayImage19 != null)
                {
                    await DayImage19.DeleteAsync();
                    DayImage19 = null;
                }
                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "18";

                AddDayImage_19.Content = "Add 19.th Day Image";
                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_19.IsEnabled = false;
                AddDayImage_19.Visibility = Visibility.Visible;
                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddDayImage_20_Click(object sender, RoutedEventArgs e)
        {
            if (DayImage20 == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

                pickerWallpaper.FileTypeFilter.Add(".jpeg");

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayImage20 = await fileName.CopyAsync(temp, "Theme_Day_20_Theme" + fileName.FileType);
                    AddDayImage_20.Content = fileName.Name;
                    dayNumber = "20";
                }
            }
            else
            {

                if (DayImage20 != null)
                {
                    await DayImage20.DeleteAsync();
                    DayImage20 = null;
                }

                dayNumber = "19";

                AddDayImage_20.Content = "Add 20.th Day Image";

                AddDayImage_20.IsEnabled = false;
                AddDayImage_20.Visibility = Visibility.Visible;
            }
        }

        private async void AddNightImage_01_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage1 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage1 = await fileName.CopyAsync(temp, "Theme_Night_1_Theme" + fileName.FileType);
                    AddNightImage_02.IsEnabled = true;
                    AddNightImage_01.Content = fileName.Name;

                    nightNumber = "1";
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = false;
                    NightImageIcon.Visibility = Visibility.Visible;
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = false;
                    NightImageIcon.Visibility = Visibility.Visible;
                    SaveFile.Visibility = Visibility.Visible;
                    SaveFile.IsEnabled = false;
                    SaveThame.Visibility = Visibility.Visible;
                    SaveThame.IsEnabled = false;
                }
            }
            else
            {
                if (NightImage1 != null)
                {
                    await NightImage1.DeleteAsync();
                    NightImage1 = null;
                }
                if (NightImage2 != null)
                {
                    await NightImage2.DeleteAsync();
                    NightImage2 = null;
                }
                if (NightImage3 != null)
                {
                    await NightImage3.DeleteAsync();
                    NightImage3 = null;
                }
                if (NightImage4 != null)
                {
                    await NightImage4.DeleteAsync();
                    NightImage4 = null;
                }
                if (NightImage5 != null)
                {
                    await NightImage5.DeleteAsync();
                    NightImage5 = null;
                }
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = null;
                AddNightImage_01.Content = "Add 1.st Night Image";
                AddNightImage_02.Content = "Add 2.nd Night Image";
                AddNightImage_03.Content = "Add 3.rd Night Image";
                AddNightImage_04.Content = "Add 4.th Night Image";
                AddNightImage_05.Content = "Add 5.th Night Image";
                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_02.IsEnabled = false;
                AddNightImage_02.Visibility = Visibility.Visible;
                AddNightImage_03.IsEnabled = false;
                AddNightImage_03.Visibility = Visibility.Visible;
                AddNightImage_04.IsEnabled = false;
                AddNightImage_04.Visibility = Visibility.Visible;
                AddNightImage_05.IsEnabled = false;
                AddNightImage_05.Visibility = Visibility.Visible;
                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }

        private async void AddNightImage_02_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage2 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage2 = await fileName.CopyAsync(temp, "Theme_Night_2_Theme" + fileName.FileType);
                    AddNightImage_03.IsEnabled = true;

                    AddNightImage_02.Content = fileName.Name;
                    nightNumber = "2";
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = true;

                    NightImageIcon.Visibility = Visibility.Visible;
                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.IsEnabled = true;

                    NightImageIcon.Visibility = Visibility.Visible;
                    SaveFile.Visibility = Visibility.Visible;
                    SaveFile.IsEnabled = true;
                    SaveThame.Visibility = Visibility.Visible;
                    SaveThame.IsEnabled = true;
                }
            }
            else
            {
                if (NightImage2 != null)
                {
                    await NightImage2.DeleteAsync();
                    NightImage2 = null;
                }
                if (NightImage3 != null)
                {
                    await NightImage3.DeleteAsync();
                    NightImage3 = null;
                }
                if (NightImage4 != null)
                {
                    await NightImage4.DeleteAsync();
                    NightImage4 = null;
                }
                if (NightImage5 != null)
                {
                    await NightImage5.DeleteAsync();
                    NightImage5 = null;
                }
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "1";

                AddNightImage_02.Content = "Add 2.nd Night Image";
                AddNightImage_03.Content = "Add 3.rd Night Image";
                AddNightImage_04.Content = "Add 4.th Night Image";
                AddNightImage_05.Content = "Add 5.th Night Image";
                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_03.IsEnabled = false;
                AddNightImage_03.Visibility = Visibility.Visible;
                AddNightImage_04.IsEnabled = false;
                AddNightImage_04.Visibility = Visibility.Visible;
                AddNightImage_05.IsEnabled = false;
                AddNightImage_05.Visibility = Visibility.Visible;
                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }

        private async void AddNightImage_03_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage3 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage3 = await fileName.CopyAsync(temp, "Theme_Night_3_Theme" + fileName.FileType);
                    AddNightImage_04.IsEnabled = true;

                    AddNightImage_03.Content = fileName.Name;
                    nightNumber = "3";
                }
            }
            else
            {
                if (NightImage3 != null)
                {
                    await NightImage3.DeleteAsync();
                    NightImage3 = null;
                }
                if (NightImage4 != null)
                {
                    await NightImage4.DeleteAsync();
                    NightImage4 = null;
                }
                if (NightImage5 != null)
                {
                    await NightImage5.DeleteAsync();
                    NightImage5 = null;
                }
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "2";

                AddNightImage_03.Content = "Add 3.rd Night Image";
                AddNightImage_04.Content = "Add 4.th Night Image";
                AddNightImage_05.Content = "Add 5.th Night Image";
                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_04.IsEnabled = false;
                AddNightImage_04.Visibility = Visibility.Visible;
                AddNightImage_05.IsEnabled = false;
                AddNightImage_05.Visibility = Visibility.Visible;
                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }

        private async void AddNightImage_04_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage4 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage4 = await fileName.CopyAsync(temp, "Theme_Night_4_Theme" + fileName.FileType);
                    AddNightImage_05.IsEnabled = true;

                    AddNightImage_04.Content = fileName.Name;
                    nightNumber = "4";
                }
            }
            else
            {
                if (NightImage4 != null)
                {
                    await NightImage4.DeleteAsync();
                    NightImage4 = null;
                }
                if (NightImage5 != null)
                {
                    await NightImage5.DeleteAsync();
                    NightImage5 = null;
                }
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "3";

                AddNightImage_04.Content = "Add 4.th Night Image";
                AddNightImage_05.Content = "Add 5.th Night Image";
                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_05.IsEnabled = false;
                AddNightImage_05.Visibility = Visibility.Visible;
                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_05_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage5 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage5 = await fileName.CopyAsync(temp, "Theme_Night_5_Theme" + fileName.FileType);
                    AddNightImage_06.IsEnabled = true;

                    AddNightImage_05.Content = fileName.Name;
                    nightNumber = "5";
                }
            }
            else
            {
                if (NightImage5 != null)
                {
                    await NightImage5.DeleteAsync();
                    NightImage5 = null;
                }
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "4";

                AddNightImage_05.Content = "Add 5.th Night Image";
                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_06.IsEnabled = false;
                AddNightImage_06.Visibility = Visibility.Visible;
                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_06_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage6 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage6 = await fileName.CopyAsync(temp, "Theme_Night_6_Theme" + fileName.FileType);
                    AddNightImage_07.IsEnabled = true;
                    AddNightImage_06.Content = fileName.Name;
                    nightNumber = "6";
                }
            }
            else
            {
                if (NightImage6 != null)
                {
                    await NightImage6.DeleteAsync();
                    NightImage6 = null;
                }
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "5";

                AddNightImage_06.Content = "Add 6.th Night Image";
                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_07.IsEnabled = false;
                AddNightImage_07.Visibility = Visibility.Visible;
                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_07_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage7 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage7 = await fileName.CopyAsync(temp, "Theme_Night_7_Theme" + fileName.FileType);
                    AddNightImage_08.IsEnabled = true;
                    AddNightImage_07.Content = fileName.Name;
                    nightNumber = "7";
                }
            }
            else
            {
                if (NightImage7 != null)
                {
                    await NightImage7.DeleteAsync();
                    NightImage7 = null;
                }
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "6";

                AddNightImage_07.Content = "Add 7.th Night Image";
                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_08.IsEnabled = false;
                AddNightImage_08.Visibility = Visibility.Visible;
                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_08_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage8 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage8 = await fileName.CopyAsync(temp, "Theme_Night_8_Theme" + fileName.FileType);
                    AddNightImage_09.IsEnabled = true;
                    AddNightImage_08.Content = fileName.Name;
                    nightNumber = "8";
                }
            }
            else
            {
                if (NightImage8 != null)
                {
                    await NightImage8.DeleteAsync();
                    NightImage8 = null;
                }
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "7";

                AddNightImage_08.Content = "Add 8.th Night Image";
                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_09.IsEnabled = false;
                AddNightImage_09.Visibility = Visibility.Visible;
                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_09_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage9 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage9 = await fileName.CopyAsync(temp, "Theme_Night_9_Theme" + fileName.FileType);
                    AddNightImage_10.IsEnabled = true;
                    AddNightImage_09.Content = fileName.Name;
                    nightNumber = "9";
                }
            }
            else
            {
                if (NightImage9 != null)
                {
                    await NightImage9.DeleteAsync();
                    NightImage9 = null;
                }
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "8";

                AddNightImage_09.Content = "Add 9.th Night Image";
                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_10.IsEnabled = false;
                AddNightImage_10.Visibility = Visibility.Visible;
                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_10_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage10 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage10 = await fileName.CopyAsync(temp, "Theme_Night_10_Theme" + fileName.FileType);
                    AddNightImage_11.IsEnabled = true;

                    AddNightImage_10.Content = fileName.Name;
                    nightNumber = "10";
                }
            }
            else
            {
                if (NightImage10 != null)
                {
                    await NightImage10.DeleteAsync();
                    NightImage10 = null;
                }
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "9";

                AddNightImage_10.Content = "Add 10.th Night Image";
                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_11.IsEnabled = false;
                AddNightImage_11.Visibility = Visibility.Visible;
                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }

        }
        private async void AddNightImage_11_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage11 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage11 = await fileName.CopyAsync(temp, "Theme_Night_11_Theme" + fileName.FileType);
                    AddNightImage_12.IsEnabled = true;
                    AddNightImage_11.Content = fileName.Name;
                    nightNumber = "11";
                }
            }
            else
            {
                if (NightImage11 != null)
                {
                    await NightImage11.DeleteAsync();
                    NightImage11 = null;
                }
                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "10";


                AddNightImage_11.Content = "Add 11.th Night Image";
                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_12.IsEnabled = false;
                AddNightImage_12.Visibility = Visibility.Visible;
                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_12_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage12 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage12 = await fileName.CopyAsync(temp, "Theme_Night_12_Theme" + fileName.FileType);
                    AddNightImage_13.IsEnabled = true;
                    AddNightImage_12.Content = fileName.Name;
                    nightNumber = "12";
                }
            }
            else
            {

                if (NightImage12 != null)
                {
                    await NightImage12.DeleteAsync();
                    NightImage12 = null;
                }
                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "11";

                AddNightImage_12.Content = "Add 12.th Night Image";
                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_13.IsEnabled = false;
                AddNightImage_13.Visibility = Visibility.Visible;
                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_13_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage13 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage13 = await fileName.CopyAsync(temp, "Theme_Night_13_Theme" + fileName.FileType);
                    AddNightImage_14.IsEnabled = true;
                    AddNightImage_13.Content = fileName.Name;
                    nightNumber = "13";
                }
            }
            else
            {

                if (NightImage13 != null)
                {
                    await NightImage13.DeleteAsync();
                    NightImage13 = null;
                }
                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "12";

                AddNightImage_13.Content = "Add 13.th Night Image";
                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_14.IsEnabled = false;
                AddNightImage_14.Visibility = Visibility.Visible;
                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_14_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage14 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage14 = await fileName.CopyAsync(temp, "Theme_Night_14_Theme" + fileName.FileType);
                    AddNightImage_15.IsEnabled = true;
                    AddNightImage_14.Content = fileName.Name;
                    nightNumber = "14";
                }
            }
            else
            {

                if (NightImage14 != null)
                {
                    await NightImage14.DeleteAsync();
                    NightImage14 = null;
                }
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "13";

                AddNightImage_14.Content = "Add 14.th Night Image";
                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_15.IsEnabled = false;
                AddNightImage_15.Visibility = Visibility.Visible;
                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_15_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage15 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage15 = await fileName.CopyAsync(temp, "Theme_Night_15_Theme" + fileName.FileType);
                    AddNightImage_16.IsEnabled = true;
                    AddNightImage_15.Content = fileName.Name;
                    nightNumber = "15";
                }
            }
            else
            {
                if (NightImage15 != null)
                {
                    await NightImage15.DeleteAsync();
                    NightImage15 = null;
                }
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "14";

                AddNightImage_15.Content = "Add 15.th Night Image";
                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_16.IsEnabled = false;
                AddNightImage_16.Visibility = Visibility.Visible;
                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_16_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage16 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage16 = await fileName.CopyAsync(temp, "Theme_Night_16_Theme" + fileName.FileType);
                    AddNightImage_17.IsEnabled = true;
                    AddNightImage_16.Content = fileName.Name;
                    nightNumber = "16";
                }
            }
            else
            {
                if (NightImage16 != null)
                {
                    await NightImage16.DeleteAsync();
                    NightImage16 = null;
                }
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "15";

                AddNightImage_16.Content = "Add 16.th Night Image";
                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_17.IsEnabled = false;
                AddNightImage_17.Visibility = Visibility.Visible;
                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_17_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage17 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage17 = await fileName.CopyAsync(temp, "Theme_Night_17_Theme" + fileName.FileType);
                    AddNightImage_18.IsEnabled = true;
                    AddNightImage_17.Content = fileName.Name;
                    nightNumber = "17";
                }
            }
            else
            {
                if (NightImage17 != null)
                {
                    await NightImage17.DeleteAsync();
                    NightImage17 = null;
                }
                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "16";

                AddNightImage_17.Content = "Add 17.th Night Image";
                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_18.IsEnabled = false;
                AddNightImage_18.Visibility = Visibility.Visible;
                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_18_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage18 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage18 = await fileName.CopyAsync(temp, "Theme_Night_18_Theme" + fileName.FileType);
                    AddNightImage_19.IsEnabled = true;
                    AddNightImage_18.Content = fileName.Name;
                    nightNumber = "18";
                }
            }
            else
            {

                if (NightImage18 != null)
                {
                    await NightImage18.DeleteAsync();
                    NightImage18 = null;
                }
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "17";

                AddNightImage_18.Content = "Add 18.th Night Image";
                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_19_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage19 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage19 = await fileName.CopyAsync(temp, "Theme_Night_19_Theme" + fileName.FileType);
                    AddNightImage_20.IsEnabled = true;
                    AddNightImage_19.Content = fileName.Name;
                    nightNumber = "19";
                }
            }
            else
            {
                if (NightImage19 != null)
                {
                    await NightImage19.DeleteAsync();
                    NightImage19 = null;
                }
                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "18";

                AddNightImage_19.Content = "Add 19.th Night Image";
                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_19.IsEnabled = false;
                AddNightImage_19.Visibility = Visibility.Visible;
                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }
        private async void AddNightImage_20_Click(object sender, RoutedEventArgs e)
        {
            if (NightImage20 == null)
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
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightImage20 = await fileName.CopyAsync(temp, "Theme_Night_20_Theme" + fileName.FileType);
                    AddNightImage_20.Content = fileName.Name;
                    nightNumber = "20";
                }
            }
            else
            {

                if (NightImage20 != null)
                {
                    await NightImage20.DeleteAsync();
                    NightImage20 = null;
                }

                nightNumber = "19";

                AddNightImage_20.Content = "Add 20.th Night Image";

                AddNightImage_20.IsEnabled = false;
                AddNightImage_20.Visibility = Visibility.Visible;
            }
        }





        private async void AddDayIcon_Click(object sender, RoutedEventArgs e)
        {
            if (DayIcon == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    DayIcon = await fileName.CopyAsync(temp, "Thumnail_Day" + fileName.FileType);
                    AddDayIcon.Visibility = Visibility.Collapsed;
                    AddDayIcon.Content = fileName.Name;
                    DayImageIcon.Visibility = Visibility.Visible;
                    DayImageIcon.Source = await StorageFileToBitmapImage(DayIcon);
                }
            }
            else
            {
                if (DayIcon != null)
                {
                    await DayIcon.DeleteAsync();
                    DayIcon = null;
                    AddDayIcon.Content = "Add Theme Day Icon";
                    DayImageIcon.Visibility = Visibility.Visible;
                    DayImageIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/DayPlaceHolder.png"));
                }
            }
            
        }
        private async void AddNightIcon_Click(object sender, RoutedEventArgs e)
        {
            if (NightIcon == null)
            {
                FileOpenPicker pickerWallpaper = new FileOpenPicker();
                pickerWallpaper.ViewMode = PickerViewMode.Thumbnail;
                pickerWallpaper.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
                StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
                StorageFile fileName = await pickerWallpaper.PickSingleFileAsync();
                if (fileName != null)
                {
                    NightIcon = await fileName.CopyAsync(temp, "Thumnail_Night" + fileName.FileType);
                    AddNightIcon.Visibility = Visibility.Collapsed;
                    AddNightIcon.Content = fileName.Name;
                    NightImageIcon.Visibility = Visibility.Visible;
                    NightImageIcon.Source = await StorageFileToBitmapImage(NightIcon);
                }
            }
            else
            {
                if (NightIcon != null)
                {
                    await NightIcon.DeleteAsync();

                    AddNightIcon.Visibility = Visibility.Visible;
                    AddNightIcon.Content = "Add Theme Night Icon";

                    NightImageIcon.Visibility = Visibility.Visible;
                    NightImageIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/NightPlaceHolder.png"));
                }
            }
        }

        private async void SaveToFile(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
            StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
            StorageFile themeConfiguration = await temp.CreateFileAsync("Theme.Config", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string[] lines = { dayNumber, nightNumber, ThemeName.Text, ThemeTextBox1.Text, ThemeTextBox2.Text, ThemeTextBox3.Text, ThemeTextBox4.Text, ThemeTextBox5.Text };
            File.WriteAllLines(themeConfiguration.Path, lines);

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");


            if (DayImage1 != null && DayImage2 != null && NightImage1 != null && NightImage2 != null && dayNumber != null && nightNumber != null && NightImageIcon != null && DayImageIcon != null)
            {
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder != null)
                {

                    StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                    await Task.Run(() =>
                    {
                        try
                        {
                            ZipFile.CreateFromDirectory(temp.Path, $"{folder.Path}\\{Guid.NewGuid()}.udt");
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
            await localFolder.CreateFolderAsync("96ab317b", CreationCollisionOption.OpenIfExists);
            StorageFolder temp = await localFolder.GetFolderAsync("96ab317b");
            StorageFile themeConfiguration = await temp.CreateFileAsync("Theme.Config", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string[] lines = { dayNumber, nightNumber, ThemeName.Text, ThemeTextBox1.Text, ThemeTextBox2.Text, ThemeTextBox3.Text, ThemeTextBox4.Text, ThemeTextBox5.Text };
            File.WriteAllLines(themeConfiguration.Path, lines);
            StorageFolder createdynamicFolder = await localFolder.CreateFolderAsync("212b8071", CreationCollisionOption.OpenIfExists);
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
            StorageFolder storage = await dynamicFolder.CreateFolderAsync(ThemeName.Text, CreationCollisionOption.GenerateUniqueName);

            if (DayImage1 != null && DayImage2 != null && NightImage1 != null && NightImage2 != null && dayNumber != null && nightNumber != null && NightImageIcon != null && DayImageIcon != null)
            {
                var storagefiles = await temp.GetFilesAsync();

                foreach (StorageFile storagefile in storagefiles)
                {
                    await storagefile.CopyAsync(storage);
                    SaveThame.IsEnabled = false;
                }
            }
        }




        public static async Task<BitmapImage> StorageFileToBitmapImage(StorageFile savedStorageFile)
        {
            using (IRandomAccessStream fileStream = await savedStorageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelHeight = 100;
                bitmapImage.DecodePixelWidth = 100;
                await bitmapImage.SetSourceAsync(fileStream);
                return bitmapImage;
            }
        }

    }
}
