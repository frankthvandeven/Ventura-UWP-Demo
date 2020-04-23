using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{
    public class SingleCrumb : Control
    {
        // Statics

        public static DependencyProperty FirstItemProperty { private set; get; }
        public static DependencyProperty TextProperty { private set; get; }

        static SingleCrumb()
        {
            FirstItemProperty = DependencyProperty.Register(nameof(FirstItem),
                typeof(bool), typeof(SingleCrumb),
                new PropertyMetadata(true));

            TextProperty = DependencyProperty.Register(nameof(Text),
                typeof(string), typeof(SingleCrumb),
                new PropertyMetadata(""));

        }

        public bool FirstItem
        {
            set { SetValue(FirstItemProperty, value); }
            get { return (bool)GetValue(FirstItemProperty); }
        }

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        // The rest...

        public SingleCrumb()
        {
            DefaultStyleKey = typeof(SingleCrumb);
        }

        private Path _pathfirst;
        private Path _pathsecond;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _pathfirst = this.GetTemplateChild("PathFirst") as Path;
            _pathsecond = this.GetTemplateChild("PathSecond") as Path;

            if( this.FirstItem == false )
            {
                _pathfirst.Visibility = Visibility.Collapsed;
                _pathsecond.Visibility = Visibility.Visible;
            }

        }


    }
}
