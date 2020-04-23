using System;
using System.Threading;
using System.Threading.Tasks;
using Ventura.Controls;
using Windows.UI.Xaml;

namespace Demo.Pages
{
    public sealed partial class InstantScreenUpdatePage : SmartPage
    {
        public InstantScreenUpdatePage()
        {
            this.InitializeComponent();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i <= 300; i++)
            {
                tbInfo.Text = i.ToString();

                Thread.Sleep(5);
            }

        }

        private async void CountWithDispatcher_Click(object sender, RoutedEventArgs e)
        {

            await Task.Run(() =>
            {
                for (int i = 0; i <= 300; i++)
                {
                    RunOnUiThread(() => tbInfo.Text = i.ToString());

                    Thread.Sleep(5);
                }
            });

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            tbInfo.Text = "0";
        }

        private void RunOnUiThread(Action action)
        {
            // This sample uses the Dispatcher property of the control (SmartPage).
            // If you need to use a dispatcher outside of control code, you can use
            // the dispatcher of the main window:
            //
            // Window.Current.Dispatcher.RunAsync(..)
            //
            // or
            //
            // CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync();
            //

            _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
              {
                  //UI code here
                  action();
              });
        }


    }
}

