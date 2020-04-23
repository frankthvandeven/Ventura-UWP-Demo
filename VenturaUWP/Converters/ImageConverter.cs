using System;
using Ventura.Helpers;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Ventura.Converters
{
    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if( value is byte[] array)
            {
                return BitmapTools.LoadBitmap(array);
            }
            else if (value is ImageSource imageSource)
            {
                return imageSource;
            }
            else if (value is String url)
            {
                return url;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
