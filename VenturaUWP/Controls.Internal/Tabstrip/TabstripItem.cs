using System;
using Ventura.Shell;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{
    public class TabstripItem : ListViewItem
    {
        // Statics for fast resource data access
        public static Brush ForegroundBrush = new SolidColorBrush(Colors.Black);
        public static Brush BackgroundBrush = (Brush)Application.Current.Resources["VenturaGrayDark1Brush"];

        public TabstripItem()
        {
            DefaultStyleKey = typeof(TabstripItem);

            //RegisterPropertyChangedCallback(IsSelectedProperty, IsSelected_PropertyChanged);

            this.DataContextChanged += TabstripItem_DataContextChanged;
        }

        private TabData _tabdata;

        private void TabstripItem_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (_tabdata != null)
                _tabdata.PropertyChanged -= TabData_PropertyChanged;

            _tabdata = args.NewValue as TabData;

            _tabdata.PropertyChanged += TabData_PropertyChanged;

            UpdateDisplay();
        }

        private void TabData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (_tabdata == null)
                throw new Exception("tabdata null, should not happen");

            // The visual tree is not ready yet.
            if (_initialized == false)
                return;

            _linksymbol.Visibility = Visibility.Collapsed;
            _antennasymbol.Visibility = Visibility.Collapsed;
            _rectangle_left.Visibility = Visibility.Collapsed;
            _rectangle_right.Visibility = Visibility.Collapsed;

            if (_tabdata.IsLinkedActive)
            {
                _rectangle_left.Fill = _tabdata.ColorInfo.BackgroundBrush;
                _rectangle_left.Visibility = Visibility.Visible;

                _rectangle_right.Fill = _tabdata.ColorInfo.BackgroundBrush;
                _rectangle_right.Visibility = Visibility.Visible;

                if (_tabdata.IsSatellite)
                    _linksymbol.Visibility = Visibility.Visible;
                else
                    _antennasymbol.Visibility = Visibility.Visible;
            }

            if (_tabdata.IsSelected)
            {
                _textblockCaption.Foreground = _tabdata.ColorInfo.ForegroundBrush;
                _trapezium.Fill = _tabdata.ColorInfo.BackgroundBrush;
            }
            else
            {
                _textblockCaption.Foreground = TabstripItem.ForegroundBrush;
                _trapezium.Fill = TabstripItem.BackgroundBrush;
            }

            if (_tabdata.IsSelected)
                _trapezium.Height = 36;
            else
                _trapezium.Height = 26;

            _textblockCaption.Text = _tabdata.Caption;

#if TESTING
            StringBuilder test = new StringBuilder();

            test.Append(_tabdata.IsSelected ? "selYES" : "selNO");
            test.Append(_tabdata.IsActivated ? " actYES" : " actNO");
            test.Append(_tabdata.IsSatellite ? " satYES" : " satNO");
            test.Append(_tabdata.MasterTabActiveAndSelected ? " masterYES" : " masterNO");
            _textblockCaption.Text = test.ToString();
#endif

        }

        private bool _initialized = false;
        private TextBlock _textblockCaption;
        private Path _trapezium;
        private Path _linksymbol;
        private Path _antennasymbol;
        private Rectangle _rectangle_left;
        private Rectangle _rectangle_right;

        protected override void OnApplyTemplate()
        {
            if (_initialized)
                throw new Exception("only once allowed");

            base.OnApplyTemplate();

            _trapezium = (Path)GetTemplateChild("Trapezium");
            _linksymbol = (Path)GetTemplateChild("LinkSymbol");
            _antennasymbol = (Path)GetTemplateChild("AntennaSymbol");
            _rectangle_left = (Rectangle)GetTemplateChild("RectangleLeft");
            _rectangle_right = (Rectangle)GetTemplateChild("RectangleRight");
            _textblockCaption = (TextBlock)GetTemplateChild("TextBlockCaption");

            _initialized = true;

            UpdateDisplay();
        }


    }
}
