// <copyright file = "ExcelReport.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;

    [ SuppressMessage( "ReSharper", "PossiblyMistakenUseOfParamsMethod" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public class ExcelReport
    {
        // ***************************************************************************************************************************
        // ****************************************************     FIELDS    ********************************************************
        // ***************************************************************************************************************************

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "ExcelReport"/> class.
        /// </summary>
        public ExcelReport()
        {
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Creates the excel document.
        /// </summary>
        /// <typeparam name = "T" >
        /// </typeparam>
        /// <param name = "data" >
        /// The list.
        /// </param>
        /// <param name = "excelfilepath" >
        /// The excelfilepath.
        /// </param>
        /// <returns>
        /// </returns>
        public bool CreateExcelDocument<T>( IEnumerable<T> data, string excelfilepath )
        {
            if( data != null
                && Verify.Input( excelfilepath ) )
            {
                try
                {
                    using var ds = new DataSet();
                    ds.Tables.Add( ListToDataTable( data ) );
                    return CreateExcelDocument( ds, excelfilepath );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the excel document.
        /// </summary>
        /// <param name = "datatable" >
        /// The table.
        /// </param>
        /// <param name = "excelfilepath" >
        /// The excelfilepath.
        /// </param>
        /// <returns>
        /// </returns>
        public bool CreateExcelDocument( DataTable datatable, string excelfilepath )
        {
            if( Verify.Input( excelfilepath )
                && datatable?.Rows?.Count > 0
                && datatable?.Columns?.Count > 0 )
            {
                try
                {
                    using var ds = new DataSet();
                    ds.Tables.Add( datatable );
                    var result = CreateExcelDocument( ds, excelfilepath );
                    ds.Tables.Remove( datatable );
                    return result;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the excel document.
        /// </summary>
        /// <param name = "dataset" >
        /// The dataset.
        /// </param>
        /// <param name = "excelfilename" >
        /// The excelfilename.
        /// </param>
        /// <returns>
        /// </returns>
        public bool CreateExcelDocument( DataSet dataset, string excelfilename )
        {
            if( Verify.Input( excelfilename )
                && dataset != null )
            {
                try
                {
                    using( var document = SpreadsheetDocument.Create( excelfilename,
                        SpreadsheetDocumentType.Workbook ) )
                    {
                        WriteExcelFile( dataset, document );
                    }

                    Trace.WriteLine( "Successfully created: " + excelfilename );
                    return true;
                }
                catch( Exception ex )
                {
                    Trace.WriteLine( "Failed, exception thrown: " + ex.Message );
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Lists to data table.
        /// </summary>
        /// <typeparam name = "T" >
        /// </typeparam>
        /// <param name = "data" >
        /// The list.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable ListToDataTable<T>( IEnumerable<T> data )
        {
            if( data != null )
            {
                try
                {
                    var datatable = new DataTable();

                    foreach( var info in typeof( T ).GetProperties() )
                    {
                        datatable.Columns.Add( new DataColumn( info.Name,
                            GetNullableType( info.PropertyType ) ) );
                    }

                    foreach( var t in data )
                    {
                        var row = datatable.NewRow();

                        foreach( var info in typeof( T ).GetProperties() )
                        {
                            row[ info.Name ] = !IsNullableType( info.PropertyType )
                                ? info.GetValue( t, null )
                                : info.GetValue( t, null ) ?? DBNull.Value;
                        }

                        datatable.Rows.Add( row );
                    }

                    return datatable;
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
        /// Gets the type of the nullable.
        /// </summary>
        /// <param name = "type" >
        /// The type.
        /// </param>
        /// <returns>
        /// </returns>
        public Type GetNullableType( Type type )
        {
            try
            {
                var returntype = type;

                if( type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof( Nullable<> ) )
                {
                    returntype = Nullable.GetUnderlyingType( type );
                }

                return returntype;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Determines whether [is nullable type] [the specified type].
        /// </summary>
        /// <param name = "type" >
        /// The type.
        /// </param>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if [is nullable type] [the specified type]; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        private protected bool IsNullableType( Type type )
        {
            try
            {
                return type == typeof( string ) || type.IsArray || type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof( Nullable<> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }

        /// <summary>
        /// Appends the text cell.
        /// </summary>
        /// <param name = "cellreference" >
        /// The cellreference.
        /// </param>
        /// <param name = "cellstringvalue" >
        /// The cellstringvalue.
        /// </param>
        /// <param name = "excelrow" >
        /// The excelrow.
        /// </param>
        public void AppendTextCell( string cellreference, string cellstringvalue, OpenXmlElement excelrow )
        {
            try
            {
                var cell = new Cell
                {
                    CellReference = cellreference,
                    DataType = CellValues.String
                };

                var cellvalue = new CellValue
                {
                    Text = cellstringvalue
                };

                cell.Append( cellvalue );
                excelrow.Append( cell );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Appends the numeric cell.
        /// </summary>
        /// <param name = "cellreference" >
        /// The cellreference.
        /// </param>
        /// <param name = "cellstringvalue" >
        /// The cellstringvalue.
        /// </param>
        /// <param name = "excelrow" >
        /// The excelrow.
        /// </param>
        public void AppendNumericCell( string cellreference, string cellstringvalue, OpenXmlElement excelrow )
        {
            if( Verify.Input( cellreference )
                && Verify.Input( cellstringvalue )
                && excelrow != null )
            {
                try
                {
                    var cell = new Cell
                    {
                        CellReference = cellreference
                    };

                    var cellvalue = new CellValue
                    {
                        Text = cellstringvalue
                    };

                    cell.Append( cellvalue );
                    excelrow.Append( cell );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Gets the name of the excel column.
        /// </summary>
        /// <param name = "columnindex" >
        /// The columnindex.
        /// </param>
        /// <returns>
        /// </returns>
        public string GetExcelColumnName( int columnindex )
        {
            try
            {
                if( columnindex < 26 )
                {
                    return ( (char)( 'A' + columnindex ) ).ToString();
                }

                var first = (char)( 'A' + columnindex / 26 - 1 );
                var second = (char)( 'A' + columnindex % 26 );
                return $"{first}{second}";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Writes the excel file.
        /// </summary>
        /// <param name = "dataset" >
        /// The dataset.
        /// </param>
        /// <param name = "spreadsheet" >
        /// The spreadsheet.
        /// </param>
        public void WriteExcelFile( DataSet dataset, SpreadsheetDocument spreadsheet )
        {
            if( dataset != null
                && spreadsheet != null )
            {
                try
                {
                    spreadsheet.AddWorkbookPart();
                    spreadsheet.WorkbookPart.Workbook = new Workbook();
                    spreadsheet.WorkbookPart.Workbook.Append( new BookViews( new WorkbookView() ) );

                    var workbookstylespart =
                        spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>( "rIdStyles" );

                    var stylesheet = new Stylesheet();
                    workbookstylespart.Stylesheet = stylesheet;
                    uint worksheetnumber = 1;

                    foreach( DataTable dt in dataset.Tables )
                    {
                        var newworksheetpart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                        newworksheetpart.Worksheet = new Worksheet();
                        newworksheetpart.Worksheet.AppendChild( new SheetData() );
                        WriteDataTableToExcelWorksheet( dt, newworksheetpart );
                        newworksheetpart.Worksheet.Save();

                        if( worksheetnumber == 1 )
                        {
                            spreadsheet.WorkbookPart.Workbook.AppendChild( new Sheets() );
                        }

                        spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>()
                            .AppendChild( new Sheet
                            {
                                Id = spreadsheet.WorkbookPart.GetIdOfPart( newworksheetpart ),
                                SheetId = worksheetnumber,
                                Name = dt.TableName
                            } );

                        worksheetnumber++;
                    }

                    spreadsheet.WorkbookPart.Workbook.Save();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Writes the data table to excel worksheet.
        /// </summary>
        /// <param name = "datatable" >
        /// The datatable.
        /// </param>
        /// <param name = "worksheetpart" >
        /// The worksheetpart.
        /// </param>
        public void WriteDataTableToExcelWorksheet( DataTable datatable, WorksheetPart worksheetpart )
        {
            if( datatable != null
                && datatable.Rows.Count > 0
                && datatable.Columns.Count > 0
                && worksheetpart != null )
            {
                try
                {
                    var worksheet = worksheetpart.Worksheet;
                    var sheetdata = worksheet?.GetFirstChild<SheetData>();
                    var columns = datatable.Columns.Count;
                    var isnumeric = new bool[ columns ];
                    var columnnames = new string[ columns ];

                    for( var n = 0; n < columns; n++ )
                    {
                        columnnames[ n ] = GetExcelColumnName( n );
                    }

                    uint rowindex = 1;

                    var headerrow = new Row
                    {
                        RowIndex = rowindex
                    };

                    sheetdata?.Append( headerrow );

                    for( var colinx = 0; colinx < columns; colinx++ )
                    {
                        var col = datatable.Columns[ colinx ];
                        AppendTextCell( columnnames[ colinx ] + "1", col.ColumnName, headerrow );

                        isnumeric[ colinx ] = col.DataType.FullName == "System.Decimal"
                            || col.DataType.FullName == "System.Int32";
                    }

                    foreach( DataRow dr in datatable.Rows )
                    {
                        ++rowindex;

                        var newexcelrow = new Row
                        {
                            RowIndex = rowindex
                        };

                        sheetdata?.Append( newexcelrow );

                        for( var i = 0; i < columns; i++ )
                        {
                            var cellvalue = dr.ItemArray[ i ].ToString();

                            if( isnumeric[ i ] )
                            {
                                if( double.TryParse( cellvalue, out var cellnumericvalue ) )
                                {
                                    cellvalue = cellnumericvalue.ToString();
                                    AppendNumericCell( columnnames[ i ] + rowindex, cellvalue, newexcelrow );
                                }
                            }
                            else
                            {
                                AppendTextCell( columnnames[ i ] + rowindex, cellvalue, newexcelrow );
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
