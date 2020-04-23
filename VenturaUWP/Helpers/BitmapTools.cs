using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

namespace Ventura.Helpers
{
    public static class BitmapTools
    {
        public static async Task<BitmapImage> LoadBitmapAsync(byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                using (var stream = new InMemoryRandomAccessStream())
                {
                    var bitmap = new BitmapImage();
                    await stream.WriteAsync(bytes.AsBuffer());
                    stream.Seek(0);
                    await bitmap.SetSourceAsync(stream);
                    return bitmap;
                }
            }
            return null;
        }

        public static async Task<BitmapImage> LoadBitmapAsync(IRandomAccessStreamReference randomStreamReference)
        {
            var bitmap = new BitmapImage();
            try
            {
                using (var stream = await randomStreamReference.OpenReadAsync())
                {
                    await bitmap.SetSourceAsync(stream);
                }
            }
            catch { }
            return bitmap;
        }

        public static BitmapImage LoadBitmap(object value)
        {
            var array = value as byte[];

            if (array == null)
                return null;

            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(array);
                    writer.StoreAsync().GetResults();
                }
                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            }

        }
    }
}
