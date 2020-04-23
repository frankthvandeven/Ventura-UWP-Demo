using Ventura.Controls;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


namespace Demo
{
    public sealed partial class LocalmenusPage : SmartPage
    {
        private static Brush VenturaAccentBrush = (Brush)Application.Current.Resources["VenturaAccentBrush"];

        public LocalmenusPage()
        {
            this.InitializeComponent();
        }

        protected override void OnActivated()
        {
            rectangle.Fill = VenturaAccentBrush;
        }

        protected override void OnDeActivated()
        {
            rectangle.Fill = null;
        }


    }
}
