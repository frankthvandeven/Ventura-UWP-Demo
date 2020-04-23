using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public enum FormRemarkPosition
    {
        Bottom,
        Right
    }

    public partial class FormField : Control
    {
        // Statics

        public static DependencyProperty IsActiveProperty { private set; get; }
        public static DependencyProperty FieldWidthProperty { private set; get; }
        public static DependencyProperty HeaderProperty { private set; get; }
        public static DependencyProperty RemarkProperty { private set; get; }
        public static DependencyProperty RemarkPositionProperty { private set; get; }
        public static DependencyProperty RemarkWidthProperty { private set; get; }
        public static DependencyProperty ChildProperty { private set; get; }
        public static DependencyProperty SmartScaleFactorProperty { private set; get; }
        public static DependencyProperty ButtonsProperty { private set; get; }


        static FormField()
        {
            IsActiveProperty = DependencyProperty.Register(nameof(IsActive),
                typeof(bool), typeof(FormField),
                new PropertyMetadata(false, OnIsActivePropertyChanged)); 

            FieldWidthProperty = DependencyProperty.Register(nameof(FieldWidth),
                typeof(double), typeof(FormField),
                new PropertyMetadata(200d)); // double.NaN

            HeaderProperty = DependencyProperty.Register(nameof(Header),
                typeof(string), typeof(FormField),
                new PropertyMetadata("no header set"));

            RemarkProperty = DependencyProperty.Register(nameof(Remark),
                typeof(string), typeof(FormField),
                new PropertyMetadata("", OnRemarkPropertyChanged));

            RemarkPositionProperty = DependencyProperty.Register(nameof(RemarkPosition),
                typeof(FormRemarkPosition), typeof(FormField),
                new PropertyMetadata(FormRemarkPosition.Bottom, OnRemarkPositionPropertyChanged));

            RemarkWidthProperty = DependencyProperty.Register(nameof(RemarkWidth),
                typeof(double), typeof(FormField),
                new PropertyMetadata(0d)); // double.NaN

            ChildProperty = DependencyProperty.Register(nameof(Child),
                typeof(FrameworkElement), typeof(FormField),
                new PropertyMetadata(null, OnChildPropertyChanged));

            SmartScaleFactorProperty = DependencyProperty.Register(nameof(SmartScaleFactor),
                typeof(double), typeof(FormField),
                new PropertyMetadata(1.0d));

            ButtonsProperty = DependencyProperty.Register(nameof(Buttons),
                typeof(ObservableCollection<MiniButton>), typeof(FormField),
                new PropertyMetadata(null));

        }

        // OnPropertyChanged callbacks.
        private static void OnIsActivePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as FormField).OnIsActivePropertyChanged(args);
        }

        private void OnIsActivePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetIsActive();
        }

        private static void OnRemarkPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as FormField).OnRemarkPropertyChanged(args);
        }

        private void OnRemarkPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetRemark();
        }

        private static void OnRemarkPositionPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as FormField).OnRemarkPositionPropertyChanged(args);
        }

        private void OnRemarkPositionPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetRemark();
        }

        private static void OnChildPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as FormField).OnChildPropertyChanged(args);
        }

        private void OnChildPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            if (_smartscaler == null)
                return;

            // Clear current child.
            //_layoutRoot.Children.Clear();
            _smartscaler.Content = null;

            if (args.NewValue != null)
            {
                // Add the new child to the tree.
                //_layoutRoot.Children.Add(newContent);
                _smartscaler.Content = args.NewValue;
            }

            // New child means re-layout is necessary.
            InvalidateMeasure();
        }


        // DP <-> Property

        public bool IsActive
        {
            set { SetValue(IsActiveProperty, value); }
            get { return (bool)GetValue(IsActiveProperty); }
        }

        /// <summary>
        /// The preferred width of the formfield. The field will get at least this width.
        /// The final width can be more.
        /// </summary>
        public double FieldWidth
        {
            set { SetValue(FieldWidthProperty, value); }
            get { return (double)GetValue(FieldWidthProperty); }
        }

        /// <summary>
        /// Gets or sets the header text for the form field.
        /// </summary>
        public string Header
        {
            set { SetValue(HeaderProperty, value); }
            get { return (string)GetValue(HeaderProperty); }
        }

        public string Remark
        {
            set { SetValue(RemarkProperty, value); }
            get { return (string)GetValue(RemarkProperty); }
        }

        public FormRemarkPosition RemarkPosition
        {
            set { SetValue(RemarkPositionProperty, value); }
            get { return (FormRemarkPosition)GetValue(RemarkPositionProperty); }
        }

        public double RemarkWidth
        {
            set { SetValue(RemarkWidthProperty, value); }
            get { return (double)GetValue(RemarkWidthProperty); }
        }

        public FrameworkElement Child
        {
            get { return (FrameworkElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public double SmartScaleFactor
        {
            get { return (double)this.GetValue(SmartScaleFactorProperty); }
            set { SetValue(SmartScaleFactorProperty, value); }
        }

        public ObservableCollection<MiniButton> Buttons
        {
            get { return (ObservableCollection<MiniButton>)GetValue(ButtonsProperty); }
        }

    }
}
