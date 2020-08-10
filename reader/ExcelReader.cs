// // <copyright file = "ExcelReader.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **************************************************************
    // ******************************************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using OfficeOpenXml;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:Badger.Query"/>
    /// <seealso cref = "T:Badger.IQueryBase"/>
    public class ExcelReader
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        private protected readonly Provider Provider = Provider.Excel;

        private protected readonly string XLS = DataPath.ConnectionString[ "OleDb" ].ToString();

        private protected readonly string XLSX = DataPath.ConnectionString[ "Excel" ].ToString();

        private protected readonly string CSV = DataPath.ConnectionString[ "CSV" ].ToString();

        private protected readonly string ACCDB = DataPath.ConnectionString[ "Access" ].ToString();

        private protected readonly string MDB = DataPath.ConnectionString[ "OleDb" ].ToString();

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        public ExcelReader()
        {
        }

        public ExcelReader( string filepath, IDictionary<string, object> dict )
        {
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the r6.
        /// </summary>
        /// <value>
        /// The r6.
        /// </value>
        private DataSet DataSet { get; set; }

        /// <summary>
        /// Gets or sets the datatable.
        /// </summary>
        /// <value>
        /// The datatable.
        /// </value>
        private DataTable Table { get; set; }

        /// <summary>
        /// Gets or sets the excel.
        /// </summary>
        /// <value>
        /// The excel.
        /// </value>
        private ExcelPackage Excel { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <dict name = "workbook" >
        /// The workbook.
        /// </dict>
        public void SaveFile( ExcelPackage excel )
        {
            if( excel != null )
            {
                try
                {
                    using var dialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FilterIndex = 1
                    };

                    if( dialog.ShowDialog() == DialogResult.OK )
                    {
                        excel.Save( dialog.FileName );
                        const string msg = "Save Successful!";
                        using var message = new Message( msg );
                        message?.ShowDialog();
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
        /// <dict name = "table" >
        /// The datatable.
        /// </dict>
        public void ExportToExcel( DataTable table, string filepath )
        {
            if( table != null
                && table.Columns.Count > 0
                && table.Rows.Count > 0
                && Verify.Input( filepath ) )
            {
                try
                {
                    using var excel = CreateExcelFile( filepath );
                    var filename = Path.GetFileNameWithoutExtension( filepath );
                    var worksheet = excel.Workbook.Worksheets.Add( filename );
                    var columns = table.Columns.Count;
                    var rows = table.Rows.Count;

                    for( var column = 1; column <= columns; column++ )
                    {
                        worksheet.Cells[ 1, column ].Value = table.Columns[ column - 1 ].ColumnName;
                    }

                    for( var row = 1; row <= rows; row++ )
                    {
                        for( var col = 0; col < columns; col++ )
                        {
                            worksheet.Cells[ row + 1, col + 1 ].Value = table.Rows[ row - 1 ][ col ];
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
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <returns>
        /// </returns>
        private ExcelPackage CreateExcelFile( string filepath )
        {
            if( Verify.Input( filepath ) )
            {
                try
                {
                    var fileinfo = new FileInfo( filepath );
                    return new ExcelPackage( fileinfo );
                }
                catch( Exception ex )
                {
                    Fail( ex );

                    return default;
                }
            }

            return default;
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
                var fname = "";

                using var dialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    fname = dialog.FileName;
                }

                return Verify.Input( fname ) && File.Exists( fname )
                    ? fname
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );

                return default;
            }
        }

        /// <summary>
        /// Gets the data datatable from excel file.
        /// </summary>
        /// <dict name = "sheetname" >
        /// The sheetname.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable ImportExcelFile( ref string sheetname )
        {
            if( Verify.Input( sheetname ) )
            {
                try
                {
                    using var dataset = new DataSet();
                    using var connection = new OleDbConnection( XLSX );
                    connection?.Open();
                    var sql = "SELECT * FROM [" + sheetname + "]";
                    var schema = connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( schema != null
                        && schema.Columns.Count > 0
                        && !SheetExists( sheetname, schema ) )
                    {
                        const string msg = "Sheet Does Not Exist!";
                        using var message = new Message( msg );
                        message?.ShowDialog();
                    }
                    else
                    {
                        sheetname = schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var adapter = new OleDbDataAdapter( sql, connection );
                    adapter?.Fill( dataset );
                    return dataset?.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );

                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the data datatable from CSV file.
        /// </summary>
        /// <dict name = "filename" >
        /// The filename.
        /// </dict>
        /// <dict name = "sheetname" >
        /// The sheetname.
        /// </dict>
        /// <returns>
        /// </returns>
        public DataTable CsvImport( string filename, ref string sheetname )
        {
            if( Verify.Input( filename )
                && Verify.Input( sheetname ) )
            {
                try
                {
                    using var data = new DataSet();
                    var sql = "SELECT * FROM [" + sheetname + "]";

                    var conectionstring =
                        $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( filename )};"
                        + @"Extended Properties='Text;HDR=YES;FMT=Delimited'";

                    using var connection = new OleDbConnection( conectionstring );
                    var schema = connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );

                    if( Verify.Input( sheetname ) )
                    {
                        if( !SheetExists( sheetname, schema ) )
                        {
                            var msg = $"{sheetname} in {filename} Does Not Exist!";
                            using var message = new Message( msg );
                            message?.ShowDialog();
                        }
                    }
                    else
                    {
                        sheetname = schema?.Rows[ 0 ][ "TABLENAME" ].ToString();
                    }

                    using var adapter = new OleDbDataAdapter( sql, connection );
                    adapter.Fill( data );
                    return data.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );

                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Imports to data grid view.
        /// </summary>
        /// <dict name = "datagrid" >
        /// The datagrid.
        /// </dict>
        private void ImportToDataGrid( DataGridView datagrid, string filelocation )
        {
            if( datagrid?.DataSource != null )
            {
                try
                {
                    var filepath = Path.GetFullPath( filelocation );
                    using var excel = new ExcelPackage( new FileInfo( filepath ) );
                    var workbook = excel.Workbook;
                    var worksheet = workbook.Worksheets[ 1 ];
                    var range = worksheet.Cells;
                    var rows = range.Rows;
                    var columns = range.Columns;
                    datagrid.ColumnCount = columns;
                    datagrid.RowCount = rows;

                    for( var i = 1; i <= rows; i++ )
                    {
                        for( var j = 1; j <= columns; j++ )
                        {
                            if( worksheet.Cells[ i, j ] != null
                                && worksheet.Cells[ i, j ].Value != null )
                            {
                                datagrid.Rows[ i - 1 ].Cells[ j - 1 ].Value =
                                    worksheet.Cells[ i, j ].Value.ToString();
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
        /// <dict name = "sheetname" >
        /// Name of the sheet.
        /// </dict>
        /// <dict name = "datatable" >
        /// The dt datatable.
        /// </dict>
        /// <returns>
        /// </returns>
        private bool SheetExists( string sheetname, DataTable datatable )
        {
            if( Verify.Input( sheetname )
                && datatable != null
                && datatable.Columns.Count > 0
                && datatable.Rows.Count > 0 )
            {
                try
                {
                    for( var i = 0; i < datatable.Rows.Count; i++ )
                    {
                        var datarow = datatable.Rows[ i ];

                        if( sheetname == datarow[ "TABLENAME" ].ToString() )
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
