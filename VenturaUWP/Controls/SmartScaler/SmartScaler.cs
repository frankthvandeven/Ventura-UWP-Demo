using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{
    public class SmartScaler : ContentPresenter
    {

        protected override Size MeasureOverride(Size availableSize)
        {
            double measure_width = availableSize.Width;
            double measure_height = availableSize.Height;

            double scale_factor = this.SmartScaleFactor;
            double multiplier = (1d / scale_factor);

            if (double.IsInfinity(measure_width) == false)
                measure_width = measure_width * multiplier;

            if (double.IsInfinity(measure_height) == false)
                measure_height = measure_height * multiplier;

            UIElement element = (UIElement)this.Content;

            element.Measure(new Size(measure_width, measure_height));

            if (scale_factor == 1d)
                element.RenderTransform = null;
            else
                element.RenderTransform = new ScaleTransform() { ScaleX = scale_factor, ScaleY = scale_factor };

            double return_width = element.DesiredSize.Width / multiplier;
            double return_height = element.DesiredSize.Height / multiplier;

            return new Size(return_width, return_height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double scale_factor = this.SmartScaleFactor;
            double multiplier = (1d / scale_factor);

            UIElement element = (UIElement)this.Content;

            double arrange_width = finalSize.Width * multiplier;
            double arrange_height = finalSize.Height * multiplier;

            element.Arrange(new Rect(0, 0, arrange_width, arrange_height));

            return finalSize;
        }

        #region DP - SmartScaleFactor

        public static readonly DependencyProperty SmartScaleFactorProperty = DependencyProperty.Register(nameof(SmartScaleFactor),
            typeof(double), typeof(SmartScaler), new PropertyMetadata(1.0d, OnScaleFactorChanged));

        private static void OnScaleFactorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var control = d as SmartScaler;
            //control.UpdateLayout();
        }

        public double SmartScaleFactor
        {
            get { return (double)this.GetValue(SmartScaleFactorProperty); }
            set { SetValue(SmartScaleFactorProperty, value); }
        }

        #endregion

    }
}
