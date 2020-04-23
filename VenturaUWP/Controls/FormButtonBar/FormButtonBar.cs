using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{

    public class FormButtonBar : ItemsControl
    {
        public FormButtonBar()
        {
            DefaultStyleKey = typeof(FormButtonBar);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            bool valid = element is MiniButton;

            if (valid == false)
                throw new InvalidOperationException("FormButtonBar only accepts items of type MiniButton.");

            base.PrepareContainerForItemOverride(element, item);
        }

    }

}
