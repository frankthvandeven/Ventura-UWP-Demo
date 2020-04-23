using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{
    // SVG Path editor online (rotate and flip)
    // https://aydos.com/svgedit/

    [ContentProperty(Name = nameof(Label))]
    public class SmartButton : Button, ISmartButton
    {
        // The space between icon and text label. Only used when both are present.
        private const double SPACING = 6.0d;

        // Statics

        public static DependencyProperty LabelProperty { private set; get; }
        public static DependencyProperty PathDataProperty { private set; get; }
        public static DependencyProperty KeyboardAcceleratorTextOverrideProperty { private set; get; }


        static SmartButton()
        {
            LabelProperty = DependencyProperty.Register(nameof(Label),
                typeof(string), typeof(SmartButton),
                new PropertyMetadata(null, OnLabelPropertyChanged));

            PathDataProperty = DependencyProperty.Register(nameof(PathData),
                typeof(string), typeof(SmartButton),
                new PropertyMetadata(null, OnPathDataPropertyChanged));

            KeyboardAcceleratorTextOverrideProperty = DependencyProperty.Register(nameof(KeyboardAcceleratorTextOverride),
                typeof(string), typeof(SmartButton),
                new PropertyMetadata(null));
        }

        private static void OnLabelPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as SmartButton).OnLabelPropertyChanged(args);
        }

        private void OnLabelPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetControls();
        }

        private static void OnPathDataPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as SmartButton).OnPathDataPropertyChanged(args);
        }

        private Geometry _geometry = null;

        private void OnPathDataPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // A Geometry is not a shareable resource. That is why a path-data string is dynamically converted to Geometry for each button instance.

            string pathdata = args.NewValue as string;

            if (pathdata == null)
                _geometry = null;
            else
                _geometry = (Geometry)XamlBindingHelper.ConvertValue(typeof(Geometry), pathdata);

            ResetControls();
        }

        #region DP <-> Property

        /// <summary>
        /// Gets or sets a collection that is used to generate the content of the control.
        /// </summary>
        public string Label
        {
            set { SetValue(LabelProperty, value); }
            get { return (string)GetValue(LabelProperty); }
        }

        public string PathData
        {
            set { SetValue(PathDataProperty, value); }
            get { return (string)GetValue(PathDataProperty); }
        }

        public string KeyboardAcceleratorTextOverride
        {
            set { SetValue(KeyboardAcceleratorTextOverrideProperty, value); }
            get { return (string)GetValue(KeyboardAcceleratorTextOverrideProperty); }
        }

        #endregion

        // The rest...

        public SmartButton()
        {
            DefaultStyleKey = typeof(SmartButton);
        }

        private bool _init = false;

        private ColumnDefinition _middle_column;
        private Path _iconpath;
        private TextBlock _textlabel;

        protected override void OnApplyTemplate()
        {
            if (_init)
                throw new InvalidOperationException("cannot re-template");

            base.OnApplyTemplate();

            _iconpath = (Path)GetTemplateChild("IconPath");
            _middle_column = (ColumnDefinition)GetTemplateChild("MiddleColumn");
            _textlabel = (TextBlock)GetTemplateChild("TextLabel");

            _init = true;

            ResetControls();
        }

        private void ResetControls()
        {
            if (_init == false)
                return;

            _iconpath.Data = _geometry;

            bool has_label = false;
            bool has_pathdata = false;

            if (this.Label != null && this.Label.Length > 0)
                has_label = true;

            if (_geometry != null)
                has_pathdata = true;

            if (has_pathdata && has_label)
                _middle_column.Width = new GridLength(SPACING);
            else
                _middle_column.Width = new GridLength(0);

            _iconpath.Visibility = has_pathdata ? Visibility.Visible : Visibility.Collapsed;
            _textlabel.Visibility = has_label ? Visibility.Visible : Visibility.Collapsed;

        }




    }
}
