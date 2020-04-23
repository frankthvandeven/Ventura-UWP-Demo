using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public class NavigationBarPanel : Panel
    {
        private Rect[] _coordinates;

        protected override Size MeasureOverride(Size availableSize)
        {
            double SPACING = 6d; // was 5d;
            const double MINIMUM_ELEMENT_WIDTH = 20d;

            int child_count = this.Children.Count;

            _coordinates = new Rect[child_count];
            bool[] compensate = new bool[child_count];

            double total_panel_width = 0d;
            //double max_height = 0d;

            for (int x = 0; x < child_count; x++)
            {
                if (x > 0)
                {
                    total_panel_width += SPACING;
                }

                FrameworkElement element = (FrameworkElement)this.Children[x];

                element.Measure(new Size(double.PositiveInfinity, availableSize.Height));

                _coordinates[x].Width = element.DesiredSize.Width;
                _coordinates[x].Height = availableSize.Height; // element.DesiredSize.Height;

                total_panel_width += element.DesiredSize.Width;
                //max_height = Math.Max(max_height, element.DesiredSize.Height);
            }

            if (double.IsInfinity(availableSize.Width) == false && availableSize.Width < total_panel_width)
            {
                // The panel contents are too wide.
                double factor = availableSize.Width / total_panel_width;

                SPACING = SPACING * factor;

                double compensate_width = 0d;
                int compensate_count = 0;

                for (int x = 0; x < child_count; x++)
                {
                    double new_width = _coordinates[x].Width * factor;

                    if (new_width < MINIMUM_ELEMENT_WIDTH)
                    {
                        compensate_width += (MINIMUM_ELEMENT_WIDTH - new_width);
                        _coordinates[x].Width = MINIMUM_ELEMENT_WIDTH;
                        compensate[x] = false;
                    }
                    else
                    {
                        _coordinates[x].Width = new_width;
                        compensate[x] = true;
                        compensate_count++;
                    }
                }

                if (compensate_count > 0 && compensate_width > 0)
                {
                    double compensate_per_element = compensate_width / compensate_count;

                    for (int x = 0; x < child_count; x++)
                    {
                        if (compensate[x])
                        {
                            double new_width = _coordinates[x].Width - compensate_per_element;
                            new_width = Math.Max(new_width, MINIMUM_ELEMENT_WIDTH);
                            _coordinates[x].Width = new_width;
                        }
                    }
                }

            }

            double X = 0d;
            total_panel_width = 0d;

            // Set the X coordinate.
            for (int x = 0; x < child_count; x++)
            {
                if (x > 0)
                {
                    X += SPACING;
                    total_panel_width += SPACING;
                }

                _coordinates[x].X = X;

                X += _coordinates[x].Width;
                total_panel_width += _coordinates[x].Width;
            }

            // Set the height to max_height.
            //for (int x = 0; x < child_count; x++)
            //{
            //    _coordinates[x].Height = max_height;
            //}

            // Measure again
            for (int x = 0; x < child_count; x++)
            {
                FrameworkElement element = (FrameworkElement)this.Children[x];

                element.Measure(new Size(_coordinates[x].Width, _coordinates[x].Height));
            }

            return new Size(total_panel_width, availableSize.Height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            for (int i = 0; i < Children.Count; i++)
                Children[i].Arrange(_coordinates[i]);

            return finalSize;
        }


    }
}
