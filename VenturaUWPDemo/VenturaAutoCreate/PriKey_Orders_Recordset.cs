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
	/// The updateable table is [Orders]. Updateable table column information:
	/// • 17 out of 17 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: OrderID.
	/// • Non-primary key columns present in the resultset: CustomerID, DeliveredDate, LastModifiedOn, OrderDate, PaymentType,
	///   SearchTerms, ShipAddress, ShipCity, ShipCountryCode, ShipPhone, ShipPostalCode, ShipRegion, ShipVia, ShippedDate, Status
	///   and TrackingNumber.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class PriKey_Orders_Recordset : ResultsetObservable<PriKey_Orders_Recordset, PriKey_Orders_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private object[] _inputparametervalues;
		private InputParamHolder _inputparamholder;
		private VenturaSchema _parameterschema;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public PriKey_Orders_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [OrderID],[CustomerID],[DeliveredDate],[LastModifiedOn],[OrderDate],[PaymentType],[SearchTerms],[ShipAddress],[ShipCity],[ShipCountryCode],[ShipPhone]," + CRLF +
			             @"[ShipPostalCode],[ShipRegion],[ShipVia],[ShippedDate],[Status],[TrackingNumber]" + CRLF +
			             @"FROM [Orders]" + CRLF +
			             @"WHERE [OrderID] = @OrderID";

			_inputparametervalues = new object[1];
			_inputparamholder = new InputParamHolder(_inputparametervalues);

			ColumnArrayBuilder param_array = new ColumnArrayBuilder();

			param_array.AddParameterColumn("@OrderID", typeof(long), true, false, DbType.Int64, null, null, null);

			_parameterschema = new VenturaSchema(param_array);

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("OrderID", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "OrderID"
			});

			schema_array.Add(new VenturaColumn("CustomerID", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "CustomerID"
			});

			schema_array.Add(new VenturaColumn("DeliveredDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "DeliveredDate"
			});

			schema_array.Add(new VenturaColumn("LastModifiedOn", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "LastModifiedOn"
			});

			schema_array.Add(new VenturaColumn("OrderDate", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "OrderDate"
			});

			schema_array.Add(new VenturaColumn("PaymentType", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "PaymentType"
			});

			schema_array.Add(new VenturaColumn("SearchTerms", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "SearchTerms"
			});

			schema_array.Add(new VenturaColumn("ShipAddress", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipAddress"
			});

			schema_array.Add(new VenturaColumn("ShipCity", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipCity"
			});

			schema_array.Add(new VenturaColumn("ShipCountryCode", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipCountryCode"
			});

			schema_array.Add(new VenturaColumn("ShipPhone", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipPhone"
			});

			schema_array.Add(new VenturaColumn("ShipPostalCode", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipPostalCode"
			});

			schema_array.Add(new VenturaColumn("ShipRegion", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipRegion"
			});

			schema_array.Add(new VenturaColumn("ShipVia", typeof(long), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShipVia"
			});

			schema_array.Add(new VenturaColumn("ShippedDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "ShippedDate"
			});

			schema_array.Add(new VenturaColumn("Status", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "Status"
			});

			schema_array.Add(new VenturaColumn("TrackingNumber", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Orders",
				BaseColumnName = "TrackingNumber"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[Orders]";
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public long CustomerID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CustomerID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CustomerID = value; }
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public string LastModifiedOn
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.LastModifiedOn; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.LastModifiedOn = value; }
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
		public long? PaymentType
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.PaymentType; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.PaymentType = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string SearchTerms
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.SearchTerms; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.SearchTerms = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipAddress
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipAddress; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipAddress = value; }
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipCountryCode
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipCountryCode; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipCountryCode = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipPhone
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipPhone; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipPhone = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipPostalCode
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipPostalCode; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipPostalCode = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipRegion
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipRegion; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipRegion = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public long? ShipVia
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ShipVia; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ShipVia = value; }
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public long Status
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Status; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Status = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string TrackingNumber
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.TrackingNumber; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.TrackingNumber = value; }
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
			this.InsertItem(index, new PriKey_Orders_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(PriKey_Orders_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public PriKey_Orders_Record NewRecord()
		{
			return new PriKey_Orders_Record();
		}

		protected override PriKey_Orders_Record InternalCreateExistingRecordObject(object[] columnvalues) => new PriKey_Orders_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 165, 61, 34, 228, 206, 113, 234, 53, 243, 45, 61, 40, 69, 155, 247, 244 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "A53D22E4CE71EA35F32D3D28459BF7F4"; }
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
			get { return _parameterschema; }
		}

		/// <summary>
		/// For internal use by Ventura only. Use SetExecSqlParams() instead.
		/// </summary>
		object[] IRecordsetBase.InputParameterValues
		{
			get { return _inputparametervalues; }
		}

		/// <summary>
		/// For internal use by Ventura only. Use Output property instead.
		/// </summary>
		object[] IRecordsetBase.OutputParameterValues
		{
			get { return null; }
		}

		public InputParamHolder InputParam
		{
			get { return _inputparamholder; }
		}

		public int MaxRows
		{
			get { return _maxrows; }
			set { _maxrows = value; }
		}

		public void SetExecSqlParams(long? OrderID)
		{
			_inputparametervalues[0] = OrderID;
		}

		public void ExecSql(long? OrderID)
		{
			_inputparametervalues[0] = OrderID;
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector, long? OrderID)
		{
			_inputparametervalues[0] = OrderID;
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(long? OrderID)
		{
			_inputparametervalues[0] = OrderID;
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector, long? OrderID)
		{
			_inputparametervalues[0] = OrderID;
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

		public class InputParamHolder
		{
			private object[] _values;

			public InputParamHolder(object[] values)
			{
				_values = values;
			}

			public long? OrderID
			{
				get { return (long?)_values[0]; }
				set { _values[0] = value; }
			}

		}

	}

	public sealed partial class PriKey_Orders_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__OrderID; private long _ori__OrderID; private bool _mod__OrderID;
		private long _cur__CustomerID; private long _ori__CustomerID; private bool _mod__CustomerID;
		private string _cur__DeliveredDate; private string _ori__DeliveredDate; private bool _mod__DeliveredDate;
		private string _cur__LastModifiedOn; private string _ori__LastModifiedOn; private bool _mod__LastModifiedOn;
		private string _cur__OrderDate; private string _ori__OrderDate; private bool _mod__OrderDate;
		private long? _cur__PaymentType; private long? _ori__PaymentType; private bool _mod__PaymentType;
		private string _cur__SearchTerms; private string _ori__SearchTerms; private bool _mod__SearchTerms;
		private string _cur__ShipAddress; private string _ori__ShipAddress; private bool _mod__ShipAddress;
		private string _cur__ShipCity; private string _ori__ShipCity; private bool _mod__ShipCity;
		private string _cur__ShipCountryCode; private string _ori__ShipCountryCode; private bool _mod__ShipCountryCode;
		private string _cur__ShipPhone; private string _ori__ShipPhone; private bool _mod__ShipPhone;
		private string _cur__ShipPostalCode; private string _ori__ShipPostalCode; private bool _mod__ShipPostalCode;
		private string _cur__ShipRegion; private string _ori__ShipRegion; private bool _mod__ShipRegion;
		private long? _cur__ShipVia; private long? _ori__ShipVia; private bool _mod__ShipVia;
		private string _cur__ShippedDate; private string _ori__ShippedDate; private bool _mod__ShippedDate;
		private long _cur__Status; private long _ori__Status; private bool _mod__Status;
		private string _cur__TrackingNumber; private string _ori__TrackingNumber; private bool _mod__TrackingNumber;


		public PriKey_Orders_Record()
		{
			_cur__OrderID = 0;
			_cur__CustomerID = 0;
			_cur__DeliveredDate = null;
			_cur__LastModifiedOn = "";
			_cur__OrderDate = "";
			_cur__PaymentType = null;
			_cur__SearchTerms = null;
			_cur__ShipAddress = null;
			_cur__ShipCity = null;
			_cur__ShipCountryCode = null;
			_cur__ShipPhone = null;
			_cur__ShipPostalCode = null;
			_cur__ShipRegion = null;
			_cur__ShipVia = null;
			_cur__ShippedDate = null;
			_cur__Status = 0;
			_cur__TrackingNumber = null;
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public PriKey_Orders_Record(object[] columnvalues)
		{
			_cur__OrderID = (long)columnvalues[0];
			_cur__CustomerID = (long)columnvalues[1];
			_cur__DeliveredDate = (string)columnvalues[2];
			_cur__LastModifiedOn = (string)columnvalues[3];
			_cur__OrderDate = (string)columnvalues[4];
			_cur__PaymentType = (long?)columnvalues[5];
			_cur__SearchTerms = (string)columnvalues[6];
			_cur__ShipAddress = (string)columnvalues[7];
			_cur__ShipCity = (string)columnvalues[8];
			_cur__ShipCountryCode = (string)columnvalues[9];
			_cur__ShipPhone = (string)columnvalues[10];
			_cur__ShipPostalCode = (string)columnvalues[11];
			_cur__ShipRegion = (string)columnvalues[12];
			_cur__ShipVia = (long?)columnvalues[13];
			_cur__ShippedDate = (string)columnvalues[14];
			_cur__Status = (long)columnvalues[15];
			_cur__TrackingNumber = (string)columnvalues[16];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
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
		public long? PaymentType
		{
			get { return _cur__PaymentType; }
			set
			{
				if (_started_with_dbvalues == false) _mod__PaymentType = true;
				if (_cur__PaymentType == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__PaymentType == false) { _ori__PaymentType = _cur__PaymentType; _mod__PaymentType = true; } // existing record and column is not modified
					else { if (value == _ori__PaymentType) { _ori__PaymentType = default(long?); _mod__PaymentType = false; } } // existing record and column is modified
				}
				_cur__PaymentType = value; OnPropertyChanged("PaymentType"); OnAfterPropertyChanged("PaymentType");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipAddress
		{
			get { return _cur__ShipAddress; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipAddress = true;
				if (_cur__ShipAddress == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipAddress == false) { _ori__ShipAddress = _cur__ShipAddress; _mod__ShipAddress = true; } // existing record and column is not modified
					else { if (value == _ori__ShipAddress) { _ori__ShipAddress = default(string); _mod__ShipAddress = false; } } // existing record and column is modified
				}
				_cur__ShipAddress = value; OnPropertyChanged("ShipAddress"); OnAfterPropertyChanged("ShipAddress");
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipCountryCode
		{
			get { return _cur__ShipCountryCode; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipCountryCode = true;
				if (_cur__ShipCountryCode == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipCountryCode == false) { _ori__ShipCountryCode = _cur__ShipCountryCode; _mod__ShipCountryCode = true; } // existing record and column is not modified
					else { if (value == _ori__ShipCountryCode) { _ori__ShipCountryCode = default(string); _mod__ShipCountryCode = false; } } // existing record and column is modified
				}
				_cur__ShipCountryCode = value; OnPropertyChanged("ShipCountryCode"); OnAfterPropertyChanged("ShipCountryCode");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipPhone
		{
			get { return _cur__ShipPhone; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipPhone = true;
				if (_cur__ShipPhone == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipPhone == false) { _ori__ShipPhone = _cur__ShipPhone; _mod__ShipPhone = true; } // existing record and column is not modified
					else { if (value == _ori__ShipPhone) { _ori__ShipPhone = default(string); _mod__ShipPhone = false; } } // existing record and column is modified
				}
				_cur__ShipPhone = value; OnPropertyChanged("ShipPhone"); OnAfterPropertyChanged("ShipPhone");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipPostalCode
		{
			get { return _cur__ShipPostalCode; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipPostalCode = true;
				if (_cur__ShipPostalCode == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipPostalCode == false) { _ori__ShipPostalCode = _cur__ShipPostalCode; _mod__ShipPostalCode = true; } // existing record and column is not modified
					else { if (value == _ori__ShipPostalCode) { _ori__ShipPostalCode = default(string); _mod__ShipPostalCode = false; } } // existing record and column is modified
				}
				_cur__ShipPostalCode = value; OnPropertyChanged("ShipPostalCode"); OnAfterPropertyChanged("ShipPostalCode");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string ShipRegion
		{
			get { return _cur__ShipRegion; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipRegion = true;
				if (_cur__ShipRegion == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipRegion == false) { _ori__ShipRegion = _cur__ShipRegion; _mod__ShipRegion = true; } // existing record and column is not modified
					else { if (value == _ori__ShipRegion) { _ori__ShipRegion = default(string); _mod__ShipRegion = false; } } // existing record and column is modified
				}
				_cur__ShipRegion = value; OnPropertyChanged("ShipRegion"); OnAfterPropertyChanged("ShipRegion");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public long? ShipVia
		{
			get { return _cur__ShipVia; }
			set
			{
				if (_started_with_dbvalues == false) _mod__ShipVia = true;
				if (_cur__ShipVia == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ShipVia == false) { _ori__ShipVia = _cur__ShipVia; _mod__ShipVia = true; } // existing record and column is not modified
					else { if (value == _ori__ShipVia) { _ori__ShipVia = default(long?); _mod__ShipVia = false; } } // existing record and column is modified
				}
				_cur__ShipVia = value; OnPropertyChanged("ShipVia"); OnAfterPropertyChanged("ShipVia");
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
		/// Database Column Updateable. Table [Orders]. NotReadonly. NotNull.
		/// </summary>
		public long Status
		{
			get { return _cur__Status; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Status = true;
				if (_cur__Status == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Status == false) { _ori__Status = _cur__Status; _mod__Status = true; } // existing record and column is not modified
					else { if (value == _ori__Status) { _ori__Status = default(long); _mod__Status = false; } } // existing record and column is modified
				}
				_cur__Status = value; OnPropertyChanged("Status"); OnAfterPropertyChanged("Status");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Orders]. NotReadonly. AllowNull.
		/// </summary>
		public string TrackingNumber
		{
			get { return _cur__TrackingNumber; }
			set
			{
				if (_started_with_dbvalues == false) _mod__TrackingNumber = true;
				if (_cur__TrackingNumber == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__TrackingNumber == false) { _ori__TrackingNumber = _cur__TrackingNumber; _mod__TrackingNumber = true; } // existing record and column is not modified
					else { if (value == _ori__TrackingNumber) { _ori__TrackingNumber = default(string); _mod__TrackingNumber = false; } } // existing record and column is modified
				}
				_cur__TrackingNumber = value; OnPropertyChanged("TrackingNumber"); OnAfterPropertyChanged("TrackingNumber");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "OrderID") return _mod__OrderID;
			if (column_name == "CustomerID") return _mod__CustomerID;
			if (column_name == "DeliveredDate") return _mod__DeliveredDate;
			if (column_name == "LastModifiedOn") return _mod__LastModifiedOn;
			if (column_name == "OrderDate") return _mod__OrderDate;
			if (column_name == "PaymentType") return _mod__PaymentType;
			if (column_name == "SearchTerms") return _mod__SearchTerms;
			if (column_name == "ShipAddress") return _mod__ShipAddress;
			if (column_name == "ShipCity") return _mod__ShipCity;
			if (column_name == "ShipCountryCode") return _mod__ShipCountryCode;
			if (column_name == "ShipPhone") return _mod__ShipPhone;
			if (column_name == "ShipPostalCode") return _mod__ShipPostalCode;
			if (column_name == "ShipRegion") return _mod__ShipRegion;
			if (column_name == "ShipVia") return _mod__ShipVia;
			if (column_name == "ShippedDate") return _mod__ShippedDate;
			if (column_name == "Status") return _mod__Status;
			if (column_name == "TrackingNumber") return _mod__TrackingNumber;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__OrderID == true) count++;
			if (_mod__CustomerID == true) count++;
			if (_mod__DeliveredDate == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__OrderDate == true) count++;
			if (_mod__PaymentType == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__ShipAddress == true) count++;
			if (_mod__ShipCity == true) count++;
			if (_mod__ShipCountryCode == true) count++;
			if (_mod__ShipPhone == true) count++;
			if (_mod__ShipPostalCode == true) count++;
			if (_mod__ShipRegion == true) count++;
			if (_mod__ShipVia == true) count++;
			if (_mod__ShippedDate == true) count++;
			if (_mod__Status == true) count++;
			if (_mod__TrackingNumber == true) count++;
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
			if (_mod__DeliveredDate == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__OrderDate == true) count++;
			if (_mod__PaymentType == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__ShipAddress == true) count++;
			if (_mod__ShipCity == true) count++;
			if (_mod__ShipCountryCode == true) count++;
			if (_mod__ShipPhone == true) count++;
			if (_mod__ShipPostalCode == true) count++;
			if (_mod__ShipRegion == true) count++;
			if (_mod__ShipVia == true) count++;
			if (_mod__ShippedDate == true) count++;
			if (_mod__Status == true) count++;
			if (_mod__TrackingNumber == true) count++;
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
				track_array.AppendDataValue(0, _cur__OrderID);
				track_array.AppendDataValue(1, _cur__CustomerID);
				if (_cur__DeliveredDate != null) track_array.AppendDataValue(2, _cur__DeliveredDate);
				track_array.AppendDataValue(3, _cur__LastModifiedOn);
				track_array.AppendDataValue(4, _cur__OrderDate);
				if (_cur__PaymentType != null) track_array.AppendDataValue(5, _cur__PaymentType);
				if (_cur__SearchTerms != null) track_array.AppendDataValue(6, _cur__SearchTerms);
				if (_cur__ShipAddress != null) track_array.AppendDataValue(7, _cur__ShipAddress);
				if (_cur__ShipCity != null) track_array.AppendDataValue(8, _cur__ShipCity);
				if (_cur__ShipCountryCode != null) track_array.AppendDataValue(9, _cur__ShipCountryCode);
				if (_cur__ShipPhone != null) track_array.AppendDataValue(10, _cur__ShipPhone);
				if (_cur__ShipPostalCode != null) track_array.AppendDataValue(11, _cur__ShipPostalCode);
				if (_cur__ShipRegion != null) track_array.AppendDataValue(12, _cur__ShipRegion);
				if (_cur__ShipVia != null) track_array.AppendDataValue(13, _cur__ShipVia);
				if (_cur__ShippedDate != null) track_array.AppendDataValue(14, _cur__ShippedDate);
				track_array.AppendDataValue(15, _cur__Status);
				if (_cur__TrackingNumber != null) track_array.AppendDataValue(16, _cur__TrackingNumber);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__OrderID) track_array.AppendDataValue(0, _cur__OrderID);
				}
				if (_mod__CustomerID) track_array.AppendDataValue(1, _cur__CustomerID);
				if (_mod__DeliveredDate) track_array.AppendDataValue(2, _cur__DeliveredDate);
				if (_mod__LastModifiedOn) track_array.AppendDataValue(3, _cur__LastModifiedOn);
				if (_mod__OrderDate) track_array.AppendDataValue(4, _cur__OrderDate);
				if (_mod__PaymentType) track_array.AppendDataValue(5, _cur__PaymentType);
				if (_mod__SearchTerms) track_array.AppendDataValue(6, _cur__SearchTerms);
				if (_mod__ShipAddress) track_array.AppendDataValue(7, _cur__ShipAddress);
				if (_mod__ShipCity) track_array.AppendDataValue(8, _cur__ShipCity);
				if (_mod__ShipCountryCode) track_array.AppendDataValue(9, _cur__ShipCountryCode);
				if (_mod__ShipPhone) track_array.AppendDataValue(10, _cur__ShipPhone);
				if (_mod__ShipPostalCode) track_array.AppendDataValue(11, _cur__ShipPostalCode);
				if (_mod__ShipRegion) track_array.AppendDataValue(12, _cur__ShipRegion);
				if (_mod__ShipVia) track_array.AppendDataValue(13, _cur__ShipVia);
				if (_mod__ShippedDate) track_array.AppendDataValue(14, _cur__ShippedDate);
				if (_mod__Status) track_array.AppendDataValue(15, _cur__Status);
				if (_mod__TrackingNumber) track_array.AppendDataValue(16, _cur__TrackingNumber);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__OrderID && _started_with_dbvalues) ? _ori__OrderID : _cur__OrderID);
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
				if (_mod__OrderID) _ori__OrderID = default(long);
				if (_mod__CustomerID) _ori__CustomerID = default(long);
				if (_mod__DeliveredDate) _ori__DeliveredDate = default(string);
				if (_mod__LastModifiedOn) _ori__LastModifiedOn = default(string);
				if (_mod__OrderDate) _ori__OrderDate = default(string);
				if (_mod__PaymentType) _ori__PaymentType = default(long?);
				if (_mod__SearchTerms) _ori__SearchTerms = default(string);
				if (_mod__ShipAddress) _ori__ShipAddress = default(string);
				if (_mod__ShipCity) _ori__ShipCity = default(string);
				if (_mod__ShipCountryCode) _ori__ShipCountryCode = default(string);
				if (_mod__ShipPhone) _ori__ShipPhone = default(string);
				if (_mod__ShipPostalCode) _ori__ShipPostalCode = default(string);
				if (_mod__ShipRegion) _ori__ShipRegion = default(string);
				if (_mod__ShipVia) _ori__ShipVia = default(long?);
				if (_mod__ShippedDate) _ori__ShippedDate = default(string);
				if (_mod__Status) _ori__Status = default(long);
				if (_mod__TrackingNumber) _ori__TrackingNumber = default(string);
			}
			_mod__OrderID = false;
			_mod__CustomerID = false;
			_mod__DeliveredDate = false;
			_mod__LastModifiedOn = false;
			_mod__OrderDate = false;
			_mod__PaymentType = false;
			_mod__SearchTerms = false;
			_mod__ShipAddress = false;
			_mod__ShipCity = false;
			_mod__ShipCountryCode = false;
			_mod__ShipPhone = false;
			_mod__ShipPostalCode = false;
			_mod__ShipRegion = false;
			_mod__ShipVia = false;
			_mod__ShippedDate = false;
			_mod__Status = false;
			_mod__TrackingNumber = false;
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
	public partial class PriKey_Orders_Record
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
