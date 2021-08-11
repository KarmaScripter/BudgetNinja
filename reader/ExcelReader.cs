// <copyright file = "ExcelReader.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Windows.Forms;
    using OfficeOpenXml;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:Badger.Query"/>
    /// <seealso cref = "T:Badger.IQueryBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedReadonlyField" ) ]
    public class ExcelReader
    {
        /// <summary>
        /// The provider
        /// </summary>
        private protected readonly Provider _provider = Provider.Excel;

        /// <summary>
        /// The XLS
        /// </summary>
        private protected readonly string _xls = DataPath.ConnectionString[ "OleDb" ].ToString();

        /// <summary>
        /// The XLSX
        /// </summary>
        private protected readonly string _xlsx = DataPath.ConnectionString[ "Excel" ].ToString();

        /// <summary>
        /// The CSV
        /// </summary>
        private protected readonly string _csv = DataPath.ConnectionString[ "CSV" ].ToString();

        /// <summary>
        /// The accdb
        /// </summary>
        private protected readonly string _accdb = DataPath.ConnectionString[ "Access" ].ToString();

        /// <summary>
        /// The MDB
        /// </summary>
        private protected readonly string _mdb = DataPath.ConnectionString[ "OleDb" ].ToString();
        
        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        private protected readonly DataSet _dataSet;

        /// <summary>
        /// Gets or sets the dataTable.
        /// </summary>
        /// <value>
        /// The dataTable.
        /// </value>
        private protected readonly DataTable _table;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelReader"/> class.
        /// </summary>
        public ExcelReader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelReader"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="dict">The dictionary.</param>
        public ExcelReader( string filePath, IDictionary<string, object> dict )
        {
        }
        
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <dict name = "workbook" >
        /// The workbook.
        /// </dict>
        public void SaveFile( ExcelPackage excelPackage )
        {
            if( excelPackage != null )
            {
                try
                {
                    using var _fileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FilterIndex = 1
                    };

                    if( _fileDialog.ShowDialog() == DialogResult.OK )
                    {
                        excelPackage.Save( _fileDialog.FileName );
                        const string _msg = "Save Successful!";
                        using var _message = new Message( _msg );
                        _message?.ShowDialog();
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Exports to excelPackage.
        /// </summary>
        /// <dict name = "dataTable" >
        /// The dataTable.
        /// </dict>
        public void ExportToExcel( DataTable dataTable, string filePath )
        {
            if( dataTable?.Columns?.Count > 0 
                && dataTable.Rows?.Count > 0 
                && Verify.Input( filePath ) )
            {
                try
                {
                    using var _package = CreateExcelFile( filePath );
                    var _name = Path.GetFileNameWithoutExtension( filePath );
                    var _worksheet = _package.Workbook.Worksheets.Add( _name );
                    var _columns = dataTable.Columns.Count;
                    var _rows = dataTable.Rows.Count;

                    for( var column = 1; column <= _columns; column++ )
                    {
                        _worksheet.Cells[ 1, column ].Value = dataTable.Columns[ column - 1 ].ColumnName;
                    }

                    for( var row = 1; row <= _rows; row++ )
                    {
                        for( var col = 0; col < _columns; col++ )
                        {
                            _worksheet.Cells[ row + 1, col + 1 ].Value = dataTable.Rows[ row - 1 ][ col ];
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Creates the excelPackage file.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <returns>
        /// </returns>
        private ExcelPackage CreateExcelFile( string filePath )
        {
            if( Verify.Input( filePath ) )
            {
                try
                {
                    var _fileInfo = new FileInfo( filePath );
                    return new ExcelPackage( _fileInfo );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelPackage );
                }
            }

            return default( ExcelPackage );
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetExcelFile()
        {
            try
            {
                var _name = "";

                using var _fileDialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( _fileDialog.ShowDialog() == DialogResult.OK )
                {
                    _name = _fileDialog.FileName;
                }

                return Verify.Input( _name ) && File.Exists( _name )
                    ? _name
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the data dataTable from excelPackage file.
        /// </summary>
        /// <dict name = "sheetName" >
        /// The sheetName.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable ImportExcelFile( ref string sheetName )
        {
            if( Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataset = new DataSet();
                    using var _connection = new OleDbConnection( _xlsx );
                    _connection?.Open();
                    var _sql = "SELECT * FROM [" + sheetName + "]";
                    var _schema = _connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( _schema?.Columns.Count > 0 
                        && !SheetExists( sheetName, _schema ) )
                    {
                        const string _msg = "Sheet Does Not Exist!";
                        using var _message = new Message( _msg );
                        _message?.ShowDialog();
                    }
                    else
                    {
                        sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _adapter = new OleDbDataAdapter( _sql, _connection );
                    _adapter?.Fill( _dataset );
                    return _dataset?.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Gets the data dataTable from CSV file.
        /// </summary>
        /// <dict name = "fileName" >
        /// The fileName.
        /// </dict>
        /// <dict name = "sheetName" >
        /// The sheetName.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( string fileName, ref string sheetName )
        {
            if( Verify.Input( fileName )
                && Verify.Input( sheetName ) )
            {
                try
                {
                    using var _data = new DataSet();
                    var _sql = "SELECT * FROM [" + sheetName + "]";

                    var _connectionString =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;_dataRow _source={Path.GetDirectoryName( fileName )};"
                        + @"Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var connection = new OleDbConnection( _connectionString );
                    var schema = connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetName ) )
                    {
                        if( !SheetExists( sheetName, schema ) )
                        {
                            var _msg = $"{sheetName} in {fileName} Does Not Exist!";
                            using var _message = new Message( _msg );
                            _message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetName = schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _adapter = new OleDbDataAdapter( _sql, connection );
                    _adapter.Fill( _data );
                    return _data.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Imports to data grid view.
        /// </summary>
        /// <dict name = "dataGrid" >
        /// The dataGrid.
        /// </dict>
        private void ImportToDataGrid( DataGridView dataGrid, string location )
        {
            if( dataGrid?.DataSource != null )
            {
                try
                {
                    var _path = Path.GetFullPath( location );
                    using var _excelPackage = new ExcelPackage( new FileInfo( _path ) );
                    var _workbook = _excelPackage.Workbook;
                    var _worksheet = _workbook.Worksheets[ 1 ];
                    var _range = _worksheet.Cells;
                    var _rows = _range.Rows;
                    var _columns = _range.Columns;
                    dataGrid.ColumnCount = _columns;
                    dataGrid.RowCount = _rows;

                    for( var i = 1; i <= _rows; i++ )
                    {
                        for( var j = 1; j <= _columns; j++ )
                        {
                            if( _worksheet.Cells[ i, j ] != null
                                && _worksheet.Cells[ i, j ].Value != null )
                            {
                                dataGrid.Rows[ i - 1 ].Cells[ j - 1 ].Value =
                                    _worksheet.Cells[ i, j ].Value.ToString();
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <dict name = "sheetName" >
        /// _name of the sheet.
        /// </dict>
        /// <dict name = "dataTable" >
        /// The dt dataTable.
        /// </dict>
        /// <returns>
        /// </returns>
        private bool SheetExists( string sheetName, DataTable dataTable )
        {
            if( Verify.Input( sheetName ) 
                && dataTable?.Columns.Count > 0 
                && dataTable.Rows.Count > 0 )
            {
                try
                {
                    for( var i = 0; i < dataTable.Rows.Count; i++ )
                    {
                        var _row = dataTable.Rows[ i ];

                        if( sheetName == _row[ "TABLENAME" ].ToString() )
                        {
                            return true;
                        }
                    }

                    return false;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return false;
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
