using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Microsoft.Toolkit.Uwp.UI.Extensions; // visual tree helper extension methods

namespace Ventura.Controls
{
    public sealed partial class ShellFrame
    {
        private void NavigationBar_DisplayMenuPanel(NavigationBarControl sender, MenubarItem item)
        {
            MenuPanel.ShowMenuPanel(item);
        }

        private void NavigationBar_HideMenuPanel()
        {
            MenuPanel.HideMenuPanel();
        }

        private void WorkSpaceGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Begin: Check if the tap was inside the menupanel.
            UIElement tapped_element = e.OriginalSource as UIElement;

            bool clicked_inside_menupanel = (tapped_element.FindAscendant<MenuPanel>() != null);

            if (clicked_inside_menupanel == true)
                return;
            // End: Check if the tap was inside the open menupanel.

            NavigationBarControl.CloseMenuPanel();

        }

    }
}

//public async void MakeSureMenuPanelIsClosedAsync()
//{
//   await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => NavigationBar.SelectedItem = null);
//}
