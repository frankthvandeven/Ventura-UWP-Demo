using Demo.VenturaAutoCreate;
using Demo.VenturaRecordsets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Ventura.Controls;
using Ventura.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Demo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsListPage : SmartPage
    {

        public ProductsListViewmodel Viewmodel { get; }
        public GetAll_Products_Recordset _rs { get; } = new GetAll_Products_Recordset();

        public ProductsListPage(ProductsListViewmodel view_model)
        {
            if (view_model == null)
                Viewmodel = new ProductsListViewmodel();
            else
                Viewmodel = view_model;

            this.InitializeComponent();

        }

        protected override void OnPageOpened()
        {
            _rs.MaxRows = 50000;
            _rs.ExecSql();

            ProductsGrid.ItemsSource = _rs;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            string message = "Ff"; // OrdersGrid.SelectionMode.ToString();

            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //GetAll_Products_Record record = _CustomersRS.CurrentRecord;

            //var vm = new CustomerViewmodel();
            //vm.ModelMode = CustomerViewmodel.ModeKind.Edit;
            //vm.CustomerID = record.ProductID;

            //object retvar = await this.OpenModal($"Edit Product {record.ProductID}", new CustomerPage(vm));
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
