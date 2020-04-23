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
	/// The updateable table is [OrderStatus]. Updateable table column information:
	/// • 2 out of 2 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: Status.
	/// • Non-primary key column present in the resultset: Name.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class PriKey_OrderStatus_Recordset : ResultsetObservable<PriKey_OrderStatus_Recordset, PriKey_OrderStatus_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private object[] _inputparametervalues;
		private InputParamHolder _inputparamholder;
		private VenturaSchema _parameterschema;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public PriKey_OrderStatus_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [Status],[Name]" + CRLF +
			             @"FROM [OrderStatus]" + CRLF +
			             @"WHERE [Status] = @Status";

			_inputparametervalues = new object[1];
			_inputparamholder = new InputParamHolder(_inputparametervalues);

			ColumnArrayBuilder param_array = new ColumnArrayBuilder();

			param_array.AddParameterColumn("@Status", typeof(long), true, false, DbType.Int64, null, null, null);

			_parameterschema = new VenturaSchema(param_array);

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("Status", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderStatus",
				BaseColumnName = "Status"
			});

			schema_array.Add(new VenturaColumn("Name", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "OrderStatus",
				BaseColumnName = "Name"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[OrderStatus]";
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderStatus]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long Status
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Status; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Status = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderStatus]. NotReadonly. NotNull.
		/// </summary>
		public string Name
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Name; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Name = value; }
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
			this.InsertItem(index, new PriKey_OrderStatus_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(PriKey_OrderStatus_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public PriKey_OrderStatus_Record NewRecord()
		{
			return new PriKey_OrderStatus_Record();
		}

		protected override PriKey_OrderStatus_Record InternalCreateExistingRecordObject(object[] columnvalues) => new PriKey_OrderStatus_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 37, 134, 204, 243, 161, 153, 195, 154, 244, 177, 65, 220, 251, 227, 216, 228 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "2586CCF3A199C39AF4B141DCFBE3D8E4"; }
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

		public void SetExecSqlParams(long? Status)
		{
			_inputparametervalues[0] = Status;
		}

		public void ExecSql(long? Status)
		{
			_inputparametervalues[0] = Status;
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector, long? Status)
		{
			_inputparametervalues[0] = Status;
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(long? Status)
		{
			_inputparametervalues[0] = Status;
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector, long? Status)
		{
			_inputparametervalues[0] = Status;
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

			public long? Status
			{
				get { return (long?)_values[0]; }
				set { _values[0] = value; }
			}

		}

	}

	public sealed partial class PriKey_OrderStatus_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__Status; private long _ori__Status; private bool _mod__Status;
		private string _cur__Name; private string _ori__Name; private bool _mod__Name;


		public PriKey_OrderStatus_Record()
		{
			_cur__Status = 0;
			_cur__Name = "";
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public PriKey_OrderStatus_Record(object[] columnvalues)
		{
			_cur__Status = (long)columnvalues[0];
			_cur__Name = (string)columnvalues[1];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [OrderStatus]. PrimaryKey. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [OrderStatus]. NotReadonly. NotNull.
		/// </summary>
		public string Name
		{
			get { return _cur__Name; }
			set
			{
				if (value == null) throw new ArgumentNullException("Name", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__Name = true;
				if (_cur__Name == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Name == false) { _ori__Name = _cur__Name; _mod__Name = true; } // existing record and column is not modified
					else { if (value == _ori__Name) { _ori__Name = default(string); _mod__Name = false; } } // existing record and column is modified
				}
				_cur__Name = value; OnPropertyChanged("Name"); OnAfterPropertyChanged("Name");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "Status") return _mod__Status;
			if (column_name == "Name") return _mod__Name;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__Status == true) count++;
			if (_mod__Name == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__Status) count++;
			}
			if (_mod__Name == true) count++;
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
			if (_mod__Status == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "Status"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__Status);
				track_array.AppendDataValue(1, _cur__Name);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__Status) track_array.AppendDataValue(0, _cur__Status);
				}
				if (_mod__Name) track_array.AppendDataValue(1, _cur__Name);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__Status && _started_with_dbvalues) ? _ori__Status : _cur__Status);
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
				if (_mod__Status) _ori__Status = default(long);
				if (_mod__Name) _ori__Name = default(string);
			}
			_mod__Status = false;
			_mod__Name = false;
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
	public partial class PriKey_OrderStatus_Record
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
