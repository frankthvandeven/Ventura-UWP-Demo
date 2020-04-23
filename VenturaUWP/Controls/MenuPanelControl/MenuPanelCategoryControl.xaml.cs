using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ventura.Controls
{
    public sealed partial class MenuPanelCategoryControl : UserControl
    {
        public MenuPanelCategoryControl()
        {
            this.InitializeComponent();
        }

        public MenubarCategory ViewModel
        {
            get { return this.DataContext as MenubarCategory; }
        }

        private void Hyperlink_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {

            TextBlock tb = VisualTreeHelper.GetParent(sender) as TextBlock;

            if (tb == null) return;

            MenuItem mi = tb.DataContext as MenuItem;

            if (mi == null) return;


            mi.RaiseClickEvent(sender);

            ShellFrame.Instance.NavigationBarControl.CloseMenuPanel();


        }
    }
}
