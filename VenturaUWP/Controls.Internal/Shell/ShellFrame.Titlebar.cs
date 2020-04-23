using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{
    public sealed partial class ShellFrame
    {
        // Statics for fast resource data access
        private static Brush ForegroundActivatedBrush = (Brush)Application.Current.Resources["VenturaWhiteBrush"];
        private static Brush ForegroundDeActivatedBrush = (Brush)Application.Current.Resources["VenturaGrayBrush"];

        // Call this method from ShellFrame's constructor.
        private async void InitializeCustomTitlebar()
        {
            SetTitleBarColors();

            textBlockTitleBar.Text = await FetchDisplayNameAsync();

            // Hide default title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            UpdateTitleBarLayout(coreTitleBar);

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);

            // Register a handler for when the size of the overlaid caption control changes.
            // For example, when the app moves to a screen with a different DPI.
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            // Register a handler for when the title bar visibility changes.
            // For example, when the title bar is invoked in full screen mode.
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;

            Window.Current.Activated += Window_Activated;
        }

        private void SetTitleBarColors()
        {
            // Not sure if the color setting code should be at "position 1"
            // The documentation says the color setting comes after Activate().
            // https://docs.microsoft.com/en-us/windows/uwp/design/shell/title-bar

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            Color bg = (Color)Application.Current.Resources["VenturaBlueColor"];

            // Set active window colors
            titleBar.ForegroundColor = Colors.White;
            titleBar.BackgroundColor = bg;
            //titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = bg;
            //titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
            //titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.DarkSeaGreen;
            //titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.Gray;
            //titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.LightGreen;

            // Set inactive window colors
            //titleBar.InactiveForegroundColor = Colors.Gray;
            titleBar.InactiveBackgroundColor = bg;
            //titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.Gray;
            titleBar.ButtonInactiveBackgroundColor = bg;
        }

        private void Window_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                textBlockTitleBar.Foreground = ForegroundDeActivatedBrush;
            }
            else
            {
                textBlockTitleBar.Foreground = ForegroundActivatedBrush;
            }
        }

        private async Task<string> FetchDisplayNameAsync()
        {
            IList<AppDiagnosticInfo> list = await App​Diagnostic​Info.RequestInfoAsync();

            if (list.Count == 0)
                return "no display name found (reason 1)";

            try
            {
                return list[0].AppInfo.DisplayInfo.DisplayName;
            }
            catch
            {
                return "no display name found (reason 2)";
            }

        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
        {
            // Get the size of the caption controls area and back button 
            // (returned in logical pixels), and move your content around as necessary.
            LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
            RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
            //TitleBarButton.Margin = new Thickness(0, 0, coreTitleBar.SystemOverlayRightInset, 0);

            // Update title bar control size as needed to account for system size changes.
            AppTitleBar.Height = coreTitleBar.Height;
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }



    }
}
