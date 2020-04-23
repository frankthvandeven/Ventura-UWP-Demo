using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{


    public class InputInt32Nullable : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputInt32Nullable()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Int32?), typeof(InputInt32Nullable),
                new PropertyMetadata(default(Int32?), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputInt32Nullable),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputInt32Nullable),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputInt32Nullable).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        //[TypeConverter(typeof(Int32TypeConverter))]
        public Int32? Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Int32?)GetValue(ValueProperty); }
        }

        //[TypeConverter(typeof(Int32TypeConverter))]
        public string MinValue
        {
            set { SetValue(MinValueProperty, value); }
            get { return (string)GetValue(MinValueProperty); }
        }

        //[TypeConverter(typeof(Int32TypeConverter))]
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
            if (this.Value == null)
                this.Text = "";
            else
                this.Text = this.Value.ToString();
        }

    }

}



//[TypeConverter(typeof(Int32TypeConverter))]
//public class Int32TypeConverter : TypeConverter
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
