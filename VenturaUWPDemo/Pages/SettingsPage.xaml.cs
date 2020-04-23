using Demo.Helpers;
using Ventura.Controls;
using System;
using Windows.UI.Popups;

namespace Demo.Pages
{
    
    public sealed partial class SettingsPage : SmartPage
    {
        public SettingsPage()
        {
            this.InitializeComponent();

        }

        private async void Restore_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await DatabaseHelper.RestoreDatabaseFile(true);

            var dialog = new MessageDialog("Database was restored.");

            await dialog.ShowAsync();

        }
    }
}
