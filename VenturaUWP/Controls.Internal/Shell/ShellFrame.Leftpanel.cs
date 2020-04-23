using Windows.UI.Xaml;

namespace Ventura.Controls
{
    public partial class ShellFrame
    {
        private void btnOpenCloseLeftPanel_Click(object sender, RoutedEventArgs e)
        {
            bool is_checked = btnOpenCloseLeftPanel.IsChecked.GetValueOrDefault();

            LeftPanel.IsOpen = !LeftPanel.IsOpen;

        }

        private void LeftPanel_BeforeOpenAnimation(object sender, RoutedEventArgs e)
        {
            DropShadowLeft.Visibility = Visibility.Visible;
            RoundedCorner.Visibility = Visibility.Visible;
        }

        private void LeftPanel_AfterOpenAnimation(object sender, RoutedEventArgs e)
        {
            DropShadowLeft.Visibility = Visibility.Visible;
            RoundedCorner.Visibility = Visibility.Visible;
        }

        private void LeftPanel_AfterCloseAnimation(object sender, RoutedEventArgs e)
        {
            DropShadowLeft.Visibility = Visibility.Collapsed;
            RoundedCorner.Visibility = Visibility.Collapsed;
        }
    }
}
