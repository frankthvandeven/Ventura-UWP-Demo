using System;
using System.Collections.ObjectModel;
using Ventura.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Ventura.Controls
{

    [ContentProperty(Name = "Child")]
    public partial class FormField : Control, IFormField
    {
        private FormButtonZoom _standard_zoom_button;

        public FormField()
        {
            this.DefaultStyleKey = typeof(FormField);

            SetValue(ButtonsProperty, new ObservableCollection<MiniButton>());

            // The first item in the collection is always the zoombutton
            _standard_zoom_button = new FormButtonZoom() { Visibility = Visibility.Collapsed };
            _standard_zoom_button.Click += ZoomButton_Click;

            this.Buttons.Add(_standard_zoom_button);

        }

        private void ZoomButton_Click(object sender, RoutedEventArgs e)
        {
            // Relay the button's click event to the ZoombuttonClick event.
            _zoombutton_click_handler?.Invoke(sender, e);
        }

        private bool _init = false;
        private Grid _rootgrid;
        private SmartScaler _smartscaler;
        private TextBlock _header;
        private TextBlock _bottomremark;
        private TextBlock _rightremark;
        private FormButtonBar _formbuttonbar;

        protected override void OnApplyTemplate()
        {
            if (_init == true)
                throw new System.Exception("can not re-template");

            // Save existing content and remove it from the visual tree.
            // This is needed as the Child property is already set before the template XAML is loaded.
            FrameworkElement savedContent = this.Child;
            this.Child = null;

            base.OnApplyTemplate();

            _rootgrid = this.GetTemplateChild("RootGrid") as Grid;
            _smartscaler = this.GetTemplateChild("smartscaler") as SmartScaler;
            _header = this.GetTemplateChild("textblockHeader") as TextBlock;
            _bottomremark = this.GetTemplateChild("BottomRemark") as TextBlock;
            _rightremark = this.GetTemplateChild("RightRemark") as TextBlock;
            _formbuttonbar = this.GetTemplateChild("FormButtonBar") as FormButtonBar;

            AutoStyler.SetStyle(savedContent);
            AutoStyler.SetMargin(savedContent);
            AutoStyler.SetScale(savedContent, _smartscaler);

            // Hook up the formbuttons collection to the FormButtonBar.
            _formbuttonbar.ItemsSource = this.Buttons;

            _init = true;

            ResetRemark();

            // Restore saved content
            this.Child = savedContent;

            this.PointerPressed += FormField_PointerPressed;
        }


        // A click inside the FormField will result in the first focussable control to get focus.
        private void FormField_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var element = _smartscaler.Content as FrameworkElement;

            if (element == null)
                return;

            Control control = VenturaVisualTreeHelper.FindDescendant<Control>(element);

            if (control == null)
                return;

            control.Focus(FocusState.Programmatic);

            e.Handled = true;
        }

        private void ResetIsActive()
        {
            if (_init == false)
                return;

            bool is_active = this.IsActive;

            if (is_active)
            {
                _header.FontWeight = Windows.UI.Text.FontWeights.Bold;
            }
            else
            {
                _header.FontWeight = Windows.UI.Text.FontWeights.Normal;
            }

        }

        private void ResetRemark()
        {
            if (_init == false)
                return;

            string text = this.Remark;
            var position = this.RemarkPosition;

            if (text == null)
                throw new Exception("should not happen");

            _rightremark.Visibility = (position == FormRemarkPosition.Right) ? Visibility.Visible : Visibility.Collapsed;

            if (position == FormRemarkPosition.Bottom)
            {
                _bottomremark.Text = text;
                _bottomremark.Visibility = (text.Length > 0) ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                _rightremark.Text = text;
                _bottomremark.Visibility = Visibility.Collapsed;
            }

        }

    }
}
