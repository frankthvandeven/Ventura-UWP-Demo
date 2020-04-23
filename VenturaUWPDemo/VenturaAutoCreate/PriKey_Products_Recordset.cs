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
	/// The updateable table is [Products]. Updateable table column information:
	/// • 19 out of 19 table columns are present in the resultset.
	/// • All primary key columns are present in the resultset: ProductID.
	/// • Non-primary key columns present in the resultset: CategoryID, Color, CreatedOn, DealerPrice, Description, Discount,
	///   DiscountEndDate, DiscountStartDate, LastModifiedOn, ListPrice, Name, Picture, SafetyStockLevel, SearchTerms, Size,
	///   StockUnits, TaxType and Thumbnail.
	/// Recordset item automatically created by Ventura SQL Studio.
	/// </summary>
	public partial class PriKey_Products_Recordset : ResultsetObservable<PriKey_Products_Recordset, PriKey_Products_Record>, IRecordsetBase
	{
		private IResultsetBase[] _resultsets;
		private string _sqlscript;
		private object[] _inputparametervalues;
		private InputParamHolder _inputparamholder;
		private VenturaSchema _parameterschema;
		private int _maxrows = 500;
		private const string CRLF = "\r\n";

		public PriKey_Products_Recordset()
		{
			_resultsets = new IResultsetBase[] { this };

			_sqlscript = @"SELECT [ProductID],[CategoryID],[Color],[CreatedOn],[DealerPrice],[Description],[Discount],[DiscountEndDate],[DiscountStartDate],[LastModifiedOn],[ListPrice]," + CRLF +
			             @"[Name],[Picture],[SafetyStockLevel],[SearchTerms],[Size],[StockUnits],[TaxType],[Thumbnail]" + CRLF +
			             @"FROM [Products]" + CRLF +
			             @"WHERE [ProductID] = @ProductID";

			_inputparametervalues = new object[1];
			_inputparamholder = new InputParamHolder(_inputparametervalues);

			ColumnArrayBuilder param_array = new ColumnArrayBuilder();

			param_array.AddParameterColumn("@ProductID", typeof(string), true, false, DbType.String, null, null, null);

			_parameterschema = new VenturaSchema(param_array);

			ColumnArrayBuilder schema_array = new ColumnArrayBuilder();

			schema_array.Add(new VenturaColumn("ProductID", typeof(string), false)
			{
				Updateable = true,
				IsUnique = true,
				IsKey = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "ProductID"
			});

			schema_array.Add(new VenturaColumn("CategoryID", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "CategoryID"
			});

			schema_array.Add(new VenturaColumn("Color", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Color"
			});

			schema_array.Add(new VenturaColumn("CreatedOn", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "CreatedOn"
			});

			schema_array.Add(new VenturaColumn("DealerPrice", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "DealerPrice"
			});

			schema_array.Add(new VenturaColumn("Description", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Description"
			});

			schema_array.Add(new VenturaColumn("Discount", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Discount"
			});

			schema_array.Add(new VenturaColumn("DiscountEndDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "DiscountEndDate"
			});

			schema_array.Add(new VenturaColumn("DiscountStartDate", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "DiscountStartDate"
			});

			schema_array.Add(new VenturaColumn("LastModifiedOn", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "LastModifiedOn"
			});

			schema_array.Add(new VenturaColumn("ListPrice", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "ListPrice"
			});

			schema_array.Add(new VenturaColumn("Name", typeof(string), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Name"
			});

			schema_array.Add(new VenturaColumn("Picture", typeof(object), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Picture"
			});

			schema_array.Add(new VenturaColumn("SafetyStockLevel", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "SafetyStockLevel"
			});

			schema_array.Add(new VenturaColumn("SearchTerms", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "SearchTerms"
			});

			schema_array.Add(new VenturaColumn("Size", typeof(string), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Size"
			});

			schema_array.Add(new VenturaColumn("StockUnits", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "StockUnits"
			});

			schema_array.Add(new VenturaColumn("TaxType", typeof(long), false)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "TaxType"
			});

			schema_array.Add(new VenturaColumn("Thumbnail", typeof(object), true)
			{
				Updateable = true,
				BaseCatalogName = "main",
				BaseTableName = "Products",
				BaseColumnName = "Thumbnail"
			});

			((IResultsetBase)this).Schema = new VenturaSchema(schema_array);
			((IResultsetBase)this).UpdateableTablename = "[Products]";
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. PrimaryKey. NotReadonly. NotNull.
		/// </summary>
		public string ProductID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ProductID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ProductID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long CategoryID
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CategoryID; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CategoryID = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Color
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Color; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Color = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string CreatedOn
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.CreatedOn; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.CreatedOn = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string DealerPrice
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.DealerPrice; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.DealerPrice = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Description
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Description; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Description = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string Discount
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Discount; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Discount = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string DiscountEndDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.DiscountEndDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.DiscountEndDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string DiscountStartDate
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.DiscountStartDate; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.DiscountStartDate = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string LastModifiedOn
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.LastModifiedOn; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.LastModifiedOn = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string ListPrice
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.ListPrice; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.ListPrice = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string Name
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Name; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Name = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public object Picture
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Picture; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Picture = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long SafetyStockLevel
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.SafetyStockLevel; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.SafetyStockLevel = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string SearchTerms
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.SearchTerms; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.SearchTerms = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Size
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Size; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Size = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long StockUnits
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.StockUnits; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.StockUnits = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long TaxType
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.TaxType; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.TaxType = value; }
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public object Thumbnail
		{
			get { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); return CurrentRecord.Thumbnail; }
			set { if (CurrentRecord == null) throw new InvalidOperationException(VenturaStrings.CURRENT_RECORD_NOT_SET); CurrentRecord.Thumbnail = value; }
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
			this.InsertItem(index, new PriKey_Products_Record());
			this.CurrentRecordIndex = index;
		}

		public void Append(PriKey_Products_Record record)
		{
			int index = this.RecordCount;
			this.InsertItem(index, record);
			this.CurrentRecordIndex = index;
		}

		public PriKey_Products_Record NewRecord()
		{
			return new PriKey_Products_Record();
		}

		protected override PriKey_Products_Record InternalCreateExistingRecordObject(object[] columnvalues) => new PriKey_Products_Record(columnvalues);

		byte[] IRecordsetBase.Hash
		{
			get { return new byte[] { 107, 97, 14, 87, 42, 139, 10, 215, 102, 93, 37, 92, 223, 108, 49, 153 }; }
		}

		string IRecordsetBase.HashString
		{
			get { return "6B610E572A8B0AD7665D255CDF6C3199"; }
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

		public void SetExecSqlParams(string ProductID)
		{
			_inputparametervalues[0] = ProductID;
		}

		public void ExecSql(string ProductID)
		{
			_inputparametervalues[0] = ProductID;
			Transactional.ExecSql(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public void ExecSql(Connector connector, string ProductID)
		{
			_inputparametervalues[0] = ProductID;
			Transactional.ExecSql(connector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(string ProductID)
		{
			_inputparametervalues[0] = ProductID;
			await Transactional.ExecSqlAsync(VenturaConfig.DefaultConnector, new IRecordsetBase[] { this });
		}

		public async Task ExecSqlAsync(Connector connector, string ProductID)
		{
			_inputparametervalues[0] = ProductID;
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

			public string ProductID
			{
				get { return (string)_values[0]; }
				set { _values[0] = value; }
			}

		}

	}

	public sealed partial class PriKey_Products_Record : IRecordBase, INotifyPropertyChanged
	{
		private DataRecordStatus _recordstatus;
		private bool _started_with_dbvalues;

		private string _cur__ProductID; private string _ori__ProductID; private bool _mod__ProductID;
		private long _cur__CategoryID; private long _ori__CategoryID; private bool _mod__CategoryID;
		private string _cur__Color; private string _ori__Color; private bool _mod__Color;
		private string _cur__CreatedOn; private string _ori__CreatedOn; private bool _mod__CreatedOn;
		private string _cur__DealerPrice; private string _ori__DealerPrice; private bool _mod__DealerPrice;
		private string _cur__Description; private string _ori__Description; private bool _mod__Description;
		private string _cur__Discount; private string _ori__Discount; private bool _mod__Discount;
		private string _cur__DiscountEndDate; private string _ori__DiscountEndDate; private bool _mod__DiscountEndDate;
		private string _cur__DiscountStartDate; private string _ori__DiscountStartDate; private bool _mod__DiscountStartDate;
		private string _cur__LastModifiedOn; private string _ori__LastModifiedOn; private bool _mod__LastModifiedOn;
		private string _cur__ListPrice; private string _ori__ListPrice; private bool _mod__ListPrice;
		private string _cur__Name; private string _ori__Name; private bool _mod__Name;
		private object _cur__Picture; private object _ori__Picture; private bool _mod__Picture;
		private long _cur__SafetyStockLevel; private long _ori__SafetyStockLevel; private bool _mod__SafetyStockLevel;
		private string _cur__SearchTerms; private string _ori__SearchTerms; private bool _mod__SearchTerms;
		private string _cur__Size; private string _ori__Size; private bool _mod__Size;
		private long _cur__StockUnits; private long _ori__StockUnits; private bool _mod__StockUnits;
		private long _cur__TaxType; private long _ori__TaxType; private bool _mod__TaxType;
		private object _cur__Thumbnail; private object _ori__Thumbnail; private bool _mod__Thumbnail;


		public PriKey_Products_Record()
		{
			_cur__ProductID = "";
			_cur__CategoryID = 0;
			_cur__Color = null;
			_cur__CreatedOn = "";
			_cur__DealerPrice = "";
			_cur__Description = null;
			_cur__Discount = "";
			_cur__DiscountEndDate = null;
			_cur__DiscountStartDate = null;
			_cur__LastModifiedOn = "";
			_cur__ListPrice = "";
			_cur__Name = "";
			_cur__Picture = null;
			_cur__SafetyStockLevel = 0;
			_cur__SearchTerms = null;
			_cur__Size = null;
			_cur__StockUnits = 0;
			_cur__TaxType = 0;
			_cur__Thumbnail = null;
			_started_with_dbvalues = false;
			_recordstatus = DataRecordStatus.New;
		}

		public PriKey_Products_Record(object[] columnvalues)
		{
			_cur__ProductID = (string)columnvalues[0];
			_cur__CategoryID = (long)columnvalues[1];
			_cur__Color = (string)columnvalues[2];
			_cur__CreatedOn = (string)columnvalues[3];
			_cur__DealerPrice = (string)columnvalues[4];
			_cur__Description = (string)columnvalues[5];
			_cur__Discount = (string)columnvalues[6];
			_cur__DiscountEndDate = (string)columnvalues[7];
			_cur__DiscountStartDate = (string)columnvalues[8];
			_cur__LastModifiedOn = (string)columnvalues[9];
			_cur__ListPrice = (string)columnvalues[10];
			_cur__Name = (string)columnvalues[11];
			_cur__Picture = (object)columnvalues[12];
			_cur__SafetyStockLevel = (long)columnvalues[13];
			_cur__SearchTerms = (string)columnvalues[14];
			_cur__Size = (string)columnvalues[15];
			_cur__StockUnits = (long)columnvalues[16];
			_cur__TaxType = (long)columnvalues[17];
			_cur__Thumbnail = (object)columnvalues[18];
			_started_with_dbvalues = true;
			_recordstatus = DataRecordStatus.Existing;
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. PrimaryKey. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long CategoryID
		{
			get { return _cur__CategoryID; }
			set
			{
				if (_started_with_dbvalues == false) _mod__CategoryID = true;
				if (_cur__CategoryID == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__CategoryID == false) { _ori__CategoryID = _cur__CategoryID; _mod__CategoryID = true; } // existing record and column is not modified
					else { if (value == _ori__CategoryID) { _ori__CategoryID = default(long); _mod__CategoryID = false; } } // existing record and column is modified
				}
				_cur__CategoryID = value; OnPropertyChanged("CategoryID"); OnAfterPropertyChanged("CategoryID");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Color
		{
			get { return _cur__Color; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Color = true;
				if (_cur__Color == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Color == false) { _ori__Color = _cur__Color; _mod__Color = true; } // existing record and column is not modified
					else { if (value == _ori__Color) { _ori__Color = default(string); _mod__Color = false; } } // existing record and column is modified
				}
				_cur__Color = value; OnPropertyChanged("Color"); OnAfterPropertyChanged("Color");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string DealerPrice
		{
			get { return _cur__DealerPrice; }
			set
			{
				if (value == null) throw new ArgumentNullException("DealerPrice", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__DealerPrice = true;
				if (_cur__DealerPrice == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__DealerPrice == false) { _ori__DealerPrice = _cur__DealerPrice; _mod__DealerPrice = true; } // existing record and column is not modified
					else { if (value == _ori__DealerPrice) { _ori__DealerPrice = default(string); _mod__DealerPrice = false; } } // existing record and column is modified
				}
				_cur__DealerPrice = value; OnPropertyChanged("DealerPrice"); OnAfterPropertyChanged("DealerPrice");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Description
		{
			get { return _cur__Description; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Description = true;
				if (_cur__Description == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Description == false) { _ori__Description = _cur__Description; _mod__Description = true; } // existing record and column is not modified
					else { if (value == _ori__Description) { _ori__Description = default(string); _mod__Description = false; } } // existing record and column is modified
				}
				_cur__Description = value; OnPropertyChanged("Description"); OnAfterPropertyChanged("Description");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string DiscountEndDate
		{
			get { return _cur__DiscountEndDate; }
			set
			{
				if (_started_with_dbvalues == false) _mod__DiscountEndDate = true;
				if (_cur__DiscountEndDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__DiscountEndDate == false) { _ori__DiscountEndDate = _cur__DiscountEndDate; _mod__DiscountEndDate = true; } // existing record and column is not modified
					else { if (value == _ori__DiscountEndDate) { _ori__DiscountEndDate = default(string); _mod__DiscountEndDate = false; } } // existing record and column is modified
				}
				_cur__DiscountEndDate = value; OnPropertyChanged("DiscountEndDate"); OnAfterPropertyChanged("DiscountEndDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string DiscountStartDate
		{
			get { return _cur__DiscountStartDate; }
			set
			{
				if (_started_with_dbvalues == false) _mod__DiscountStartDate = true;
				if (_cur__DiscountStartDate == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__DiscountStartDate == false) { _ori__DiscountStartDate = _cur__DiscountStartDate; _mod__DiscountStartDate = true; } // existing record and column is not modified
					else { if (value == _ori__DiscountStartDate) { _ori__DiscountStartDate = default(string); _mod__DiscountStartDate = false; } } // existing record and column is modified
				}
				_cur__DiscountStartDate = value; OnPropertyChanged("DiscountStartDate"); OnAfterPropertyChanged("DiscountStartDate");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public string ListPrice
		{
			get { return _cur__ListPrice; }
			set
			{
				if (value == null) throw new ArgumentNullException("ListPrice", VenturaStrings.SET_NULL_MSG);
				if (_started_with_dbvalues == false) _mod__ListPrice = true;
				if (_cur__ListPrice == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__ListPrice == false) { _ori__ListPrice = _cur__ListPrice; _mod__ListPrice = true; } // existing record and column is not modified
					else { if (value == _ori__ListPrice) { _ori__ListPrice = default(string); _mod__ListPrice = false; } } // existing record and column is modified
				}
				_cur__ListPrice = value; OnPropertyChanged("ListPrice"); OnAfterPropertyChanged("ListPrice");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long SafetyStockLevel
		{
			get { return _cur__SafetyStockLevel; }
			set
			{
				if (_started_with_dbvalues == false) _mod__SafetyStockLevel = true;
				if (_cur__SafetyStockLevel == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__SafetyStockLevel == false) { _ori__SafetyStockLevel = _cur__SafetyStockLevel; _mod__SafetyStockLevel = true; } // existing record and column is not modified
					else { if (value == _ori__SafetyStockLevel) { _ori__SafetyStockLevel = default(long); _mod__SafetyStockLevel = false; } } // existing record and column is modified
				}
				_cur__SafetyStockLevel = value; OnPropertyChanged("SafetyStockLevel"); OnAfterPropertyChanged("SafetyStockLevel");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
		/// </summary>
		public string Size
		{
			get { return _cur__Size; }
			set
			{
				if (_started_with_dbvalues == false) _mod__Size = true;
				if (_cur__Size == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__Size == false) { _ori__Size = _cur__Size; _mod__Size = true; } // existing record and column is not modified
					else { if (value == _ori__Size) { _ori__Size = default(string); _mod__Size = false; } } // existing record and column is modified
				}
				_cur__Size = value; OnPropertyChanged("Size"); OnAfterPropertyChanged("Size");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
		/// </summary>
		public long StockUnits
		{
			get { return _cur__StockUnits; }
			set
			{
				if (_started_with_dbvalues == false) _mod__StockUnits = true;
				if (_cur__StockUnits == value) return;
				if (_started_with_dbvalues == true)
				{
					if (_mod__StockUnits == false) { _ori__StockUnits = _cur__StockUnits; _mod__StockUnits = true; } // existing record and column is not modified
					else { if (value == _ori__StockUnits) { _ori__StockUnits = default(long); _mod__StockUnits = false; } } // existing record and column is modified
				}
				_cur__StockUnits = value; OnPropertyChanged("StockUnits"); OnAfterPropertyChanged("StockUnits");
			}
		}

		/// <summary>
		/// Database Column Updateable. Table [Products]. NotReadonly. NotNull.
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
		/// Database Column Updateable. Table [Products]. NotReadonly. AllowNull.
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

		public bool IsModified(string column_name)
		{
			if (column_name == "ProductID") return _mod__ProductID;
			if (column_name == "CategoryID") return _mod__CategoryID;
			if (column_name == "Color") return _mod__Color;
			if (column_name == "CreatedOn") return _mod__CreatedOn;
			if (column_name == "DealerPrice") return _mod__DealerPrice;
			if (column_name == "Description") return _mod__Description;
			if (column_name == "Discount") return _mod__Discount;
			if (column_name == "DiscountEndDate") return _mod__DiscountEndDate;
			if (column_name == "DiscountStartDate") return _mod__DiscountStartDate;
			if (column_name == "LastModifiedOn") return _mod__LastModifiedOn;
			if (column_name == "ListPrice") return _mod__ListPrice;
			if (column_name == "Name") return _mod__Name;
			if (column_name == "Picture") return _mod__Picture;
			if (column_name == "SafetyStockLevel") return _mod__SafetyStockLevel;
			if (column_name == "SearchTerms") return _mod__SearchTerms;
			if (column_name == "Size") return _mod__Size;
			if (column_name == "StockUnits") return _mod__StockUnits;
			if (column_name == "TaxType") return _mod__TaxType;
			if (column_name == "Thumbnail") return _mod__Thumbnail;
			throw new ArgumentOutOfRangeException(String.Format(VenturaStrings.UNKNOWN_COLUMN_NAME, column_name));
		}

		public int ModifiedColumnCount()
		{
			int count = 0;
			if (_mod__ProductID == true) count++;
			if (_mod__CategoryID == true) count++;
			if (_mod__Color == true) count++;
			if (_mod__CreatedOn == true) count++;
			if (_mod__DealerPrice == true) count++;
			if (_mod__Description == true) count++;
			if (_mod__Discount == true) count++;
			if (_mod__DiscountEndDate == true) count++;
			if (_mod__DiscountStartDate == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__ListPrice == true) count++;
			if (_mod__Name == true) count++;
			if (_mod__Picture == true) count++;
			if (_mod__SafetyStockLevel == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__Size == true) count++;
			if (_mod__StockUnits == true) count++;
			if (_mod__TaxType == true) count++;
			if (_mod__Thumbnail == true) count++;
			return count;
		}

		public bool PendingChanges()
		{
			if (_recordstatus == DataRecordStatus.New || _recordstatus == DataRecordStatus.ExistingDelete) return true;
			int count = 0;
			if (_started_with_dbvalues)
			{
				if (_mod__ProductID) count++;
			}
			if (_mod__CategoryID == true) count++;
			if (_mod__Color == true) count++;
			if (_mod__CreatedOn == true) count++;
			if (_mod__DealerPrice == true) count++;
			if (_mod__Description == true) count++;
			if (_mod__Discount == true) count++;
			if (_mod__DiscountEndDate == true) count++;
			if (_mod__DiscountStartDate == true) count++;
			if (_mod__LastModifiedOn == true) count++;
			if (_mod__ListPrice == true) count++;
			if (_mod__Name == true) count++;
			if (_mod__Picture == true) count++;
			if (_mod__SafetyStockLevel == true) count++;
			if (_mod__SearchTerms == true) count++;
			if (_mod__Size == true) count++;
			if (_mod__StockUnits == true) count++;
			if (_mod__TaxType == true) count++;
			if (_mod__Thumbnail == true) count++;
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
			if (_mod__ProductID == false) throw new Exception(string.Format(VenturaStrings.VALUE_NOT_SET_MSG, record_index_to_display, "ProductID"));
		}

		void IRecordBase.WriteChangesToTrackArray(TrackArray track_array)
		{
			if (_recordstatus == DataRecordStatus.New)
			{
				track_array.AppendDataValue(0, _cur__ProductID);
				track_array.AppendDataValue(1, _cur__CategoryID);
				if (_cur__Color != null) track_array.AppendDataValue(2, _cur__Color);
				track_array.AppendDataValue(3, _cur__CreatedOn);
				track_array.AppendDataValue(4, _cur__DealerPrice);
				if (_cur__Description != null) track_array.AppendDataValue(5, _cur__Description);
				track_array.AppendDataValue(6, _cur__Discount);
				if (_cur__DiscountEndDate != null) track_array.AppendDataValue(7, _cur__DiscountEndDate);
				if (_cur__DiscountStartDate != null) track_array.AppendDataValue(8, _cur__DiscountStartDate);
				track_array.AppendDataValue(9, _cur__LastModifiedOn);
				track_array.AppendDataValue(10, _cur__ListPrice);
				track_array.AppendDataValue(11, _cur__Name);
				if (_cur__Picture != null) track_array.AppendDataValue(12, _cur__Picture);
				track_array.AppendDataValue(13, _cur__SafetyStockLevel);
				if (_cur__SearchTerms != null) track_array.AppendDataValue(14, _cur__SearchTerms);
				if (_cur__Size != null) track_array.AppendDataValue(15, _cur__Size);
				track_array.AppendDataValue(16, _cur__StockUnits);
				track_array.AppendDataValue(17, _cur__TaxType);
				if (_cur__Thumbnail != null) track_array.AppendDataValue(18, _cur__Thumbnail);
			}
			else if (_recordstatus == DataRecordStatus.Existing)
			{
				if (_started_with_dbvalues)
				{
					if (_mod__ProductID) track_array.AppendDataValue(0, _cur__ProductID);
				}
				if (_mod__CategoryID) track_array.AppendDataValue(1, _cur__CategoryID);
				if (_mod__Color) track_array.AppendDataValue(2, _cur__Color);
				if (_mod__CreatedOn) track_array.AppendDataValue(3, _cur__CreatedOn);
				if (_mod__DealerPrice) track_array.AppendDataValue(4, _cur__DealerPrice);
				if (_mod__Description) track_array.AppendDataValue(5, _cur__Description);
				if (_mod__Discount) track_array.AppendDataValue(6, _cur__Discount);
				if (_mod__DiscountEndDate) track_array.AppendDataValue(7, _cur__DiscountEndDate);
				if (_mod__DiscountStartDate) track_array.AppendDataValue(8, _cur__DiscountStartDate);
				if (_mod__LastModifiedOn) track_array.AppendDataValue(9, _cur__LastModifiedOn);
				if (_mod__ListPrice) track_array.AppendDataValue(10, _cur__ListPrice);
				if (_mod__Name) track_array.AppendDataValue(11, _cur__Name);
				if (_mod__Picture) track_array.AppendDataValue(12, _cur__Picture);
				if (_mod__SafetyStockLevel) track_array.AppendDataValue(13, _cur__SafetyStockLevel);
				if (_mod__SearchTerms) track_array.AppendDataValue(14, _cur__SearchTerms);
				if (_mod__Size) track_array.AppendDataValue(15, _cur__Size);
				if (_mod__StockUnits) track_array.AppendDataValue(16, _cur__StockUnits);
				if (_mod__TaxType) track_array.AppendDataValue(17, _cur__TaxType);
				if (_mod__Thumbnail) track_array.AppendDataValue(18, _cur__Thumbnail);
				if (track_array.HasData == false) return;
			}

			if (_recordstatus == DataRecordStatus.Existing || _recordstatus == DataRecordStatus.ExistingDelete)
			{
				track_array.AppendPrikeyValue(0, (_mod__ProductID && _started_with_dbvalues) ? _ori__ProductID : _cur__ProductID);
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
				if (_mod__ProductID) _ori__ProductID = default(string);
				if (_mod__CategoryID) _ori__CategoryID = default(long);
				if (_mod__Color) _ori__Color = default(string);
				if (_mod__CreatedOn) _ori__CreatedOn = default(string);
				if (_mod__DealerPrice) _ori__DealerPrice = default(string);
				if (_mod__Description) _ori__Description = default(string);
				if (_mod__Discount) _ori__Discount = default(string);
				if (_mod__DiscountEndDate) _ori__DiscountEndDate = default(string);
				if (_mod__DiscountStartDate) _ori__DiscountStartDate = default(string);
				if (_mod__LastModifiedOn) _ori__LastModifiedOn = default(string);
				if (_mod__ListPrice) _ori__ListPrice = default(string);
				if (_mod__Name) _ori__Name = default(string);
				if (_mod__Picture) _ori__Picture = default(object);
				if (_mod__SafetyStockLevel) _ori__SafetyStockLevel = default(long);
				if (_mod__SearchTerms) _ori__SearchTerms = default(string);
				if (_mod__Size) _ori__Size = default(string);
				if (_mod__StockUnits) _ori__StockUnits = default(long);
				if (_mod__TaxType) _ori__TaxType = default(long);
				if (_mod__Thumbnail) _ori__Thumbnail = default(object);
			}
			_mod__ProductID = false;
			_mod__CategoryID = false;
			_mod__Color = false;
			_mod__CreatedOn = false;
			_mod__DealerPrice = false;
			_mod__Description = false;
			_mod__Discount = false;
			_mod__DiscountEndDate = false;
			_mod__DiscountStartDate = false;
			_mod__LastModifiedOn = false;
			_mod__ListPrice = false;
			_mod__Name = false;
			_mod__Picture = false;
			_mod__SafetyStockLevel = false;
			_mod__SearchTerms = false;
			_mod__Size = false;
			_mod__StockUnits = false;
			_mod__TaxType = false;
			_mod__Thumbnail = false;
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
	public partial class PriKey_Products_Record
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
