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

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedReadonlyField" ) ]
    public class ExcelReader
    {
        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public Provider Provider { get; } = Provider.Excel;

        /// <summary>
        /// Gets the XLS.
        /// </summary>
        /// <value>
        /// The XLS.
        /// </value>
        public string XLS { get; } = DataPath.ConnectionString[ "OleDb" ].ToString();

        /// <summary>
        /// Gets the XLSX.
        /// </summary>
        /// <value>
        /// The XLSX.
        /// </value>
        public string XLSX { get; } = DataPath.ConnectionString[ "Excel" ].ToString();

        /// <summary>
        /// Gets the CSV.
        /// </summary>
        /// <value>
        /// The CSV.
        /// </value>
        public string CSV { get; } = DataPath.ConnectionString[ "CSV" ].ToString();

        /// <summary>
        /// Gets the accdb.
        /// </summary>
        /// <value>
        /// The accdb.
        /// </value>
        public string ACCDB { get; } = DataPath.ConnectionString[ "Access" ].ToString();

        /// <summary>
        /// Gets the MDB.
        /// </summary>
        /// <value>
        /// The MDB.
        /// </value>
        public string MDB { get; } = DataPath.ConnectionString[ "OleDb" ].ToString();

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
        /// <param name="excelPackage">The excel package.</param>
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
        /// Exports to excel.
        /// </summary>
        /// <param name="dataTable">The Data table.</param>
        /// <param name="filePath">The file path.</param>
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
        /// Creates the excel file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
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
        /// Gets the excel file.
        /// </summary>
        /// <returns></returns>
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
        /// Imports the excel file.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable ImportExcelFile( ref string sheetName )
        {
            if( Verify.Input( sheetName ) )
            {
                try
                {
                    using var _dataset = new DataSet();
                    using var _connection = new OleDbConnection( XLSX );
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
        /// CSVs the import.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
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
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;_dataRow Source={Path.GetDirectoryName( fileName )};"
                        + @"Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var _connection = new OleDbConnection( _connectionString );
                    var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetName ) )
                    {
                        if( !SheetExists( sheetName, _schema ) )
                        {
                            var _msg = $"{sheetName} in {fileName} Does Not Exist!";
                            using var _message = new Message( _msg );
                            _message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var _adapter = new OleDbDataAdapter( _sql, _connection );
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
        /// Imports to Data grid.
        /// </summary>
        /// <param name="dataGrid">The Data grid.</param>
        /// <param name="location">The location.</param>
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
        /// Sheets the exists.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="dataTable">The Data table.</param>
        /// <returns></returns>
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
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
