using Demo.VenturaAutoCreate;
using Ventura.Controls;
using Windows.UI.Xaml;

namespace Demo.Pages
{
    public sealed partial class CustomersListPage : SmartPage
    {

        public CustomersListViewmodel Viewmodel { get; }
        public GetAll_Customers_Recordset _CustomersRS { get; } = new GetAll_Customers_Recordset();

        public CustomersListPage(CustomersListViewmodel view_model)
        {
            Viewmodel = view_model != null ? view_model : new CustomersListViewmodel(CustomersListViewmodel.ModeKind.List);

            this.InitializeComponent();
        }

        protected override void OnPageOpened()
        {
            if( Viewmodel.ModelMode == CustomersListViewmodel.ModeKind.List)
            {
                buttonSelect.Visibility = Visibility.Collapsed;
                CustomersGrid.RowDoubleClick += Edit_Click;
            }
            else if (Viewmodel.ModelMode == CustomersListViewmodel.ModeKind.Lookup)
            {
                buttonSelect.Visibility = Visibility.Visible;
                CustomersGrid.RowDoubleClick += Select_Click;
            }

            _CustomersRS.MaxRows = 100;
            _CustomersRS.ExecSql();

            CustomersGrid.ItemsSource = _CustomersRS;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            this.ClosePage(CustomersGrid.SelectedItem);
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            GetAll_Customers_Record record = _CustomersRS.CurrentRecord;

            var vm = new CustomerViewmodel();
            vm.ModelMode = CustomerViewmodel.ModeKind.Edit;
            vm.CustomerID = record.CustomerID;

            object retvar = await this.OpenModal($"Edit Customer {record.CustomerID}", new CustomerPage(vm));
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            //var record = _CustomersRS.CurrentRecord as GetAll_Customers_Record;

            //var vm2 = new OrderViewmodel();

            //vm2.InitializeForEdit(record.OrderID);

            //object retvar = await this.OpenModal("New Order", new OrderPage(vm2));

        }

    }
}
