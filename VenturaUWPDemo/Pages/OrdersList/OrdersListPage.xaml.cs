using System;
using System.Diagnostics;
using Demo.VenturaAutoCreate;
using Demo.VenturaRecordsets;
using Ventura.Controls;
using Windows.UI.Xaml;

namespace Demo.Pages
{
    public sealed partial class OrdersListPage : SmartPage
    {

        public OrdersListViewmodel Viewmodel { get; }
        public MostRecentOrdersRecordset _OrdersRS { get; } = new MostRecentOrdersRecordset();

        public OrdersListPage(OrdersListViewmodel view_model)
        {
            Viewmodel = (view_model != null) ? view_model : new OrdersListViewmodel(OrdersListViewmodel.ModeKind.List);

            this.InitializeComponent();

        }

        protected override void OnPageOpened()
        {
            _OrdersRS.MaxRows = 10;
            _OrdersRS.ExecSql();

            OrdersGrid.ItemsSource = _OrdersRS;
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            var vm = new OrderViewmodel(OrderViewmodel.ModeKind.Edit);
            vm.OrderID = _OrdersRS.OrderID;

            object retvar = await this.OpenModal($"Edit Order {_OrdersRS.OrderID}", new OrderPage(vm));

            if (retvar is PriKey_Orders_Record temp)
            {
                _OrdersRS.FirstName = "???modi";
                _OrdersRS.LastName = "???modi";
                _OrdersRS.ShipCity = temp.ShipCity;
                _OrdersRS.ResetToUnmodifiedExisting();
            }

        }

        private async void New_Click(object sender, RoutedEventArgs e)
        {
            var vm = new OrderViewmodel(OrderViewmodel.ModeKind.New);

            object retvar = await this.OpenModal("New Order", new OrderPage(vm));

            if( retvar is PriKey_Orders_Record temp)
            {
                Debug.WriteLine("Pre append");
                _OrdersRS.Append();
                Debug.WriteLine("Post append");

                _OrdersRS.OrderID = temp.OrderID;
                _OrdersRS.FirstName = "???";
                _OrdersRS.LastName = "???";
                _OrdersRS.ShipCity = temp.ShipCity;
                _OrdersRS.ResetToUnmodifiedExisting();
            }

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool result = await Popup.ConfirmDelete($"Permanently delete order {_OrdersRS.OrderID}?");

            if( result)
            {
                //foreach (MostRecentOrdersRecord rec in _OrdersRS)
                //    _OrdersRS.Delete(rec);


                _OrdersRS.Delete();
                _OrdersRS.SaveChanges();
            }

        }
    }
}
