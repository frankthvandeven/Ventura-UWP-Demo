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
	/// The updateable table is [DbVersion]. Updateable table column information:
	/// • 1 out of 1 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: Version.
	/// • Apart from the primary key column, there are no table columns present in the resultset.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class GetAll_DbVersion_Recordset : ResultsetObservable<GetAll_DbVersion_Recordset, GetAll_DbVersion_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public GetAll_DbVersion_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [Version]" + CRLF +
			             @"FROM [DbVersion]";

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("Version", typeof(string), false)
			{
				Updateable = true,
				IsUnique = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "DbVersion",
				BaseColumnName = "Version"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[DbVersion]";
		}

		/// <summary>
		/// Database Column Updateable. Table [DbVersion]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public string Version
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Version; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Version = value; }
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
			this.InsertItem(index, new GetAll_DbVersion_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(GetAll_DbVersion_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public GetAll_DbVersion_Record NewRecord()
		{
			return new GetAll_DbVersion_Record();
		}

		protected override GetAll_DbVersion_Record InternalCreateExistingRecordObject(object[] columnvalues) => new GetAll_DbVersion_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 251, 42, 232, 3, 187, 251, 240, 201, 35, 15, 188, 198, 188, 20, 57, 2 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "FB2AE803BBFBF0C9230FBCC6BC143902"; }
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

	public sealed partial class GetAll_DbVersion_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private string _cur__Version; private string _ori__Version; private bool _mod__Version;


		public GetAll_DbVersion_Record()
		{
			_cur__Version = "";
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public GetAll_DbVersion_Record(object[] columnvalues)
		{
			_cur__Version = (string)columnvalues[0];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [DbVersion]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public string Version
		{
			get { return _cur__Version; }
			set
			{
				if (value == null) throw new ArgumentNullException("Version", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__Version = true;
				if (_cur__Version == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Version == false) { _ori__Version = _cur__Version; _mod__Version = true; } // existing record and column is not modified
					else { if (value == _ori__Version) { _ori__Version = default(string); _mod__Version = false; } } // existing record and column is modified
				}
				_cur__Version = value; OnPropertyChanged("Version"); OnAfterPropertyChanged("Version");
			}
		}

		public bool IsModified(string column_name)
		{
			if (column_name == "Version") return _mod__Version;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__Version == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__Version) count++;
			}
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
			if (_mod__Version == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "Version"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__Version);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__Version) track_array.AppendDataValue(0, _cur__Version);
				}
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__Version && _started_with_dbvalues) ? _ori__Version : _cur__Version);
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
				if (_mod__Version) _ori__Version = default(string);
			}
			_mod__Version = false;
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
	public partial class GetAll_DbVersion_Record
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
