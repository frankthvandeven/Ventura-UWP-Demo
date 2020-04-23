using Ventura;

namespace Demo.Pages
{
    public class CustomerViewmodel : ViewmodelBase
    {
        public enum ModeKind { New, Edit }

        private ModeKind _modelmode;

        public ModeKind ModelMode
        {
            get { return _modelmode; }
            set
            {
                if (_modelmode == value) return;
                _modelmode = value;
                NotifyPropertyChanged(nameof(ModelMode));
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

        private string _addressline1;

        public string AddressLine1
        {
            get { return _addressline1; }
            set
            {
                if (_addressline1 == value) return;
                _addressline1 = value;
                NotifyPropertyChanged(nameof(AddressLine1));
            }
        }

        private string _addressline2;

        public string AddressLine2
        {
            get { return _addressline2; }
            set
            {
                if (_addressline2 == value) return;
                _addressline2 = value;
                NotifyPropertyChanged(nameof(AddressLine2));
            }
        }

        private string _birthdate;

        public string BirthDate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate == value) return;
                _birthdate = value;
                NotifyPropertyChanged(nameof(BirthDate));
            }
        }

        private long? _childrenathome;

        public long? ChildrenAtHome
        {
            get { return _childrenathome; }
            set
            {
                if (_childrenathome == value) return;
                _childrenathome = value;
                NotifyPropertyChanged(nameof(ChildrenAtHome));
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value) return;
                _city = value;
                NotifyPropertyChanged(nameof(City));
            }
        }

        private string _countrycode;

        public string CountryCode
        {
            get { return _countrycode; }
            set
            {
                if (_countrycode == value) return;
                _countrycode = value;
                NotifyPropertyChanged(nameof(CountryCode));
            }
        }

        private string _createdon;

        public string CreatedOn
        {
            get { return _createdon; }
            set
            {
                if (_createdon == value) return;
                _createdon = value;
                NotifyPropertyChanged(nameof(CreatedOn));
            }
        }

        private string _education;

        public string Education
        {
            get { return _education; }
            set
            {
                if (_education == value) return;
                _education = value;
                NotifyPropertyChanged(nameof(Education));
            }
        }

        private string _emailaddress;

        public string EmailAddress
        {
            get { return _emailaddress; }
            set
            {
                if (_emailaddress == value) return;
                _emailaddress = value;
                NotifyPropertyChanged(nameof(EmailAddress));
            }
        }

        private string _firstname;

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (_firstname == value) return;
                _firstname = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender == value) return;
                _gender = value;
                NotifyPropertyChanged(nameof(Gender));
            }
        }

        private long? _ishouseowner;

        public long? IsHouseOwner
        {
            get { return _ishouseowner; }
            set
            {
                if (_ishouseowner == value) return;
                _ishouseowner = value;
                NotifyPropertyChanged(nameof(IsHouseOwner));
            }
        }

        private string _lastmodifiedon;

        public string LastModifiedOn
        {
            get { return _lastmodifiedon; }
            set
            {
                if (_lastmodifiedon == value) return;
                _lastmodifiedon = value;
                NotifyPropertyChanged(nameof(LastModifiedOn));
            }
        }

        private string _lastname;

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname == value) return;
                _lastname = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }

        private string _maritalstatus;

        public string MaritalStatus
        {
            get { return _maritalstatus; }
            set
            {
                if (_maritalstatus == value) return;
                _maritalstatus = value;
                NotifyPropertyChanged(nameof(MaritalStatus));
            }
        }

        private string _middlename;

        public string MiddleName
        {
            get { return _middlename; }
            set
            {
                if (_middlename == value) return;
                _middlename = value;
                NotifyPropertyChanged(nameof(MiddleName));
            }
        }

        private long? _numbercarsowned;

        public long? NumberCarsOwned
        {
            get { return _numbercarsowned; }
            set
            {
                if (_numbercarsowned == value) return;
                _numbercarsowned = value;
                NotifyPropertyChanged(nameof(NumberCarsOwned));
            }
        }

        private string _occupation;

        public string Occupation
        {
            get { return _occupation; }
            set
            {
                if (_occupation == value) return;
                _occupation = value;
                NotifyPropertyChanged(nameof(Occupation));
            }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value) return;
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        private object _picture;

        public object Picture
        {
            get { return _picture; }
            set
            {
                if (_picture == value) return;
                _picture = value;
                NotifyPropertyChanged(nameof(Picture));
            }
        }

        private string _postalcode;

        public string PostalCode
        {
            get { return _postalcode; }
            set
            {
                if (_postalcode == value) return;
                _postalcode = value;
                NotifyPropertyChanged(nameof(PostalCode));
            }
        }

        private string _region;

        public string Region
        {
            get { return _region; }
            set
            {
                if (_region == value) return;
                _region = value;
                NotifyPropertyChanged(nameof(Region));
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

        private string _suffix;

        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (_suffix == value) return;
                _suffix = value;
                NotifyPropertyChanged(nameof(Suffix));
            }
        }

        private object _thumbnail;

        public object Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                if (_thumbnail == value) return;
                _thumbnail = value;
                NotifyPropertyChanged(nameof(Thumbnail));
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        private long? _totalchildren;

        public long? TotalChildren
        {
            get { return _totalchildren; }
            set
            {
                if (_totalchildren == value) return;
                _totalchildren = value;
                NotifyPropertyChanged(nameof(TotalChildren));
            }
        }

        private string _yearlyincome;

        public string YearlyIncome
        {
            get { return _yearlyincome; }
            set
            {
                if (_yearlyincome == value) return;
                _yearlyincome = value;
                NotifyPropertyChanged(nameof(YearlyIncome));
            }
        }

    }
}
