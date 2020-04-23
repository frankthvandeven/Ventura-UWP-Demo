using System;
using Windows.UI.Xaml.Data;

namespace Ventura.Converters
{
    public sealed class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal m)
            {
                return m == 0 ? "" : m.ToString();
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (Decimal.TryParse(value.ToString(), out decimal m))
                {
                    return m;
                }
            }
            return 0m;
        }
    }
}
