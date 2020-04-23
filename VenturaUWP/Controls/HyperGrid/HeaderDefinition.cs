using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Ventura.Controls
{

    [ContentProperty(Name = "Caption")]
    public class HeaderDefinition : ViewmodelBase
    {
        private double _width = 200;
        private string _caption = "Set a Caption";
        private CaptionAlignment _alignment = CaptionAlignment.Left;

        // The LeftLineVisibility for the first column will be disabled in HyperGridHeader.xaml.cs
        public Visibility LeftLineVisibility { get; set; } = Visibility.Visible;

        public double Width
        {
            get { return _width; }
            internal set
            {
                if (_width == value)
                    return;

                _width = value;

                NotifyPropertyChanged(nameof(Width));
            }
        }


        public string Caption
        {
            get { return _caption; }
            set
            {
                if (_caption == value)
                    return;

                _caption = value;

                NotifyPropertyChanged(nameof(Caption));
            }
        }

        public CaptionAlignment Alignment
        {
            get { return _alignment; }
            set
            {
                if (_alignment == value)
                    return;

                _alignment = value;

                NotifyPropertyChanged(nameof(Alignment));
            }
        }

        public enum CaptionAlignment
        {
            Left = 0,
            Center = 1,
            Right = 2
        }


    }
}
