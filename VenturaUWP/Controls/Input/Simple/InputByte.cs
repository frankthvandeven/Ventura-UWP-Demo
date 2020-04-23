using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputByte : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputByte()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Byte), typeof(InputByte),
                new PropertyMetadata(default(Byte), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputByte),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputByte),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputByte).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        public Byte Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Byte)GetValue(ValueProperty); }
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

            bool valid = Byte.TryParse(completedtext, out Byte value_candidate);

            if (valid == false)
                return;

            if (Byte.TryParse(this.MinValue, out Byte minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Byte.TryParse(this.MaxValue, out Byte maxvalue))
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

