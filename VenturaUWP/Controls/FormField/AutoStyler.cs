using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    internal static class AutoStyler
    {

        internal static void SetStyle(FrameworkElement element)
        {
            //TextBox tb = element as TextBox;

            //if (tb != null)
            //{
            //    tb.BorderThickness = new Thickness(0);
            //}

        }

        internal static void SetScale(FrameworkElement element, SmartScaler smartscaler)
        {
            if (element is RadioButton || element is CheckBox)
            {
                smartscaler.SmartScaleFactor = 0.80;
            }
            else if (element is Panel panel)
            {
                if (panel.Children.Count > 0)
                    SetScale(panel.Children[0] as FrameworkElement, smartscaler);
            }
        }

        internal static void SetMargin(FrameworkElement element)
        {
            if (element is StackPanel)
            {
                StackPanel stackpanel = element as StackPanel;

                if (stackpanel.Orientation == Orientation.Horizontal || stackpanel.Children.Count > 1)
                {
                    for (int i = 0; i < stackpanel.Children.Count; i++)
                    {
                        FrameworkElement child = (FrameworkElement)stackpanel.Children[i];
                        bool last_child = i == (stackpanel.Children.Count - 1);

                        if (last_child == false)
                            child.Margin = new Thickness(0, 0, 20, 0);
                    }

                }

            }


        }

    }
}
