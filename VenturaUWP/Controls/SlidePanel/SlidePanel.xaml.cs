using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Ventura.Controls
{
    public sealed partial class SlidePanel : UserControl
    {
        public event EventHandler BackdropTapped;

        public SlidePanel()
        {
            InitializeComponent();

            //ShowSlide.To = new Vector3(0, -500, 0);
        }

        private void Backdrop_Tapped(object sender, TappedRoutedEventArgs e) => BackdropTapped?.Invoke(this, new EventArgs());

        //public static readonly DependencyProperty PanelContentProperty = DependencyProperty.Register(
        //    "PanelContent", typeof(FrameworkElement), typeof(SlidePanel), new PropertyMetadata(default(FrameworkElement), OnPanelContentChanged));

        //private static void OnPanelContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is SlidePanel instance)
        //    {
        //        instance.Presenter.Content = e.NewValue;
        //    }
        //}

        //public FrameworkElement PanelContent
        //{
        //    get => (FrameworkElement) GetValue(PanelContentProperty);
        //    set => SetValue(PanelContentProperty, value);
        //}
    }
}
