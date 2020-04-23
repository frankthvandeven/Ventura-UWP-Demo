using Demo;
using Demo.Pages;
using Ventura.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Navigator.AddTab("Customers", "Customers", new CustomersListPage(null), "CUSTOMERS");
            Navigator.AddTab("Orders", "Orders", new OrdersListPage(null), "ORDERS");
            Navigator.AddTab("Products", "Products", new ProductsListPage(null), "PRODUCTS");
            Navigator.AddTab("Start Page", "Start Page", new StartPage(), "STARTPAGE");

            //Navigator.AddTab("Distinct colors", "Distinct colors", new ColorPage(), "DISTINCT_COLORS");
            /////Navigator.AddTab("Input Controls", "Input Controls Page", new InputControlsPage(), "INPUTCONTROLS");
            //Navigator.AddTab("Local menus", "Local menus Page", new LocalmenusPage(), "LOCALMENUS");

        }

        private void Customers_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Customers", "Customers", new CustomersListPage(null), "CUSTOMERS");
        }

        private void Products_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Products", "Products", new ProductsListPage(null), "PRODUCTS");
        }

        private void Orders_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Orders", "Orders", new OrdersListPage(null), "ORDERS");
        }

        private void OrderStatus_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Order Status", "Order Status", new OrderStatusListPage(), "ORDERSTATUS");

        }



        private void one_click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Start Page", "Start Page", new StartPage(), "STARTPAGE");
        }

        private void InputControls_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Input Controls", "Input Controls Page", new InputControlsPage(), "INPUTCONTROLS");
        }

        private void Buttons_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Button Controls", "Button Controls Page", new ButtonsPage(), "BUTTONCONTROLS");
        }

        private void Headers_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Headers", "Headers Page", new HeadersPage(), "HEADERS");
        }

        private void DistinctColors_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Distinct colors", "Distinct colors", new ColorPage(), "DISTINCT_COLORS");
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            string unique_id = "SETTINGS";

            if (Navigator.IsTabOpen(unique_id))
            {
                Navigator.SelectAndActivateTab(unique_id);
                return;
            }

            Navigator.AddTab("Settings", "Settings", new SettingsPage(), unique_id);

        }

        private void LocalMenus_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Local menus", "Local menus Page", new LocalmenusPage(), "LOCALMENUS");
        }

        private void InstantScreenUpdate_Click(object sender, Ventura.Controls.MenuItem args)
        {
            Navigator.AddTab("Screen update", "Instant screen update Page", new InstantScreenUpdatePage(), "SCREEN_UPDATE");
        }
    }
}
