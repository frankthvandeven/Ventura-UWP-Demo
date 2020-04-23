using Ventura.Controls;
using Ventura.Helpers;
using Windows.UI.Xaml.Controls;

namespace Demo.Pages
{
    
    public sealed partial class ColorPage : SmartPage
    {
        public ColorPage()
        {
            this.InitializeComponent();

            this.Loaded += ColorPage_Loaded;

        }

        private void ColorPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var colorinfo = new DistinctColors();
            var array = colorinfo.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                DistinctColorInfo info = array[i];

                var tb = new TextBlock
                {
                    Margin= new Windows.UI.Xaml.Thickness(10,3,10,3),
                    Text = $"{info.Name} {i}",
                    Foreground = info.ForegroundBrush,
                };

                var grid = new Grid
                {
                    Height = 32,
                    Children = { tb },
                    Background = info.BackgroundBrush
                };

                stackpanel.Children.Add(grid);
            }
        }
    }
}
