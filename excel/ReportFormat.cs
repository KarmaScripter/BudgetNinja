// <copyright file = "ReportFormat.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IDisposable"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ReportFormat : ExcelBase, IDisposable
    {
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The font color
        /// </summary>
        private protected readonly Color _fontColor = Color.Black;

        /// <summary>
        /// The font
        /// </summary>
        private protected readonly Font _font = new Font( "Consolas", 8, FontStyle.Regular );

        /// <summary>
        /// The title font
        /// </summary>
        private protected readonly Font _titleFont = new Font( "Consolas", 8, FontStyle.Bold );

        /// <summary>
        /// The header image width
        /// </summary>
        private protected readonly double _headerImageWidth = 1.75;

        /// <summary>
        /// The header image height
        /// </summary>
        private protected readonly double _headerImageHeight = 0.75;

        /// <summary>
        /// The footer image width
        /// </summary>
        private protected readonly double _footerImageWidth = 2.04;

        /// <summary>
        /// The footer image height
        /// </summary>
        private protected readonly double _footerImageHeight = 0.70;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "ReportFormat"/> class.
        /// </summary>
        public ReportFormat()
        {
            FileInfo = new FileInfo( _filePath );
            Excel = new ExcelPackage( FileInfo );
            Workbook = Excel.Workbook;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ReportFormat"/> class.
        /// </summary>
        /// <param name = "table" >
        /// The table.
        /// </param>
        public ReportFormat( DataTable table )
            : this()
        {
            Data = table.AsEnumerable();
            Worksheet = Workbook.Worksheets.Add( table.TableName );
            Worksheet.View.ShowGridLines = false;
            Worksheet.View.ZoomScale = _zoomLevel;
            Worksheet.View.PageLayoutView = true;
            Worksheet.View.ShowHeaders = true;
            Worksheet.DefaultRowHeight = _rowHeight;
            Worksheet.DefaultColWidth = _columnWidth;
            Worksheet.PrinterSettings.ShowHeaders = false;
            Worksheet.PrinterSettings.ShowGridLines = false;
            Worksheet.PrinterSettings.LeftMargin = _leftMargin;
            Worksheet.PrinterSettings.RightMargin = _rightMargin;
            Worksheet.PrinterSettings.TopMargin = _topMargin;
            Worksheet.PrinterSettings.BottomMargin = _bottomMarging;
            Worksheet.PrinterSettings.HorizontalCentered = true;
            Worksheet.PrinterSettings.VerticalCentered = true;
            Worksheet.PrinterSettings.FitToPage = true;
            Worksheet.HeaderFooter.AlignWithMargins = true;
            Worksheet.HeaderFooter.ScaleWithDocument = true;
        }

        // **************************************************************************************************************************
        // ******************************************************   PROPERTIES   ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the header image.
        /// </summary>
        /// <value>
        /// The header image.
        /// </value>
        private protected Image HeaderImage { get; set; }

        /// <summary>
        /// Gets or sets the footer image.
        /// </summary>
        /// <value>
        /// The footer image.
        /// </value>
        private protected Image FooterImage { get; set; }

        // **************************************************************************************************************************
        // ******************************************************     METHODS   *****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the header format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        private protected void SetHeaderFormat( Grid grid )
        {
            if( grid?.GetWorksheet() != null )
            {
                try
                {
                    using var font = _font;
                    SetFontColor( grid, _fontColor );
                    SetBackgroudColor( grid, _primaryBackColor );
                    SetHorizontalAligment( grid, _left );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the header text.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        private protected void SetHeaderText( Grid grid )
        {
            if( grid?.GetWorksheet() != null )
            {
                try
                {
                    using var worksheet = grid.GetWorksheet();
                    using var range = grid.GetRange();
                    var row = range.Start.Row;
                    var column = range.Start.Column;
                    SetFontColor( grid, _fontColor );
                    SetBackgroudColor( grid, _primaryBackColor );
                    SetHorizontalAligment( grid, _left );
                    worksheet.Cells[ row, column ].Value = "Account";
                    worksheet.Cells[ row, column + 1 ].Value = "Site";
                    worksheet.Cells[ row, column + 2 ].Value = "Travel";
                    worksheet.Cells[ row, column + 3 ].Value = "Expenses";
                    worksheet.Cells[ row, column + 4 ].Value = "Contracts";
                    worksheet.Cells[ row, column + 5 ].Value = "Grants";
                    worksheet.Cells[ row, column + 6 ].Value = "Total";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the dark color row.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
        private protected void SetDarkColorRow( ExcelRange range )
        {
            if( range != null )
            {
                try
                {
                    range.Style.Font.Color.SetColor( Color.Black );

                    using( _font )
                    {
                        range.Style.Font.SetFromFont( _font );
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                        range.Style.HorizontalAlignment = _center;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the light color row.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
        private protected void SetLightColorRow( ExcelRange range )
        {
            if( range != null )
            {
                try
                {
                    range.Style.Font.Color.SetColor( _fontColor );

                    using( _font )
                    {
                        range.Style.Font.SetFromFont( _font );
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor( Color.White );
                        range.Style.HorizontalAlignment = _center;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the color of the alternating row.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        private protected void SetAlternatingRowColor( ExcelRange range )
        {
            if( Worksheet != null
                && range.Start.Row > -1
                && range.Start.Column > -1
                && range.End.Row > -1
                && range.End.Column > -1 )
            {
                try
                {
                    var prc = Worksheet.Cells[ range.Start.Row, range.Start.Column, range.End.Row,
                        range.End.Column ];

                    for( var i = range.Start.Row; i < range.End.Row; i++ )
                    {
                        if( i % 2 == 0 )
                        {
                            SetLightColorRow( prc );
                        }

                        if( i % 2 != 0 )
                        {
                            SetDarkColorRow( prc );
                        }
                    }

                    SetNumericRowFormat( range );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the numeric row format.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        private protected void SetNumericRowFormat( ExcelRange range )
        {
            if( Worksheet != null
                && range.Start.Row > -1
                && range.Start.Column > -1
                && range.End.Row > -1
                && range.End.Column > -1 )
            {
                try
                {
                    using( range )
                    {
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.Numberformat.Format = "#,###";
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        private protected void SetTableFormat( Grid grid )
        {
            if( grid?.GetWorksheet() != null )
            {
                try
                {
                    SetHeaderText( grid );
                    using var range = grid.GetRange();
                    using var font = _titleFont;
                    range.Style.Font.SetFromFont( _titleFont );
                    range.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    range.Style.HorizontalAlignment = _center;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the total row format.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        private protected void SetTotalRowFormat( ExcelRange range )
        {
            if( Worksheet != null
                && range.Start.Row > -1
                && range.Start.Column > -1
                && range.End.Row > -1
                && range.End.Column > -1 )
            {
                try
                {
                    var total = Worksheet.Cells[ range.Start.Row, range.Start.Column, range.Start.Row,
                        range.Start.Column + 6 ];

                    var data = Worksheet.Cells[ range.Start.Row, range.Start.Column + 1, range.Start.Row,
                        range.Start.Column + 6 ];

                    total.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    total.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    data.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name = "disposing" >
        /// <c>
        /// true
        /// </c>
        /// to release both managed and unmanaged resources;
        /// <c>
        /// false
        /// </c>
        /// to release only unmanaged resources.
        /// </param>
        [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
        private protected void Dispose( bool disposing )
        {
            _titleFont?.Dispose();
            _font?.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
}
