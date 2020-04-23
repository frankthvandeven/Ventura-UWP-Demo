using Demo.Helpers;
using Demo.VenturaAutoCreate;
using System;
using System.Diagnostics;
using Ventura.Controls;
using Ventura.Helpers;
using Ventura.Navigation;
using Windows.UI.Xaml;

namespace Demo.Pages
{
    public sealed partial class OrderPage : SmartPage
    {
        public OrderViewmodel Viewmodel { get; }
        PriKey_Orders_Recordset _rs = new PriKey_Orders_Recordset();

        public OrderPage(OrderViewmodel view_model)
        {
            if (view_model == null)
                throw new ArgumentNullException();

            Viewmodel = view_model;

            this.InitializeComponent();
        }

        public Validator<OrderViewmodel> _validator;

        protected override void OnPageOpened()
        {
            if (Viewmodel.ModelMode == OrderViewmodel.ModeKind.Edit)
            {
                _rs.ExecSql(Viewmodel.OrderID);

                if (_rs.RecordCount == 0)
                    throw new Exception("wrong");

                Viewmodel.CustomerID = _rs.CustomerID;
                Viewmodel.DeliveredDate = Sqlite.TEXTToDateTimeNullable(_rs.DeliveredDate);
                Viewmodel.LastModifiedOn = Sqlite.TEXTToDateTime(_rs.LastModifiedOn);
                Viewmodel.OrderDate = Sqlite.TEXTToDateTime(_rs.OrderDate);
                Viewmodel.PaymentType = _rs.PaymentType;
                Viewmodel.SearchTerms = _rs.SearchTerms;
                Viewmodel.ShipAddress = _rs.ShipAddress;
                Viewmodel.ShipCity = _rs.ShipCity;
                Viewmodel.ShipCountryCode = _rs.ShipCountryCode;
                Viewmodel.ShipPhone = _rs.ShipPhone;
                Viewmodel.ShipPostalCode = _rs.ShipPostalCode;
                Viewmodel.ShipRegion = _rs.ShipRegion;
                Viewmodel.ShipVia = _rs.ShipVia;
                Viewmodel.ShippedDate = Sqlite.TEXTToDateTimeNullable(_rs.ShippedDate);
                Viewmodel.Status = _rs.Status;
                Viewmodel.TrackingNumber = _rs.TrackingNumber;
            }
            else if (Viewmodel.ModelMode == OrderViewmodel.ModeKind.New)
            {
                Viewmodel.OrderID = 0;
                Viewmodel.CustomerID = 0;
                Viewmodel.DeliveredDate = null;
                Viewmodel.LastModifiedOn = null;
                Viewmodel.OrderDate = DateTime.UtcNow;
                Viewmodel.PaymentType = null;
                Viewmodel.SearchTerms = null;
                Viewmodel.ShipAddress = null;
                Viewmodel.ShipCity = null;
                Viewmodel.ShipCountryCode = "US";
                Viewmodel.ShipPhone = null;
                Viewmodel.ShipPostalCode = null;
                Viewmodel.ShipRegion = null;
                Viewmodel.ShipVia = null;
                Viewmodel.ShippedDate = null;
                Viewmodel.Status = 0;
                Viewmodel.TrackingNumber = null;
            }

            Viewmodel.ResetModelModified();

            _validator = CreateValidator(Viewmodel);
            _validator.ValidateEvent += ValidateEvent;
            _validator.AddItem(vm => vm.CustomerID, inputCustomerID);
            _validator.AddItem(vm => vm.ShipCountryCode, inputShipCountryCode);
            _validator.AddItem(vm => vm.ShippedDate, inputShippedDate);

            _validator.ValidateAll();
        }

        private void ValidateEvent(Validator<OrderViewmodel> sender, OrderViewmodel viewmodel, ValidateEventArgs<OrderViewmodel> e)
        {
            if (e.IsProperty(vm => vm.CustomerID))
            {
                CustomerIdHelper.Validate(e, viewmodel.CustomerID);
            }
            else if (e.IsProperty(vm => vm.ShippedDate))
            {
                if (viewmodel.ShippedDate != null && viewmodel.ShippedDate.Value.Year < 2019)
                {
                    e.Remark = "The date is not correct.";
                    return;
                }

                e.IsValid = true;
            }
            else if (e.IsProperty(vm => vm.ShipCountryCode))
            {
                CountryCodeHelper.Validate(e, viewmodel.ShipCountryCode);
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Viewmodel.ModelMode == OrderViewmodel.ModeKind.New)
            {
                var random = new Random();

                _rs.Append();
                _rs.OrderID = random.Next(1000, 10000); // Viewmodel.OrderID;
            }

            _rs.CustomerID = Viewmodel.CustomerID;
            _rs.DeliveredDate = Sqlite.DateTimeToTEXTNullable(Viewmodel.DeliveredDate);
            _rs.OrderDate = Sqlite.DateTimeToTEXTNullable(Viewmodel.OrderDate);
            _rs.PaymentType = Viewmodel.PaymentType;
            _rs.SearchTerms = Viewmodel.SearchTerms;
            _rs.ShipAddress = Viewmodel.ShipAddress;
            _rs.ShipCity = Viewmodel.ShipCity;
            _rs.ShipCountryCode = Viewmodel.ShipCountryCode;
            _rs.ShipPhone = Viewmodel.ShipPhone;
            _rs.ShipPostalCode = Viewmodel.ShipPostalCode;
            _rs.ShipRegion = Viewmodel.ShipRegion;
            _rs.ShipVia = Viewmodel.ShipVia;
            _rs.ShippedDate = Sqlite.DateTimeToTEXTNullable(Viewmodel.ShippedDate);
            _rs.Status = Viewmodel.Status;
            _rs.TrackingNumber = Viewmodel.TrackingNumber;

            _rs.LastModifiedOn = Sqlite.DateTimeToTEXTNullable(DateTime.UtcNow);
            _rs.SaveChanges();

            Ventura.DataRecordStatus aa = _rs.CurrentRecord.RecordStatus();

            this.ClosePage(_rs.CurrentRecord);
        }

        private void CustomerID_Zoom_Click(object sender, RoutedEventArgs e)
        {
            var vm = new CustomersListViewmodel(CustomersListViewmodel.ModeKind.Lookup);
            vm.Input_CustomerID = Viewmodel.CustomerID;

            this.OpenSatellite("Customers", "Customers", new CustomersListPage(vm), "CUSTOMERS");
        }

        private void CountryCode_Zoom_Click(object sender, RoutedEventArgs e)
        {
            var vm = new CountriesListViewmodel(CountriesListViewmodel.ModeKind.Lookup);
            vm.Input_CountryCodeID = Viewmodel.ShipCountryCode;

            this.OpenSatellite("Countries", "Countries", new CountriesListPage(vm), "COUNTRIES");
        }

        private void BtnOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            //this.OpenModal("cap",destpage)
            this.OpenSatellite("Order Status", "Order status", new OrderStatusListPage(), "ORDERSTATUS");

        }

        protected override void SatellitePageClosed(string instance_id, object retvar)
        {
            if (retvar is GetAll_Customers_Record customer_record)
            {
                Viewmodel.CustomerID = customer_record.CustomerID;
                inputCustomerID.Focus(FocusState.Programmatic);
            }
            else if (retvar is GetAll_CountryCodes_Record country_record)
            {
                Viewmodel.ShipCountryCode = country_record.CountryCodeID;
                inputShipCountryCode.Focus(FocusState.Programmatic);
            }
        }

        // This is for testing only.
        private async void OpenAnotherModal_Click(object sender, RoutedEventArgs e)
        {
            var retvar = await this.OpenModal("OrderAsModal", new OrderPage(Viewmodel));

            Debug.WriteLine("Returned from modal. " + PageCaption);
        }

        // This is for testing only.
        private void OpenAnotherSatellite_Click(object sender, RoutedEventArgs e)
        {
            this.OpenSatellite("OrderSat", "OrderAsSat", new OrderPage(Viewmodel));
        }

        // This is for testing only.
        private void ForceCloseTab_Click(object sender, RoutedEventArgs e)
        {
            Navigator.CloseTab(this);
        }

    }
}
