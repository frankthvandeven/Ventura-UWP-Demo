using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{


    public class InputByteNullable : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputByteNullable()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Byte?), typeof(InputByteNullable),
                new PropertyMetadata(default(Byte?), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputByteNullable),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputByteNullable),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputByteNullable).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        //[TypeConverter(typeof(ByteTypeConverter))]
        public Byte? Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Byte?)GetValue(ValueProperty); }
        }

        //[TypeConverter(typeof(ByteTypeConverter))]
        public string MinValue
        {
            set { SetValue(MinValueProperty, value); }
            get { return (string)GetValue(MinValueProperty); }
        }

        //[TypeConverter(typeof(ByteTypeConverter))]
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
            if (this.Value == null)
                this.Text = "";
            else
                this.Text = this.Value.ToString();
        }

    }

}

