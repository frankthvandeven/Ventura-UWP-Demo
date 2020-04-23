using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{

    public class NavigationBarItem : Control
    {

        // Statics
        public static Brush VenturaOrangeBrush = (Brush)Application.Current.Resources["VenturaOrangeBrush"];

        public static DependencyProperty LabelProperty { private set; get; }
        public static DependencyProperty IsDroppedDownProperty { private set; get; }

        static NavigationBarItem()
        {
            LabelProperty = DependencyProperty.Register(nameof(Label),
                typeof(string), typeof(NavigationBarItem),
                new PropertyMetadata(null, OnLabelPropertyChanged));

            IsDroppedDownProperty = DependencyProperty.Register(nameof(IsDroppedDown),
                typeof(bool), typeof(NavigationBarItem),
                new PropertyMetadata(false, OnIsDroppedDownPropertyChanged));
        }

        private static void OnLabelPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as NavigationBarItem).OnLabelPropertyChanged(args);
        }

        private void OnLabelPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetControls();
        }

        private static void OnIsDroppedDownPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as NavigationBarItem).OnIsDroppedDownPropertyChanged(args);
        }

        private void OnIsDroppedDownPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetControls();
        }


        // DP <-> Property

        public string Label
        {
            set { SetValue(LabelProperty, value); }
            get { return (string)GetValue(LabelProperty); }
        }

        public bool IsDroppedDown
        {
            set { SetValue(IsDroppedDownProperty, value); }
            get { return (bool)GetValue(IsDroppedDownProperty); }
        }

        // The rest...
        private const string VISUALSTATE_NORMAL = "Normal";
        private const string VISUALSTATE_POINTEROVER = "PointerOver";
        //private const string VISUALSTATE_PRESSED = "Pressed";
        //private const string VISUALSTATE_SELECTED = "Selected";
        //private const string VISUALSTATE_POINTEROVERSELECTED = "PointerOverSelected";
        //private const string VISUALSTATE_PRESSEDSELECTED = "PressedSelected";

        public NavigationBarItem()
        {
            DefaultStyleKey = typeof(NavigationBarItem);

            this.DataContextChanged += Control_DataContextChanged;
        }

        private MenubarItem _menubaritem;

        private void Control_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            _menubaritem = (MenubarItem)args.NewValue;

            ResetControls();
        }

        private bool _init = false;

        private Grid _rootgrid;
        private TextBlock _textlabel;
        private Rectangle _rectangle;

        protected override void OnApplyTemplate()
        {
            if (_init)
                throw new InvalidOperationException("cannot re-template");

            base.OnApplyTemplate();

            _rootgrid = (Grid)GetTemplateChild("Root");
            _textlabel = (TextBlock)GetTemplateChild("TextLabel");
            _rectangle = (Rectangle)GetTemplateChild("Rectangle");

            _init = true;

            ResetControls();
        }

        private void ResetControls()
        {
            if (_init == false)
                return;

            _textlabel.Text = _menubaritem.Caption;

            if (this.IsDroppedDown)
                _rectangle.Fill = VenturaOrangeBrush;
            else
                _rectangle.Fill = null;

        }

        protected override void OnPointerEntered(PointerRoutedEventArgs e)
        {
            base.OnPointerEntered(e);

            VisualStateManager.GoToState(this, VISUALSTATE_POINTEROVER, false);
        }

        protected override void OnPointerExited(PointerRoutedEventArgs e)
        {
            base.OnPointerExited(e);

            VisualStateManager.GoToState(this, VISUALSTATE_NORMAL, false);
        }


    }
}
