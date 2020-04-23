using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputInt32 : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputInt32()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Int32), typeof(InputInt32),
                new PropertyMetadata(default(Int32), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputInt32),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputInt32),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputInt32).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        public Int32 Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Int32)GetValue(ValueProperty); }
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

        #endregion

        // The rest...

        protected override void ConvertText2Value()
        {
            string completedtext = AutoCompletionTools.AutoCompleteIntegral(this.Text, false);

            completedtext = completedtext.Trim();

            bool valid = Int32.TryParse(completedtext, out Int32 value_candidate);

            if (valid == false)
                return;

            if (Int32.TryParse(this.MinValue, out Int32 minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Int32.TryParse(this.MaxValue, out Int32 maxvalue))
                if (value_candidate > maxvalue)
                    return;

            this.Value = value_candidate;
        }

        protected override void ConvertValue2Text()
        {
            this.Text = this.Value.ToString();
        }

    }

}

