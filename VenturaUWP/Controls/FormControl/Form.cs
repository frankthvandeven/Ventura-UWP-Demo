using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{

    // custom boxpanel
    // https://docs.microsoft.com/en-us/windows/uwp/design/layout/boxpanel-example-custom-panel
    //
    // Panel < FrameworkElement < UIElement
    //
    // Acryllic Effect: https://stackoverflow.com/questions/43208841/how-to-use-acrylic-accent-createhostbackdropbrush-in-windows-10-creators-upd
    // Draw a line border around panel: https://stackoverflow.com/questions/21437236/draw-a-line-border-on-a-custom-panel
    //
    // https://blogs.msdn.microsoft.com/mim/2013/04/16/winrt-create-a-custom-itemspanel-for-an-itemscontrol/

    //[ContentProperty(Name = nameof(Children))]
    public partial class Form : ItemsControl
    {
        private static Brush GridLineBrush = (Brush)Application.Current.Resources["GridLineBrush"];

        public Form()
        {
            this.DefaultStyleKey = typeof(Form);
        }

        private bool _init;
        private Grid _canvasControl;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvasControl = GetTemplateChild("Canvas") as Grid;

            _init = true;
        }


        internal void DrawSeparatorLines(List<Rect> rectangles)
        {
            if (_init == false)
                throw new Exception("DrawSeparatorLines called before template was applied.");

            // Clear the existing visual rectangles
            _canvasControl.Children.Clear();

            // Draw rectangles using the coordinates in the rectangles list.
            foreach (var rect in rectangles)
            {
                RectangleGeometry geo = new RectangleGeometry
                {
                    Rect = rect
                };

                Path path = new Path
                {
                    Fill = Form.GridLineBrush,
                    Data = geo
                };

                _canvasControl.Children.Add(path);
            }

        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            bool valid = element is IFormField;

            if (valid == false)
                throw new InvalidOperationException("Form only accepts FormField, Filler and NewLine.");

            base.PrepareContainerForItemOverride(element, item);
        }

    }
}