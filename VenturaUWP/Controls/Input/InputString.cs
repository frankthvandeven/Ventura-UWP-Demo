using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputString : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty FormattingProperty { private set; get; }

        static InputString()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(string), typeof(InputString),
                new PropertyMetadata(string.Empty, OnValuePropertyChanged));

            FormattingProperty = DependencyProperty.Register(nameof(Formatting),
                typeof(InputStringFormatting), typeof(InputString),
                new PropertyMetadata(InputStringFormatting.None, OnFormattingPropertyChanged));

        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputString).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        private static void OnFormattingPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputString).OnFormattingPropertyChanged(args);
        }

        private void OnFormattingPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        public string Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (string)GetValue(ValueProperty); }
        }

        public InputStringFormatting Formatting
        {
            set { SetValue(FormattingProperty, value); }
            get { return (InputStringFormatting)GetValue(FormattingProperty); }
        }

        #endregion

        // The rest...

        protected override void ConvertText2Value()
        {
            string completedtext = AutoCompletionTools.AutoCompleteString(this.Text, this.Formatting);

            this.Value = completedtext;
        }

        protected override void ConvertValue2Text()
        {
            if (this.Value == null)
                this.Text = "";
            else
                this.Text = this.Value;
        }

    }


}
