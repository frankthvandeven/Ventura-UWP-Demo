using System;
using Ventura;

namespace Demo.Pages
{
    public class OrderViewmodel : ViewmodelBase
    {
        public enum ModeKind { New, Edit }

        public ModeKind ModelMode { get; }

        public OrderViewmodel(ModeKind mode)
        {
            ModelMode = mode;
        }

        private long _orderid;

        public long OrderID
        {
            get { return _orderid; }
            set
            {
                if (_orderid == value) return;
                _orderid = value;
                NotifyPropertyChanged(nameof(OrderID));
            }
        }

        private long _customerid;

        public long CustomerID
        {
            get { return _customerid; }
            set
            {
                if (_customerid == value) return;
                _customerid = value;
                NotifyPropertyChanged(nameof(CustomerID));
            }
        }

        private DateTime? _delivereddate;

        public DateTime? DeliveredDate
        {
            get { return _delivereddate; }
            set
            {
                if (_delivereddate == value) return;
                _delivereddate = value;
                NotifyPropertyChanged(nameof(DeliveredDate));
            }
        }

        private DateTime? _lastmodifiedon;

        public DateTime? LastModifiedOn
        {
            get { return _lastmodifiedon; }
            set
            {
                if (_lastmodifiedon == value) return;
                _lastmodifiedon = value;
                NotifyPropertyChanged(nameof(LastModifiedOn));
            }
        }

        private DateTime _orderdate;

        public DateTime OrderDate
        {
            get { return _orderdate; }
            set
            {
                if (_orderdate == value) return;
                _orderdate = value;
                NotifyPropertyChanged(nameof(OrderDate));
            }
        }

        private long? _paymenttype;

        public long? PaymentType
        {
            get { return _paymenttype; }
            set
            {
                if (_paymenttype == value) return;
                _paymenttype = value;
                NotifyPropertyChanged(nameof(PaymentType));
            }
        }

        private string _searchterms;

        public string SearchTerms
        {
            get { return _searchterms; }
            set
            {
                if (_searchterms == value) return;
                _searchterms = value;
                NotifyPropertyChanged(nameof(SearchTerms));
            }
        }

        private string _shipaddress;

        public string ShipAddress
        {
            get { return _shipaddress; }
            set
            {
                if (_shipaddress == value) return;
                _shipaddress = value;
                NotifyPropertyChanged(nameof(ShipAddress));
            }
        }

        private string _shipcity;

        public string ShipCity
        {
            get { return _shipcity; }
            set
            {
                if (_shipcity == value) return;
                _shipcity = value;
                NotifyPropertyChanged(nameof(ShipCity));
            }
        }

        private string _shipcountrycode;

        public string ShipCountryCode
        {
            get { return _shipcountrycode; }
            set
            {
                if (_shipcountrycode == value) return;
                _shipcountrycode = value;
                NotifyPropertyChanged(nameof(ShipCountryCode));
            }
        }

        private string _shipphone;

        public string ShipPhone
        {
            get { return _shipphone; }
            set
            {
                if (_shipphone == value) return;
                _shipphone = value;
                NotifyPropertyChanged(nameof(ShipPhone));
            }
        }

        private string _shippostalcode;

        public string ShipPostalCode
        {
            get { return _shippostalcode; }
            set
            {
                if (_shippostalcode == value) return;
                _shippostalcode = value;
                NotifyPropertyChanged(nameof(ShipPostalCode));
            }
        }

        private string _shipregion;

        public string ShipRegion
        {
            get { return _shipregion; }
            set
            {
                if (_shipregion == value) return;
                _shipregion = value;
                NotifyPropertyChanged(nameof(ShipRegion));
            }
        }

        private long? _shipvia;

        public long? ShipVia
        {
            get { return _shipvia; }
            set
            {
                if (_shipvia == value) return;
                _shipvia = value;
                NotifyPropertyChanged(nameof(ShipVia));
            }
        }

        private DateTime? _shippeddate;

        public DateTime? ShippedDate
        {
            get { return _shippeddate; }
            set
            {
                if (_shippeddate == value) return;
                _shippeddate = value;
                NotifyPropertyChanged(nameof(ShippedDate));
            }
        }

        private long _status;

        public long Status
        {
            get { return _status; }
            set
            {
                if (_status == value) return;
                _status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }

        private string _trackingnumber;

        public string TrackingNumber
        {
            get { return _trackingnumber; }
            set
            {
                if (_trackingnumber == value) return;
                _trackingnumber = value;
                NotifyPropertyChanged(nameof(TrackingNumber));
            }
        }


        //public void InitializeForEdit(long order_id)
        //{
        //    Mode = ModelMode.Edit;

        //    PriKey_Orders_Recordset prikey = new PriKey_Orders_Recordset();

        //    prikey.ExecSql(order_id);

        //    if (prikey.RecordCount != 1)
        //        throw new Exception($"Order {order_id} not found.");

        //    this.CustomerID = prikey.CustomerID;
        //    this.OrderDate = Parsers.ParseISO8601String(prikey.OrderDate);
        //    this.ShipAddress = prikey.ShipAddress;
        //    this.ShipCity = prikey.ShipCity;
        //    this.ShipPostalCode = prikey.ShipPostalCode;
        //    this.ShipCountryCode = prikey.ShipCountryCode;
        //    //textblockTitle.Text = $"Edit order {prikey.OrderID}";
        //}

    }
}
