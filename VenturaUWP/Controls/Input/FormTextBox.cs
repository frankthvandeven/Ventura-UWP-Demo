using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    // This is a regular TextBox with the following changes:
    // 1. FontSize reduced
    // 2. Padding removed
    // 3. Border child control collapsed
    // 4. The delete button removed (using trickery)
    //
    // This is a better solution than modifying a copy the TextBox control template,
    // taking into account future changes to the template by Microsoft.

    public class FormTextBox : TextBox
    {

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Border border = (Border)GetTemplateChild("BorderElement");
            Button delete_button = (Button)GetTemplateChild("DeleteButton");

            border.Visibility = Visibility.Collapsed;

            //this.FontSize = 44d;
            this.Padding = new Thickness(0d);

            // Even though the Border is collapsed, the ContentControl takes the BorderThickness property into account.
            this.BorderThickness = new Thickness(0d); 

            delete_button.MinWidth = 0d;
            delete_button.Width = 0d;
            delete_button.Height = 0d;

            // HACK: temporarily disabled.
            //delete_button.Style = null; // not needed anyway.
        }
        

    }
}
