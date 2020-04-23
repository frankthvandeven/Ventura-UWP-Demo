using Demo.VenturaAutoCreate;
using Ventura.Controls;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderStatusListPage : SmartPage
    {

        private GetAll_OrderStatus_Recordset _rs { get;  }

        //public OrdersListViewmodel Viewmodel { get; }

        public OrderStatusListPage()
        {
            _rs = new GetAll_OrderStatus_Recordset();

            //if (view_model == null)
            //    Viewmodel = new OrdersListViewmodel();
            //else
            //    Viewmodel = view_model;

            this.InitializeComponent();

            Loaded += Page_Loaded;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await _rs.ExecSqlAsync();

            OrderStatusGrid.ItemsSource = _rs;
        }


        private void OrderStatusGrid_RowDoubleClick(object sender, RoutedEventArgs e)
        {
            //var order_model = new OrderViewmodel();

            //await this.OpenModal("Order", new OrderPage(order_model));
        }
    }
}
