using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputDouble : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }
        public static DependencyProperty MinValueProperty { private set; get; }
        public static DependencyProperty MaxValueProperty { private set; get; }

        static InputDouble()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(Double), typeof(InputDouble),
                new PropertyMetadata(default(Double), OnValuePropertyChanged));

            MinValueProperty = DependencyProperty.Register(nameof(MinValue),
                typeof(string), typeof(InputDouble),
                new PropertyMetadata(""));

            MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                typeof(string), typeof(InputDouble),
                new PropertyMetadata(""));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDouble).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            ConvertValue2Text();
        }

        #region DP <-> Property

        public Double Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (Double)GetValue(ValueProperty); }
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
            string completedtext = AutoCompletionTools.AutoCompleteFloatingPoint(this.Text, false);

            completedtext = completedtext.Trim();

            bool valid = Double.TryParse(completedtext, out Double value_candidate);


            if (valid == false)
                return;

            if (Double.TryParse(this.MinValue, out Double minvalue))
                if (value_candidate < minvalue)
                    return;

            if (Double.TryParse(this.MaxValue, out Double maxvalue))
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

