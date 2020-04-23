using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Ventura.Helpers
{
    public static class ClipHelper
    {
        
        /// <summary>
        /// Call this method from the SizeChanged event of a UIElement to enable clipping.
        /// </summary>
        public static void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UIElement element = sender as UIElement;

            if (element == null)
                return; // nothing to do

            element.Clip = new RectangleGeometry()
            {
                Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height)
            };
        }

    }
}

