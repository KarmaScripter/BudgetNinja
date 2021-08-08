// // <copyright file=" <File _name> .cs" company="Terry D. Eppler">
// // Copyright (c) Terry Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Linq;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BudgetExecution.ExcelConfig" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class BudgetConfig : ExcelConfig
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;

        /// <summary>
        /// The title
        /// </summary>
        private protected Grid _title;

        /// <summary>
        /// The control number
        /// </summary>
        private protected Grid _controlNumber;

        /// <summary>
        /// The PRC
        /// </summary>
        private protected Grid _prc;

        /// <summary>
        /// The fte
        /// </summary>
        private protected Grid _fte;

        /// <summary>
        /// The awards
        /// </summary>
        private protected Grid _awards;

        /// <summary>
        /// The overtime
        /// </summary>
        private protected Grid _overtime;

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="text">The text.</param>
        public void AddComment( Grid grid, string text )
        {
            if( Validate.Grid( grid )
                && Verify.Input( text ) )
            {
                try
                {
                    using var _range = grid?.GetRange();
                    var _comment = _range?.AddComment( text, "Budget" );

                    if( _comment != null )
                    {
                        _comment.From.Row = _range.Start.Row;
                        _comment.From.Column = _range.Start.Column;
                        _comment.To.Row = _range.End.Row;
                        _comment.To.Column = _range.End.Column;
                        _comment.BackgroundColor = _primaryBackColor;
                        _comment.Font.FontName = "Consolas";
                        _comment.Font.Size = 8;
                        _comment.Font.Color = Color.Black;
                        _comment.Text = text;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the caption text.
        /// </summary>
        /// <param name="grid">The grid.</param>
        public void SetCaptionText( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _worksheet = grid.GetWorksheet();
                    var _row = grid.GetRange().Start.Row;
                    var _column = grid.GetRange().Start.Column;
                    _worksheet.Cells[ _row, _column ].Value = "Account";
                    _worksheet.Cells[ _row, _column + 1 ].Value = "Site";
                    _worksheet.Cells[ _row, _column + 2 ].Value = "Travel";
                    _worksheet.Cells[ _row, _column  + 3 ].Value = "Expenses";
                    _worksheet.Cells[ _row, _column  + 4 ].Value = "Contracts";
                    _worksheet.Cells[ _row, _column  + 5 ].Value = "Grants";
                    _worksheet.Cells[ _row, _column  + 6 ].Value = "_total";
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="text">The text.</param>
        public void SetText( Grid grid, IEnumerable<string> text )
        {
            if( Validate.Grid( grid )
                && text?.Any() == true 
                && grid.GetRange().Any() )
            {
                try
                {
                    foreach( var cell in grid.GetRange() )
                    {
                        foreach( var caption in text )
                        {
                            if( cell != null
                                && Verify.Input( caption ) )
                            {
                                cell.Value = caption;
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
        /// Sets the worksheet properties.
        /// </summary>
        /// <param name="worksheet">The worksheet.</param>
        public void SetWorksheetProperties( ExcelWorksheet worksheet )
        {
            if( worksheet != null )
            {
                worksheet = Workbook.Worksheets[ 1 ];
                worksheet.View.ShowGridLines = false;
                worksheet.View.ZoomScale = _zoomLevel;
                worksheet.View.PageLayoutView = true;
                worksheet.View.ShowHeaders = true;
                worksheet.DefaultRowHeight = _rowHeight;
                worksheet.DefaultColWidth = _columnWidth;
                worksheet.PrinterSettings.ShowHeaders = false;
                worksheet.PrinterSettings.ShowGridLines = false;
                worksheet.PrinterSettings.LeftMargin = _leftMargin;
                worksheet.PrinterSettings.RightMargin = _rightMargin;
                worksheet.PrinterSettings.TopMargin = _topMargin;
                worksheet.PrinterSettings.BottomMargin = _bottomMarging;
                worksheet.PrinterSettings.HorizontalCentered = true;
                worksheet.PrinterSettings.VerticalCentered = true;
                worksheet.PrinterSettings.FitToPage = true;
                worksheet.HeaderFooter.AlignWithMargins = true;
                worksheet.HeaderFooter.ScaleWithDocument = true;
            }
        }

        /// <summary>
        /// Sets the header footer text.
        /// </summary>
        /// <param name="headerText">The header text.</param>
        public void SetHeaderFooterText( string headerText )
        {
            if( Verify.Input( headerText ) )
            {
                try
                {
                    var _header = Worksheet.HeaderFooter.FirstHeader;
                    _header.CenteredText = headerText;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}