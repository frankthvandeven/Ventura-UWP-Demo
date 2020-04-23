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
	/// The updateable table is [TaxTypes]. Updateable table column information:
	/// • 3 out of 3 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: TaxTypeID.
	/// • Non-primary key columns present in the resultset: Name and Rate.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class PriKey_TaxTypes_Recordset : ResultsetObservable<PriKey_TaxTypes_Recordset, PriKey_TaxTypes_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private object[] _inputparametervalues;
		private InputParamHolder _inputparamholder;
		private VenturaSchema _parameterschema;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public PriKey_TaxTypes_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [TaxTypeID],[Name],[Rate]" + CRLF +
			             @"FROM [TaxTypes]" + CRLF +
			             @"WHERE [TaxTypeID] = @TaxTypeID";

			_inputparametervalues = new object[1];
			_inputparamholder = new InputParamHolder(_inputparametervalues);

			ColumnArrayBuilder param_array = new ColumnArrayBuilder();

			param_array.AddParameterColumn("@TaxTypeID", typeof(long), true, false, DbType.Int64, null, null, null);

			_parameterschema = new VenturaSchema(param_array);

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("TaxTypeID", typeof(long), false)
			{
				Updateable = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "TaxTypes",
				BaseColumnName = "TaxTypeID"
			});

			schema_array.Add(new VenturaColumn("Name", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "TaxTypes",
				BaseColumnName = "Name"
			});

			schema_array.Add(new VenturaColumn("Rate", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "TaxTypes",
				BaseColumnName = "Rate"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[TaxTypes]";
		}

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long TaxTypeID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.TaxTypeID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.TaxTypeID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. NotReadonly. NotNull.
		/// </summary>
		public string Name
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Name; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Name = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. NotReadonly. NotNull.
		/// </summary>
		public string Rate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Rate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Rate = value; }
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
			this.InsertItem(index, new PriKey_TaxTypes_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(PriKey_TaxTypes_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public PriKey_TaxTypes_Record NewRecord()
		{
			return new PriKey_TaxTypes_Record();
		}

		protected override PriKey_TaxTypes_Record InternalCreateExistingRecordObject(object[] columnvalues) => new PriKey_TaxTypes_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 12, 67, 103, 91, 1, 90, 165, 171, 180, 197, 240, 99, 77, 37, 223, 35 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "0C43675B015AA5ABB4C5F0634D25DF23"; }
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

		public void SetExecSqlParams(long? TaxTypeID)
		{
			_inputparametervalues[0] = TaxTypeID;
		}

		public void ExecSql(long? TaxTypeID)
		{
			_inputparametervalues[0] = TaxTypeID;
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector, long? TaxTypeID)
		{
			_inputparametervalues[0] = TaxTypeID;
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(long? TaxTypeID)
		{
			_inputparametervalues[0] = TaxTypeID;
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector, long? TaxTypeID)
		{
			_inputparametervalues[0] = TaxTypeID;
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

			public long? TaxTypeID
			{
				get { return (long?)_values[0]; }
				set { _values[0] = value; }
			}

		}

	}

	public sealed partial class PriKey_TaxTypes_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private long _cur__TaxTypeID; private long _ori__TaxTypeID; private bool _mod__TaxTypeID;
		private string _cur__Name; private string _ori__Name; private bool _mod__Name;
		private string _cur__Rate; private string _ori__Rate; private bool _mod__Rate;


		public PriKey_TaxTypes_Record()
		{
			_cur__TaxTypeID = 0;
			_cur__Name = "";
			_cur__Rate = "";
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public PriKey_TaxTypes_Record(object[] columnvalues)
		{
			_cur__TaxTypeID = (long)columnvalues[0];
			_cur__Name = (string)columnvalues[1];
			_cur__Rate = (string)columnvalues[2];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public long TaxTypeID
		{
			get { return _cur__TaxTypeID; }
			set
			{
				if (_started_with_dbvalues == false) _mod__TaxTypeID = true;
				if (_cur__TaxTypeID == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__TaxTypeID == false) { _ori__TaxTypeID = _cur__TaxTypeID; _mod__TaxTypeID = true; } // existing record and column is not modified
					else { if (value == _ori__TaxTypeID) { _ori__TaxTypeID = default(long); _mod__TaxTypeID = false; } } // existing record and column is modified
				}
				_cur__TaxTypeID = value; OnPropertyChanged("TaxTypeID"); OnAfterPropertyChanged("TaxTypeID");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. NotReadonly. NotNull.
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

		/// <summary>
		/// Database Column Updateable. Table [TaxTypes]. NotReadonly. NotNull.
		/// </summary>
		public string Rate
		{
			get { return _cur__Rate; }
			set
			{
				if (value == null) throw new ArgumentNullException("Rate", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__Rate = true;
				if (_cur__Rate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Rate == false) { _ori__Rate = _cur__Rate; _mod__Rate = true; } // existing record and column is not modified
					else { if (value == _ori__Rate) { _ori__Rate = default(string); _mod__Rate = false; } } // existing record and column is modified
				}
				_cur__Rate = value; OnPropertyChanged("Rate"); OnAfterPropertyChanged("Rate");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "TaxTypeID") return _mod__TaxTypeID;
			if (column_name == "Name") return _mod__Name;
			if (column_name == "Rate") return _mod__Rate;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__TaxTypeID == true) count++;
			if (_mod__Name == true) count++;
			if (_mod__Rate == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__TaxTypeID) count++;
			}
			if (_mod__Name == true) count++;
			if (_mod__Rate == true) count++;
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
			if (_mod__TaxTypeID == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "TaxTypeID"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__TaxTypeID);
				track_array.AppendDataValue(1, _cur__Name);
				track_array.AppendDataValue(2, _cur__Rate);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__TaxTypeID) track_array.AppendDataValue(0, _cur__TaxTypeID);
				}
				if (_mod__Name) track_array.AppendDataValue(1, _cur__Name);
				if (_mod__Rate) track_array.AppendDataValue(2, _cur__Rate);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__TaxTypeID && _started_with_dbvalues) ? _ori__TaxTypeID : _cur__TaxTypeID);
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
				if (_mod__TaxTypeID) _ori__TaxTypeID = default(long);
				if (_mod__Name) _ori__Name = default(string);
				if (_mod__Rate) _ori__Rate = default(string);
			}
			_mod__TaxTypeID = false;
			_mod__Name = false;
			_mod__Rate = false;
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
	public partial class PriKey_TaxTypes_Record
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
