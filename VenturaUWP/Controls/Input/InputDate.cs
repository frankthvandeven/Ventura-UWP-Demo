using System;
using Windows.UI.Xaml;

namespace Ventura.Controls
{

    public class InputDate : InputBase
    {
        // Statics

        public static DependencyProperty ValueProperty { private set; get; }

        static InputDate()
        {
            ValueProperty = DependencyProperty.Register(nameof(Value),
                typeof(DateTime), typeof(InputDate),
                new PropertyMetadata(default(DateTime), OnValuePropertyChanged));
        }

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as InputDate).OnValuePropertyChanged(args);
        }

        private void OnValuePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // Note: this.Value already contains the updated value

            //DateTime value = (DateTime)args.NewValue;
            //DateTime timeremoved = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day);
            //this.TextEditor.Value = timeremoved.ToShortDateString();

            ConvertValue2Text();
        }

        #region DP <-> Property

        public DateTime Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (DateTime)GetValue(ValueProperty); }
        }

        #endregion

        // The rest...

        protected override void ConvertText2Value()
        {
            string completedtext = AutoCompletionTools.AutoCompleteDate(this.Text);

            completedtext = completedtext.Trim();

            bool valid = DateTime.TryParse(completedtext, out DateTime value_candidate);

            if (valid == false)
                return;

            this.Value = value_candidate;
        }

        protected override void ConvertValue2Text()
        {
            this.Text = this.Value.ToShortDateString();
        }

    }
}
