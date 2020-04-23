using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputDecimalNullable : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }
        public static DependencyProperty MaskProperty { private set; get; }

        static InputDecimalNullable()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(decimal?), typeof(InputDecimalNullable),
                new PropertyMetadata(default(decimal?), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputDecimalNullable),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputDecimalNullable),
                new PropertyMetadata(""));

            MaskProperty = DependencyProperty.Register(nameof(Mask),
                typeof(string), typeof(InputDecimalNullable),
                new PropertyMetadata("99999999.99", OnMaskPropertyChanged));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDecimalNullable).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        private static void OnMaskPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDecimalNullable).OnMaskPropertyChanged(args);
        }

        private void OnMaskPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            InputDecimal.ValidateMask(args.NewValue as string);
        }

        #region DP <-> Property

        public decimal? Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (decimal?)GetValue(ValueProperty); }
        }

        public string MinValue
        {
            set { SetValue(MinValueProperty, value); }
            get { return (string)GetValue(MinValueProperty); }
        }

        public string MaxValue
        {
            set { SetValue(MaxValueProperty, value); }
            get { return (string)GetValue(MaxValueProperty); }
        }

        /// <summary>
        /// Determines the conversion of text to decimal. For example "99999.99" or "99.99999"
        /// </summary>
        public string Mask
        {
            set { SetValue(MaskProperty, value); }
            get { return (string)GetValue(MaskProperty); }
        }

        #endregion

        // The rest...

        protected override void ConvertText2Value()
        {
            (int precision, int scale) = InputDecimal.GetPrecisionAndScale(this.Mask);

            string completedtext = AutoCompletionTools.AutoCompleteDecimal(this.Text, true, precision, scale);

            completedtext = completedtext.Trim();

            if (completedtext == "")
            {
                this.Value = null;
                return;
            }

            bool valid = decimal.TryParse(completedtext, out decimal value_candidate);

            if (valid == false)
                return;

            if (Decimal.TryParse(this.MinValue, out Decimal minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Decimal.TryParse(this.MaxValue, out Decimal maxvalue))
                if (value_candidate > maxvalue)
                    return;

            this.Value = value_candidate;
        }

        protected override void ConvertValue2Text()
        {
            if (this.Value == null)
                this.Text = "";
            else
                this.Text = this.Value.ToString();
        }

    }
}
