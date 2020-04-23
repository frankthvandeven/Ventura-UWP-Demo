using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{

    public class ButtonBar : ItemsControl
    {
        public ButtonBar()
        {
            DefaultStyleKey = typeof(ButtonBar);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            bool valid = element is ISmartButton;

            if (valid == false)
                throw new InvalidOperationException("ButtonBar only accepts items of type SmartButton and SmartToggleButton.");

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