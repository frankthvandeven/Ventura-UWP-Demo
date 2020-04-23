using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventura.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{
    public class SmartGridColumn : DataGridTextColumn, IValueConverter
    {
        private SmartGridColumnKind _columnkind;

        public SmartGridColumn()
        {
            _columnkind = SmartGridColumnKind.Text;
        }

        public SmartGridColumnKind Kind
        {
            get { return _columnkind; }
            set { _columnkind = value; }
        }


        public override Binding Binding
        {
            get
            {
                return base.Binding;
            }
            set
            {
                if (value != null)
                    value.Converter = this; // We want to convert values inside this class.

                base.Binding = value;
            }
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var element = base.GenerateElement(cell, dataItem);

            // The hardcoded margins are 12,0,12,0
            element.Margin = new Thickness(3d, 0d, 3d, 0d);

            return element;
        }

        // The value parameter is the databound value.
        // The return value is the grid cell value.
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            if (_columnkind == SmartGridColumnKind.DateTimeIso)
            {
                DateTime dt = Parsers.ParseISO8601String(value as string);
                return dt.ToString();
            }

            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public enum SmartGridColumnKind
    {
        Text,

        DateTimeIso,
        DateIso,


    }


}


