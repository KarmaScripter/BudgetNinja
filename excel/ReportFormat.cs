// <copyright file = "ReportFormat.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
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
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class ReportFormat : ExcelBase, IDisposable
    {
        /// <summary>
        /// The font color
        /// </summary>
        private protected readonly Color _fontColor = Color.Black;

        /// <summary>
        /// The font
        /// </summary>
        private protected readonly Font _font = new Font( "Source Code Pro", 8, FontStyle.Regular );

        /// <summary>
        /// The title font
        /// </summary>
        private protected readonly Font _titleFont = new Font( "Source Code Pro", 8, FontStyle.Bold );

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

        /// <summary>
        /// Gets or sets the header image.
        /// </summary>
        /// <value>
        /// The header image.
        /// </value>
        private protected Image _headerImage;

        /// <summary>
        /// Gets or sets the footer image.
        /// </summary>
        /// <value>
        /// The footer image.
        /// </value>
        private protected Image _footerImage;

        /// <summary>
        /// Initializes a new instance of the <see cref = "ReportFormat"/> class.
        /// </summary>
        public ReportFormat()
        {
            _fileInfo = new FileInfo( _filePath );
            _excel = new ExcelPackage( _fileInfo );
            _workbook = _excel.Workbook;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ReportFormat"/> class.
        /// </summary>
        /// <param name = "dataTable" >
        /// The dataTable.
        /// </param>
        public ReportFormat( DataTable dataTable )
            : this()
        {
            _data = dataTable.AsEnumerable();
            _worksheet = _workbook.Worksheets.Add( dataTable.TableName );
            _worksheet.View.ShowGridLines = false;
            _worksheet.View.ZoomScale = _zoomLevel;
            _worksheet.View.PageLayoutView = true;
            _worksheet.View.ShowHeaders = true;
            _worksheet.DefaultRowHeight = _rowHeight;
            _worksheet.DefaultColWidth = _columnWidth;
            _worksheet.PrinterSettings.ShowHeaders = false;
            _worksheet.PrinterSettings.ShowGridLines = false;
            _worksheet.PrinterSettings.LeftMargin = _leftMargin;
            _worksheet.PrinterSettings.RightMargin = _rightMargin;
            _worksheet.PrinterSettings.TopMargin = _topMargin;
            _worksheet.PrinterSettings.BottomMargin = _bottomMarging;
            _worksheet.PrinterSettings.HorizontalCentered = true;
            _worksheet.PrinterSettings.VerticalCentered = true;
            _worksheet.PrinterSettings.FitToPage = true;
            _worksheet.HeaderFooter.AlignWithMargins = true;
            _worksheet.HeaderFooter.ScaleWithDocument = true;
        }

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
                    using var _gridFont = _font;
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
                    using var _worksheet = grid.GetWorksheet();
                    using var _range = grid.GetRange();
                    var _row = _range.Start.Row;
                    var _column = _range.Start.Column;
                    SetFontColor( grid, _fontColor );
                    SetBackgroudColor( grid, _primaryBackColor );
                    SetHorizontalAligment( grid, _left );
                    _worksheet.Cells[ _row, _column ].Value = "Account";
                    _worksheet.Cells[ _row, _column + 1 ].Value = "Site";
                    _worksheet.Cells[ _row, _column + 2 ].Value = "Travel";
                    _worksheet.Cells[ _row, _column + 3 ].Value = "Expenses";
                    _worksheet.Cells[ _row, _column + 4 ].Value = "Contracts";
                    _worksheet.Cells[ _row, _column + 5 ].Value = "Grants";
                    _worksheet.Cells[ _row, _column + 6 ].Value = "_total";
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
        /// <param name = "excelRange" >
        /// The excelRange.
        /// </param>
        [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
        private protected void SetDarkColorRow( ExcelRange excelRange )
        {
            if( excelRange != null )
            {
                try
                {
                    excelRange.Style.Font.Color.SetColor( Color.Black );

                    using( _font )
                    {
                        excelRange.Style.Font.SetFromFont( _font );
                        excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelRange.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                        excelRange.Style.HorizontalAlignment = _center;
                        excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
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
        /// <param name = "excelRange" >
        /// The excelRange.
        /// </param>
        [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
        private protected void SetLightColorRow( ExcelRange excelRange )
        {
            if( excelRange != null )
            {
                try
                {
                    excelRange.Style.Font.Color.SetColor( _fontColor );

                    using( _font )
                    {
                        excelRange.Style.Font.SetFromFont( _font );
                        excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelRange.Style.Fill.BackgroundColor.SetColor( Color.White );
                        excelRange.Style.HorizontalAlignment = _center;
                        excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
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
        /// <param name = "excelRange" >
        /// The excelRange.
        /// </param>
        private protected void SetAlternatingRowColor( ExcelRange excelRange )
        {
            if( _worksheet != null
                && excelRange?.Start?.Row > -1
                && excelRange.Start.Column > -1
                && excelRange.End?.Row > -1
                && excelRange.End.Column > -1 )
            {
                try
                {
                    var _prc = 
                        _worksheet.Cells[ excelRange.Start.Row, excelRange.Start.Column,
                            excelRange.End.Row, excelRange.End.Column ];

                    for( var i = excelRange.Start.Row; i < excelRange.End.Row; i++ )
                    {
                        if( i % 2 == 0 )
                        {
                            SetLightColorRow( _prc );
                        }

                        if( i % 2 != 0 )
                        {
                            SetDarkColorRow( _prc );
                        }
                    }

                    SetNumericRowFormat( excelRange );
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
        /// <param name = "excelRange" >
        /// The excelRange.
        /// </param>
        private protected void SetNumericRowFormat( ExcelRange excelRange )
        {
            if( _worksheet != null
                && excelRange.Start.Row > -1
                && excelRange.Start.Column > -1
                && excelRange.End.Row > -1
                && excelRange.End.Column > -1 )
            {
                try
                {
                    using( excelRange )
                    {
                        excelRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        excelRange.Style.Numberformat.Format = "#,###";
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the dataTable format.
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
                    using var _range = grid.GetRange();
                    using var _gridFont = _titleFont;
                    _range.Style.Font.SetFromFont( _titleFont );
                    _range.Style.Border.BorderAround( ExcelBorderStyle.Thin );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    _range.Style.HorizontalAlignment = _center;
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
        /// <param name = "excelRange" >
        /// The excelRange.
        /// </param>
        private protected void SetTotalRowFormat( ExcelRange excelRange )
        {
            if( _worksheet != null
                && excelRange.Start.Row > -1
                && excelRange.Start.Column > -1
                && excelRange.End.Row > -1
                && excelRange.End.Column > -1 )
            {
                try
                {
                    var _total = _worksheet.Cells[ excelRange.Start.Row, excelRange.Start.Column, 
                        excelRange.Start.Row, excelRange.Start.Column + 6 ];

                    var _range = _worksheet.Cells[ excelRange.Start.Row, excelRange.Start.Column + 1, 
                        excelRange.Start.Row, excelRange.Start.Column + 6 ];

                    _total.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _total.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
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
