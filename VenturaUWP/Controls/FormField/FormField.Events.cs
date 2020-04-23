using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{

    public partial class FormField : Control
    {

        private RoutedEventHandler _zoombutton_click_handler;

        public event RoutedEventHandler ZoombuttonClick
        {
            add
            {
                //if (_zoombuttonClick == null) timer.Start();
                _zoombutton_click_handler += value;

                // Make the Zoombutton visible.
                _standard_zoom_button.Visibility = Visibility.Visible;
            }
            remove
            {
                _zoombutton_click_handler -= value;

                // Hide the Zoombutton if the event is not listened to anymore.
                if (_zoombutton_click_handler == null)
                    _standard_zoom_button.Visibility = Visibility.Collapsed;
            }
        }

    }
}
