using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    // this.Value communicates with the outside world.
    // _TextBox.Text is just the internal representation.

    // Old code:
    // C:\Bagger\TN6\TN10\Sources\Core\TerranovaWinFormsCore\InputControls

    public abstract class InputBase : Control
    {
        // Statics

        public static DependencyProperty MaxLengthProperty { private set; get; }

        static InputBase()
        {

            MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength),
                typeof(int), typeof(InputBase),
                new PropertyMetadata(0, OnMaxLengthPropertyChanged));
        }

        private static void OnMaxLengthPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputBase).OnMaxLengthPropertyChanged(args);
        }

        private void OnMaxLengthPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            int maxlength = (int)args.NewValue;

            if (_initialized)
            {
                _TextBox.MaxLength = maxlength;
            }

        }

        #region DP <-> Property

        public int MaxLength
        {
            set { SetValue(MaxLengthProperty, value); }
            get { return (int)GetValue(MaxLengthProperty); }
        }

        #endregion

        // The rest...

        public InputBase()
        {
            this.DefaultStyleKey = typeof(InputBase);
        }

        public TextBox TextBox
        {
            get { return _TextBox; }
        }


        private bool _initialized = false;
        private TextBox _TextBox;

        private MiniButton _enterbutton;
        private MiniButton _cancelbutton;

        protected override void OnApplyTemplate()
        {
            if (_initialized) throw new System.Exception("only call once");

            base.OnApplyTemplate();

            _TextBox = (TextBox)GetTemplateChild("textbox");
            _enterbutton = (MiniButton)GetTemplateChild("EnterButton");
            _cancelbutton = (MiniButton)GetTemplateChild("CancelButton");

            _TextBox.MaxLength = this.MaxLength;

            _TextBox.GotFocus += TextBox_GotFocus;
            _TextBox.TextChanged += TextBox_TextChanged;
            _TextBox.LostFocus += TextBox_LostFocus;

            _enterbutton.Click += EnterButton_Click;
            _cancelbutton.Click += CancelButton_Click;

            _initialized = true;

            ConvertValue2Text();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _TextBox.SelectAll();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_TextBox.FocusState != FocusState.Unfocused)
            {
                _enterbutton.Visibility = Visibility.Visible;
                _cancelbutton.Visibility = Visibility.Visible;
            }

        }

        private void TextBox_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _enterbutton.Visibility = Visibility.Collapsed;
            _cancelbutton.Visibility = Visibility.Collapsed;

            // Tries to convert the text to a value and sets the value.
            ConvertText2Value();

            // This will AutoComplete the text entered by the user.
            ConvertValue2Text();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            _TextBox.TextChanged -= TextBox_TextChanged;

            // Tries to convert the text to a value and sets the value.
            ConvertText2Value();

            // This will AutoComplete the text entered by the user.
            ConvertValue2Text();

            _TextBox.SelectAll();

            _enterbutton.Visibility = Visibility.Collapsed;
            _cancelbutton.Visibility = Visibility.Collapsed;

            _TextBox.TextChanged += TextBox_TextChanged;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _TextBox.TextChanged -= TextBox_TextChanged;

            ConvertValue2Text();

            _TextBox.SelectAll();

            _enterbutton.Visibility = Visibility.Collapsed;
            _cancelbutton.Visibility = Visibility.Collapsed;

            _TextBox.TextChanged += TextBox_TextChanged;

        }

        protected string Text
        {
            get
            {
                if (!_initialized) // OnApplyTemplate() did not run yet.
                    return null;

                return _TextBox.Text;
            }
            set
            {
                if (!_initialized) // OnApplyTemplate() did not run yet.
                    return;

                if (value.Equals(_TextBox.Text))
                    return;

                _TextBox.TextChanged -= TextBox_TextChanged;

                _TextBox.Text = value;

                _TextBox.TextChanged += TextBox_TextChanged;

            }
        }

        protected abstract void ConvertText2Value();

        protected abstract void ConvertValue2Text();


    }
}
