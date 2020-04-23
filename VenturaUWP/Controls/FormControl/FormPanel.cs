using Microsoft.Toolkit.Uwp.UI.Extensions;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    internal class FormPanel : Panel
    {
        private static double GridLineWidth = (double)Application.Current.Resources["GridLineWidth"];

        private Form _formControl;
        private FormFieldData[] _fields;

        private List<FormRowData> _rows;
        private double _LINE_WIDTH;

        private List<Rect> _rectangles = new List<Rect>(128);

        private bool _stretch_rows;

        protected override Size MeasureOverride(Size availableSize)
        {
            //if (double.IsInfinity(availableSize.Width))
            //    throw new Exception("Did not learn how to handle infinity-width in measure pass yet.");

            _LINE_WIDTH = FormPanel.GridLineWidth;

            _stretch_rows = this.Form.StretchRows;

            // This contains FieldData per child control.
            _fields = new FormFieldData[this.Children.Count];

            // The same field data split in rows.
            _rows = new List<FormRowData>();

            _rectangles.Clear();

            // Create a FormFieldDataObject for each child control.
            // Find the DesiredHeight and DesiredHeight for each child control and store it in the FieldData object.
            // Also detect if a child control is of fixed width or height.
            InitializeFieldDataObjects();

            // Fill the _rows list.
            BuildRowStructure(availableSize.Width);

            // Calculates and sets RowData and FormFieldData properties.
            SetRowAndFieldProperties();

            foreach (var row in _rows)
                row.TotalRowWidth = CalculateTotalRowWidth(row);

            // Calculate the Width of the panel.
            double panel_width = this.CalculateDesiredPanelWidth();

            if (_stretch_rows == true)
                foreach (var row in _rows)
                    this.BalanceRow(panel_width, row);

            // ReMeasure all the children for an updated Height.

            foreach (var row in _rows)
                row.TotalRowHeight = CalculateTotalRowHeight(row);

            // Make all fields in a single row the same height.
            foreach (var row in _rows)
                BalanceRowHeight(row);

            double panel_height = this.CalculatePanelHeight();

            // Calculate the exact field coordinates
            double OffsetY = 0;

            FormRowData previous_row = null;

            foreach (var row in _rows)
            {
                double horizontal_width = row.TotalRowWidth;

                if (previous_row != null && previous_row.TotalRowWidth > horizontal_width)
                    horizontal_width = previous_row.TotalRowWidth;

                if (_stretch_rows)
                    horizontal_width = panel_width;

                // Horizontal line
                AddRectangle(0, OffsetY, horizontal_width, _LINE_WIDTH);

                OffsetY += _LINE_WIDTH;

                if (_stretch_rows == true && row.TotalRowWidth < panel_width)
                {
                    // The closing vertical line.
                    AddRectangle(panel_width - _LINE_WIDTH, OffsetY, _LINE_WIDTH, row.TotalRowHeight);
                }

                // The method will also fill the list of _rectangles for the vertical separators
                CalculateFieldPositions(ref OffsetY, row);

                previous_row = row;
            }

            // The final horizontal line
            AddRectangle(0, OffsetY, _stretch_rows ? panel_width : previous_row.TotalRowWidth, _LINE_WIDTH);

            this.Form.DrawSeparatorLines(_rectangles);

            return new Size(panel_width, panel_height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            //base.ArrangeOverride(finalSize);

            for (int i = 0; i < _fields.Length; i++)
            {
                var field = _fields[i];

                if (field != null)
                    this.Children[i].Arrange(new Rect(field.X, field.Y, field.Width, field.Height));
                else
                    this.Children[i].Arrange(new Rect(0, 0, 0, 0));
            }

            return finalSize;
        }

        private void InitializeFieldDataObjects()
        {
            for (int i = 0; i < this.Children.Count; i++)
            {
                FrameworkElement element = this.Children[i] as FrameworkElement;

                if (element == null)
                    throw new Exception("a Form child is not a FrameworkElement");

                if (element.ReadLocalValue(FrameworkElement.WidthProperty) != DependencyProperty.UnsetValue)
                    throw new Exception("Do not set the Width property for Form children.");

                if (element is FormField)
                {
                    double fieldwidth = ((FormField)element).FieldWidth;

                    // Measure the element
                    element.Measure(new Size(fieldwidth, double.PositiveInfinity));
                    var desired = element.DesiredSize;

                    _fields[i] = new FormFieldData
                    {
                        Width = fieldwidth,
                        Height = desired.Height
                    };


                }
                else if (element is NewLine)
                {
                    _fields[i] = null;
                }
                else
                {
                    throw new Exception("unknown element type");
                }

            }
        }

        private double CalculateTotalRowWidth(FormRowData row)
        {
            double row_width = _LINE_WIDTH;

            foreach (var field in row.Fields)
            {
                row_width += field.Width;
                row_width += _LINE_WIDTH;
            }

            return row_width;
        }

        private double CalculateTotalRowHeight(FormRowData row)
        {
            double row_height = 0;

            foreach (var field in row.Fields)
                row_height = Math.Max(row_height, field.Height);

            return row_height;
        }

        private double CalculateDesiredPanelWidth()
        {
            double panelWidth = 0;

            foreach (var row in _rows)
                panelWidth = Math.Max(row.TotalRowWidth, panelWidth);

            return panelWidth;
        }

        private double CalculatePanelHeight()
        {
            // The width and height of the panel contents.
            double panel_height = _LINE_WIDTH;

            foreach (var row in _rows)
            {
                panel_height += row.TotalRowHeight;
                panel_height += _LINE_WIDTH;
            }

            return panel_height;
        }

        public void BalanceRow(double target_width, FormRowData row)
        {
            if (row.TotalRowWidth == target_width)
                return;

            double remainder = target_width - row.TotalRowWidth;
            double rowfactor = remainder / row.TotalRowWidth;

            if (rowfactor > 1.30d) // more than 30% space to fill, stretching the fields will start to look weird
                return;

            double total = 0;

            foreach (var field in row.Fields)
                total += field.Width;

            foreach (var field in row.Fields)
            {
                double factor = (field.Width / total);
                double extra = remainder * factor;
                field.Width += extra;
                row.TotalRowWidth += extra;
            }

        }

        public void BalanceRowHeight(FormRowData row)
        {
            foreach (var field in row.Fields)
            {
                if (field.Height < row.TotalRowHeight)
                    field.Height = row.TotalRowHeight;
            }

        }

        private void AddRectangle(double x, double y, double width, double height)
        {
            _rectangles.Add(new Rect(x, y, width, height));
        }

        private void CalculateFieldPositions(ref double OffsetY, FormRowData row)
        {
            double OffsetX = 0;

            // The first vertical line on the left.
            AddRectangle(OffsetX, OffsetY,  _LINE_WIDTH, row.TotalRowHeight);
            OffsetX += _LINE_WIDTH;

            foreach (var field in row.Fields)
            {
                field.X = OffsetX;
                field.Y = OffsetY;

                OffsetX += field.Width;

                // The vertical line after each FormField
                AddRectangle(OffsetX, OffsetY, _LINE_WIDTH, row.TotalRowHeight);
                OffsetX += _LINE_WIDTH;

            }

            OffsetY += row.TotalRowHeight;
        }

        public void BuildRowStructure(double available_width)
        {
            FormRowData new_row = new FormRowData();
            double width = 0d;

            for (int i = 0; i < _fields.Length; i++)
            {
                FormFieldData field = _fields[i];

                if (field == null) // This is a NewLine. 
                {
                    if (new_row.Fields.Count > 0)
                        _rows.Add(new_row);

                    new_row = new FormRowData();
                    width = 0d;
                }
                else // field is not null
                {
                    if ((width + field.Width) > available_width) // wrap the formfield to a new line.
                    {
                        if (new_row.Fields.Count > 0)
                            _rows.Add(new_row);

                        new_row = new FormRowData();
                        width = 0;
                    }

                    new_row.Fields.Add(field);
                    width += field.Width;
                }
            }

            if (new_row.Fields.Count > 0)
                _rows.Add(new_row);
        }

        public void SetRowAndFieldProperties()
        {
            for (int i = 0; i < _rows.Count; i++)
            {
                var row = _rows[i];

                row.IsLastRow = (i == _rows.Count - 1);

                for (int z = 0; z < row.Fields.Count; z++)
                {
                    var field = row.Fields[z];

                    field.IsLastField = (z == row.Fields.Count - 1);
                }

            }
        }

        /// <summary>
        /// Gets the Current Form control.
        /// Form is the parent of FormPanel.
        /// </summary>
        public Form Form
        {
            get
            {
                if (_formControl != null)
                    return _formControl;

                _formControl = this.FindAscendant<Form>();

                if (_formControl == null) throw new Exception("This FormPanel must be used as an ItemsPanel in a Form control.");

                return _formControl;
            }
        }

    }
}
