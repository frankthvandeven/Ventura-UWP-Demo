using Demo.Helpers;
using Demo.VenturaAutoCreate;
using System;
using Ventura.Controls;
using Ventura.Navigation;
using Windows.UI.Xaml;

namespace Demo.Pages
{

    public sealed partial class CustomerPage : SmartPage
    {
        public CustomerViewmodel Viewmodel { get; }

        private PriKey_Customers_Recordset _rs = new PriKey_Customers_Recordset();

        public CustomerPage(CustomerViewmodel view_model)
        {
            if (view_model == null)
                throw new ArgumentNullException();

            Viewmodel = view_model;

            this.InitializeComponent();

        }

        public Validator<CustomerViewmodel> _validator;

        protected override void OnPageOpened()
        {
            if (Viewmodel.ModelMode == CustomerViewmodel.ModeKind.Edit)
            {
                _rs.ExecSql(Viewmodel.CustomerID);

                if (_rs.RecordCount == 0)
                    throw new Exception("wrong");

                Viewmodel.AddressLine1 = _rs.AddressLine1;
                Viewmodel.AddressLine2 = _rs.AddressLine2;
                Viewmodel.BirthDate = _rs.BirthDate;
                Viewmodel.ChildrenAtHome = _rs.ChildrenAtHome;
                Viewmodel.City = _rs.City;
                Viewmodel.CountryCode = _rs.CountryCode;
                Viewmodel.CreatedOn = _rs.CreatedOn;
                Viewmodel.Education = _rs.Education;
                Viewmodel.EmailAddress = _rs.EmailAddress;
                Viewmodel.FirstName = _rs.FirstName;
                Viewmodel.Gender = _rs.Gender;
                Viewmodel.IsHouseOwner = _rs.IsHouseOwner;
                Viewmodel.LastModifiedOn = _rs.LastModifiedOn;
                Viewmodel.LastName = _rs.LastName;
                Viewmodel.MaritalStatus = _rs.MaritalStatus;
                Viewmodel.MiddleName = _rs.MiddleName;
                Viewmodel.NumberCarsOwned = _rs.NumberCarsOwned;
                Viewmodel.Occupation = _rs.Occupation;
                Viewmodel.Phone = _rs.Phone;
                Viewmodel.Picture = _rs.Picture;
                Viewmodel.PostalCode = _rs.PostalCode;
                Viewmodel.Region = _rs.Region;
                Viewmodel.SearchTerms = _rs.SearchTerms;
                Viewmodel.Suffix = _rs.Suffix;
                Viewmodel.Thumbnail = _rs.Thumbnail;
                Viewmodel.Title = _rs.Title;
                Viewmodel.TotalChildren = _rs.TotalChildren;
                Viewmodel.YearlyIncome = _rs.YearlyIncome;
            }
            else if (Viewmodel.ModelMode == CustomerViewmodel.ModeKind.New)
            {
                Viewmodel.AddressLine1 = "";
                Viewmodel.AddressLine2 = null;
                Viewmodel.BirthDate = null;
                Viewmodel.ChildrenAtHome = null;
                Viewmodel.City = "";
                Viewmodel.CountryCode = "";
                Viewmodel.CreatedOn = "";
                Viewmodel.Education = null;
                Viewmodel.EmailAddress = "";
                Viewmodel.FirstName = "";
                Viewmodel.Gender = null;
                Viewmodel.IsHouseOwner = null;
                Viewmodel.LastModifiedOn = "";
                Viewmodel.LastName = "";
                Viewmodel.MaritalStatus = null;
                Viewmodel.MiddleName = null;
                Viewmodel.NumberCarsOwned = null;
                Viewmodel.Occupation = null;
                Viewmodel.Phone = null;
                Viewmodel.Picture = null;
                Viewmodel.PostalCode = "";
                Viewmodel.Region = "";
                Viewmodel.SearchTerms = null;
                Viewmodel.Suffix = null;
                Viewmodel.Thumbnail = null;
                Viewmodel.Title = null;
                Viewmodel.TotalChildren = null;
                Viewmodel.YearlyIncome = null;
            }

            Viewmodel.ResetModelModified();

            _validator = CreateValidator(Viewmodel);
            _validator.ValidateEvent += ValidateEvent;
            _validator.AddItem(vm => vm.CountryCode, inputCountryCode);

            _validator.ValidateAll();
        }

        private void ValidateEvent(Validator<CustomerViewmodel> sender, CustomerViewmodel viewmodel, ValidateEventArgs<CustomerViewmodel> e)
        {
            if (e.IsProperty(vm => vm.CountryCode))
            {
                CountryCodeHelper.Validate(e, viewmodel.CountryCode);
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var aa = Viewmodel.City;

            //if (FocusManager.FindLastFocusableElement(null) is Control ctrl)
            //{
            //    ctrl.Focus(FocusState.Keyboard);
            //}

            if (Viewmodel.ModelMode == CustomerViewmodel.ModeKind.New)
            {
                _rs.Append();
                //_rs.CustomerID = Viewmodel.CustomerID;
            }

            _rs.AddressLine1 = Viewmodel.AddressLine1;
            _rs.AddressLine2 = Viewmodel.AddressLine2;
            _rs.BirthDate = Viewmodel.BirthDate;
            _rs.ChildrenAtHome = Viewmodel.ChildrenAtHome;
            _rs.City = Viewmodel.City;
            _rs.CountryCode = Viewmodel.CountryCode;
            _rs.CreatedOn = Viewmodel.CreatedOn;
            _rs.Education = Viewmodel.Education;
            _rs.EmailAddress = Viewmodel.EmailAddress;
            _rs.FirstName = Viewmodel.FirstName;
            _rs.Gender = Viewmodel.Gender;
            _rs.IsHouseOwner = Viewmodel.IsHouseOwner;
            _rs.LastModifiedOn = Viewmodel.LastModifiedOn;
            _rs.LastName = Viewmodel.LastName;
            _rs.MaritalStatus = Viewmodel.MaritalStatus;
            _rs.MiddleName = Viewmodel.MiddleName;
            _rs.NumberCarsOwned = Viewmodel.NumberCarsOwned;
            _rs.Occupation = Viewmodel.Occupation;
            _rs.Phone = Viewmodel.Phone;
            _rs.Picture = Viewmodel.Picture;
            _rs.PostalCode = Viewmodel.PostalCode;
            _rs.Region = Viewmodel.Region;
            _rs.SearchTerms = Viewmodel.SearchTerms;
            _rs.Suffix = Viewmodel.Suffix;
            _rs.Thumbnail = Viewmodel.Thumbnail;
            _rs.Title = Viewmodel.Title;
            _rs.TotalChildren = Viewmodel.TotalChildren;
            _rs.YearlyIncome = Viewmodel.YearlyIncome;

            _rs.SaveChanges();
            this.ClosePage(_rs.CurrentRecord);

        }

        private void CountryCode_ZoombuttonClick(object sender, RoutedEventArgs e)
        {
            var vm = new CountriesListViewmodel(CountriesListViewmodel.ModeKind.Lookup);
            vm.Input_CountryCodeID = Viewmodel.CountryCode;

            this.OpenSatellite("Countries", "Countries", new CountriesListPage(vm), "COUNTRIES");
        }

        protected override void SatellitePageClosed(string instance_id, object retvar)
        {
            if (retvar is GetAll_CountryCodes_Record country_record)
            {
                Viewmodel.CountryCode = country_record.CountryCodeID;
                inputCountryCode.Focus(FocusState.Programmatic);
            }

        }


    }
}
