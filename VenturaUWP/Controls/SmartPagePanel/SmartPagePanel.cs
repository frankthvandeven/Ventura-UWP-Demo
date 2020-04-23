using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{

    public class SmartPagePanel : ItemsControl
    {
        public SmartPagePanel()
        {
            DefaultStyleKey = typeof(SmartPagePanel);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            bool valid = element is UIElement;

            if (valid == false)
                throw new InvalidOperationException("SmartPagePanel only accepts items of type UIElement.");

            base.PrepareContainerForItemOverride(element, item);
        }

    }

}










//[Windows.Foundation.Metadata.CreateFromString(MethodName = "App12.PseudoDecimal.ConvertToPseudoDecimal")]
//public class PseudoDecimal
//{
//    public decimal Value { get; set; }
//    public static PseudoDecimal ConvertToPseudoDecimal(string rawString)
//    {
//        var x = new PseudoDecimal();
//        x.Value = 1234.56M;
//        return x;
//    }
//}