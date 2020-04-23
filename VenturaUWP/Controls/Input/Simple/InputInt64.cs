using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputInt64 : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputInt64()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Int64), typeof(InputInt64),
                new PropertyMetadata(default(Int64), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputInt64),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputInt64),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputInt64).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        public Int64 Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Int64)GetValue(ValueProperty); }
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

            bool valid = Int64.TryParse(completedtext, out Int64 value_candidate);

            if (valid == false)
                return;

            if (Int64.TryParse(this.MinValue, out Int64 minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Int64.TryParse(this.MaxValue, out Int64 maxvalue))
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



//[TypeConverter(typeof(Int64TypeConverter))]
//public class Int64TypeConverter : TypeConverter
//{
//    // Can convert a string into ......
//    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
//    {
//        return true;
//        return base.CanConvertFrom(context, sourceType);
//    }

//    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
//    {
//        return true;
//        return base.CanConvertTo(context, destinationType);
//    }

//    // From string(xaml) to long
//    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
//    {
//        //var x = base.ConvertFrom(context, culture, value);
//        return 12L;
//    }

//    // Convert from long to string(xaml)
//    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
//    {
//        //var x = base.ConvertTo(context, culture, value, destinationType);
//        return "12";
//    }
//}
