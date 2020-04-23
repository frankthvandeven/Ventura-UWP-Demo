using System;
using Ventura.Shell;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Ventura
{
    public static class VenturaApplication
    {

        public static void OnLaunched(Type main_page, LaunchActivatedEventArgs e)
        {
            if (main_page == null)
                throw new ArgumentNullException(nameof(main_page));

            if (e == null)
                throw new ArgumentNullException(nameof(e));

            MakeSureAppDictionaryIsReferenced();

            SetTitleBarColors();

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                Windows.ApplicationModel.Core.CoreApplication.EnablePrelaunch(true);

                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(main_page, e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();

                // position 1 
            }


        } // end of method

        



        private static bool _dictionary_verified = false;

        private static void MakeSureAppDictionaryIsReferenced()
        {
            if (_dictionary_verified == true)
                return;

            bool found = false;

            foreach (ResourceDictionary dict in Application.Current.Resources.MergedDictionaries)
                if (dict.Source.AbsoluteUri == "ms-appx:///VenturaUWP/Styles/AppDictionary.xaml")
                {
                    found = true;
                    break;
                }

            if (found == false)
                throw new Exception("\nDear application developer, please add the following lines to your App.xaml:\n\n<ResourceDictionary.MergedDictionaries>\n     <ResourceDictionary Source=\"ms-appx:///VenturaUWP/Styles/AppDictionary.xaml\" />\n</ResourceDictionary.MergedDictionaries>");

            _dictionary_verified = true;

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        static void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private static void SetTitleBarColors()
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





    } // end of class
} // end of namespace

// Example of setting a resource from code:
//Application.Current.Resources["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush(Colors.Red);


#if dfgfgfdg
            // Hide default title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = false;

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
#endif
