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

namespace Demo.VenturaRecordsets
{
	/// <summary>
	/// The updateable table is [Orders]. Updateable table column information:
	/// • 6 out of 17 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: OrderID.
	/// • Non-primary key columns present in the resultset: CustomerID, DeliveredDate, OrderDate, ShipCity and ShippedDate.
	/// • Non-primary key columns not present in the resultset: LastModifiedOn, PaymentType, SearchTerms, ShipAddress,
	///   ShipCountryCode, ShipPhone, ShipPostalCode, ShipRegion, ShipVia, Status and TrackingNumber.
	/// </summary>
	public partial class MostRecentOrdersRecordset : ResultsetObservable<MostRecentOrdersRecordset, MostRecentOrdersRecord>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public MostRecentOrdersRecordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"select Orders.CustomerID, Customers.FirstName, Customers.LastName, OrderID, OrderStatus.Name as OrderStatusName, OrderDate, ShippedDate, DeliveredDate, ShipCity, " + CRLF +
			             @"CountryCodes.Name as ShipCountryName" + CRLF +
			             @"from  Orders" + CRLF +
			             @"join Customers on Customers.CustomerID = Orders.CustomerID" + CRLF +
			             @"join OrderStatus on OrderStatus.Status = Orders.Status" + CRLF +
			             @"join CountryCodes on CountryCodes.CountryCodeID = Orders.ShipCountryCode" + CRLF +
			             @"order by OrderDate desc limit 5000";

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("CustomerID", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "CustomerID"
			});

			schema_array.Add(new VenturaColumn("FirstName", typeof(string), false)
			{
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "FirstName"
			});

			schema_array.Add(new VenturaColumn("LastName", typeof(string), false)
			{
				BaseCatalogName = "main",
				BaseTableName = "Customers",
				BaseColumnName = "LastName"
			});

			schema_array.Add(new VenturaColumn("OrderID", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "OrderID"
			});

			schema_array.Add(new VenturaColumn("OrderStatusName", typeof(string), false)
			{
				IsAliased = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderStatus",
				BaseColumnName = "Name"
			});

			schema_array.Add(new VenturaColumn("OrderDate", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "OrderDate"
			});

			schema_array.Add(new VenturaColumn("ShippedDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShippedDate"
			});

			schema_array.Add(new VenturaColumn("DeliveredDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "DeliveredDate"
			});

			schema_array.Add(new VenturaColumn("ShipCity", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipCity"
			});

			schema_array.Add(new VenturaColumn("ShipCountryName", typeof(string), false)
			{
				IsAliased = true,
				BaseCatalogName = "main",
				BaseTableName = "CountryCodes",
				BaseColumnName = "Name"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[Orders]";
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public long CustomerID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CustomerID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CustomerID = value; }
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string FirstName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.FirstName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.FirstName = value; }
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [Customers]. NotReadonly. NotNull.
		/// </summary>
		public string LastName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.LastName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.LastName = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long OrderID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.OrderID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.OrderID = value; }
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [OrderStatus]. NotReadonly. NotNull.
		/// </summary>
		public string OrderStatusName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.OrderStatusName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.OrderStatusName = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public string OrderDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.OrderDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.OrderDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShippedDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShippedDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShippedDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string DeliveredDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.DeliveredDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.DeliveredDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipCity
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipCity; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipCity = value; }
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [CountryCodes]. NotReadonly. NotNull.
		/// </summary>
		public string ShipCountryName
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipCountryName; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipCountryName = value; }
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
			this.InsertItem(index, new MostRecentOrdersRecord());
			this.CurrentRecordIndex = index;
		}

		public void Append(MostRecentOrdersRecord record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public MostRecentOrdersRecord NewRecord()
		{
			return new MostRecentOrdersRecord();
		}

		protected override MostRecentOrdersRecord InternalCreateExistingRecordObject(object[] columnvalues) => new MostRecentOrdersRecord(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 127, 226, 15, 251, 134, 147, 218, 248, 74, 134, 227, 131, 19, 35, 180, 175 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "7FE20FFB8693DAF84A86E3831323B4AF"; }
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

	public sealed partial class MostRecentOrdersRecord : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__CustomerID; private long _ori__CustomerID; private bool _mod__CustomerID;
		private string _cur__FirstName; private string _ori__FirstName; private bool _mod__FirstName;
		private string _cur__LastName; private string _ori__LastName; private bool _mod__LastName;
		private long _cur__OrderID; private long _ori__OrderID; private bool _mod__OrderID;
		private string _cur__OrderStatusName; private string _ori__OrderStatusName; private bool _mod__OrderStatusName;
		private string _cur__OrderDate; private string _ori__OrderDate; private bool _mod__OrderDate;
		private string _cur__ShippedDate; private string _ori__ShippedDate; private bool _mod__ShippedDate;
		private string _cur__DeliveredDate; private string _ori__DeliveredDate; private bool _mod__DeliveredDate;
		private string _cur__ShipCity; private string _ori__ShipCity; private bool _mod__ShipCity;
		private string _cur__ShipCountryName; private string _ori__ShipCountryName; private bool _mod__ShipCountryName;


		public MostRecentOrdersRecord()
		{
			_cur__CustomerID = 0;
			_cur__FirstName = "";
			_cur__LastName = "";
			_cur__OrderID = 0;
			_cur__OrderStatusName = "";
			_cur__OrderDate = "";
			_cur__ShippedDate = null;
			_cur__DeliveredDate = null;
			_cur__ShipCity = null;
			_cur__ShipCountryName = "";
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public MostRecentOrdersRecord(object[] columnvalues)
		{
			_cur__CustomerID = (long)columnvalues[0];
			_cur__FirstName = (string)columnvalues[1];
			_cur__LastName = (string)columnvalues[2];
			_cur__OrderID = (long)columnvalues[3];
			_cur__OrderStatusName = (string)columnvalues[4];
			_cur__OrderDate = (string)columnvalues[5];
			_cur__ShippedDate = (string)columnvalues[6];
			_cur__DeliveredDate = (string)columnvalues[7];
			_cur__ShipCity = (string)columnvalues[8];
			_cur__ShipCountryName = (string)columnvalues[9];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
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
		/// Database Column NotUpdateable. Table [Customers]. NotReadonly. NotNull.
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
		/// Database Column NotUpdateable. Table [Customers]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Orders]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long OrderID
		{
			get { return _cur__OrderID; }
			set
			{
				if (_started_with_dbvalues == false) _mod__OrderID = true;
				if (_cur__OrderID == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__OrderID == false) { _ori__OrderID = _cur__OrderID; _mod__OrderID = true; } // existing record and column is not modified
					else { if (value == _ori__OrderID) { _ori__OrderID = default(long); _mod__OrderID = false; } } // existing record and column is modified
				}
				_cur__OrderID = value; OnPropertyChanged("OrderID"); OnAfterPropertyChanged("OrderID");
			}
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [OrderStatus]. NotReadonly. NotNull.
		/// </summary>
		public string OrderStatusName
		{
			get { return _cur__OrderStatusName; }
			set
			{
				if (value == null) throw new ArgumentNullException("OrderStatusName", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__OrderStatusName = true;
				if (_cur__OrderStatusName == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__OrderStatusName == false) { _ori__OrderStatusName = _cur__OrderStatusName; _mod__OrderStatusName = true; } // existing record and column is not modified
					else { if (value == _ori__OrderStatusName) { _ori__OrderStatusName = default(string); _mod__OrderStatusName = false; } } // existing record and column is modified
				}
				_cur__OrderStatusName = value; OnPropertyChanged("OrderStatusName"); OnAfterPropertyChanged("OrderStatusName");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public string OrderDate
		{
			get { return _cur__OrderDate; }
			set
			{
				if (value == null) throw new ArgumentNullException("OrderDate", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__OrderDate = true;
				if (_cur__OrderDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__OrderDate == false) { _ori__OrderDate = _cur__OrderDate; _mod__OrderDate = true; } // existing record and column is not modified
					else { if (value == _ori__OrderDate) { _ori__OrderDate = default(string); _mod__OrderDate = false; } } // existing record and column is modified
				}
				_cur__OrderDate = value; OnPropertyChanged("OrderDate"); OnAfterPropertyChanged("OrderDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShippedDate
		{
			get { return _cur__ShippedDate; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShippedDate = true;
				if (_cur__ShippedDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShippedDate == false) { _ori__ShippedDate = _cur__ShippedDate; _mod__ShippedDate = true; } // existing record and column is not modified
					else { if (value == _ori__ShippedDate) { _ori__ShippedDate = default(string); _mod__ShippedDate = false; } } // existing record and column is modified
				}
				_cur__ShippedDate = value; OnPropertyChanged("ShippedDate"); OnAfterPropertyChanged("ShippedDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string DeliveredDate
		{
			get { return _cur__DeliveredDate; }
			set
			{
				if (_started_with_dbvalues == false) _mod__DeliveredDate = true;
				if (_cur__DeliveredDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__DeliveredDate == false) { _ori__DeliveredDate = _cur__DeliveredDate; _mod__DeliveredDate = true; } // existing record and column is not modified
					else { if (value == _ori__DeliveredDate) { _ori__DeliveredDate = default(string); _mod__DeliveredDate = false; } } // existing record and column is modified
				}
				_cur__DeliveredDate = value; OnPropertyChanged("DeliveredDate"); OnAfterPropertyChanged("DeliveredDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipCity
		{
			get { return _cur__ShipCity; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipCity = true;
				if (_cur__ShipCity == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipCity == false) { _ori__ShipCity = _cur__ShipCity; _mod__ShipCity = true; } // existing record and column is not modified
					else { if (value == _ori__ShipCity) { _ori__ShipCity = default(string); _mod__ShipCity = false; } } // existing record and column is modified
				}
				_cur__ShipCity = value; OnPropertyChanged("ShipCity"); OnAfterPropertyChanged("ShipCity");
			}
		}

		/// <summary>
		/// Database Column NotUpdateable. Table [CountryCodes]. NotReadonly. NotNull.
		/// </summary>
		public string ShipCountryName
		{
			get { return _cur__ShipCountryName; }
			set
			{
				if (value == null) throw new ArgumentNullException("ShipCountryName", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__ShipCountryName = true;
				if (_cur__ShipCountryName == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipCountryName == false) { _ori__ShipCountryName = _cur__ShipCountryName; _mod__ShipCountryName = true; } // existing record and column is not modified
					else { if (value == _ori__ShipCountryName) { _ori__ShipCountryName = default(string); _mod__ShipCountryName = false; } } // existing record and column is modified
				}
				_cur__ShipCountryName = value; OnPropertyChanged("ShipCountryName"); OnAfterPropertyChanged("ShipCountryName");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "CustomerID") return _mod__CustomerID;
			if (column_name == "FirstName") return _mod__FirstName;
			if (column_name == "LastName") return _mod__LastName;
			if (column_name == "OrderID") return _mod__OrderID;
			if (column_name == "OrderStatusName") return _mod__OrderStatusName;
			if (column_name == "OrderDate") return _mod__OrderDate;
			if (column_name == "ShippedDate") return _mod__ShippedDate;
			if (column_name == "DeliveredDate") return _mod__DeliveredDate;
			if (column_name == "ShipCity") return _mod__ShipCity;
			if (column_name == "ShipCountryName") return _mod__ShipCountryName;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__CustomerID == true) count++;
			if (_mod__FirstName == true) count++;
			if (_mod__LastName == true) count++;
			if (_mod__OrderID == true) count++;
			if (_mod__OrderStatusName == true) count++;
			if (_mod__OrderDate == true) count++;
			if (_mod__ShippedDate == true) count++;
			if (_mod__DeliveredDate == true) count++;
			if (_mod__ShipCity == true) count++;
			if (_mod__ShipCountryName == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__OrderID) count++;
			}
			if (_mod__CustomerID == true) count++;
			if (_mod__OrderDate == true) count++;
			if (_mod__ShippedDate == true) count++;
			if (_mod__DeliveredDate == true) count++;
			if (_mod__ShipCity == true) count++;
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
			if (_mod__OrderID == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "OrderID"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__CustomerID);
				track_array.AppendDataValue(3, _cur__OrderID);
				track_array.AppendDataValue(5, _cur__OrderDate);
				if (_cur__ShippedDate != null) track_array.AppendDataValue(6, _cur__ShippedDate);
				if (_cur__DeliveredDate != null) track_array.AppendDataValue(7, _cur__DeliveredDate);
				if (_cur__ShipCity != null) track_array.AppendDataValue(8, _cur__ShipCity);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__OrderID) track_array.AppendDataValue(3, _cur__OrderID);
				}
				if (_mod__CustomerID) track_array.AppendDataValue(0, _cur__CustomerID);
				if (_mod__OrderDate) track_array.AppendDataValue(5, _cur__OrderDate);
				if (_mod__ShippedDate) track_array.AppendDataValue(6, _cur__ShippedDate);
				if (_mod__DeliveredDate) track_array.AppendDataValue(7, _cur__DeliveredDate);
				if (_mod__ShipCity) track_array.AppendDataValue(8, _cur__ShipCity);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(3, (_mod__OrderID && _started_with_dbvalues) ? _ori__OrderID : _cur__OrderID);
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
				if (_mod__FirstName) _ori__FirstName = default(string);
				if (_mod__LastName) _ori__LastName = default(string);
				if (_mod__OrderID) _ori__OrderID = default(long);
				if (_mod__OrderStatusName) _ori__OrderStatusName = default(string);
				if (_mod__OrderDate) _ori__OrderDate = default(string);
				if (_mod__ShippedDate) _ori__ShippedDate = default(string);
				if (_mod__DeliveredDate) _ori__DeliveredDate = default(string);
				if (_mod__ShipCity) _ori__ShipCity = default(string);
				if (_mod__ShipCountryName) _ori__ShipCountryName = default(string);
			}
			_mod__CustomerID = false;
			_mod__FirstName = false;
			_mod__LastName = false;
			_mod__OrderID = false;
			_mod__OrderStatusName = false;
			_mod__OrderDate = false;
			_mod__ShippedDate = false;
			_mod__DeliveredDate = false;
			_mod__ShipCity = false;
			_mod__ShipCountryName = false;
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
namespace Demo.VenturaRecordsets
{
	public partial class MostRecentOrdersRecord
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
