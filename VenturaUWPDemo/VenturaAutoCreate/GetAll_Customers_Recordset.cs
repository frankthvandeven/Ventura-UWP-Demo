/*
	Project file: "C:\Active\VenturaUWP\Projects\VenturaUWPDemo.venproj"
	Target platform: NETStandard
	Generator version: 2.8.16
	Generated on: Thursday, April 23, 2020 at 9:16:04 AM
	At the bottom of this file you find a template for extending Recordsets with calculated columns for XAML data binding.
*/
using Ventura;
using System;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace Demo.VenturaAutoCreate
{
	/// <summary>
	/// The updateable table is [Customers]. Updateable table column information:
	/// • 29 out of 29 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: CustomerID.
	/// • Non-primary key columns present in the resultset: AddressLine1, AddressLine2, BirthDate, ChildrenAtHome, City,
	///   CountryCode, CreatedOn, Education, EmailAddress, FirstName, Gender, IsHouseOwner, LastModifiedOn, LastName,
	///   MaritalStatus, MiddleName, NumberCarsOwned, Occupation, Phone, Picture, PostalCode, Region, SearchTerms, Suffix,
	///   Thumbnail, Title, TotalChildren and YearlyIncome.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class GetAll_Customers_Recordset : ResultsetObservable<GetAll_Customers_Recordset, GetAll_Customers_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public GetAll_Customers_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [CustomerID],[AddressLine1],[AddressLine2],[BirthDate],[ChildrenAtHome],[City],[CountryCode],[CreatedOn],[Education],[EmailAddress],[FirstName],[Gender]," + CRLF +
			             @"[IsHouseOwner],[LastModifiedOn],[LastName],[MaritalStatus],[MiddleName],[NumberCarsOwned],[Occupation],[Phone],[Picture],[PostalCode],[Region],[SearchTerms]," + CRLF +
			             @"[Suffix],[Thumbnail],[Title],[TotalChildren],[YearlyIncome]" + CRLF +
			             @"FROM [Customers]";

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("CustomerID", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "CustomerID"
			});

			schema_array.Add(new VenturaColumn("AddressLine1", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "AddressLine1"
			});

			schema_array.Add(new VenturaColumn("AddressLine2", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "AddressLine2"
			});

			schema_array.Add(new VenturaColumn("BirthDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "BirthDate"
			});

			schema_array.Add(new VenturaColumn("ChildrenAtHome", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "ChildrenAtHome"
			});

			schema_array.Add(new VenturaColumn("City", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "City"
			});

			schema_array.Add(new VenturaColumn("CountryCode", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "CountryCode"
			});

			schema_array.Add(new VenturaColumn("CreatedOn", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "CreatedOn"
			});

			schema_array.Add(new VenturaColumn("Education", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Education"
			});

			schema_array.Add(new VenturaColumn("EmailAddress", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "EmailAddress"
			});

			schema_array.Add(new VenturaColumn("FirstName", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "FirstName"
			});

			schema_array.Add(new VenturaColumn("Gender", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Gender"
			});

			schema_array.Add(new VenturaColumn("IsHouseOwner", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "IsHouseOwner"
			});

			schema_array.Add(new VenturaColumn("LastModifiedOn", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "LastModifiedOn"
			});

			schema_array.Add(new VenturaColumn("LastName", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "LastName"
			});

			schema_array.Add(new VenturaColumn("MaritalStatus", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "MaritalStatus"
			});

			schema_array.Add(new VenturaColumn("MiddleName", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "MiddleName"
			});

			schema_array.Add(new VenturaColumn("NumberCarsOwned", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "NumberCarsOwned"
			});

			schema_array.Add(new VenturaColumn("Occupation", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Occupation"
			});

			schema_array.Add(new VenturaColumn("Phone", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Phone"
			});

			schema_array.Add(new VenturaColumn("Picture", typeof(object), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Picture"
			});

			schema_array.Add(new VenturaColumn("PostalCode", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "PostalCode"
			});

			schema_array.Add(new VenturaColumn("Region", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Region"
			});

			schema_array.Add(new VenturaColumn("SearchTerms", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "SearchTerms"
			});

			schema_array.Add(new VenturaColumn("Suffix", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Suffix"
			});

			schema_array.Add(new VenturaColumn("Thumbnail", typeof(object), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Thumbnail"
			});

			schema_array.Add(new VenturaColumn("Title", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "Title"
			});

			schema_array.Add(new VenturaColumn("TotalChildren", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "TotalChildren"
			});

			schema_array.Add(new VenturaColumn("YearlyIncome", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "YearlyIncome"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[Customers]";
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long CustomerID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CustomerID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CustomerID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string AddressLine1
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.AddressLine1; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.AddressLine1 = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string AddressLine2
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.AddressLine2; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.AddressLine2 = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string BirthDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.BirthDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.BirthDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? ChildrenAtHome
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ChildrenAtHome; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ChildrenAtHome = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string City
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.City; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.City = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string CountryCode
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CountryCode; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CountryCode = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string CreatedOn
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CreatedOn; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CreatedOn = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Education
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Education; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Education = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string EmailAddress
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.EmailAddress; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.EmailAddress = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string FirstName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.FirstName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.FirstName = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Gender
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Gender; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Gender = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? IsHouseOwner
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.IsHouseOwner; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.IsHouseOwner = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string LastModifiedOn
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.LastModifiedOn; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.LastModifiedOn = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string LastName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.LastName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.LastName = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string MaritalStatus
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.MaritalStatus; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.MaritalStatus = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string MiddleName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.MiddleName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.MiddleName = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? NumberCarsOwned
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.NumberCarsOwned; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.NumberCarsOwned = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Occupation
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Occupation; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Occupation = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Phone
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Phone; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Phone = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public object Picture
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Picture; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Picture = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string PostalCode
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.PostalCode; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.PostalCode = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string Region
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Region; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Region = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string SearchTerms
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.SearchTerms; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.SearchTerms = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Suffix
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Suffix; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Suffix = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public object Thumbnail
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Thumbnail; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Thumbnail = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Title
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Title; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Title = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? TotalChildren
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.TotalChildren; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.TotalChildren = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string YearlyIncome
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.YearlyIncome; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.YearlyIncome = value; }
		}

		public void ResetToUnmodified()
		{
			if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET);
			CurrentRecord.ResetToUnmodified();
		}

		public void ResetToUnmodifiedExisting()
		{
			if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET);
			CurrentRecord.ResetToUnmodifiedExisting();
		}

		public void ResetToExisting()
		{
			if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET);
			CurrentRecord.ResetToExisting();
		}

		public void Append()
		{
			int index = this.RecordCount;
			this.InsertItem(index, new GetAll_Customers_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(GetAll_Customers_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public GetAll_Customers_Record NewRecord()
		{
			return new GetAll_Customers_Record();
		}

		protected override GetAll_Customers_Record InternalCreateExistingRecordObject(object[] columnvalues) => new GetAll_Customers_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 237, 134, 166, 249, 43, 45, 213, 234, 103, 16, 70, 150, 35, 143, 176, 169 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "ED86A6F92B2DD5EA67104696238FB0A9"; }
		}

		VenturaPlatform IRecordsetBase.GeneratorTarget
		{
			get { return VenturaPlatform.NETStandard; }
		}

		Version IRecordsetBase.GeneratorVersion
		{
			get { return new Version(2,8,16); }
		}

		DateTime IRecordsetBase.GeneratorTimestamp
		{
			get { return new DateTime(2020, 4, 23, 9, 16, 4); } // Thursday, April 23, 2020 at 9:16:04 AM
		}

		string IRecordsetBase.GeneratorProviderInvariantName
		{
			get { return "Microsoft.Data.Sqlite"; }
		}

		IResultsetBase[] IRecordsetBase.Resultsets
		{
			get { return _resultsets; }
		}

		string IRecordsetBase.SqlScript
		{
			get { return _sqlscript; }
		}

		VenturaSchema IRecordsetBase.ParameterSchema
		{
			get { return null; }
		}

		/// <summary>
		/// For internal use by Ventura only. Use SetExecSqlParams() instead.
		/// </summary>
		object[] IRecordsetBase.InputParameterValues
		{
			get { return null; }
		}

		/// <summary>
		/// For internal use by Ventura only. Use Output property instead.
		/// </summary>
		object[] IRecordsetBase.OutputParameterValues
		{
			get { return null; }
		}

		public int MaxRows
		{
			get { return _maxrows; }
			set { _maxrows = value; }
		}

		public void ExecSql()
		{
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector)
		{
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync()
		{
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector)
		{
			await Transactional.ExecSqlAsync(connector, new IRecordsetBase[] { this });
		}

		public void SaveChanges()
		{
			Transactional.SaveChanges(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void SaveChanges(Connector connector)
		{
			Transactional.SaveChanges(connector, new IRecordsetBase[] { this });
		}

		public async Task SaveChangesAsync()
		{
			await Transactional.SaveChangesAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task SaveChangesAsync(Connector connector)
		{
			await Transactional.SaveChangesAsync(connector, new IRecordsetBase[] { this });
		}

	}

	public sealed partial class GetAll_Customers_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__CustomerID; private long _ori__CustomerID; private bool _mod__CustomerID;
		private string _cur__AddressLine1; private string _ori__AddressLine1; private bool _mod__AddressLine1;
		private string _cur__AddressLine2; private string _ori__AddressLine2; private bool _mod__AddressLine2;
		private string _cur__BirthDate; private string _ori__BirthDate; private bool _mod__BirthDate;
		private long? _cur__ChildrenAtHome; private long? _ori__ChildrenAtHome; private bool _mod__ChildrenAtHome;
		private string _cur__City; private string _ori__City; private bool _mod__City;
		private string _cur__CountryCode; private string _ori__CountryCode; private bool _mod__CountryCode;
		private string _cur__CreatedOn; private string _ori__CreatedOn; private bool _mod__CreatedOn;
		private string _cur__Education; private string _ori__Education; private bool _mod__Education;
		private string _cur__EmailAddress; private string _ori__EmailAddress; private bool _mod__EmailAddress;
		private string _cur__FirstName; private string _ori__FirstName; private bool _mod__FirstName;
		private string _cur__Gender; private string _ori__Gender; private bool _mod__Gender;
		private long? _cur__IsHouseOwner; private long? _ori__IsHouseOwner; private bool _mod__IsHouseOwner;
		private string _cur__LastModifiedOn; private string _ori__LastModifiedOn; private bool _mod__LastModifiedOn;
		private string _cur__LastName; private string _ori__LastName; private bool _mod__LastName;
		private string _cur__MaritalStatus; private string _ori__MaritalStatus; private bool _mod__MaritalStatus;
		private string _cur__MiddleName; private string _ori__MiddleName; private bool _mod__MiddleName;
		private long? _cur__NumberCarsOwned; private long? _ori__NumberCarsOwned; private bool _mod__NumberCarsOwned;
		private string _cur__Occupation; private string _ori__Occupation; private bool _mod__Occupation;
		private string _cur__Phone; private string _ori__Phone; private bool _mod__Phone;
		private object _cur__Picture; private object _ori__Picture; private bool _mod__Picture;
		private string _cur__PostalCode; private string _ori__PostalCode; private bool _mod__PostalCode;
		private string _cur__Region; private string _ori__Region; private bool _mod__Region;
		private string _cur__SearchTerms; private string _ori__SearchTerms; private bool _mod__SearchTerms;
		private string _cur__Suffix; private string _ori__Suffix; private bool _mod__Suffix;
		private object _cur__Thumbnail; private object _ori__Thumbnail; private bool _mod__Thumbnail;
		private string _cur__Title; private string _ori__Title; private bool _mod__Title;
		private long? _cur__TotalChildren; private long? _ori__TotalChildren; private bool _mod__TotalChildren;
		private string _cur__YearlyIncome; private string _ori__YearlyIncome; private bool _mod__YearlyIncome;


		public GetAll_Customers_Record()
		{
			_cur__CustomerID = 0;
			_cur__AddressLine1 = "";
			_cur__AddressLine2 = null;
			_cur__BirthDate = null;
			_cur__ChildrenAtHome = null;
			_cur__City = "";
			_cur__CountryCode = "";
			_cur__CreatedOn = "";
			_cur__Education = null;
			_cur__EmailAddress = "";
			_cur__FirstName = "";
			_cur__Gender = null;
			_cur__IsHouseOwner = null;
			_cur__LastModifiedOn = "";
			_cur__LastName = "";
			_cur__MaritalStatus = null;
			_cur__MiddleName = null;
			_cur__NumberCarsOwned = null;
			_cur__Occupation = null;
			_cur__Phone = null;
			_cur__Picture = null;
			_cur__PostalCode = "";
			_cur__Region = "";
			_cur__SearchTerms = null;
			_cur__Suffix = null;
			_cur__Thumbnail = null;
			_cur__Title = null;
			_cur__TotalChildren = null;
			_cur__YearlyIncome = null;
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public GetAll_Customers_Record(object[] columnvalues)
		{
			_cur__CustomerID = (long)columnvalues[0];
			_cur__AddressLine1 = (string)columnvalues[1];
			_cur__AddressLine2 = (string)columnvalues[2];
			_cur__BirthDate = (string)columnvalues[3];
			_cur__ChildrenAtHome = (long?)columnvalues[4];
			_cur__City = (string)columnvalues[5];
			_cur__CountryCode = (string)columnvalues[6];
			_cur__CreatedOn = (string)columnvalues[7];
			_cur__Education = (string)columnvalues[8];
			_cur__EmailAddress = (string)columnvalues[9];
			_cur__FirstName = (string)columnvalues[10];
			_cur__Gender = (string)columnvalues[11];
			_cur__IsHouseOwner = (long?)columnvalues[12];
			_cur__LastModifiedOn = (string)columnvalues[13];
			_cur__LastName = (string)columnvalues[14];
			_cur__MaritalStatus = (string)columnvalues[15];
			_cur__MiddleName = (string)columnvalues[16];
			_cur__NumberCarsOwned = (long?)columnvalues[17];
			_cur__Occupation = (string)columnvalues[18];
			_cur__Phone = (string)columnvalues[19];
			_cur__Picture = (object)columnvalues[20];
			_cur__PostalCode = (string)columnvalues[21];
			_cur__Region = (string)columnvalues[22];
			_cur__SearchTerms = (string)columnvalues[23];
			_cur__Suffix = (string)columnvalues[24];
			_cur__Thumbnail = (object)columnvalues[25];
			_cur__Title = (string)columnvalues[26];
			_cur__TotalChildren = (long?)columnvalues[27];
			_cur__YearlyIncome = (string)columnvalues[28];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long CustomerID
		{
			get { return _cur__CustomerID; }
			set
			{
				if (_started_with_dbvalues == false) _mod__CustomerID = true;
				if (_cur__CustomerID == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__CustomerID == false) { _ori__CustomerID = _cur__CustomerID; _mod__CustomerID = true; } // existing record and column is not modified
					else { if (value == _ori__CustomerID) { _ori__CustomerID = default(long); _mod__CustomerID = false; } } // existing record and column is modified
				}
				_cur__CustomerID = value; OnPropertyChanged("CustomerID"); OnAfterPropertyChanged("CustomerID");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string AddressLine1
		{
			get { return _cur__AddressLine1; }
			set
			{
				if (value == null) throw new ArgumentNullException("AddressLine1", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__AddressLine1 = true;
				if (_cur__AddressLine1 == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__AddressLine1 == false) { _ori__AddressLine1 = _cur__AddressLine1; _mod__AddressLine1 = true; } // existing record and column is not modified
					else { if (value == _ori__AddressLine1) { _ori__AddressLine1 = default(string); _mod__AddressLine1 = false; } } // existing record and column is modified
				}
				_cur__AddressLine1 = value; OnPropertyChanged("AddressLine1"); OnAfterPropertyChanged("AddressLine1");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string AddressLine2
		{
			get { return _cur__AddressLine2; }
			set
			{
				if (_started_with_dbvalues == false) _mod__AddressLine2 = true;
				if (_cur__AddressLine2 == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__AddressLine2 == false) { _ori__AddressLine2 = _cur__AddressLine2; _mod__AddressLine2 = true; } // existing record and column is not modified
					else { if (value == _ori__AddressLine2) { _ori__AddressLine2 = default(string); _mod__AddressLine2 = false; } } // existing record and column is modified
				}
				_cur__AddressLine2 = value; OnPropertyChanged("AddressLine2"); OnAfterPropertyChanged("AddressLine2");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string BirthDate
		{
			get { return _cur__BirthDate; }
			set
			{
				if (_started_with_dbvalues == false) _mod__BirthDate = true;
				if (_cur__BirthDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__BirthDate == false) { _ori__BirthDate = _cur__BirthDate; _mod__BirthDate = true; } // existing record and column is not modified
					else { if (value == _ori__BirthDate) { _ori__BirthDate = default(string); _mod__BirthDate = false; } } // existing record and column is modified
				}
				_cur__BirthDate = value; OnPropertyChanged("BirthDate"); OnAfterPropertyChanged("BirthDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? ChildrenAtHome
		{
			get { return _cur__ChildrenAtHome; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ChildrenAtHome = true;
				if (_cur__ChildrenAtHome == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ChildrenAtHome == false) { _ori__ChildrenAtHome = _cur__ChildrenAtHome; _mod__ChildrenAtHome = true; } // existing record and column is not modified
					else { if (value == _ori__ChildrenAtHome) { _ori__ChildrenAtHome = default(long?); _mod__ChildrenAtHome = false; } } // existing record and column is modified
				}
				_cur__ChildrenAtHome = value; OnPropertyChanged("ChildrenAtHome"); OnAfterPropertyChanged("ChildrenAtHome");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string City
		{
			get { return _cur__City; }
			set
			{
				if (value == null) throw new ArgumentNullException("City", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__City = true;
				if (_cur__City == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__City == false) { _ori__City = _cur__City; _mod__City = true; } // existing record and column is not modified
					else { if (value == _ori__City) { _ori__City = default(string); _mod__City = false; } } // existing record and column is modified
				}
				_cur__City = value; OnPropertyChanged("City"); OnAfterPropertyChanged("City");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string CountryCode
		{
			get { return _cur__CountryCode; }
			set
			{
				if (value == null) throw new ArgumentNullException("CountryCode", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__CountryCode = true;
				if (_cur__CountryCode == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__CountryCode == false) { _ori__CountryCode = _cur__CountryCode; _mod__CountryCode = true; } // existing record and column is not modified
					else { if (value == _ori__CountryCode) { _ori__CountryCode = default(string); _mod__CountryCode = false; } } // existing record and column is modified
				}
				_cur__CountryCode = value; OnPropertyChanged("CountryCode"); OnAfterPropertyChanged("CountryCode");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string CreatedOn
		{
			get { return _cur__CreatedOn; }
			set
			{
				if (value == null) throw new ArgumentNullException("CreatedOn", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__CreatedOn = true;
				if (_cur__CreatedOn == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__CreatedOn == false) { _ori__CreatedOn = _cur__CreatedOn; _mod__CreatedOn = true; } // existing record and column is not modified
					else { if (value == _ori__CreatedOn) { _ori__CreatedOn = default(string); _mod__CreatedOn = false; } } // existing record and column is modified
				}
				_cur__CreatedOn = value; OnPropertyChanged("CreatedOn"); OnAfterPropertyChanged("CreatedOn");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Education
		{
			get { return _cur__Education; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Education = true;
				if (_cur__Education == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Education == false) { _ori__Education = _cur__Education; _mod__Education = true; } // existing record and column is not modified
					else { if (value == _ori__Education) { _ori__Education = default(string); _mod__Education = false; } } // existing record and column is modified
				}
				_cur__Education = value; OnPropertyChanged("Education"); OnAfterPropertyChanged("Education");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string EmailAddress
		{
			get { return _cur__EmailAddress; }
			set
			{
				if (value == null) throw new ArgumentNullException("EmailAddress", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__EmailAddress = true;
				if (_cur__EmailAddress == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__EmailAddress == false) { _ori__EmailAddress = _cur__EmailAddress; _mod__EmailAddress = true; } // existing record and column is not modified
					else { if (value == _ori__EmailAddress) { _ori__EmailAddress = default(string); _mod__EmailAddress = false; } } // existing record and column is modified
				}
				_cur__EmailAddress = value; OnPropertyChanged("EmailAddress"); OnAfterPropertyChanged("EmailAddress");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string FirstName
		{
			get { return _cur__FirstName; }
			set
			{
				if (value == null) throw new ArgumentNullException("FirstName", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__FirstName = true;
				if (_cur__FirstName == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__FirstName == false) { _ori__FirstName = _cur__FirstName; _mod__FirstName = true; } // existing record and column is not modified
					else { if (value == _ori__FirstName) { _ori__FirstName = default(string); _mod__FirstName = false; } } // existing record and column is modified
				}
				_cur__FirstName = value; OnPropertyChanged("FirstName"); OnAfterPropertyChanged("FirstName");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Gender
		{
			get { return _cur__Gender; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Gender = true;
				if (_cur__Gender == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Gender == false) { _ori__Gender = _cur__Gender; _mod__Gender = true; } // existing record and column is not modified
					else { if (value == _ori__Gender) { _ori__Gender = default(string); _mod__Gender = false; } } // existing record and column is modified
				}
				_cur__Gender = value; OnPropertyChanged("Gender"); OnAfterPropertyChanged("Gender");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? IsHouseOwner
		{
			get { return _cur__IsHouseOwner; }
			set
			{
				if (_started_with_dbvalues == false) _mod__IsHouseOwner = true;
				if (_cur__IsHouseOwner == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__IsHouseOwner == false) { _ori__IsHouseOwner = _cur__IsHouseOwner; _mod__IsHouseOwner = true; } // existing record and column is not modified
					else { if (value == _ori__IsHouseOwner) { _ori__IsHouseOwner = default(long?); _mod__IsHouseOwner = false; } } // existing record and column is modified
				}
				_cur__IsHouseOwner = value; OnPropertyChanged("IsHouseOwner"); OnAfterPropertyChanged("IsHouseOwner");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string LastModifiedOn
		{
			get { return _cur__LastModifiedOn; }
			set
			{
				if (value == null) throw new ArgumentNullException("LastModifiedOn", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__LastModifiedOn = true;
				if (_cur__LastModifiedOn == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__LastModifiedOn == false) { _ori__LastModifiedOn = _cur__LastModifiedOn; _mod__LastModifiedOn = true; } // existing record and column is not modified
					else { if (value == _ori__LastModifiedOn) { _ori__LastModifiedOn = default(string); _mod__LastModifiedOn = false; } } // existing record and column is modified
				}
				_cur__LastModifiedOn = value; OnPropertyChanged("LastModifiedOn"); OnAfterPropertyChanged("LastModifiedOn");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string LastName
		{
			get { return _cur__LastName; }
			set
			{
				if (value == null) throw new ArgumentNullException("LastName", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__LastName = true;
				if (_cur__LastName == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__LastName == false) { _ori__LastName = _cur__LastName; _mod__LastName = true; } // existing record and column is not modified
					else { if (value == _ori__LastName) { _ori__LastName = default(string); _mod__LastName = false; } } // existing record and column is modified
				}
				_cur__LastName = value; OnPropertyChanged("LastName"); OnAfterPropertyChanged("LastName");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string MaritalStatus
		{
			get { return _cur__MaritalStatus; }
			set
			{
				if (_started_with_dbvalues == false) _mod__MaritalStatus = true;
				if (_cur__MaritalStatus == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__MaritalStatus == false) { _ori__MaritalStatus = _cur__MaritalStatus; _mod__MaritalStatus = true; } // existing record and column is not modified
					else { if (value == _ori__MaritalStatus) { _ori__MaritalStatus = default(string); _mod__MaritalStatus = false; } } // existing record and column is modified
				}
				_cur__MaritalStatus = value; OnPropertyChanged("MaritalStatus"); OnAfterPropertyChanged("MaritalStatus");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string MiddleName
		{
			get { return _cur__MiddleName; }
			set
			{
				if (_started_with_dbvalues == false) _mod__MiddleName = true;
				if (_cur__MiddleName == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__MiddleName == false) { _ori__MiddleName = _cur__MiddleName; _mod__MiddleName = true; } // existing record and column is not modified
					else { if (value == _ori__MiddleName) { _ori__MiddleName = default(string); _mod__MiddleName = false; } } // existing record and column is modified
				}
				_cur__MiddleName = value; OnPropertyChanged("MiddleName"); OnAfterPropertyChanged("MiddleName");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? NumberCarsOwned
		{
			get { return _cur__NumberCarsOwned; }
			set
			{
				if (_started_with_dbvalues == false) _mod__NumberCarsOwned = true;
				if (_cur__NumberCarsOwned == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__NumberCarsOwned == false) { _ori__NumberCarsOwned = _cur__NumberCarsOwned; _mod__NumberCarsOwned = true; } // existing record and column is not modified
					else { if (value == _ori__NumberCarsOwned) { _ori__NumberCarsOwned = default(long?); _mod__NumberCarsOwned = false; } } // existing record and column is modified
				}
				_cur__NumberCarsOwned = value; OnPropertyChanged("NumberCarsOwned"); OnAfterPropertyChanged("NumberCarsOwned");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Occupation
		{
			get { return _cur__Occupation; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Occupation = true;
				if (_cur__Occupation == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Occupation == false) { _ori__Occupation = _cur__Occupation; _mod__Occupation = true; } // existing record and column is not modified
					else { if (value == _ori__Occupation) { _ori__Occupation = default(string); _mod__Occupation = false; } } // existing record and column is modified
				}
				_cur__Occupation = value; OnPropertyChanged("Occupation"); OnAfterPropertyChanged("Occupation");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Phone
		{
			get { return _cur__Phone; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Phone = true;
				if (_cur__Phone == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Phone == false) { _ori__Phone = _cur__Phone; _mod__Phone = true; } // existing record and column is not modified
					else { if (value == _ori__Phone) { _ori__Phone = default(string); _mod__Phone = false; } } // existing record and column is modified
				}
				_cur__Phone = value; OnPropertyChanged("Phone"); OnAfterPropertyChanged("Phone");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public object Picture
		{
			get { return _cur__Picture; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Picture = true;
				if (_cur__Picture == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Picture == false) { _ori__Picture = _cur__Picture; _mod__Picture = true; } // existing record and column is not modified
					else { if (value == _ori__Picture) { _ori__Picture = default(object); _mod__Picture = false; } } // existing record and column is modified
				}
				_cur__Picture = value; OnPropertyChanged("Picture"); OnAfterPropertyChanged("Picture");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string PostalCode
		{
			get { return _cur__PostalCode; }
			set
			{
				if (value == null) throw new ArgumentNullException("PostalCode", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__PostalCode = true;
				if (_cur__PostalCode == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__PostalCode == false) { _ori__PostalCode = _cur__PostalCode; _mod__PostalCode = true; } // existing record and column is not modified
					else { if (value == _ori__PostalCode) { _ori__PostalCode = default(string); _mod__PostalCode = false; } } // existing record and column is modified
				}
				_cur__PostalCode = value; OnPropertyChanged("PostalCode"); OnAfterPropertyChanged("PostalCode");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string Region
		{
			get { return _cur__Region; }
			set
			{
				if (value == null) throw new ArgumentNullException("Region", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__Region = true;
				if (_cur__Region == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Region == false) { _ori__Region = _cur__Region; _mod__Region = true; } // existing record and column is not modified
					else { if (value == _ori__Region) { _ori__Region = default(string); _mod__Region = false; } } // existing record and column is modified
				}
				_cur__Region = value; OnPropertyChanged("Region"); OnAfterPropertyChanged("Region");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string SearchTerms
		{
			get { return _cur__SearchTerms; }
			set
			{
				if (_started_with_dbvalues == false) _mod__SearchTerms = true;
				if (_cur__SearchTerms == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__SearchTerms == false) { _ori__SearchTerms = _cur__SearchTerms; _mod__SearchTerms = true; } // existing record and column is not modified
					else { if (value == _ori__SearchTerms) { _ori__SearchTerms = default(string); _mod__SearchTerms = false; } } // existing record and column is modified
				}
				_cur__SearchTerms = value; OnPropertyChanged("SearchTerms"); OnAfterPropertyChanged("SearchTerms");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Suffix
		{
			get { return _cur__Suffix; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Suffix = true;
				if (_cur__Suffix == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Suffix == false) { _ori__Suffix = _cur__Suffix; _mod__Suffix = true; } // existing record and column is not modified
					else { if (value == _ori__Suffix) { _ori__Suffix = default(string); _mod__Suffix = false; } } // existing record and column is modified
				}
				_cur__Suffix = value; OnPropertyChanged("Suffix"); OnAfterPropertyChanged("Suffix");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public object Thumbnail
		{
			get { return _cur__Thumbnail; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Thumbnail = true;
				if (_cur__Thumbnail == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Thumbnail == false) { _ori__Thumbnail = _cur__Thumbnail; _mod__Thumbnail = true; } // existing record and column is not modified
					else { if (value == _ori__Thumbnail) { _ori__Thumbnail = default(object); _mod__Thumbnail = false; } } // existing record and column is modified
				}
				_cur__Thumbnail = value; OnPropertyChanged("Thumbnail"); OnAfterPropertyChanged("Thumbnail");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string Title
		{
			get { return _cur__Title; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Title = true;
				if (_cur__Title == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Title == false) { _ori__Title = _cur__Title; _mod__Title = true; } // existing record and column is not modified
					else { if (value == _ori__Title) { _ori__Title = default(string); _mod__Title = false; } } // existing record and column is modified
				}
				_cur__Title = value; OnPropertyChanged("Title"); OnAfterPropertyChanged("Title");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public long? TotalChildren
		{
			get { return _cur__TotalChildren; }
			set
			{
				if (_started_with_dbvalues == false) _mod__TotalChildren = true;
				if (_cur__TotalChildren == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__TotalChildren == false) { _ori__TotalChildren = _cur__TotalChildren; _mod__TotalChildren = true; } // existing record and column is not modified
					else { if (value == _ori__TotalChildren) { _ori__TotalChildren = default(long?); _mod__TotalChildren = false; } } // existing record and column is modified
				}
				_cur__TotalChildren = value; OnPropertyChanged("TotalChildren"); OnAfterPropertyChanged("TotalChildren");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Customers]. NotReadonly. AllowNull.
		/// </summary>
		public string YearlyIncome
		{
			get { return _cur__YearlyIncome; }
			set
			{
				if (_started_with_dbvalues == false) _mod__YearlyIncome = true;
				if (_cur__YearlyIncome == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__YearlyIncome == false) { _ori__YearlyIncome = _cur__YearlyIncome; _mod__YearlyIncome = true; } // existing record and column is not modified
					else { if (value == _ori__YearlyIncome) { _ori__YearlyIncome = default(string); _mod__YearlyIncome = false; } } // existing record and column is modified
				}
				_cur__YearlyIncome = value; OnPropertyChanged("YearlyIncome"); OnAfterPropertyChanged("YearlyIncome");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "CustomerID") return _mod__CustomerID;
			if (column_name == "AddressLine1") return _mod__AddressLine1;
			if (column_name == "AddressLine2") return _mod__AddressLine2;
			if (column_name == "BirthDate") return _mod__BirthDate;
			if (column_name == "ChildrenAtHome") return _mod__ChildrenAtHome;
			if (column_name == "City") return _mod__City;
			if (column_name == "CountryCode") return _mod__CountryCode;
			if (column_name == "CreatedOn") return _mod__CreatedOn;
			if (column_name == "Education") return _mod__Education;
			if (column_name == "EmailAddress") return _mod__EmailAddress;
			if (column_name == "FirstName") return _mod__FirstName;
			if (column_name == "Gender") return _mod__Gender;
			if (column_name == "IsHouseOwner") return _mod__IsHouseOwner;
			if (column_name == "LastModifiedOn") return _mod__LastModifiedOn;
			if (column_name == "LastName") return _mod__LastName;
			if (column_name == "MaritalStatus") return _mod__MaritalStatus;
			if (column_name == "MiddleName") return _mod__MiddleName;
			if (column_name == "NumberCarsOwned") return _mod__NumberCarsOwned;
			if (column_name == "Occupation") return _mod__Occupation;
			if (column_name == "Phone") return _mod__Phone;
			if (column_name == "Picture") return _mod__Picture;
			if (column_name == "PostalCode") return _mod__PostalCode;
			if (column_name == "Region") return _mod__Region;
			if (column_name == "SearchTerms") return _mod__SearchTerms;
			if (column_name == "Suffix") return _mod__Suffix;
			if (column_name == "Thumbnail") return _mod__Thumbnail;
			if (column_name == "Title") return _mod__Title;
			if (column_name == "TotalChildren") return _mod__TotalChildren;
			if (column_name == "YearlyIncome") return _mod__YearlyIncome;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__CustomerID == true) count++;
			if (_mod__AddressLine1 == true) count++;
			if (_mod__AddressLine2 == true) count++;
			if (_mod__BirthDate == true) count++;
			if (_mod__ChildrenAtHome == true) count++;
			if (_mod__City == true) count++;
			if (_mod__CountryCode == true) count++;
			if (_mod__CreatedOn == true) count++;
			if (_mod__Education == true) count++;
			if (_mod__EmailAddress == true) count++;
			if (_mod__FirstName == true) count++;
			if (_mod__Gender == true) count++;
			if (_mod__IsHouseOwner == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__LastName == true) count++;
			if (_mod__MaritalStatus == true) count++;
			if (_mod__MiddleName == true) count++;
			if (_mod__NumberCarsOwned == true) count++;
			if (_mod__Occupation == true) count++;
			if (_mod__Phone == true) count++;
			if (_mod__Picture == true) count++;
			if (_mod__PostalCode == true) count++;
			if (_mod__Region == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__Suffix == true) count++;
			if (_mod__Thumbnail == true) count++;
			if (_mod__Title == true) count++;
			if (_mod__TotalChildren == true) count++;
			if (_mod__YearlyIncome == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__CustomerID) count++;
			}
			if (_mod__AddressLine1 == true) count++;
			if (_mod__AddressLine2 == true) count++;
			if (_mod__BirthDate == true) count++;
			if (_mod__ChildrenAtHome == true) count++;
			if (_mod__City == true) count++;
			if (_mod__CountryCode == true) count++;
			if (_mod__CreatedOn == true) count++;
			if (_mod__Education == true) count++;
			if (_mod__EmailAddress == true) count++;
			if (_mod__FirstName == true) count++;
			if (_mod__Gender == true) count++;
			if (_mod__IsHouseOwner == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__LastName == true) count++;
			if (_mod__MaritalStatus == true) count++;
			if (_mod__MiddleName == true) count++;
			if (_mod__NumberCarsOwned == true) count++;
			if (_mod__Occupation == true) count++;
			if (_mod__Phone == true) count++;
			if (_mod__Picture == true) count++;
			if (_mod__PostalCode == true) count++;
			if (_mod__Region == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__Suffix == true) count++;
			if (_mod__Thumbnail == true) count++;
			if (_mod__Title == true) count++;
			if (_mod__TotalChildren == true) count++;
			if (_mod__YearlyIncome == true) count++;
			return count > 0;
		}

		public DataRecordStatus RecordStatus()
		{
			return _recordstatus;
		}

		DataRecordStatus IRecordBase.RecordStatus
		{
			get { return _recordstatus; }
			set { _recordstatus = value; }
		}

		void IRecordBase.ValidateBeforeSaving(int record_index_to_display)
		{
			if (_started_with_dbvalues) return;
			if (_recordstatus == DataRecordStatus.Existing) return;
			if (_mod__CustomerID == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "CustomerID"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__CustomerID);
				track_array.AppendDataValue(1, _cur__AddressLine1);
				if (_cur__AddressLine2 != null) track_array.AppendDataValue(2, _cur__AddressLine2);
				if (_cur__BirthDate != null) track_array.AppendDataValue(3, _cur__BirthDate);
				if (_cur__ChildrenAtHome != null) track_array.AppendDataValue(4, _cur__ChildrenAtHome);
				track_array.AppendDataValue(5, _cur__City);
				track_array.AppendDataValue(6, _cur__CountryCode);
				track_array.AppendDataValue(7, _cur__CreatedOn);
				if (_cur__Education != null) track_array.AppendDataValue(8, _cur__Education);
				track_array.AppendDataValue(9, _cur__EmailAddress);
				track_array.AppendDataValue(10, _cur__FirstName);
				if (_cur__Gender != null) track_array.AppendDataValue(11, _cur__Gender);
				if (_cur__IsHouseOwner != null) track_array.AppendDataValue(12, _cur__IsHouseOwner);
				track_array.AppendDataValue(13, _cur__LastModifiedOn);
				track_array.AppendDataValue(14, _cur__LastName);
				if (_cur__MaritalStatus != null) track_array.AppendDataValue(15, _cur__MaritalStatus);
				if (_cur__MiddleName != null) track_array.AppendDataValue(16, _cur__MiddleName);
				if (_cur__NumberCarsOwned != null) track_array.AppendDataValue(17, _cur__NumberCarsOwned);
				if (_cur__Occupation != null) track_array.AppendDataValue(18, _cur__Occupation);
				if (_cur__Phone != null) track_array.AppendDataValue(19, _cur__Phone);
				if (_cur__Picture != null) track_array.AppendDataValue(20, _cur__Picture);
				track_array.AppendDataValue(21, _cur__PostalCode);
				track_array.AppendDataValue(22, _cur__Region);
				if (_cur__SearchTerms != null) track_array.AppendDataValue(23, _cur__SearchTerms);
				if (_cur__Suffix != null) track_array.AppendDataValue(24, _cur__Suffix);
				if (_cur__Thumbnail != null) track_array.AppendDataValue(25, _cur__Thumbnail);
				if (_cur__Title != null) track_array.AppendDataValue(26, _cur__Title);
				if (_cur__TotalChildren != null) track_array.AppendDataValue(27, _cur__TotalChildren);
				if (_cur__YearlyIncome != null) track_array.AppendDataValue(28, _cur__YearlyIncome);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__CustomerID) track_array.AppendDataValue(0, _cur__CustomerID);
				}
				if (_mod__AddressLine1) track_array.AppendDataValue(1, _cur__AddressLine1);
				if (_mod__AddressLine2) track_array.AppendDataValue(2, _cur__AddressLine2);
				if (_mod__BirthDate) track_array.AppendDataValue(3, _cur__BirthDate);
				if (_mod__ChildrenAtHome) track_array.AppendDataValue(4, _cur__ChildrenAtHome);
				if (_mod__City) track_array.AppendDataValue(5, _cur__City);
				if (_mod__CountryCode) track_array.AppendDataValue(6, _cur__CountryCode);
				if (_mod__CreatedOn) track_array.AppendDataValue(7, _cur__CreatedOn);
				if (_mod__Education) track_array.AppendDataValue(8, _cur__Education);
				if (_mod__EmailAddress) track_array.AppendDataValue(9, _cur__EmailAddress);
				if (_mod__FirstName) track_array.AppendDataValue(10, _cur__FirstName);
				if (_mod__Gender) track_array.AppendDataValue(11, _cur__Gender);
				if (_mod__IsHouseOwner) track_array.AppendDataValue(12, _cur__IsHouseOwner);
				if (_mod__LastModifiedOn) track_array.AppendDataValue(13, _cur__LastModifiedOn);
				if (_mod__LastName) track_array.AppendDataValue(14, _cur__LastName);
				if (_mod__MaritalStatus) track_array.AppendDataValue(15, _cur__MaritalStatus);
				if (_mod__MiddleName) track_array.AppendDataValue(16, _cur__MiddleName);
				if (_mod__NumberCarsOwned) track_array.AppendDataValue(17, _cur__NumberCarsOwned);
				if (_mod__Occupation) track_array.AppendDataValue(18, _cur__Occupation);
				if (_mod__Phone) track_array.AppendDataValue(19, _cur__Phone);
				if (_mod__Picture) track_array.AppendDataValue(20, _cur__Picture);
				if (_mod__PostalCode) track_array.AppendDataValue(21, _cur__PostalCode);
				if (_mod__Region) track_array.AppendDataValue(22, _cur__Region);
				if (_mod__SearchTerms) track_array.AppendDataValue(23, _cur__SearchTerms);
				if (_mod__Suffix) track_array.AppendDataValue(24, _cur__Suffix);
				if (_mod__Thumbnail) track_array.AppendDataValue(25, _cur__Thumbnail);
				if (_mod__Title) track_array.AppendDataValue(26, _cur__Title);
				if (_mod__TotalChildren) track_array.AppendDataValue(27, _cur__TotalChildren);
				if (_mod__YearlyIncome) track_array.AppendDataValue(28, _cur__YearlyIncome);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__CustomerID && _started_with_dbvalues) ? _ori__CustomerID : _cur__CustomerID);
			}

			if (_recordstatus == DataRecordStatus.New) track_array.Status = TrackArrayStatus.DataForINSERT;
			else if (_recordstatus == DataRecordStatus.Existing) track_array.Status = TrackArrayStatus.DataForUPDATE;
			else if (_recordstatus == DataRecordStatus.ExistingDelete) track_array.Status = TrackArrayStatus.DataForDELETE;
		}

		public bool StartedWithDbValues()
		{
			return _started_with_dbvalues;
		}

		/// <summary>
		/// Resets all columns to not-modified status.
		/// </summary>
		public void ResetToUnmodified()
		{
			if (_started_with_dbvalues == true)
			{
				if (_mod__CustomerID) _ori__CustomerID = default(long);
				if (_mod__AddressLine1) _ori__AddressLine1 = default(string);
				if (_mod__AddressLine2) _ori__AddressLine2 = default(string);
				if (_mod__BirthDate) _ori__BirthDate = default(string);
				if (_mod__ChildrenAtHome) _ori__ChildrenAtHome = default(long?);
				if (_mod__City) _ori__City = default(string);
				if (_mod__CountryCode) _ori__CountryCode = default(string);
				if (_mod__CreatedOn) _ori__CreatedOn = default(string);
				if (_mod__Education) _ori__Education = default(string);
				if (_mod__EmailAddress) _ori__EmailAddress = default(string);
				if (_mod__FirstName) _ori__FirstName = default(string);
				if (_mod__Gender) _ori__Gender = default(string);
				if (_mod__IsHouseOwner) _ori__IsHouseOwner = default(long?);
				if (_mod__LastModifiedOn) _ori__LastModifiedOn = default(string);
				if (_mod__LastName) _ori__LastName = default(string);
				if (_mod__MaritalStatus) _ori__MaritalStatus = default(string);
				if (_mod__MiddleName) _ori__MiddleName = default(string);
				if (_mod__NumberCarsOwned) _ori__NumberCarsOwned = default(long?);
				if (_mod__Occupation) _ori__Occupation = default(string);
				if (_mod__Phone) _ori__Phone = default(string);
				if (_mod__Picture) _ori__Picture = default(object);
				if (_mod__PostalCode) _ori__PostalCode = default(string);
				if (_mod__Region) _ori__Region = default(string);
				if (_mod__SearchTerms) _ori__SearchTerms = default(string);
				if (_mod__Suffix) _ori__Suffix = default(string);
				if (_mod__Thumbnail) _ori__Thumbnail = default(object);
				if (_mod__Title) _ori__Title = default(string);
				if (_mod__TotalChildren) _ori__TotalChildren = default(long?);
				if (_mod__YearlyIncome) _ori__YearlyIncome = default(string);
			}
			_mod__CustomerID = false;
			_mod__AddressLine1 = false;
			_mod__AddressLine2 = false;
			_mod__BirthDate = false;
			_mod__ChildrenAtHome = false;
			_mod__City = false;
			_mod__CountryCode = false;
			_mod__CreatedOn = false;
			_mod__Education = false;
			_mod__EmailAddress = false;
			_mod__FirstName = false;
			_mod__Gender = false;
			_mod__IsHouseOwner = false;
			_mod__LastModifiedOn = false;
			_mod__LastName = false;
			_mod__MaritalStatus = false;
			_mod__MiddleName = false;
			_mod__NumberCarsOwned = false;
			_mod__Occupation = false;
			_mod__Phone = false;
			_mod__Picture = false;
			_mod__PostalCode = false;
			_mod__Region = false;
			_mod__SearchTerms = false;
			_mod__Suffix = false;
			_mod__Thumbnail = false;
			_mod__Title = false;
			_mod__TotalChildren = false;
			_mod__YearlyIncome = false;
		}

		/// <summary>
		/// Resets the record to DataRecordStatus.Existing. Like it was freshly loaded from the database.
		/// </summary>
		public void ResetToUnmodifiedExisting()
		{
			ResetToUnmodified();
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Resets the record to DataRecordStatus.Existing.
		/// </summary>
		public void ResetToExisting()
		{
			_recordstatus = DataRecordStatus.Existing;
		}

		void IRecordBase.SetIdentityColumnValue(object value)
		{
		}

		partial void OnAfterPropertyChanged(string propertyName);

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}

// The following commented out code is a template for implementing calculated columns.
//
// How to guide: https://docs.venturatools.com/CalculatedColumns.html

/*
namespace Demo.VenturaAutoCreate
{
	public partial class GetAll_Customers_Record
	{
		partial void OnAfterPropertyChanged(string propertyName)
		{
			if (propertyName == "FirstName" || propertyName == "LastName")
				this.OnPropertyChanged("FirstNameLastName");
		}

		public string FirstNameLastName
		{
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}
	}

}
*/
