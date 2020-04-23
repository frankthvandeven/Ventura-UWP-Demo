using Ventura.Controls;

namespace Demo.Pages
{
    
    public sealed partial class InputControlsPage : SmartPage
    {
        public InputControlsViewmodel Viewmodel { get; }

        public InputControlsPage()
        {
            this.Viewmodel = new InputControlsViewmodel();

            this.InitializeComponent();
        }

    }
}
