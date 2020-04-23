using System;
using System.Threading.Tasks;
using Ventura.Navigation;
using Ventura.Shell;
using Ventura.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {
        private FormField _last_formfield = null;

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            FrameworkElement focussed_element = e.OriginalSource as FrameworkElement;

            if (focussed_element == null)
                return;
                //throw new Exception("should not happen");

            bool focus_inside_smartpage = VenturaVisualTreeHelper.FindParent<SmartPagePresenter>(focussed_element) != null;
            FormField formfield = VenturaVisualTreeHelper.FindParent<FormField>(focussed_element);

            if (focus_inside_smartpage == false)
            {
                return;
            }

            if (_last_formfield != null)
            {
                _last_formfield.IsActive = false;
                _last_formfield = null;
            }

            if (formfield != null)
            {
                formfield.IsActive = true;
                _last_formfield = formfield;
            }



            if (focussed_element is InputBase inputcontrol)
            {
                string header = "";

                if (formfield != null)
                    header = formfield.Header;


                //_assistant.SetAssistantTo(header, inputcontrol.TextBox);
            }
            else if (focussed_element is TextBox textbox)
            {
                string header = "";

                //if( textbox.h)
                //textbox.Header

                if (formfield != null)
                    header = formfield.Header;

                //_assistant.SetAssistantTo(header, textbox);
            }






        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
        }





    }
}
