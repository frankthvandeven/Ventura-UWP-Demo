using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputDecimal : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }
        public static DependencyProperty MaskProperty { private set; get; }

        static InputDecimal()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(decimal), typeof(InputDecimal),
                new PropertyMetadata(default(decimal), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputDecimal),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputDecimal),
                new PropertyMetadata(""));

            MaskProperty = DependencyProperty.Register(nameof(Mask),
                typeof(string), typeof(InputDecimal),
                new PropertyMetadata("99999999.99", OnMaskPropertyChanged));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDecimal).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        private static void OnMaskPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDecimal).OnMaskPropertyChanged(args);
        }

        private void OnMaskPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            InputDecimal.ValidateMask(args.NewValue as string);
        }

        #region DP <-> Property

        public decimal Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (decimal)GetValue(ValueProperty); }
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

            string completedtext = AutoCompletionTools.AutoCompleteDecimal(this.Text, false, precision, scale);

            completedtext = completedtext.Trim();

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
            this.Text = this.Value.ToString();
        }

        internal static void ValidateMask(string mask)
        {
            const string EXAMPLE = " Example of a valid mask '999999.99' or '99.99999' or '999'";

            if (mask == null)
                throw new Exception("The Mask property cannot be set to null." + EXAMPLE);

            if (mask.Contains("9") == false)
                throw new Exception("The Mask must contain at least one '9' character." + EXAMPLE);

            mask = mask.Replace(',', '.');

            int nine_before_decimalseparator = 0;
            int nine_after_decimalseparator = 0;
            int decimal_separator_count = 0;
            int illegal_character_count = 0;

            for (int i = 0; i < mask.Length; i++)
            {
                char current = mask[i];

                if (current == '9')
                {
                    if (decimal_separator_count == 0)
                        nine_before_decimalseparator++;
                    else
                        nine_after_decimalseparator++;
                }
                else if (current == '.')
                {
                    decimal_separator_count++;
                }
                else
                {
                    illegal_character_count++;
                }
            }

            if (illegal_character_count > 0)
                throw new Exception("Illegal character detected in Mask." + EXAMPLE);

            if (decimal_separator_count > 1)
                throw new Exception("Mask contains multiple decimal separators." + EXAMPLE);

            // The validation made sure that:
            // 1.

        }

        /// <summary>
        /// Only pass a validated mask to this method.
        /// </summary>
        internal static (int precision, int scale) GetPrecisionAndScale(string mask)
        {
            // 9999.99 = precision 6, scale 2

            int precision = 0;
            int scale = 0;
            bool found_separator = false;

            // The mask has already been validated
            mask = mask.Replace(',', '.');

            for (int i = 0; i < mask.Length; i++)
            {
                char current = mask[i];

                if (current == '9')
                {
                    precision++;

                    if (found_separator == true)
                        scale++;
                }
                else if (current == '.')
                {
                    found_separator = true;
                }
                else
                    throw new Exception("should not happen");

            }

            return (precision, scale);
        }

    }
}
