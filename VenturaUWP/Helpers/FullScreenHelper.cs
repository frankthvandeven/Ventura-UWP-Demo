using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace Ventura.Helpers
{
    internal class FullScreenHelper : ViewmodelBase
    {
        // Full screen at startup:
        // ApplicationView.PreferredLaunchWindowingMode = LaunchInFullScreenModeCheckBox.IsChecked.Value? ApplicationViewWindowingMode.FullScreen : ApplicationViewWindowingMode.Auto;

        public FullScreenHelper()
        {
            Window.Current.SizeChanged += Window_SizeChanged;

            // Listen for the Escape key.
            Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;

            // Alternative event: Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;

        }

        private void Dispatcher_AcceleratorKeyActivated(Windows.UI.Core.CoreDispatcher sender, Windows.UI.Core.AcceleratorKeyEventArgs args)
        {
            if (args.VirtualKey != Windows.System.VirtualKey.Escape)
                return;

            var view = ApplicationView.GetForCurrentView();

            if (view.IsFullScreenMode == false)
                return;

            view.ExitFullScreenMode();

            NotifyPropertyChanged(nameof(IsFullscreen));

        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            //    var view = ApplicationView.GetForCurrentView();
            //var isFullScreenMode = view.IsFullScreenMode;

            NotifyPropertyChanged(nameof(IsFullscreen));
        }

        public bool IsFullscreen
        {
            get
            {
                var view = ApplicationView.GetForCurrentView();
                return view.IsFullScreenMode;
            }
        }

        public void ToggleFullscreen()
        {
            var view = ApplicationView.GetForCurrentView();

            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                //rootPage.NotifyUser("Exiting full screen mode", NotifyType.StatusMessage);
                //isLastKnownFullScreen = false;
                // The SizeChanged event will be raised when the exit from full screen mode is complete.
            }
            else
            {
                if (view.TryEnterFullScreenMode())
                {
                    //rootPage.NotifyUser("Entering full screen mode", NotifyType.StatusMessage);
                    //isLastKnownFullScreen = true;
                    // The SizeChanged event will be raised when the entry to full screen mode is complete.
                }
                else
                {
                    //rootPage.NotifyUser("Failed to enter full screen mode", NotifyType.ErrorMessage);
                }
            }

            NotifyPropertyChanged(nameof(IsFullscreen));
        }


    }
}
