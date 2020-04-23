using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{


    public class InputInt16Nullable : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputInt16Nullable()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Int16?), typeof(InputInt16Nullable),
                new PropertyMetadata(default(Int16?), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputInt16Nullable),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputInt16Nullable),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputInt16Nullable).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        //[TypeConverter(typeof(Int16TypeConverter))]
        public Int16? Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Int16?)GetValue(ValueProperty); }
        }

        //[TypeConverter(typeof(Int16TypeConverter))]
        public string MinValue
        {
            set { SetValue(MinValueProperty, value); }
            get { return (string)GetValue(MinValueProperty); }
        }

        //[TypeConverter(typeof(Int16TypeConverter))]
        public string MaxValue
        {
            set { SetValue(MaxValueProperty, value); }
            get { return (string)GetValue(MaxValueProperty); }
        }

        #endregion

        // The rest...

        protected override void ConvertText2Value()
        {
            string completedtext = AutoCompletionTools.AutoCompleteIntegral(this.Text, true);

            completedtext = completedtext.Trim();

            if (completedtext == "")
            {
                this.Value = null;
                return;
            }

            bool valid = Int16.TryParse(completedtext, out Int16 value_candidate);

            if (valid == false)
                return;

            if (Int16.TryParse(this.MinValue, out Int16 minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Int16.TryParse(this.MaxValue, out Int16 maxvalue))
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

