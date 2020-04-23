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
	/// The updateable table is [OrderItems]. Updateable table column information:
	/// • 7 out of 7 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: OrderID and OrderLine.
	/// • Non-primary key columns present in the resultset: Discount, ProductID, Quantity, TaxType and UnitPrice.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class PriKey_OrderItems_Recordset : ResultsetObservable<PriKey_OrderItems_Recordset, PriKey_OrderItems_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private object[] _inputparametervalues;
		private InputParamHolder _inputparamholder;
		private VenturaSchema _parameterschema;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public PriKey_OrderItems_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [OrderID],[OrderLine],[Discount],[ProductID],[Quantity],[TaxType],[UnitPrice]" + CRLF +
			             @"FROM [OrderItems]" + CRLF +
			             @"WHERE [OrderID] = @OrderID" + CRLF +
			             @"AND [OrderLine] = @OrderLine";

			_inputparametervalues = new object[2];
			_inputparamholder = new InputParamHolder(_inputparametervalues);

			ColumnArrayBuilder param_array = new ColumnArrayBuilder();

			param_array.AddParameterColumn("@OrderID", typeof(long), true, false, DbType.Int64, null, null, null);
			param_array.AddParameterColumn("@OrderLine", typeof(long), true, false, DbType.Int64, null, null, null);

			_parameterschema = new VenturaSchema(param_array);

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("OrderID", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "OrderID"
			});

			schema_array.Add(new VenturaColumn("OrderLine", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "OrderLine"
			});

			schema_array.Add(new VenturaColumn("Discount", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "Discount"
			});

			schema_array.Add(new VenturaColumn("ProductID", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "ProductID"
			});

			schema_array.Add(new VenturaColumn("Quantity", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "Quantity"
			});

			schema_array.Add(new VenturaColumn("TaxType", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "TaxType"
			});

			schema_array.Add(new VenturaColumn("UnitPrice", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderItems",
				BaseColumnName = "UnitPrice"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[OrderItems]";
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long OrderID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.OrderID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.OrderID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long OrderLine
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.OrderLine; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.OrderLine = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string Discount
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Discount; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Discount = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string ProductID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ProductID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ProductID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public long Quantity
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Quantity; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Quantity = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public long TaxType
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.TaxType; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.TaxType = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string UnitPrice
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.UnitPrice; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.UnitPrice = value; }
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
			this.InsertItem(index, new PriKey_OrderItems_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(PriKey_OrderItems_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public PriKey_OrderItems_Record NewRecord()
		{
			return new PriKey_OrderItems_Record();
		}

		protected override PriKey_OrderItems_Record InternalCreateExistingRecordObject(object[] columnvalues) => new PriKey_OrderItems_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 49, 167, 92, 122, 1, 195, 206, 140, 97, 20, 23, 214, 174, 79, 227, 151 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "31A75C7A01C3CE8C611417D6AE4FE397"; }
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

		public void SetExecSqlParams(long? OrderID, long? OrderLine)
		{
			_inputparametervalues[0] = OrderID;
			_inputparametervalues[1] = OrderLine;
		}

		public void ExecSql(long? OrderID, long? OrderLine)
		{
			_inputparametervalues[0] = OrderID;
			_inputparametervalues[1] = OrderLine;
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector, long? OrderID, long? OrderLine)
		{
			_inputparametervalues[0] = OrderID;
			_inputparametervalues[1] = OrderLine;
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(long? OrderID, long? OrderLine)
		{
			_inputparametervalues[0] = OrderID;
			_inputparametervalues[1] = OrderLine;
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector, long? OrderID, long? OrderLine)
		{
			_inputparametervalues[0] = OrderID;
			_inputparametervalues[1] = OrderLine;
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

			public long? OrderLine
			{
				get { return (long?)_values[1]; }
				set { _values[1] = value; }
			}

		}

	}

	public sealed partial class PriKey_OrderItems_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__OrderID; private long _ori__OrderID; private bool _mod__OrderID;
		private long _cur__OrderLine; private long _ori__OrderLine; private bool _mod__OrderLine;
		private string _cur__Discount; private string _ori__Discount; private bool _mod__Discount;
		private string _cur__ProductID; private string _ori__ProductID; private bool _mod__ProductID;
		private long _cur__Quantity; private long _ori__Quantity; private bool _mod__Quantity;
		private long _cur__TaxType; private long _ori__TaxType; private bool _mod__TaxType;
		private string _cur__UnitPrice; private string _ori__UnitPrice; private bool _mod__UnitPrice;


		public PriKey_OrderItems_Record()
		{
			_cur__OrderID = 0;
			_cur__OrderLine = 0;
			_cur__Discount = "";
			_cur__ProductID = "";
			_cur__Quantity = 0;
			_cur__TaxType = 0;
			_cur__UnitPrice = "";
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public PriKey_OrderItems_Record(object[] columnvalues)
		{
			_cur__OrderID = (long)columnvalues[0];
			_cur__OrderLine = (long)columnvalues[1];
			_cur__Discount = (string)columnvalues[2];
			_cur__ProductID = (string)columnvalues[3];
			_cur__Quantity = (long)columnvalues[4];
			_cur__TaxType = (long)columnvalues[5];
			_cur__UnitPrice = (string)columnvalues[6];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. PrimaryKey. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [OrderItems]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long OrderLine
		{
			get { return _cur__OrderLine; }
			set
			{
				if (_started_with_dbvalues == false) _mod__OrderLine = true;
				if (_cur__OrderLine == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__OrderLine == false) { _ori__OrderLine = _cur__OrderLine; _mod__OrderLine = true; } // existing record and column is not modified
					else { if (value == _ori__OrderLine) { _ori__OrderLine = default(long); _mod__OrderLine = false; } } // existing record and column is modified
				}
				_cur__OrderLine = value; OnPropertyChanged("OrderLine"); OnAfterPropertyChanged("OrderLine");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string Discount
		{
			get { return _cur__Discount; }
			set
			{
				if (value == null) throw new ArgumentNullException("Discount", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__Discount = true;
				if (_cur__Discount == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Discount == false) { _ori__Discount = _cur__Discount; _mod__Discount = true; } // existing record and column is not modified
					else { if (value == _ori__Discount) { _ori__Discount = default(string); _mod__Discount = false; } } // existing record and column is modified
				}
				_cur__Discount = value; OnPropertyChanged("Discount"); OnAfterPropertyChanged("Discount");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string ProductID
		{
			get { return _cur__ProductID; }
			set
			{
				if (value == null) throw new ArgumentNullException("ProductID", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__ProductID = true;
				if (_cur__ProductID == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ProductID == false) { _ori__ProductID = _cur__ProductID; _mod__ProductID = true; } // existing record and column is not modified
					else { if (value == _ori__ProductID) { _ori__ProductID = default(string); _mod__ProductID = false; } } // existing record and column is modified
				}
				_cur__ProductID = value; OnPropertyChanged("ProductID"); OnAfterPropertyChanged("ProductID");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public long Quantity
		{
			get { return _cur__Quantity; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Quantity = true;
				if (_cur__Quantity == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Quantity == false) { _ori__Quantity = _cur__Quantity; _mod__Quantity = true; } // existing record and column is not modified
					else { if (value == _ori__Quantity) { _ori__Quantity = default(long); _mod__Quantity = false; } } // existing record and column is modified
				}
				_cur__Quantity = value; OnPropertyChanged("Quantity"); OnAfterPropertyChanged("Quantity");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public long TaxType
		{
			get { return _cur__TaxType; }
			set
			{
				if (_started_with_dbvalues == false) _mod__TaxType = true;
				if (_cur__TaxType == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__TaxType == false) { _ori__TaxType = _cur__TaxType; _mod__TaxType = true; } // existing record and column is not modified
					else { if (value == _ori__TaxType) { _ori__TaxType = default(long); _mod__TaxType = false; } } // existing record and column is modified
				}
				_cur__TaxType = value; OnPropertyChanged("TaxType"); OnAfterPropertyChanged("TaxType");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderItems]. NotReadonly. NotNull.
		/// </summary>
		public string UnitPrice
		{
			get { return _cur__UnitPrice; }
			set
			{
				if (value == null) throw new ArgumentNullException("UnitPrice", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__UnitPrice = true;
				if (_cur__UnitPrice == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__UnitPrice == false) { _ori__UnitPrice = _cur__UnitPrice; _mod__UnitPrice = true; } // existing record and column is not modified
					else { if (value == _ori__UnitPrice) { _ori__UnitPrice = default(string); _mod__UnitPrice = false; } } // existing record and column is modified
				}
				_cur__UnitPrice = value; OnPropertyChanged("UnitPrice"); OnAfterPropertyChanged("UnitPrice");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "OrderID") return _mod__OrderID;
			if (column_name == "OrderLine") return _mod__OrderLine;
			if (column_name == "Discount") return _mod__Discount;
			if (column_name == "ProductID") return _mod__ProductID;
			if (column_name == "Quantity") return _mod__Quantity;
			if (column_name == "TaxType") return _mod__TaxType;
			if (column_name == "UnitPrice") return _mod__UnitPrice;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__OrderID == true) count++;
			if (_mod__OrderLine == true) count++;
			if (_mod__Discount == true) count++;
			if (_mod__ProductID == true) count++;
			if (_mod__Quantity == true) count++;
			if (_mod__TaxType == true) count++;
			if (_mod__UnitPrice == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__OrderID) count++;
				if (_mod__OrderLine) count++;
			}
			if (_mod__Discount == true) count++;
			if (_mod__ProductID == true) count++;
			if (_mod__Quantity == true) count++;
			if (_mod__TaxType == true) count++;
			if (_mod__UnitPrice == true) count++;
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
			if (_mod__OrderLine == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "OrderLine"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__OrderID);
				track_array.AppendDataValue(1, _cur__OrderLine);
				track_array.AppendDataValue(2, _cur__Discount);
				track_array.AppendDataValue(3, _cur__ProductID);
				track_array.AppendDataValue(4, _cur__Quantity);
				track_array.AppendDataValue(5, _cur__TaxType);
				track_array.AppendDataValue(6, _cur__UnitPrice);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__OrderID) track_array.AppendDataValue(0, _cur__OrderID);
					if (_mod__OrderLine) track_array.AppendDataValue(1, _cur__OrderLine);
				}
				if (_mod__Discount) track_array.AppendDataValue(2, _cur__Discount);
				if (_mod__ProductID) track_array.AppendDataValue(3, _cur__ProductID);
				if (_mod__Quantity) track_array.AppendDataValue(4, _cur__Quantity);
				if (_mod__TaxType) track_array.AppendDataValue(5, _cur__TaxType);
				if (_mod__UnitPrice) track_array.AppendDataValue(6, _cur__UnitPrice);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__OrderID && _started_with_dbvalues) ? _ori__OrderID : _cur__OrderID);
				track_array.AppendPrikeyValue(1, (_mod__OrderLine && _started_with_dbvalues) ? _ori__OrderLine : _cur__OrderLine);
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
				if (_mod__OrderLine) _ori__OrderLine = default(long);
				if (_mod__Discount) _ori__Discount = default(string);
				if (_mod__ProductID) _ori__ProductID = default(string);
				if (_mod__Quantity) _ori__Quantity = default(long);
				if (_mod__TaxType) _ori__TaxType = default(long);
				if (_mod__UnitPrice) _ori__UnitPrice = default(string);
			}
			_mod__OrderID = false;
			_mod__OrderLine = false;
			_mod__Discount = false;
			_mod__ProductID = false;
			_mod__Quantity = false;
			_mod__TaxType = false;
			_mod__UnitPrice = false;
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
	public partial class PriKey_OrderItems_Record
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
