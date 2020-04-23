using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Ventura.Controls
{

    
    public class Tabstrip : ListViewBase
    {
        private const int SCROLL_AMOUNT = 100; 

        public Tabstrip()
        {
            DefaultStyleKey = typeof(Tabstrip);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TabstripItem();
        }

        private bool _init = false;
        private ButtonBase _tabScrollBackButton;
        private ButtonBase _tabScrollForwardButton;
        private ScrollViewer _tabScroller;

        protected override void OnApplyTemplate()
        {
            if (_init)
                throw new Exception("re-templating not supported");

            base.OnApplyTemplate();

            _tabScrollBackButton = (ButtonBase)GetTemplateChild("ScrollBackButton");
            _tabScrollForwardButton = (ButtonBase)GetTemplateChild("ScrollForwardButton");
            _tabScroller = (ScrollViewer)GetTemplateChild("ScrollViewer");

            _tabScrollBackButton.Click += ScrollBackButton_Click;
            _tabScrollForwardButton.Click += ScrollForwardButton_Click;

            _tabScroller.RegisterPropertyChangedCallback(ScrollViewer.ScrollableWidthProperty, new DependencyPropertyChangedCallback(ScrollableWidth_PropertyChanged));


            _init = true;
        }

        private void ScrollableWidth_PropertyChanged(DependencyObject obj, DependencyProperty pr)
        {
            if( _tabScroller.ScrollableWidth > 20d) // was 65
            {
                _tabScrollBackButton.Visibility = Visibility.Visible;
                _tabScrollForwardButton.Visibility = Visibility.Visible;
            }
            else
            {
                _tabScrollBackButton.Visibility = Visibility.Collapsed;
                _tabScrollForwardButton.Visibility = Visibility.Collapsed;
            }

        }

        private void ScrollBackButton_Click(object sender, RoutedEventArgs e)
        {
            _tabScroller.ChangeView(Math.Max(0, _tabScroller.HorizontalOffset - SCROLL_AMOUNT), null, null);
        }

        private void ScrollForwardButton_Click(object sender, RoutedEventArgs e)
        {
            _tabScroller.ChangeView(Math.Min(_tabScroller.ScrollableWidth, _tabScroller.HorizontalOffset + SCROLL_AMOUNT), null, null);
        }



    }
}
