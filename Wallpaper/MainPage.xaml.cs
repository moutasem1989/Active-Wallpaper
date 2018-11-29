using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.System;
using Windows.System.UserProfile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using WeatherNet.Model;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Wallpaper
{
    public class imageClaz
    {
        public BitmapImage themeArt { get; set; }
    }

    public sealed partial class MainPage : Page
    {
        public ObservableCollection<DynamicWallpaper> DynamicWallpapers = new ObservableCollection<DynamicWallpaper>();
        public ObservableCollection<DynamicWeather> DynamicWeathers = new ObservableCollection<DynamicWeather>();
        public ObservableCollection<ModernWallpaperBitmaps> ModernWallpaperBitmap = new ObservableCollection<ModernWallpaperBitmaps>();
        public ObservableCollection<FlatWallpaperGradients> FlatWallpaperGradient = new ObservableCollection<FlatWallpaperGradients>();
        public ObservableCollection<ModernWallpaperColorBook> ModernWallpaperColors = new ObservableCollection<ModernWallpaperColorBook>();

        private string selectedDynamicThemeName;
        private SingleResult<CurrentWeatherResult> result;

        public MainPage()
        {
            this.InitializeComponent();
            LoadImagesFlatUi();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseItForDesktop"] == "true")
            {
                ApplyToDesktop.IsOn = true;
                ApplyWeatherToDesktop.IsOn = false;
                FlatWallpaperDesktop.IsChecked = false;
            }
            else
            {
                ApplyToDesktop.IsOn = false;
            }
            if ((string)settings.Values["UseItForLockscreen"] == "true")
            {
                ApplyToLockscreen.IsOn = true;
                ApplyWeatherToLockscreen.IsOn = false;
                FlatWallpaperLockscreen.IsChecked = false;
            }
            else
            {
                ApplyToLockscreen.IsOn = false;
            }
            if ((string)settings.Values["UseWeatherForDesktop"] == "true")
            {
                ApplyWeatherToDesktop.IsOn = true;
                ApplyToDesktop.IsOn = false;
                FlatWallpaperDesktop.IsChecked = false;
            }
            else
            {
                ApplyWeatherToDesktop.IsOn = false;
            }
            if ((string)settings.Values["UseWeatherForLockscreen"] == "true")
            {
                ApplyWeatherToLockscreen.IsOn = true;
                ApplyToLockscreen.IsOn = false;
                FlatWallpaperLockscreen.IsChecked = false;
            }
            else
            {
                ApplyWeatherToLockscreen.IsOn = false;
            }
            if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                FlatWallpaperDesktop.IsChecked = true;
                ApplyWeatherToDesktop.IsOn = false;
                ApplyToDesktop.IsOn = false;
            }
            else
            {
                FlatWallpaperDesktop.IsChecked = false;
            }
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                FlatWallpaperLockscreen.IsChecked = true;
                ApplyToLockscreen.IsOn = false;
                ApplyWeatherToLockscreen.IsOn = false;
            }
            else
            {
                FlatWallpaperLockscreen.IsChecked = false;
            }
            if ((string)settings.Values["UseNightMode"] == "true")
            {
                NightModeEnabled.IsChecked = true;
            }
            else
            {
                NightModeEnabled.IsChecked = false;
            }
        }
        private async Task LoadImagesFlatUi()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            
            if ((string)settings.Values["FlatWallpaperAcent"] == null)
            {
                settings.Values["FlatWallpaperAcent"] = "#c12d0f";
            }
            if ((string)settings.Values["FlatWallpaperColor"] == null)
            {
                settings.Values["FlatWallpaperColor"] = "#242526";
            }
            if ((string)settings.Values["ColorIdNumber"] == null)
            {
                settings.Values["ColorIdNumber"] = "10";
            }
            if ((string)settings.Values["DayOrNight"] == null)
            {
                settings.Values["DayOrNight"] = "Day";
            }
            if ((string)settings.Values["BackgroundTaskSliderValue"] == null)
            {
                settings.Values["BackgroundTaskSliderValue"] = "30";
                BackgroundTaskSlider.Value = Int32.Parse((string)settings.Values["BackgroundTaskSliderValue"]);
            }
            else
            {
                BackgroundTaskSlider.Value = Int32.Parse((string)settings.Values["BackgroundTaskSliderValue"]);
            }
            if ((string)settings.Values["UseDynamicAccent"] == "true")
            {
                string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
                string acent = flatWallpaperAcent.Replace("#", "");
                if (acent.Length == 6)
                {
                    SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            else
            {
                string flatWallpaperAcentTest = (string)settings.Values["FlatWallpaperAcent"];
                string acent = flatWallpaperAcentTest.Replace("#", "");
                if (acent.Length == 6)
                {
                    SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            if ((string)settings.Values["UseDynamicColor"] == "true")
            {
                string flatWallpaperColor = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
                string color = flatWallpaperColor.Replace("#", "");
                if (color.Length == 6)
                {
                    SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            else
            {
                string flatWallpaperColorTest = (string)settings.Values["FlatWallpaperColor"];
                string color = flatWallpaperColorTest.Replace("#", "");
                if (color.Length == 6)
                {
                    SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            await LookForFlatWallpaperThumnails();
            await ThemeIconButtonAsync();
            await WeatherIconLoad();

            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#b71c1c"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#c62828"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#d32f2f"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#e53935"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#f44336"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#ef5350"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#e57373"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#ef9a9a"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#880E4F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#AD1457"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#C2185B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#D81B60"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#E91E63"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#EC407A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F06292"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F48FB1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4A148C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#6A1B9A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#7B1FA2"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#8E24AA"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9C27B0"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#AB47BC"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#BA68C8"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#CE93D8"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#311B92"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4527A0"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#512DA8"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#5E35B1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#673AB7"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#7E57C2"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9575CD"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#B39DDB"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#1A237E"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#283593"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#303F9F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#3949AB"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#3F51B5"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#5C6BC0"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#7986CB"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9FA8DA"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#0D47A1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#1565C0"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#1976D2"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#1E88E5"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#2196F3"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#42A5F5"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#64B5F6"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#90CAF9"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#01579B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#0277BD"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#0288D1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#039BE5"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#03A9F4"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#29B6F6"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4FC3F7"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#81D4FA"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#006064"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00838F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#0097A7"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00ACC1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00BCD4"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#26C6DA"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4DD0E1"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#80DEEA"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#004D40"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00695C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00796B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#00897B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#009688"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#26A69A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4DB6AC"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#80CBC4"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#1B5E20"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#2E7D32"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#388E3C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#43A047"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4CAF50"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#66BB6A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#81C784"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#A5D6A7"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#33691E"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#558B2F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#689F38"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#7CB342"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#8BC34A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9CCC65"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#AED581"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#C5E1A5"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#827717"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9E9D24"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#AFB42B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#C0CA33"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#CDDC39"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#D4E157"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#DCE775"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#E6EE9C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F57F17"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F9A825"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FBC02D"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FDD835"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFEB3B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFEE58"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFF176"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFF59D"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF6F00"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF8F00"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFA000"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFB300"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFC107"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFCA28"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFD54F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFE082"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#E65100"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#EF6C00"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F57C00"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FB8C00"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF9800"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFA726"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFB74D"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFCC80"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#BF360C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#D84315"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#E64A19"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#F4511E"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF5722"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF7043"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FF8A65"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#FFAB91"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#3E2723"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#4E342E"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#5D4037"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#6D4C41"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#795548"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#8D6E63"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#A1887F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#BCAAA4"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#212121"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#424242"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#616161"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#757575"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#9E9E9E"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#BDBDBD"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#E0E0E0"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#EEEEEE"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#263238"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#37474F"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#455A64"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#546E7A"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#607D8B"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#78909C"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#90A4AE"));
            ModernWallpaperColors.Add(new ModernWallpaperColorBook("#B0BEC5"));
            ColorBackA.Source = new BitmapImage(new Uri("ms-appx:///Assets/SunSetColors.png"));
            AccentBackA.Source = new BitmapImage(new Uri("ms-appx:///Assets/SunSetColors.png"));
            ColorBackB.Source = new BitmapImage(new Uri("ms-appx:///Assets/colorsScale2.png"));
            AccentBackB.Source = new BitmapImage(new Uri("ms-appx:///Assets/colorsScale2.png"));
            ColorBackC.Source = new BitmapImage(new Uri("ms-appx:///Assets/colorsScale3.png"));
            AccentBackC.Source = new BitmapImage(new Uri("ms-appx:///Assets/colorsScale3.png"));
            
            await AddDefaultThemes();
            UnRegisterBackgroundTask();
            await RequestBackgroundAccess();

            if ((string)settings.Values["UsePosition"] == "true")
            {
                useUserPosition.IsOn = true;
                await Library.GetLocation.GetLocationTask();
                await LookForFlatWallpaperThumnails();
                await ThemeIconButtonAsync();
                await WeatherIconLoad();
            }
            else
            {
                useUserPosition.IsOn = false;
            }
        }
        private async void launchURI(object sender, RoutedEventArgs e)
        {
            var uriBing = new Uri(@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=AGPHY9JHE5NKA");
            var success = await Launcher.LaunchUriAsync(uriBing);
        }
        private async Task WeatherIconLoad()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["Weather"] != null && (string)settings.Values["Weather"] != "")
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("dw2b8071");
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Weather"]);
                StorageFile imageSource = await themeFolder.GetFileAsync("Thumnail.png");
                imageClaz obj = new imageClaz();
                obj.themeArt = new BitmapImage(new Uri(imageSource.Path, UriKind.Absolute));
                LoadedWeatherImage.Source = obj.themeArt;
                StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
                string[] lines = System.IO.File.ReadAllLines(themeConfiguration.Path);
                DynamicWeatherNameTitle.Text = lines[0];
                WeatherTextGroupFirst.Text = lines[1];
                WeatherTextGroupSecond.Text = lines[2];
                WeatherTextGroupThird.Text = lines[3];
                WeatherTextGroupFourth.Text = lines[4];
                WeatherTextGroupFifth.Text = lines[5];
            }
            else
            {
                settings.Values["Weather"] = null;
                LoadedWeatherImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/placeholder-Weather.png"));
                DynamicWeatherNameTitle.Text = "Choose a theme!";
                WeatherTextGroupFirst.Text = "Ýou Will Find Your Theme Info Here.";
            }
        }
        private async Task ThemeIconButtonAsync()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["Theme"] != null)
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
                if ((string)settings.Values["UseNightMode"] == "true")
                {
                    StorageFile imageSource = await themeFolder.GetFileAsync("Thumnail_Night.png");
                    imageClaz obj = new imageClaz();
                    obj.themeArt = new BitmapImage(new Uri(imageSource.Path, UriKind.Absolute));
                    LoadedThemeImage.Source = obj.themeArt;
                }
                else
                {
                    StorageFile imageSource = await themeFolder.GetFileAsync($"Thumnail_{(string)settings.Values["DayOrNight"]}.png");
                    imageClaz obj = new imageClaz();
                    obj.themeArt = new BitmapImage(new Uri(imageSource.Path, UriKind.Absolute));
                    LoadedThemeImage.Source = obj.themeArt;
                }

                StorageFile themeConfiguration = await themeFolder.GetFileAsync("Theme.Config");
                string[] lines = System.IO.File.ReadAllLines(themeConfiguration.Path);
                DynamicThemeNameTitle.Text = lines[2];
                TextGroupFirst.Text = lines[3];
                TextGroupSecond.Text = lines[4];
                TextGroupThird.Text = lines[5];
                TextGroupFourth.Text = lines[6];
                TextGroupFifth.Text = lines[7];
            }
            else
            {
                settings.Values["Theme"] = null;
                TextGroupFirst.Text = "Ýou Will Find Your Theme Info Here.";
                DynamicThemeNameTitle.Text = "Choose a Theme.";
                LoadedThemeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/placeholder-Dynamic.png"));
            }
        }
        private void RefreshMainPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void FilePickerWallpaperDynamic(object sender, RoutedEventArgs e)
        {
            FileOpenPicker pickerWallpaperDynamic = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            pickerWallpaperDynamic.FileTypeFilter.Add(".udt");

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.CreateFolderAsync("212b8071", CreationCollisionOption.OpenIfExists);
            StorageFile fileName = await pickerWallpaperDynamic.PickSingleFileAsync();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (fileName != null)
            {
                selectedDynamicThemeName = Path.GetFileNameWithoutExtension(fileName.Name);
                StorageFolder addedTheme = await dynamicFolder.CreateFolderAsync(selectedDynamicThemeName, CreationCollisionOption.ReplaceExisting);
                settings.Values["Theme"] = selectedDynamicThemeName;
                Stream themeZipFile = await fileName.OpenStreamForReadAsync();
                ZipArchive archive = new ZipArchive(themeZipFile);
                archive.ExtractToDirectory(addedTheme.Path);
                await ThemeIconButtonAsync();
                await ThemeIconButtonAsync();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
            else
            {
                await ThemeIconButtonAsync();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
        }
        private async void FilePickerWeatherDynamic(object sender, RoutedEventArgs e)
        {
            FileOpenPicker pickerWallpaperDynamic = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            pickerWallpaperDynamic.FileTypeFilter.Add(".udw");

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.CreateFolderAsync("dw2b8071", CreationCollisionOption.OpenIfExists);
            StorageFile fileName = await pickerWallpaperDynamic.PickSingleFileAsync();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (fileName != null)
            {
                selectedDynamicThemeName = Path.GetFileNameWithoutExtension(fileName.Name);
                StorageFolder addedTheme = await dynamicFolder.CreateFolderAsync(selectedDynamicThemeName, CreationCollisionOption.ReplaceExisting);
                settings.Values["Weather"] = selectedDynamicThemeName;
                Stream themeZipFile = await fileName.OpenStreamForReadAsync();
                ZipArchive archive = new ZipArchive(themeZipFile);
                archive.ExtractToDirectory(addedTheme.Path);
                await ThemeIconButtonAsync();
                await WeatherIconLoad();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
            else
            {
                await WeatherIconLoad();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
        }
        private async void DeleteTheme_Click(object sender, RoutedEventArgs e)
        {
            FlyoutDynamicDelete.Hide();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
            if (await dynamicFolder.TryGetItemAsync((string)settings.Values["Theme"]) != null)
            {
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Theme"]);
                await themeFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
            settings.Values["Theme"] = null;
            await DynamicLoad();
            await ThemeIconButtonAsync();
        }
        private async void DeleteThemeWeather_Click(object sender, RoutedEventArgs e)
        {
            FlyoutDeleteWeather.Hide();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.GetFolderAsync("dw2b8071");
            if (await dynamicFolder.TryGetItemAsync((string)settings.Values["Weather"]) != null)
            {
                StorageFolder themeFolder = await dynamicFolder.GetFolderAsync((string)settings.Values["Weather"]);
                await themeFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
            settings.Values["Weather"] = null;
            await LoadWeather();
            await WeatherIconLoad();
        }
        private async void LoadDynamicThemeCollection(object sender, RoutedEventArgs e)
        {
            await DynamicLoad();
        }
        private async Task DynamicLoad()
        {
            DynamicWallpapers.Clear();
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            IStorageItem storageItem = await localFolder.TryGetItemAsync("212b8071");
            if (storageItem != null)
            {
                ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
                var queryOption = new QueryOptions { FolderDepth = FolderDepth.Deep };
                var dynamicSubFolders = await dynamicFolder.CreateFolderQueryWithOptions(queryOption).GetFoldersAsync();
                foreach (StorageFolder dynamicSubFolder in dynamicSubFolders)
                {
                    if ((string)settings.Values["DayOrNight"] == "Night")
                    {
                        DynamicWallpapers.Add(new DynamicWallpaper(dynamicSubFolder.Name, new BitmapImage(new Uri(dynamicSubFolder.Path + "/Thumnail_Night.png"))));
                    }
                    else if ((string)settings.Values["UseNightMode"] == "true")
                    {
                        DynamicWallpapers.Add(new DynamicWallpaper(dynamicSubFolder.Name, new BitmapImage(new Uri(dynamicSubFolder.Path + "/Thumnail_Night.png"))));
                    }
                    else
                    {
                        DynamicWallpapers.Add(new DynamicWallpaper(dynamicSubFolder.Name, new BitmapImage(new Uri(dynamicSubFolder.Path + "/Thumnail_Day.png"))));
                    }
                }
            }
        }
        private async void LoadDynamicWeatherCollection(object sender, RoutedEventArgs e)
        {
            await LoadWeather();
        }
        private async Task LoadWeather()
        {
            DynamicWeathers.Clear();
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            IStorageItem storageItem = await localFolder.TryGetItemAsync("dw2b8071");
            if (storageItem != null)
            {
                StorageFolder dynamicFolder = await localFolder.GetFolderAsync("dw2b8071");
                var queryOption = new QueryOptions { FolderDepth = FolderDepth.Deep };
                var dynamicSubFolders = await dynamicFolder.CreateFolderQueryWithOptions(queryOption).GetFoldersAsync();
                foreach (StorageFolder dynamicSubFolder in dynamicSubFolders)
                {
                    DynamicWeathers.Add(new DynamicWeather(dynamicSubFolder.Name, new BitmapImage(new Uri(dynamicSubFolder.Path + "/Thumnail.png"))));
                }
            }
        }
        private async void UnloadDynamicTheme(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["Theme"] = null;
            await ThemeIconButtonAsync();
        }
        private async void UnloadDynamicWeather(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["Weather"] = null;
            await WeatherIconLoad();
        }
        private async void DynamicThemeSelect(object sender, ItemClickEventArgs e)
        {
            var theme = (DynamicWallpaper)e.ClickedItem;
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["Theme"] = theme.DynamicThemeName;
            await ThemeIconButtonAsync();
            if ((string)settings.Values["UsePosition"] == "true")
            {
                await Library.GetLocation.GetLocationTask();
            }
        }
        private async void WeatherThemeSelect(object sender, ItemClickEventArgs e)
        {
            var theme = (DynamicWeather)e.ClickedItem;
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["Weather"] = theme.DynamicThemeName;
            await WeatherIconLoad();
            if ((string)settings.Values["UsePosition"] == "true")
            {
                await Library.GetLocation.GetLocationTask();
            }
        }
        private async void FlatWallpaperColorSelect(object sender, ItemClickEventArgs e)
        {
            var theme = (ModernWallpaperColorBook)e.ClickedItem;
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

            if ((string)settings.Values["UseDynamicAccent"] != "true")
            {
                settings.Values["UseDynamicModern"] = "false";
            }
            settings.Values["UseDynamicColor"] = "false";
            settings.Values["FlatWallpaperColor"] = theme.ColorCode;
            string color = theme.ColorCode.Replace("#", "");
            if (color.Length == 6)
            {
                SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            ColorFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void FlatWallpaperAcentSelect(object sender, ItemClickEventArgs e)
        {
            var theme = (ModernWallpaperColorBook)e.ClickedItem;
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseDynamicColor"] != "true")
            {
                settings.Values["UseDynamicModern"] = "false";
            }
            settings.Values["UseDynamicAccent"] = "false";
            settings.Values["FlatWallpaperAcent"] = theme.ColorCode;
            string acent = theme.ColorCode.Replace("#", "");
            if (acent.Length == 6)
            {
                SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            AccentFlyout.Hide();
            await LookForFlatWallpaperThumnails();
            
        }
        private async void ModernWallpaperBitmapSelect(object sender, ItemClickEventArgs e)
        {
            var image = (ModernWallpaperBitmaps)e.ClickedItem;
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["SelectedFlatImage"] = image.FolderName;
            if ((string)settings.Values["UseFlatWallpaperLockscreen"] == "true")
            {
                await Library.ModernWallpaper.ChangeWallpaperColors();
            }
            if ((string)settings.Values["UseFlatWallpaperDesktop"] == "true")
            {
                await Library.ModernWallpaper.ChangeWallpaperColors();
            }
        }
        private void RefreshPageAsync()
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void BackgroundTaskApplyClick(object sender, RoutedEventArgs e)
        {
            UnRegisterBackgroundTask();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["BackgroundTaskSliderValue"] = BackgroundTaskSlider.Value.ToString();
            await RequestBackgroundAccess();
        }
        private async Task RequestBackgroundAccess()
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result != BackgroundAccessStatus.DeniedByUser) RegisterBackgroundTask();
        }
        private void RegisterBackgroundTask()
        {
            int howOften = int.Parse(BackgroundTaskSlider.Value.ToString());
            uint oft = Convert.ToUInt32(howOften);

            foreach (var bgTask in BackgroundTaskRegistration.AllTasks)
                if (bgTask.Value.Name == "BackgroundTrigger")
                    bgTask.Value.Unregister(true);
            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = "BackgroundTrigger";
            builder.TaskEntryPoint = "BackgroundTask.BackgroundTaskClass";
            builder.SetTrigger(new TimeTrigger(oft, false));
            builder.AddCondition(new SystemCondition(SystemConditionType.BackgroundWorkCostNotHigh));
            BackgroundTaskRegistration task = builder.Register();
        }
        private void UnRegisterBackgroundTask()
        {
            foreach (var bgTask in BackgroundTaskRegistration.AllTasks)
                if (bgTask.Value.Name == "BackgroundTrigger")
                    bgTask.Value.Unregister(true);
        }
        private async void UserPosition_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (useUserPosition.IsOn == true)
            {
                settings.Values["UsePosition"] = "true";
                await Library.GetLocation.GetLocationTask();
            }
            if (useUserPosition.IsOn == false)
            {
                settings.Values["UsePosition"] = "false";
            }
        }
        private void ApplyWeatherToDesktop_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (ApplyWeatherToDesktop.IsOn == true)
            {
                settings.Values["UseWeatherForDesktop"] = "true";
                settings.Values["UseItForDesktop"] = "false";
                settings.Values["UseFlatWallpaperDesktop"] = "false";
                FlatWallpaperDesktop.IsChecked = false;
                ApplyToDesktop.IsOn = false;
            }
            else
            {
                settings.Values["UseWeatherForDesktop"] = "false";
            }
        }
        private void ApplyToDesktop_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (ApplyToDesktop.IsOn == true)
            {
                settings.Values["UseItForDesktop"] = "true";
                settings.Values["UseWeatherForDesktop"] = "false";
                settings.Values["UseFlatWallpaperDesktop"] = "false";
                FlatWallpaperDesktop.IsChecked = false;
                ApplyWeatherToDesktop.IsOn = false;
            }
            if (ApplyToDesktop.IsOn == false)
            {
                settings.Values["UseItForDesktop"] = "false";
            }
        }
        private void ApplyToLockscreen_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (ApplyToLockscreen.IsOn == true)
            {
                settings.Values["UseItForLockscreen"] = "true";
                settings.Values["UseWeatherForLockscreen"] = "false";
                settings.Values["UseFlatWallpaperLockscreen"] = "false";
                ApplyWeatherToLockscreen.IsOn = false;
                FlatWallpaperLockscreen.IsChecked = false;
            }
            if (ApplyToLockscreen.IsOn == false)
            {
                settings.Values["UseItForLockscreen"] = "false";
            }
        }
        private void ApplyWeatherToLockscreen_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (ApplyWeatherToLockscreen.IsOn == true)
            {
                settings.Values["UseWeatherForLockscreen"] = "true";
                settings.Values["UseItForLockscreen"] = "false";
                settings.Values["UseFlatWallpaperLockscreen"] = "false";
                ApplyToLockscreen.IsOn = false;
                FlatWallpaperLockscreen.IsChecked = false;
            }
            if (ApplyWeatherToLockscreen.IsOn == false)
            {
                settings.Values["UseWeatherForLockscreen"] = "false";
            }
        }
        private void FlatwallpapertoDesktop(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (FlatWallpaperDesktop.IsChecked == true)
            {
                settings.Values["UseFlatWallpaperDesktop"] = "true";
                settings.Values["UseItForDesktop"] = "false";
                settings.Values["UseWeatherForDesktop"] = "false";
                ApplyWeatherToDesktop.IsOn = false;
                ApplyToDesktop.IsOn = false;
            }
            else
            {
                settings.Values["UseFlatWallpaperDesktop"] = "false";
            }
        }
        private void FlatwallpapertoLockscreen(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if (FlatWallpaperLockscreen.IsChecked == true)
            {
                settings.Values["UseFlatWallpaperLockscreen"] = "true";
                settings.Values["UseWeatherForLockscreen"] = "false";
                settings.Values["UseItForLockscreen"] = "false";
                ApplyToLockscreen.IsOn = false;
                ApplyWeatherToLockscreen.IsOn = false;
            }
            else
            {
                settings.Values["UseFlatWallpaperLockscreen"] = "false";
            }
        }
        private async void NightMode_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseNightMode"] == "true")
            {
                settings.Values["UseNightMode"] = "false";
                await ThemeIconButtonAsync();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
            else
            {
                settings.Values["UseNightMode"] = "true";
                await ThemeIconButtonAsync();
                if ((string)settings.Values["UsePosition"] == "true")
                {
                    await Library.GetLocation.GetLocationTask();
                }
            }
        }
        private void CreateDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateDynamicTheme));
        }
        private void CreateDynamicWeatherLocal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateDynamicWeather));
        }
        private async void SwapFlatColors(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UseDynamicAccent"] == "true" && (string)settings.Values["UseDynamicColor"] == "true")
            {
                string swapswap1 = (string)settings.Values["DayFlatColor-1"];
                string swapswap2 = (string)settings.Values["DayFlatColor-2"];
                string swapswap3 = (string)settings.Values["DayFlatColor-3"];
                string swapswap4 = (string)settings.Values["DayFlatColor-4"];
                string swapswap5 = (string)settings.Values["DayFlatColor-5"];
                string swapswap6 = (string)settings.Values["DayFlatColor-6"];
                string swapswap7 = (string)settings.Values["DayFlatColor-7"];
                string swapswap8 = (string)settings.Values["DayFlatColor-8"];
                string swapswap9 = (string)settings.Values["DayFlatColor-9"];
                string swapswap10 = (string)settings.Values["DayFlatColor-10"];
                string swapswap11 = (string)settings.Values["DayFlatColor-11"];
                string swapswap12 = (string)settings.Values["DayFlatColor-12"];
                string swapswap13 = (string)settings.Values["DayFlatColor-13"];
                string swapswap14 = (string)settings.Values["DayFlatColor-14"];
                string swapswap15 = (string)settings.Values["DayFlatColor-15"];
                string swapswap16 = (string)settings.Values["DayFlatColor-16"];
                string swapswap17 = (string)settings.Values["DayFlatColor-17"];
                string swapswap18 = (string)settings.Values["DayFlatColor-18"];
                string swapswap19 = (string)settings.Values["DayFlatColor-19"];
                string swapswap20 = (string)settings.Values["DayFlatColor-20"];
                string swapswap21 = (string)settings.Values["NightFlatColor-1"];
                string swapswap22 = (string)settings.Values["NightFlatColor-2"];
                string swapswap23 = (string)settings.Values["NightFlatColor-3"];
                string swapswap24 = (string)settings.Values["NightFlatColor-4"];
                string swapswap25 = (string)settings.Values["NightFlatColor-5"];
                string swapswap26 = (string)settings.Values["NightFlatColor-6"];
                string swapswap27 = (string)settings.Values["NightFlatColor-7"];
                string swapswap28 = (string)settings.Values["NightFlatColor-8"];
                string swapswap29 = (string)settings.Values["NightFlatColor-9"];
                string swapswap30 = (string)settings.Values["NightFlatColor-10"];
                string swapswap31 = (string)settings.Values["NightFlatColor-11"];
                string swapswap32 = (string)settings.Values["NightFlatColor-12"];
                string swapswap33 = (string)settings.Values["NightFlatColor-13"];
                string swapswap34 = (string)settings.Values["NightFlatColor-14"];
                string swapswap35 = (string)settings.Values["NightFlatColor-15"];
                string swapswap36 = (string)settings.Values["NightFlatColor-16"];
                string swapswap37 = (string)settings.Values["NightFlatColor-17"];
                string swapswap38 = (string)settings.Values["NightFlatColor-18"];
                string swapswap39 = (string)settings.Values["NightFlatColor-19"];
                string swapswap40 = (string)settings.Values["NightFlatColor-20"];

                settings.Values["DayFlatColor-1"] = (string)settings.Values["DayFlatAccent-1"];
                settings.Values["DayFlatColor-2"] = (string)settings.Values["DayFlatAccent-2"];
                settings.Values["DayFlatColor-3"] = (string)settings.Values["DayFlatAccent-3"];
                settings.Values["DayFlatColor-4"] = (string)settings.Values["DayFlatAccent-4"];
                settings.Values["DayFlatColor-5"] = (string)settings.Values["DayFlatAccent-5"];
                settings.Values["DayFlatColor-6"] = (string)settings.Values["DayFlatAccent-6"];
                settings.Values["DayFlatColor-7"] = (string)settings.Values["DayFlatAccent-7"];
                settings.Values["DayFlatColor-8"] = (string)settings.Values["DayFlatAccent-8"];
                settings.Values["DayFlatColor-9"] = (string)settings.Values["DayFlatAccent-9"];
                settings.Values["DayFlatColor-10"] = (string)settings.Values["DayFlatAccent-10"];
                settings.Values["DayFlatColor-11"] = (string)settings.Values["DayFlatAccent-11"];
                settings.Values["DayFlatColor-12"] = (string)settings.Values["DayFlatAccent-12"];
                settings.Values["DayFlatColor-13"] = (string)settings.Values["DayFlatAccent-13"];
                settings.Values["DayFlatColor-14"] = (string)settings.Values["DayFlatAccent-14"];
                settings.Values["DayFlatColor-15"] = (string)settings.Values["DayFlatAccent-15"];
                settings.Values["DayFlatColor-16"] = (string)settings.Values["DayFlatAccent-16"];
                settings.Values["DayFlatColor-17"] = (string)settings.Values["DayFlatAccent-17"];
                settings.Values["DayFlatColor-18"] = (string)settings.Values["DayFlatAccent-18"];
                settings.Values["DayFlatColor-19"] = (string)settings.Values["DayFlatAccent-19"];
                settings.Values["DayFlatColor-20"] = (string)settings.Values["DayFlatAccent-20"];
                settings.Values["NightFlatColor-1"] = (string)settings.Values["NightFlatAccent-1"];
                settings.Values["NightFlatColor-2"] = (string)settings.Values["NightFlatAccent-2"];
                settings.Values["NightFlatColor-3"] = (string)settings.Values["NightFlatAccent-3"];
                settings.Values["NightFlatColor-4"] = (string)settings.Values["NightFlatAccent-4"];
                settings.Values["NightFlatColor-5"] = (string)settings.Values["NightFlatAccent-5"];
                settings.Values["NightFlatColor-6"] = (string)settings.Values["NightFlatAccent-6"];
                settings.Values["NightFlatColor-7"] = (string)settings.Values["NightFlatAccent-7"];
                settings.Values["NightFlatColor-8"] = (string)settings.Values["NightFlatAccent-8"];
                settings.Values["NightFlatColor-9"] = (string)settings.Values["NightFlatAccent-9"];
                settings.Values["NightFlatColor-10"] = (string)settings.Values["NightFlatAccent-10"];
                settings.Values["NightFlatColor-11"] = (string)settings.Values["NightFlatAccent-11"];
                settings.Values["NightFlatColor-12"] = (string)settings.Values["NightFlatAccent-12"];
                settings.Values["NightFlatColor-13"] = (string)settings.Values["NightFlatAccent-13"];
                settings.Values["NightFlatColor-14"] = (string)settings.Values["NightFlatAccent-14"];
                settings.Values["NightFlatColor-15"] = (string)settings.Values["NightFlatAccent-15"];
                settings.Values["NightFlatColor-16"] = (string)settings.Values["NightFlatAccent-16"];
                settings.Values["NightFlatColor-17"] = (string)settings.Values["NightFlatAccent-17"];
                settings.Values["NightFlatColor-18"] = (string)settings.Values["NightFlatAccent-18"];
                settings.Values["NightFlatColor-19"] = (string)settings.Values["NightFlatAccent-19"];
                settings.Values["NightFlatColor-20"] = (string)settings.Values["NightFlatAccent-20"];

                settings.Values["DayFlatAccent-1"] = swapswap1;
                settings.Values["DayFlatAccent-2"] = swapswap2;
                settings.Values["DayFlatAccent-3"] = swapswap3;
                settings.Values["DayFlatAccent-4"] = swapswap4;
                settings.Values["DayFlatAccent-5"] = swapswap5;
                settings.Values["DayFlatAccent-6"] = swapswap6;
                settings.Values["DayFlatAccent-7"] = swapswap7;
                settings.Values["DayFlatAccent-8"] = swapswap8;
                settings.Values["DayFlatAccent-9"] = swapswap9;
                settings.Values["DayFlatAccent-10"] = swapswap10;
                settings.Values["DayFlatAccent-11"] = swapswap11;
                settings.Values["DayFlatAccent-12"] = swapswap12;
                settings.Values["DayFlatAccent-13"] = swapswap13;
                settings.Values["DayFlatAccent-14"] = swapswap14;
                settings.Values["DayFlatAccent-15"] = swapswap15;
                settings.Values["DayFlatAccent-16"] = swapswap16;
                settings.Values["DayFlatAccent-17"] = swapswap17;
                settings.Values["DayFlatAccent-18"] = swapswap18;
                settings.Values["DayFlatAccent-19"] = swapswap19;
                settings.Values["DayFlatAccent-20"] = swapswap20;
                settings.Values["NightFlatAccent-1"] = swapswap21;
                settings.Values["NightFlatAccent-2"] = swapswap22;
                settings.Values["NightFlatAccent-3"] = swapswap23;
                settings.Values["NightFlatAccent-4"] = swapswap24;
                settings.Values["NightFlatAccent-5"] = swapswap25;
                settings.Values["NightFlatAccent-6"] = swapswap26;
                settings.Values["NightFlatAccent-7"] = swapswap27;
                settings.Values["NightFlatAccent-8"] = swapswap28;
                settings.Values["NightFlatAccent-9"] = swapswap29;
                settings.Values["NightFlatAccent-10"] = swapswap30;
                settings.Values["NightFlatAccent-11"] = swapswap31;
                settings.Values["NightFlatAccent-12"] = swapswap32;
                settings.Values["NightFlatAccent-13"] = swapswap33;
                settings.Values["NightFlatAccent-14"] = swapswap34;
                settings.Values["NightFlatAccent-15"] = swapswap35;
                settings.Values["NightFlatAccent-16"] = swapswap36;
                settings.Values["NightFlatAccent-17"] = swapswap37;
                settings.Values["NightFlatAccent-18"] = swapswap38;
                settings.Values["NightFlatAccent-19"] = swapswap39;
                settings.Values["NightFlatAccent-20"] = swapswap40;
            }
            else if ((string)settings.Values["UseDynamicAccent"] != "true" && (string)settings.Values["UseDynamicColor"] == "true")
            {
                settings.Values["UseDynamicAccent"] = "true";
                settings.Values["UseDynamicColor"] = null;

                string swapswap1 = (string)settings.Values["DayFlatColor-1"];
                string swapswap2 = (string)settings.Values["DayFlatColor-2"];
                string swapswap3 = (string)settings.Values["DayFlatColor-3"];
                string swapswap4 = (string)settings.Values["DayFlatColor-4"];
                string swapswap5 = (string)settings.Values["DayFlatColor-5"];
                string swapswap6 = (string)settings.Values["DayFlatColor-6"];
                string swapswap7 = (string)settings.Values["DayFlatColor-7"];
                string swapswap8 = (string)settings.Values["DayFlatColor-8"];
                string swapswap9 = (string)settings.Values["DayFlatColor-9"];
                string swapswap10 = (string)settings.Values["DayFlatColor-10"];
                string swapswap11 = (string)settings.Values["DayFlatColor-11"];
                string swapswap12 = (string)settings.Values["DayFlatColor-12"];
                string swapswap13 = (string)settings.Values["DayFlatColor-13"];
                string swapswap14 = (string)settings.Values["DayFlatColor-14"];
                string swapswap15 = (string)settings.Values["DayFlatColor-15"];
                string swapswap16 = (string)settings.Values["DayFlatColor-16"];
                string swapswap17 = (string)settings.Values["DayFlatColor-17"];
                string swapswap18 = (string)settings.Values["DayFlatColor-18"];
                string swapswap19 = (string)settings.Values["DayFlatColor-19"];
                string swapswap20 = (string)settings.Values["DayFlatColor-20"];
                string swapswap21 = (string)settings.Values["NightFlatColor-1"];
                string swapswap22 = (string)settings.Values["NightFlatColor-2"];
                string swapswap23 = (string)settings.Values["NightFlatColor-3"];
                string swapswap24 = (string)settings.Values["NightFlatColor-4"];
                string swapswap25 = (string)settings.Values["NightFlatColor-5"];
                string swapswap26 = (string)settings.Values["NightFlatColor-6"];
                string swapswap27 = (string)settings.Values["NightFlatColor-7"];
                string swapswap28 = (string)settings.Values["NightFlatColor-8"];
                string swapswap29 = (string)settings.Values["NightFlatColor-9"];
                string swapswap30 = (string)settings.Values["NightFlatColor-10"];
                string swapswap31 = (string)settings.Values["NightFlatColor-11"];
                string swapswap32 = (string)settings.Values["NightFlatColor-12"];
                string swapswap33 = (string)settings.Values["NightFlatColor-13"];
                string swapswap34 = (string)settings.Values["NightFlatColor-14"];
                string swapswap35 = (string)settings.Values["NightFlatColor-15"];
                string swapswap36 = (string)settings.Values["NightFlatColor-16"];
                string swapswap37 = (string)settings.Values["NightFlatColor-17"];
                string swapswap38 = (string)settings.Values["NightFlatColor-18"];
                string swapswap39 = (string)settings.Values["NightFlatColor-19"];
                string swapswap40 = (string)settings.Values["NightFlatColor-20"];

                settings.Values["DayFlatColor-1"] = (string)settings.Values["DayFlatAccent-1"];
                settings.Values["DayFlatColor-2"] = (string)settings.Values["DayFlatAccent-2"];
                settings.Values["DayFlatColor-3"] = (string)settings.Values["DayFlatAccent-3"];
                settings.Values["DayFlatColor-4"] = (string)settings.Values["DayFlatAccent-4"];
                settings.Values["DayFlatColor-5"] = (string)settings.Values["DayFlatAccent-5"];
                settings.Values["DayFlatColor-6"] = (string)settings.Values["DayFlatAccent-6"];
                settings.Values["DayFlatColor-7"] = (string)settings.Values["DayFlatAccent-7"];
                settings.Values["DayFlatColor-8"] = (string)settings.Values["DayFlatAccent-8"];
                settings.Values["DayFlatColor-9"] = (string)settings.Values["DayFlatAccent-9"];
                settings.Values["DayFlatColor-10"] = (string)settings.Values["DayFlatAccent-10"];
                settings.Values["DayFlatColor-11"] = (string)settings.Values["DayFlatAccent-11"];
                settings.Values["DayFlatColor-12"] = (string)settings.Values["DayFlatAccent-12"];
                settings.Values["DayFlatColor-13"] = (string)settings.Values["DayFlatAccent-13"];
                settings.Values["DayFlatColor-14"] = (string)settings.Values["DayFlatAccent-14"];
                settings.Values["DayFlatColor-15"] = (string)settings.Values["DayFlatAccent-15"];
                settings.Values["DayFlatColor-16"] = (string)settings.Values["DayFlatAccent-16"];
                settings.Values["DayFlatColor-17"] = (string)settings.Values["DayFlatAccent-17"];
                settings.Values["DayFlatColor-18"] = (string)settings.Values["DayFlatAccent-18"];
                settings.Values["DayFlatColor-19"] = (string)settings.Values["DayFlatAccent-19"];
                settings.Values["DayFlatColor-20"] = (string)settings.Values["DayFlatAccent-20"];
                settings.Values["NightFlatColor-1"] = (string)settings.Values["NightFlatAccent-1"];
                settings.Values["NightFlatColor-2"] = (string)settings.Values["NightFlatAccent-2"];
                settings.Values["NightFlatColor-3"] = (string)settings.Values["NightFlatAccent-3"];
                settings.Values["NightFlatColor-4"] = (string)settings.Values["NightFlatAccent-4"];
                settings.Values["NightFlatColor-5"] = (string)settings.Values["NightFlatAccent-5"];
                settings.Values["NightFlatColor-6"] = (string)settings.Values["NightFlatAccent-6"];
                settings.Values["NightFlatColor-7"] = (string)settings.Values["NightFlatAccent-7"];
                settings.Values["NightFlatColor-8"] = (string)settings.Values["NightFlatAccent-8"];
                settings.Values["NightFlatColor-9"] = (string)settings.Values["NightFlatAccent-9"];
                settings.Values["NightFlatColor-10"] = (string)settings.Values["NightFlatAccent-10"];
                settings.Values["NightFlatColor-11"] = (string)settings.Values["NightFlatAccent-11"];
                settings.Values["NightFlatColor-12"] = (string)settings.Values["NightFlatAccent-12"];
                settings.Values["NightFlatColor-13"] = (string)settings.Values["NightFlatAccent-13"];
                settings.Values["NightFlatColor-14"] = (string)settings.Values["NightFlatAccent-14"];
                settings.Values["NightFlatColor-15"] = (string)settings.Values["NightFlatAccent-15"];
                settings.Values["NightFlatColor-16"] = (string)settings.Values["NightFlatAccent-16"];
                settings.Values["NightFlatColor-17"] = (string)settings.Values["NightFlatAccent-17"];
                settings.Values["NightFlatColor-18"] = (string)settings.Values["NightFlatAccent-18"];
                settings.Values["NightFlatColor-19"] = (string)settings.Values["NightFlatAccent-19"];
                settings.Values["NightFlatColor-20"] = (string)settings.Values["NightFlatAccent-20"];

                settings.Values["DayFlatAccent-1"] = swapswap1;
                settings.Values["DayFlatAccent-2"] = swapswap2;
                settings.Values["DayFlatAccent-3"] = swapswap3;
                settings.Values["DayFlatAccent-4"] = swapswap4;
                settings.Values["DayFlatAccent-5"] = swapswap5;
                settings.Values["DayFlatAccent-6"] = swapswap6;
                settings.Values["DayFlatAccent-7"] = swapswap7;
                settings.Values["DayFlatAccent-8"] = swapswap8;
                settings.Values["DayFlatAccent-9"] = swapswap9;
                settings.Values["DayFlatAccent-10"] = swapswap10;
                settings.Values["DayFlatAccent-11"] = swapswap11;
                settings.Values["DayFlatAccent-12"] = swapswap12;
                settings.Values["DayFlatAccent-13"] = swapswap13;
                settings.Values["DayFlatAccent-14"] = swapswap14;
                settings.Values["DayFlatAccent-15"] = swapswap15;
                settings.Values["DayFlatAccent-16"] = swapswap16;
                settings.Values["DayFlatAccent-17"] = swapswap17;
                settings.Values["DayFlatAccent-18"] = swapswap18;
                settings.Values["DayFlatAccent-19"] = swapswap19;
                settings.Values["DayFlatAccent-20"] = swapswap20;
                settings.Values["NightFlatAccent-1"] = swapswap21;
                settings.Values["NightFlatAccent-2"] = swapswap22;
                settings.Values["NightFlatAccent-3"] = swapswap23;
                settings.Values["NightFlatAccent-4"] = swapswap24;
                settings.Values["NightFlatAccent-5"] = swapswap25;
                settings.Values["NightFlatAccent-6"] = swapswap26;
                settings.Values["NightFlatAccent-7"] = swapswap27;
                settings.Values["NightFlatAccent-8"] = swapswap28;
                settings.Values["NightFlatAccent-9"] = swapswap29;
                settings.Values["NightFlatAccent-10"] = swapswap30;
                settings.Values["NightFlatAccent-11"] = swapswap31;
                settings.Values["NightFlatAccent-12"] = swapswap32;
                settings.Values["NightFlatAccent-13"] = swapswap33;
                settings.Values["NightFlatAccent-14"] = swapswap34;
                settings.Values["NightFlatAccent-15"] = swapswap35;
                settings.Values["NightFlatAccent-16"] = swapswap36;
                settings.Values["NightFlatAccent-17"] = swapswap37;
                settings.Values["NightFlatAccent-18"] = swapswap38;
                settings.Values["NightFlatAccent-19"] = swapswap39;
                settings.Values["NightFlatAccent-20"] = swapswap40;

                string oldflatWallpaperColor = (string)settings.Values["FlatWallpaperColor"];
                settings.Values["FlatWallpaperColor"] = (string)settings.Values["FlatWallpaperAcent"];
                settings.Values["FlatWallpaperAcent"] = oldflatWallpaperColor;
            }
            else if ((string)settings.Values["UseDynamicAccent"] == "true" && (string)settings.Values["UseDynamicColor"] != "true")
            {
                settings.Values["UseDynamicAccent"] = null;
                settings.Values["UseDynamicColor"] = "true";

                string swapswap1 = (string)settings.Values["DayFlatColor-1"];
                string swapswap2 = (string)settings.Values["DayFlatColor-2"];
                string swapswap3 = (string)settings.Values["DayFlatColor-3"];
                string swapswap4 = (string)settings.Values["DayFlatColor-4"];
                string swapswap5 = (string)settings.Values["DayFlatColor-5"];
                string swapswap6 = (string)settings.Values["DayFlatColor-6"];
                string swapswap7 = (string)settings.Values["DayFlatColor-7"];
                string swapswap8 = (string)settings.Values["DayFlatColor-8"];
                string swapswap9 = (string)settings.Values["DayFlatColor-9"];
                string swapswap10 = (string)settings.Values["DayFlatColor-10"];
                string swapswap11 = (string)settings.Values["DayFlatColor-11"];
                string swapswap12 = (string)settings.Values["DayFlatColor-12"];
                string swapswap13 = (string)settings.Values["DayFlatColor-13"];
                string swapswap14 = (string)settings.Values["DayFlatColor-14"];
                string swapswap15 = (string)settings.Values["DayFlatColor-15"];
                string swapswap16 = (string)settings.Values["DayFlatColor-16"];
                string swapswap17 = (string)settings.Values["DayFlatColor-17"];
                string swapswap18 = (string)settings.Values["DayFlatColor-18"];
                string swapswap19 = (string)settings.Values["DayFlatColor-19"];
                string swapswap20 = (string)settings.Values["DayFlatColor-20"];
                string swapswap21 = (string)settings.Values["NightFlatColor-1"];
                string swapswap22 = (string)settings.Values["NightFlatColor-2"];
                string swapswap23 = (string)settings.Values["NightFlatColor-3"];
                string swapswap24 = (string)settings.Values["NightFlatColor-4"];
                string swapswap25 = (string)settings.Values["NightFlatColor-5"];
                string swapswap26 = (string)settings.Values["NightFlatColor-6"];
                string swapswap27 = (string)settings.Values["NightFlatColor-7"];
                string swapswap28 = (string)settings.Values["NightFlatColor-8"];
                string swapswap29 = (string)settings.Values["NightFlatColor-9"];
                string swapswap30 = (string)settings.Values["NightFlatColor-10"];
                string swapswap31 = (string)settings.Values["NightFlatColor-11"];
                string swapswap32 = (string)settings.Values["NightFlatColor-12"];
                string swapswap33 = (string)settings.Values["NightFlatColor-13"];
                string swapswap34 = (string)settings.Values["NightFlatColor-14"];
                string swapswap35 = (string)settings.Values["NightFlatColor-15"];
                string swapswap36 = (string)settings.Values["NightFlatColor-16"];
                string swapswap37 = (string)settings.Values["NightFlatColor-17"];
                string swapswap38 = (string)settings.Values["NightFlatColor-18"];
                string swapswap39 = (string)settings.Values["NightFlatColor-19"];
                string swapswap40 = (string)settings.Values["NightFlatColor-20"];

                settings.Values["DayFlatColor-1"] = (string)settings.Values["DayFlatAccent-1"];
                settings.Values["DayFlatColor-2"] = (string)settings.Values["DayFlatAccent-2"];
                settings.Values["DayFlatColor-3"] = (string)settings.Values["DayFlatAccent-3"];
                settings.Values["DayFlatColor-4"] = (string)settings.Values["DayFlatAccent-4"];
                settings.Values["DayFlatColor-5"] = (string)settings.Values["DayFlatAccent-5"];
                settings.Values["DayFlatColor-6"] = (string)settings.Values["DayFlatAccent-6"];
                settings.Values["DayFlatColor-7"] = (string)settings.Values["DayFlatAccent-7"];
                settings.Values["DayFlatColor-8"] = (string)settings.Values["DayFlatAccent-8"];
                settings.Values["DayFlatColor-9"] = (string)settings.Values["DayFlatAccent-9"];
                settings.Values["DayFlatColor-10"] = (string)settings.Values["DayFlatAccent-10"];
                settings.Values["DayFlatColor-11"] = (string)settings.Values["DayFlatAccent-11"];
                settings.Values["DayFlatColor-12"] = (string)settings.Values["DayFlatAccent-12"];
                settings.Values["DayFlatColor-13"] = (string)settings.Values["DayFlatAccent-13"];
                settings.Values["DayFlatColor-14"] = (string)settings.Values["DayFlatAccent-14"];
                settings.Values["DayFlatColor-15"] = (string)settings.Values["DayFlatAccent-15"];
                settings.Values["DayFlatColor-16"] = (string)settings.Values["DayFlatAccent-16"];
                settings.Values["DayFlatColor-17"] = (string)settings.Values["DayFlatAccent-17"];
                settings.Values["DayFlatColor-18"] = (string)settings.Values["DayFlatAccent-18"];
                settings.Values["DayFlatColor-19"] = (string)settings.Values["DayFlatAccent-19"];
                settings.Values["DayFlatColor-20"] = (string)settings.Values["DayFlatAccent-20"];
                settings.Values["NightFlatColor-1"] = (string)settings.Values["NightFlatAccent-1"];
                settings.Values["NightFlatColor-2"] = (string)settings.Values["NightFlatAccent-2"];
                settings.Values["NightFlatColor-3"] = (string)settings.Values["NightFlatAccent-3"];
                settings.Values["NightFlatColor-4"] = (string)settings.Values["NightFlatAccent-4"];
                settings.Values["NightFlatColor-5"] = (string)settings.Values["NightFlatAccent-5"];
                settings.Values["NightFlatColor-6"] = (string)settings.Values["NightFlatAccent-6"];
                settings.Values["NightFlatColor-7"] = (string)settings.Values["NightFlatAccent-7"];
                settings.Values["NightFlatColor-8"] = (string)settings.Values["NightFlatAccent-8"];
                settings.Values["NightFlatColor-9"] = (string)settings.Values["NightFlatAccent-9"];
                settings.Values["NightFlatColor-10"] = (string)settings.Values["NightFlatAccent-10"];
                settings.Values["NightFlatColor-11"] = (string)settings.Values["NightFlatAccent-11"];
                settings.Values["NightFlatColor-12"] = (string)settings.Values["NightFlatAccent-12"];
                settings.Values["NightFlatColor-13"] = (string)settings.Values["NightFlatAccent-13"];
                settings.Values["NightFlatColor-14"] = (string)settings.Values["NightFlatAccent-14"];
                settings.Values["NightFlatColor-15"] = (string)settings.Values["NightFlatAccent-15"];
                settings.Values["NightFlatColor-16"] = (string)settings.Values["NightFlatAccent-16"];
                settings.Values["NightFlatColor-17"] = (string)settings.Values["NightFlatAccent-17"];
                settings.Values["NightFlatColor-18"] = (string)settings.Values["NightFlatAccent-18"];
                settings.Values["NightFlatColor-19"] = (string)settings.Values["NightFlatAccent-19"];
                settings.Values["NightFlatColor-20"] = (string)settings.Values["NightFlatAccent-20"];

                settings.Values["DayFlatAccent-1"] = swapswap1;
                settings.Values["DayFlatAccent-2"] = swapswap2;
                settings.Values["DayFlatAccent-3"] = swapswap3;
                settings.Values["DayFlatAccent-4"] = swapswap4;
                settings.Values["DayFlatAccent-5"] = swapswap5;
                settings.Values["DayFlatAccent-6"] = swapswap6;
                settings.Values["DayFlatAccent-7"] = swapswap7;
                settings.Values["DayFlatAccent-8"] = swapswap8;
                settings.Values["DayFlatAccent-9"] = swapswap9;
                settings.Values["DayFlatAccent-10"] = swapswap10;
                settings.Values["DayFlatAccent-11"] = swapswap11;
                settings.Values["DayFlatAccent-12"] = swapswap12;
                settings.Values["DayFlatAccent-13"] = swapswap13;
                settings.Values["DayFlatAccent-14"] = swapswap14;
                settings.Values["DayFlatAccent-15"] = swapswap15;
                settings.Values["DayFlatAccent-16"] = swapswap16;
                settings.Values["DayFlatAccent-17"] = swapswap17;
                settings.Values["DayFlatAccent-18"] = swapswap18;
                settings.Values["DayFlatAccent-19"] = swapswap19;
                settings.Values["DayFlatAccent-20"] = swapswap20;
                settings.Values["NightFlatAccent-1"] = swapswap21;
                settings.Values["NightFlatAccent-2"] = swapswap22;
                settings.Values["NightFlatAccent-3"] = swapswap23;
                settings.Values["NightFlatAccent-4"] = swapswap24;
                settings.Values["NightFlatAccent-5"] = swapswap25;
                settings.Values["NightFlatAccent-6"] = swapswap26;
                settings.Values["NightFlatAccent-7"] = swapswap27;
                settings.Values["NightFlatAccent-8"] = swapswap28;
                settings.Values["NightFlatAccent-9"] = swapswap29;
                settings.Values["NightFlatAccent-10"] = swapswap30;
                settings.Values["NightFlatAccent-11"] = swapswap31;
                settings.Values["NightFlatAccent-12"] = swapswap32;
                settings.Values["NightFlatAccent-13"] = swapswap33;
                settings.Values["NightFlatAccent-14"] = swapswap34;
                settings.Values["NightFlatAccent-15"] = swapswap35;
                settings.Values["NightFlatAccent-16"] = swapswap36;
                settings.Values["NightFlatAccent-17"] = swapswap37;
                settings.Values["NightFlatAccent-18"] = swapswap38;
                settings.Values["NightFlatAccent-19"] = swapswap39;
                settings.Values["NightFlatAccent-20"] = swapswap40;

                string oldflatWallpaperColor = (string)settings.Values["FlatWallpaperColor"];
                settings.Values["FlatWallpaperColor"] = (string)settings.Values["FlatWallpaperAcent"];
                settings.Values["FlatWallpaperAcent"] = oldflatWallpaperColor;
            }
            else
            {
                string oldflatWallpaperColor = (string)settings.Values["FlatWallpaperColor"];
                settings.Values["FlatWallpaperColor"] = (string)settings.Values["FlatWallpaperAcent"];
                settings.Values["FlatWallpaperAcent"] = oldflatWallpaperColor;
            }
            if ((string)settings.Values["UseDynamicAccent"] == "true")
            {
                string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
                string acent = flatWallpaperAcent.Replace("#", "");
                if (acent.Length == 6)
                {
                    SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            else
            {
                string flatWallpaperAcentTest = (string)settings.Values["FlatWallpaperAcent"];
                string acent = flatWallpaperAcentTest.Replace("#", "");
                if (acent.Length == 6)
                {
                    SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            if ((string)settings.Values["UseDynamicColor"] == "true")
            {
                string flatWallpaperColor = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
                string color = flatWallpaperColor.Replace("#", "");
                if (color.Length == 6)
                {
                    SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            else
            {
                string flatWallpaperColorTest = (string)settings.Values["FlatWallpaperColor"];
                string color = flatWallpaperColorTest.Replace("#", "");
                if (color.Length == 6)
                {
                    SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
                }
            }
            await LookForFlatWallpaperThumnails();
        }



        private async void ArchiveDynamicThemeLocal_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            IStorageItem storageItem = await localFolder.TryGetItemAsync("212b8071");
            if (storageItem != null)
            {
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder != null)
                {
                    StorageFolder dynamicFolder = await localFolder.GetFolderAsync("212b8071");
                    var queryOption = new QueryOptions { FolderDepth = FolderDepth.Deep };
                    var dynamicSubFolders = await dynamicFolder.CreateFolderQueryWithOptions(queryOption).GetFoldersAsync();
                    foreach (StorageFolder dynamicSubFolder in dynamicSubFolders)
                    {
                        StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                        await Task.Run(() =>
                        {
                            try
                            {
                                ZipFile.CreateFromDirectory(dynamicSubFolder.Path, $"{folder.Path}\\{Guid.NewGuid()}.udt");
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
        }
        private async void ArchiveDynamicWeatherLocal_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            IStorageItem storageItem = await localFolder.TryGetItemAsync("dw2b8071");
            if (storageItem != null)
            {
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder != null)
                {
                    StorageFolder dynamicFolder = await localFolder.GetFolderAsync("dw2b8071");
                    var queryOption = new QueryOptions { FolderDepth = FolderDepth.Deep };
                    var dynamicSubFolders = await dynamicFolder.CreateFolderQueryWithOptions(queryOption).GetFoldersAsync();
                    foreach (StorageFolder dynamicSubFolder in dynamicSubFolders)
                    {
                        StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                        await Task.Run(() =>
                        {
                            try
                            {
                                ZipFile.CreateFromDirectory(dynamicSubFolder.Path, $"{folder.Path}\\{Guid.NewGuid()}.udw");
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
        }
        private async void DayAndNightSunGradientAccent(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicAccent"] = "true";
            settings.Values["DayFlatAccent-1"] = "#f79347";
            settings.Values["DayFlatAccent-2"] = "#f7a148";
            settings.Values["DayFlatAccent-3"] = "#f7b949";
            settings.Values["DayFlatAccent-4"] = "#f6d14d";
            settings.Values["DayFlatAccent-5"] = "#f5e057";
            settings.Values["DayFlatAccent-6"] = "#f3e767";
            settings.Values["DayFlatAccent-7"] = "#f1e87f";
            settings.Values["DayFlatAccent-8"] = "#eee897";
            settings.Values["DayFlatAccent-9"] = "#ede8ad";
            settings.Values["DayFlatAccent-10"] = "#ebe8bd";
            settings.Values["DayFlatAccent-11"] = "#ebe9c2";
            settings.Values["DayFlatAccent-12"] = "#eeefc2";
            settings.Values["DayFlatAccent-13"] = "#f3f0b8";
            settings.Values["DayFlatAccent-14"] = "#f7f0ac";
            settings.Values["DayFlatAccent-15"] = "#f9f19e";
            settings.Values["DayFlatAccent-16"] = "#f9ee90";
            settings.Values["DayFlatAccent-17"] = "#f3d482";
            settings.Values["DayFlatAccent-18"] = "#ebac70";
            settings.Values["DayFlatAccent-19"] = "#e2825e";
            settings.Values["DayFlatAccent-20"] = "#da5e4f";
            settings.Values["NightFlatAccent-1"] = "#d44444";
            settings.Values["NightFlatAccent-2"] = "#a55d64";
            settings.Values["NightFlatAccent-3"] = "#6a7b8b";
            settings.Values["NightFlatAccent-4"] = "#677d8e";
            settings.Values["NightFlatAccent-5"] = "#677c8e";
            settings.Values["NightFlatAccent-6"] = "#667c8e";
            settings.Values["NightFlatAccent-7"] = "#5e728e";
            settings.Values["NightFlatAccent-8"] = "#4f5e8f";
            settings.Values["NightFlatAccent-9"] = "#3e488f";
            settings.Values["NightFlatAccent-10"] = "#2f328f";
            settings.Values["NightFlatAccent-11"] = "#27268f";
            settings.Values["NightFlatAccent-12"] = "#27238e";
            settings.Values["NightFlatAccent-13"] = "#2b278d";
            settings.Values["NightFlatAccent-14"] = "#322e8d";
            settings.Values["NightFlatAccent-15"] = "#3b398c";
            settings.Values["NightFlatAccent-16"] = "#47438a";
            settings.Values["NightFlatAccent-17"] = "#554f87";
            settings.Values["NightFlatAccent-18"] = "#625a83";
            settings.Values["NightFlatAccent-19"] = "#836a78";
            settings.Values["NightFlatAccent-20"] = "#c3805d";
            string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
            string acent = flatWallpaperAcent.Replace("#", "");
            if (acent.Length == 6)
            {
                SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            AccentFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void DayAndNightSunGradientColor(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicColor"] = "true";
            settings.Values["DayFlatColor-1"] = "#f79347";
            settings.Values["DayFlatColor-2"] = "#f7a148";
            settings.Values["DayFlatColor-3"] = "#f7b949";
            settings.Values["DayFlatColor-4"] = "#f6d14d";
            settings.Values["DayFlatColor-5"] = "#f5e057";
            settings.Values["DayFlatColor-6"] = "#f3e767";
            settings.Values["DayFlatColor-7"] = "#f1e87f";
            settings.Values["DayFlatColor-8"] = "#eee897";
            settings.Values["DayFlatColor-9"] = "#ede8ad";
            settings.Values["DayFlatColor-10"] = "#ebe8bd";
            settings.Values["DayFlatColor-11"] = "#ebe9c2";
            settings.Values["DayFlatColor-12"] = "#eeefc2";
            settings.Values["DayFlatColor-13"] = "#f3f0b8";
            settings.Values["DayFlatColor-14"] = "#f7f0ac";
            settings.Values["DayFlatColor-15"] = "#f9f19e";
            settings.Values["DayFlatColor-16"] = "#f9ee90";
            settings.Values["DayFlatColor-17"] = "#f3d482";
            settings.Values["DayFlatColor-18"] = "#ebac70";
            settings.Values["DayFlatColor-19"] = "#e2825e";
            settings.Values["DayFlatColor-20"] = "#da5e4f";
            settings.Values["NightFlatColor-1"] = "#d44444";
            settings.Values["NightFlatColor-2"] = "#a55d64";
            settings.Values["NightFlatColor-3"] = "#6a7b8b";
            settings.Values["NightFlatColor-4"] = "#677d8e";
            settings.Values["NightFlatColor-5"] = "#677c8e";
            settings.Values["NightFlatColor-6"] = "#667c8e";
            settings.Values["NightFlatColor-7"] = "#5e728e";
            settings.Values["NightFlatColor-8"] = "#4f5e8f";
            settings.Values["NightFlatColor-9"] = "#3e488f";
            settings.Values["NightFlatColor-10"] = "#2f328f";
            settings.Values["NightFlatColor-11"] = "#27268f";
            settings.Values["NightFlatColor-12"] = "#27238e";
            settings.Values["NightFlatColor-13"] = "#2b278d";
            settings.Values["NightFlatColor-14"] = "#322e8d";
            settings.Values["NightFlatColor-15"] = "#3b398c";
            settings.Values["NightFlatColor-16"] = "#47438a";
            settings.Values["NightFlatColor-17"] = "#554f87";
            settings.Values["NightFlatColor-18"] = "#625a83";
            settings.Values["NightFlatColor-19"] = "#836a78";
            settings.Values["NightFlatColor-20"] = "#c3805d";

            string flatWallpaperColor = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
            string color = flatWallpaperColor.Replace("#", "");
            if (color.Length == 6)
            {
                SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            ColorFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void DayAndNightSunGradientAccent2(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicAccent"] = "true";
            settings.Values["DayFlatAccent-1"] = "#f48d3d";
            settings.Values["DayFlatAccent-2"] = "#efa05c";
            settings.Values["DayFlatAccent-3"] = "#eaba87";
            settings.Values["DayFlatAccent-4"] = "#e4d0af";
            settings.Values["DayFlatAccent-5"] = "#e2dcc2";
            settings.Values["DayFlatAccent-6"] = "#e1e4cf";
            settings.Values["DayFlatAccent-7"] = "#dee7db";
            settings.Values["DayFlatAccent-8"] = "#d7e6e4";
            settings.Values["DayFlatAccent-9"] = "#d5e7ea";
            settings.Values["DayFlatAccent-10"] = "#cfe6ef";
            settings.Values["DayFlatAccent-11"] = "#cfe6f0";
            settings.Values["DayFlatAccent-12"] = "#cee4ef";
            settings.Values["DayFlatAccent-13"] = "#d0e2e9";
            settings.Values["DayFlatAccent-14"] = "#d4e3e1";
            settings.Values["DayFlatAccent-15"] = "#dae1d7";
            settings.Values["DayFlatAccent-16"] = "#dfdfc9";
            settings.Values["DayFlatAccent-17"] = "#e3dcbb";
            settings.Values["DayFlatAccent-18"] = "#e7d6a9";
            settings.Values["DayFlatAccent-19"] = "#f0cb83";
            settings.Values["DayFlatAccent-20"] = "#f6c05f";
            settings.Values["NightFlatAccent-1"] = "#fab742";
            settings.Values["NightFlatAccent-2"] = "#e6ac62";
            settings.Values["NightFlatAccent-3"] = "#d2a776";
            settings.Values["NightFlatAccent-4"] = "#c0a283";
            settings.Values["NightFlatAccent-5"] = "#b49f8d";
            settings.Values["NightFlatAccent-6"] = "#ac9e94";
            settings.Values["NightFlatAccent-7"] = "#a3999d";
            settings.Values["NightFlatAccent-8"] = "#9791a4";
            settings.Values["NightFlatAccent-9"] = "#8f8caa";
            settings.Values["NightFlatAccent-10"] = "#8a8bae";
            settings.Values["NightFlatAccent-11"] = "#8a8db0";
            settings.Values["NightFlatAccent-12"] = "#9195b0";
            settings.Values["NightFlatAccent-13"] = "#969bad";
            settings.Values["NightFlatAccent-14"] = "#a1a4a9";
            settings.Values["NightFlatAccent-15"] = "#aaaca4";
            settings.Values["NightFlatAccent-16"] = "#a6a9a4";
            settings.Values["NightFlatAccent-17"] = "#aead9e";
            settings.Values["NightFlatAccent-18"] = "#b1a998";
            settings.Values["NightFlatAccent-19"] = "#bba48f";
            settings.Values["NightFlatAccent-20"] = "#c4987f";
            string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
            string acent = flatWallpaperAcent.Replace("#", "");
            if (acent.Length == 6)
            {
                SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            AccentFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void DayAndNightSunGradientColor2(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicColor"] = "true";
            settings.Values["DayFlatColor-1"] = "#f48d3d";
            settings.Values["DayFlatColor-2"] = "#efa05c";
            settings.Values["DayFlatColor-3"] = "#eaba87";
            settings.Values["DayFlatColor-4"] = "#e4d0af";
            settings.Values["DayFlatColor-5"] = "#e2dcc2";
            settings.Values["DayFlatColor-6"] = "#e1e4cf";
            settings.Values["DayFlatColor-7"] = "#dee7db";
            settings.Values["DayFlatColor-8"] = "#d7e6e4";
            settings.Values["DayFlatColor-9"] = "#d5e7ea";
            settings.Values["DayFlatColor-10"] = "#cfe6ef";
            settings.Values["DayFlatColor-11"] = "#cfe6f0";
            settings.Values["DayFlatColor-12"] = "#cee4ef";
            settings.Values["DayFlatColor-13"] = "#d0e2e9";
            settings.Values["DayFlatColor-14"] = "#d4e3e1";
            settings.Values["DayFlatColor-15"] = "#dae1d7";
            settings.Values["DayFlatColor-16"] = "#dfdfc9";
            settings.Values["DayFlatColor-17"] = "#e3dcbb";
            settings.Values["DayFlatColor-18"] = "#e7d6a9";
            settings.Values["DayFlatColor-19"] = "#f0cb83";
            settings.Values["DayFlatColor-20"] = "#f6c05f";
            settings.Values["NightFlatColor-1"] = "#fab742";
            settings.Values["NightFlatColor-2"] = "#e6ac62";
            settings.Values["NightFlatColor-3"] = "#d2a776";
            settings.Values["NightFlatColor-4"] = "#c0a283";
            settings.Values["NightFlatColor-5"] = "#b49f8d";
            settings.Values["NightFlatColor-6"] = "#ac9e94";
            settings.Values["NightFlatColor-7"] = "#a3999d";
            settings.Values["NightFlatColor-8"] = "#9791a4";
            settings.Values["NightFlatColor-9"] = "#8f8caa";
            settings.Values["NightFlatColor-10"] = "#8a8bae";
            settings.Values["NightFlatColor-11"] = "#8a8db0";
            settings.Values["NightFlatColor-12"] = "#9195b0";
            settings.Values["NightFlatColor-13"] = "#969bad";
            settings.Values["NightFlatColor-14"] = "#a1a4a9";
            settings.Values["NightFlatColor-15"] = "#aaaca4";
            settings.Values["NightFlatColor-16"] = "#a6a9a4";
            settings.Values["NightFlatColor-17"] = "#aead9e";
            settings.Values["NightFlatColor-18"] = "#b1a998";
            settings.Values["NightFlatColor-19"] = "#bba48f";
            settings.Values["NightFlatColor-20"] = "#c4987f";
            string flatWallpaperColor = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
            string color = flatWallpaperColor.Replace("#", "");
            if (color.Length == 6)
            {
                SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            ColorFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void DayAndNightSunGradientAccent3(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicAccent"] = "true";
            settings.Values["DayFlatAccent-1"] = "#41496a";
            settings.Values["DayFlatAccent-2"] = "#4a5474";
            settings.Values["DayFlatAccent-3"] = "#596984";
            settings.Values["DayFlatAccent-4"] = "#6b8097";
            settings.Values["DayFlatAccent-5"] = "#7b95a9";
            settings.Values["DayFlatAccent-6"] = "#88a5b6";
            settings.Values["DayFlatAccent-7"] = "#93b3c1";
            settings.Values["DayFlatAccent-8"] = "#9cc0cc";
            settings.Values["DayFlatAccent-9"] = "#a5cbd7";
            settings.Values["DayFlatAccent-10"] = "#abd2dd";
            settings.Values["DayFlatAccent-11"] = "#aed5e2";
            settings.Values["DayFlatAccent-12"] = "#add2e2";
            settings.Values["DayFlatAccent-13"] = "#aacde2";
            settings.Values["DayFlatAccent-14"] = "#a6c6e2";
            settings.Values["DayFlatAccent-15"] = "#a1bde0";
            settings.Values["DayFlatAccent-16"] = "#9cb5dd";
            settings.Values["DayFlatAccent-17"] = "#93a6d8";
            settings.Values["DayFlatAccent-18"] = "#92a4d6";
            settings.Values["DayFlatAccent-19"] = "#8590cf";
            settings.Values["DayFlatAccent-20"] = "#7b81c8";
            settings.Values["NightFlatAccent-1"] = "#7476c4";
            settings.Values["NightFlatAccent-2"] = "#686bb2";
            settings.Values["NightFlatAccent-3"] = "#565b95";
            settings.Values["NightFlatAccent-4"] = "#575b96";
            settings.Values["NightFlatAccent-5"] = "#414774";
            settings.Values["NightFlatAccent-6"] = "#32395c";
            settings.Values["NightFlatAccent-7"] = "#262f4c";
            settings.Values["NightFlatAccent-8"] = "#1c273c";
            settings.Values["NightFlatAccent-9"] = "#1c263c";
            settings.Values["NightFlatAccent-10"] = "#131e2d";
            settings.Values["NightFlatAccent-11"] = "#0c1723";
            settings.Values["NightFlatAccent-12"] = "#07131a";
            settings.Values["NightFlatAccent-13"] = "#030f14";
            settings.Values["NightFlatAccent-14"] = "#030f13";
            settings.Values["NightFlatAccent-15"] = "#020f13";
            settings.Values["NightFlatAccent-16"] = "#031013";
            settings.Values["NightFlatAccent-17"] = "#041013";
            settings.Values["NightFlatAccent-18"] = "#061318";
            settings.Values["NightFlatAccent-19"] = "#0c181f";
            settings.Values["NightFlatAccent-20"] = "#263044";
            string flatWallpaperAcent = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatAccent-{(string)settings.Values["ColorIdNumber"]}"];
            string acent = flatWallpaperAcent.Replace("#", "");
            if (acent.Length == 6)
            {
                SelectFlatWallpaperAcentButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(acent.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(acent.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            AccentFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async void DayAndNightSunGradientColor3(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            settings.Values["UseDynamicModern"] = "true";
            settings.Values["UseDynamicColor"] = "true";
            settings.Values["DayFlatColor-1"] = "#41496a";
            settings.Values["DayFlatColor-2"] = "#4a5474";
            settings.Values["DayFlatColor-3"] = "#596984";
            settings.Values["DayFlatColor-4"] = "#6b8097";
            settings.Values["DayFlatColor-5"] = "#7b95a9";
            settings.Values["DayFlatColor-6"] = "#88a5b6";
            settings.Values["DayFlatColor-7"] = "#93b3c1";
            settings.Values["DayFlatColor-8"] = "#9cc0cc";
            settings.Values["DayFlatColor-9"] = "#a5cbd7";
            settings.Values["DayFlatColor-10"] = "#abd2dd";
            settings.Values["DayFlatColor-11"] = "#aed5e2";
            settings.Values["DayFlatColor-12"] = "#add2e2";
            settings.Values["DayFlatColor-13"] = "#aacde2";
            settings.Values["DayFlatColor-14"] = "#a6c6e2";
            settings.Values["DayFlatColor-15"] = "#a1bde0";
            settings.Values["DayFlatColor-16"] = "#9cb5dd";
            settings.Values["DayFlatColor-17"] = "#93a6d8";
            settings.Values["DayFlatColor-18"] = "#92a4d6";
            settings.Values["DayFlatColor-19"] = "#8590cf";
            settings.Values["DayFlatColor-20"] = "#7b81c8";
            settings.Values["NightFlatColor-1"] = "#7476c4";
            settings.Values["NightFlatColor-2"] = "#686bb2";
            settings.Values["NightFlatColor-3"] = "#565b95";
            settings.Values["NightFlatColor-4"] = "#575b96";
            settings.Values["NightFlatColor-5"] = "#414774";
            settings.Values["NightFlatColor-6"] = "#32395c";
            settings.Values["NightFlatColor-7"] = "#262f4c";
            settings.Values["NightFlatColor-8"] = "#1c273c";
            settings.Values["NightFlatColor-9"] = "#1c263c";
            settings.Values["NightFlatColor-10"] = "#131e2d";
            settings.Values["NightFlatColor-11"] = "#0c1723";
            settings.Values["NightFlatColor-12"] = "#07131a";
            settings.Values["NightFlatColor-13"] = "#030f13";
            settings.Values["NightFlatColor-14"] = "#020f13";
            settings.Values["NightFlatColor-15"] = "#041013";
            settings.Values["NightFlatColor-16"] = "#061318";
            settings.Values["NightFlatColor-17"] = "#0c181f";
            settings.Values["NightFlatColor-18"] = "#131e29";
            settings.Values["NightFlatColor-19"] = "#263044";
            settings.Values["NightFlatColor-20"] = "#303a53";
            string flatWallpaperColor = (string)settings.Values[$"{(string)settings.Values["DayOrNight"]}FlatColor-{(string)settings.Values["ColorIdNumber"]}"];
            string color = flatWallpaperColor.Replace("#", "");
            if (color.Length == 6)
            {
                SelectFlatWallpaperColorButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            ColorFlyout.Hide();
            await LookForFlatWallpaperThumnails();
        }
        private async Task LookForFlatWallpaperThumnails()
        {
            ModernWallpaperBitmap.Clear();
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
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            IStorageItem storageItem = await localFolder.TryGetItemAsync("09efe629");
            if (storageItem != null)
            {
                await AddThumbsToFlatWallCollection();
            }
            else
            {
                //color all images
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/7bbf1734-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "7bbf1734");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/13a5f8f8-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "13a5f8f8");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/54e2f31c-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "54e2f31c");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/6a05399e-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "6a05399e");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/424cbe30-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "424cbe30");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/c39dc2b3-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "c39dc2b3");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/fa234c47-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "fa234c47");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/db69f36c-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "db69f36c");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/cc06d1db-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "cc06d1db");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/c0f2f779-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "c0f2f779");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/c70d2abc-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "c70d2abc");
                await Library.ChangeImageColors.ApplyColor(new Uri("ms-appx:///ModernWallpaperGrayscale/2ef7f3e4-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", "2ef7f3e4");
                await AddThumbsToFlatWallCollection();
            }
        }
        private async Task AddThumbsToFlatWallCollection ()
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder flatWallpaperFolder = await localFolder.GetFolderAsync("09efe629");
            var queryOption = new QueryOptions { FolderDepth = FolderDepth.Deep };
            var flatWallpaperSubFolders = await flatWallpaperFolder.CreateFolderQueryWithOptions(queryOption).GetFoldersAsync();
            foreach (StorageFolder flatWallpaperSubFolder in flatWallpaperSubFolders)
            {
                IStorageItem thumnail = await flatWallpaperSubFolder.TryGetItemAsync($"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png");
                if (thumnail != null)
                {
                    BitmapImage icon = new BitmapImage(new Uri(flatWallpaperSubFolder.Path + $"/{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png"));
                    string folder = flatWallpaperSubFolder.Name.ToString();
                    ModernWallpaperBitmap.Add(new ModernWallpaperBitmaps(icon, folder));
                }
                else
                {
                    //color the image missing
                    await Library.ChangeImageColors.ApplyColor(new Uri($"ms-appx:///ModernWallpaperGrayscale/{flatWallpaperSubFolder.Name}-Thumnail.png"), $"{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png", $"{flatWallpaperSubFolder.Name.ToString()}");
                    BitmapImage icon = new BitmapImage(new Uri(flatWallpaperSubFolder.Path + $"/{Library.ChangeImageColors.ModernColor} - {Library.ChangeImageColors.ModernAcent}.png"));
                    string folder = flatWallpaperSubFolder.Name.ToString();
                    ModernWallpaperBitmap.Add(new ModernWallpaperBitmaps(icon, folder));
                }
            }
        }
        private async Task AddDefaultThemes()
        {
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["DefaultCopy"] == null)
            {
                await AddDefaultDynamicWeather();
                await AddDefaultDynamicTheme();
                settings.Values["DefaultCopy"] = "true";
            }
            
            
        }
        private async Task AddDefaultDynamicWeather()
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.CreateFolderAsync("dw2b8071", CreationCollisionOption.OpenIfExists);
            StorageFolder addedTheme = await dynamicFolder.CreateFolderAsync("Unsplash Weather Photos", CreationCollisionOption.ReplaceExisting);

            StorageFolder install = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile storageFile = await install.GetFileAsync("Mega-Tron.udw");

            Stream themeZipFile = await storageFile.OpenStreamForReadAsync();
            ZipArchive archive = new ZipArchive(themeZipFile);
            archive.ExtractToDirectory(addedTheme.Path);
        }
        private async Task AddDefaultDynamicTheme()
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder dynamicFolder = await localFolder.CreateFolderAsync("212b8071", CreationCollisionOption.OpenIfExists);
            StorageFolder addedTheme = await dynamicFolder.CreateFolderAsync("Time Shift", CreationCollisionOption.ReplaceExisting);

            StorageFolder install = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile storageFile = await install.GetFileAsync("Mega-Tron.udt");

            Stream themeZipFile = await storageFile.OpenStreamForReadAsync();
            ZipArchive archive = new ZipArchive(themeZipFile);
            archive.ExtractToDirectory(addedTheme.Path);
        }
    }
}
