using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace Ventura.Controls
{
    public sealed class HyperGridPanel : Panel
    {
        // Statics

        // The rest
        private const double LEFT_MARGIN = 4d;
        private const double RIGHT_MARGIN = 4d;
        private const double TOP_MARGIN = 2d;
        private const double BOTTOM_MARGIN = 2d;

        int _line_count = 0;
        Rect[] _coordinates;

        protected override Size MeasureOverride(Size availableSize)
        {
            double LINE_WIDTH = HyperGrid.GridLineWidth;

            //if( _line_count > 0 && Children.Count > 0 )
            // {
            //     if (!(Children[Children.Count - 1] is Rectangle))
            //         throw new Exception("This special control does not support adding children. Only use this control in a DataTemplate in Ventura's HyperGrid.");
            // }

            if (_line_count == 0)
            {
                StyleElements();
            }

            int column_count = Children.Count - _line_count;
            int line_index = column_count;

            _coordinates = new Rect[column_count * 2];

            double x_offset = 0d;
            double y_offset = TOP_MARGIN;

            double highest_column = 0d;

            for (int i = 0; i < column_count; i++)
            {

                if (i > 0)
                {
                    // This is a vertical column separator line.
                    _coordinates[line_index].X = x_offset;
                    _coordinates[line_index].Y = 0;
                    _coordinates[line_index].Width = LINE_WIDTH;

                    x_offset += LINE_WIDTH;

                    line_index++;
                }

                // Left side margin
                x_offset += LEFT_MARGIN;

                FrameworkElement element = (FrameworkElement)Children[i];

                double element_width = element.Width;

                if (double.IsNaN(element_width) == true)
                    throw new Exception("It is obligated to set the Width property of each child.");

                double element_height = MeasureTheHeight(element, element_width);

                _coordinates[i].X = x_offset;
                _coordinates[i].Y = y_offset;
                _coordinates[i].Width = element_width;

                x_offset += element_width;

                // Right side margin
                x_offset += RIGHT_MARGIN;

                highest_column = Math.Max(highest_column, element_height);
            }

            y_offset += highest_column;

            // Testing: The HyperGrid.ScrollSelectedIntoView() will cause a Measure pass for the Selected item 
            // where the availableSize.Width is infinity.
            if (double.IsInfinity(availableSize.Width))
            {
                TextBlock tb = Children[0] as TextBlock;
                Debug.WriteLine($"Measuring HyperGrid with infinity. Column0: {(tb == null ? "(null)" : tb.Text)}");
            }

            // The total width of the panel. 
            double total_panel_width = x_offset;

            // We want the horizontal line to fill the full width of the HyperGrid.
            // Expand the total_panel_width if needed.
            double available = availableSize.Width;

            if (!double.IsInfinity(available) && available > total_panel_width)
                total_panel_width = available;

            // The height of the controls is set to the highest column. This makes VerticalAlignment possible.
            for (int i = 0; i < column_count; i++)
                _coordinates[i].Height = highest_column;

            // The margin below
            y_offset += BOTTOM_MARGIN;

            // Set the height of the vertical lines
            for (int i = column_count; i < (_coordinates.Length - 1); i++)
                _coordinates[i].Height = y_offset;

            // This is the horizontal line at the bottom
            _coordinates[line_index].X = 0;
            _coordinates[line_index].Y = y_offset;
            _coordinates[line_index].Width = total_panel_width;
            _coordinates[line_index].Height = LINE_WIDTH;

            y_offset += LINE_WIDTH;

            // Create the line controls and add them to the children collection
            if (_line_count == 0)
            {
                for (int i = 0; i < column_count; i++)
                {
                    line_index = i + column_count;

                    Rectangle rectangle = new Rectangle();
                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    rectangle.HorizontalAlignment = HorizontalAlignment.Left;
                    rectangle.Fill = HyperGrid.GridLineBrush; // new SolidColorBrush(Colors.Silver);
                    rectangle.Width = _coordinates[line_index].Width;
                    rectangle.Height = _coordinates[line_index].Height;

                    Children.Add(rectangle);
                }
                _line_count = column_count;
            }
            else
            {
                for (int i = column_count; i < Children.Count; i++)
                {
                    FrameworkElement element = (FrameworkElement)Children[i];
                    element.Width = _coordinates[i].Width;
                    element.Height = _coordinates[i].Height;
                }
            }

            return new Size(total_panel_width, y_offset);
        }

        /// <summary>
        /// Asks the element for the desired height based on a fixed width.
        /// </summary>
        private double MeasureTheHeight(FrameworkElement element, double width)
        {
            var size = new Size(width, double.PositiveInfinity);

            element.Measure(size);

            return element.DesiredSize.Height;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            for (int i = 0; i < Children.Count; i++)
                Children[i].Arrange(_coordinates[i]);

            return finalSize;
        }

        private void StyleElements()
        {
            for (int i = 0; i < this.Children.Count; i++)
            {
                TextBlock textblock = Children[i] as TextBlock;

                if (textblock != null)
                {
                    textblock.FontSize = HyperGrid.GridFontSize;
                }

            }
        }

    }
}