using System.Threading;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace BackgroundTask
{

    public sealed class BackgroundTaskClass : XamlRenderingBackgroundTask
    {

        private CancellationTokenSource _cts = null;
        BackgroundTaskDeferral _deferral;
        

        protected override async void OnRun(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            if ((string)settings.Values["UsePosition"] == "true")
            {
                await Library.GetLocation.GetLocationTask();
            }
            _deferral.Complete();
        }
    }
}
