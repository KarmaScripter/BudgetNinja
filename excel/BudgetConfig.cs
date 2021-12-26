// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

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
    [ SuppressMessage( "ReSharper", "LoopCanBePartlyConvertedToQuery" ) ]
    public abstract class BudgetConfig : ExcelConfig
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public Grid Title { get; set; }

        /// <summary>
        /// The control number
        /// </summary>
        public Grid ControlNumber { get; set; }

        /// <summary>
        /// The ProgramResultCodes
        /// </summary>
        public Grid PRC { get; set; }

        /// <summary>
        /// The fte
        /// </summary>
        public Grid FTE { get; set; }

        /// <summary>
        /// The awards
        /// </summary>
        public Grid Awards { get; set; }

        /// <summary>
        /// The overtime
        /// </summary>
        public Grid Overtime { get; set; }

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
                    var _excelComment = _range?.AddComment( text, "Budget" );

                    if( _excelComment != null )
                    {
                        _excelComment.From.Row = _range.Start.Row;
                        _excelComment.From.Column = _range.Start.Column;
                        _excelComment.To.Row = _range.End.Row;
                        _excelComment.To.Column = _range.End.Column;
                        _excelComment.BackgroundColor = PrimaryBackColor;
                        _excelComment.Font.FontName = "Consolas";
                        _excelComment.Font.Size = 8;
                        _excelComment.Font.Color = Color.Black;
                        _excelComment.Text = text;
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
                    using var _sheet = grid.GetWorksheet();
                    var _row = grid.GetRange().Start.Row;
                    var _column = grid.GetRange().Start.Column;
                    _sheet.Cells[ _row, _column ].Value = "Account";
                    _sheet.Cells[ _row, _column + 1 ].Value = "Site";
                    _sheet.Cells[ _row, _column + 2 ].Value = "Travel";
                    _sheet.Cells[ _row, _column  + 3 ].Value = "Expenses";
                    _sheet.Cells[ _row, _column  + 4 ].Value = "Contracts";
                    _sheet.Cells[ _row, _column  + 5 ].Value = "Grants";
                    _sheet.Cells[ _row, _column  + 6 ].Value = "Total";
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
        /// Sets the workSheet properties.
        /// </summary>
        /// <param name="workSheet">The workSheet.</param>
        public void SetWorksheetProperties( ExcelWorksheet workSheet )
        {
            if( workSheet != null )
            {
                workSheet = Workbook.Worksheets[ 1 ];
                workSheet.View.ShowGridLines = false;
                workSheet.View.ZoomScale = ZoomLevel;
                workSheet.View.PageLayoutView = true;
                workSheet.View.ShowHeaders = true;
                workSheet.DefaultRowHeight = RowHeight;
                workSheet.DefaultColWidth = ColumnWidth;
                workSheet.PrinterSettings.ShowHeaders = false;
                workSheet.PrinterSettings.ShowGridLines = false;
                workSheet.PrinterSettings.LeftMargin = LeftMargin;
                workSheet.PrinterSettings.RightMargin = RightMargin;
                workSheet.PrinterSettings.TopMargin = TopMargin;
                workSheet.PrinterSettings.BottomMargin = BottomMargin;
                workSheet.PrinterSettings.HorizontalCentered = true;
                workSheet.PrinterSettings.VerticalCentered = true;
                workSheet.PrinterSettings.FitToPage = true;
                workSheet.HeaderFooter.AlignWithMargins = true;
                workSheet.HeaderFooter.ScaleWithDocument = true;
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