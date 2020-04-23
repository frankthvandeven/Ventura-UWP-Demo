using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{

    public partial class Form : ItemsControl
    {
        // Statics

        public static DependencyProperty StretchRowsProperty { private set; get; }

        static Form()
        {
            StretchRowsProperty = DependencyProperty.Register(nameof(StretchRows),
                typeof(bool), typeof(Form), 
                new PropertyMetadata(true));

        }

        // OnPropertyChanged callbacks.


        // DP <-> Property

        public bool StretchRows
        {
            get { return (bool)this.GetValue(StretchRowsProperty); }
            set { SetValue(StretchRowsProperty, value); }
        }





    }
}