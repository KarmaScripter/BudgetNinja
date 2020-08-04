// <copyright file="SectionConfig.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************************   ASSEMBLIES   **************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "BudgetConfig"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class SectionConfig : BudgetConfig
    {
        // **************************************************************************************************************************
        // ******************************************************   PROPERTIES   ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private protected Grid Title { get; set; }

        /// <summary>
        /// Gets or sets the control number.
        /// </summary>
        /// <value>
        /// The control number.
        /// </value>
        private protected Grid ControlNumber { get; set; }

        /// <summary>
        /// Gets or sets the PRC.
        /// </summary>
        /// <value>
        /// The PRC.
        /// </value>
        private protected Grid PRC { get; set; }

        /// <summary>
        /// Gets or sets the fte.
        /// </summary>
        /// <value>
        /// The fte.
        /// </value>
        private protected Grid FTE { get; set; }

        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        /// <value>
        /// The awards.
        /// </value>
        private protected Grid Awards { get; set; }

        /// <summary>
        /// Gets or sets the overtime.
        /// </summary>
        /// <value>
        /// The overtime.
        /// </value>
        private protected Grid Overtime { get; set; }

        // **************************************************************************************************************************
        // ******************************************************     METHODS   *****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name = "grid" >
        /// </param>
        /// <param name = "text" >
        /// The text.
        /// </param>
        public void AddComment( Grid grid, string text )
        {
            if( Verify.Grid( grid )
                && Verify.Input( text ) )
            {
                try
                {
                    using var range = grid.GetRange();
                    var comment = range.AddComment( text, "Budget" );
                    comment.From.Row = range.Start.Row;
                    comment.From.Column = range.Start.Column;
                    comment.To.Row = range.End.Row;
                    comment.To.Column = range.End.Column;
                    comment.BackgroundColor = PrimaryBackColor;
                    comment.Font.FontName = "Consolas";
                    comment.Font.Size = 8;
                    comment.Font.Color = Color.Black;
                    comment.Text = text;
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
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetCaptionText( Grid grid )
        {
            if( Verify.Grid( grid ) )
            {
                try
                {
                    using var worksheet = grid.GetWorksheet();
                    var row = grid.GetRange().Start.Row;
                    var column = grid.GetRange().Start.Column;
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
        /// Sets the text.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "text" >
        /// The text.
        /// </param>
        public void SetText( Grid grid, IEnumerable<string> text )
        {
            if( Verify.Grid( grid )
                && text?.Any() == true )
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
        /// <param name = "worksheet" >
        /// The worksheet.
        /// </param>
        public void SetWorksheetProperties( ExcelWorksheet worksheet )
        {
            if( worksheet != null )
            {
                worksheet = Workbook.Worksheets[ 1 ];
                worksheet.View.ShowGridLines = false;
                worksheet.View.ZoomScale = ZoomLevel;
                worksheet.View.PageLayoutView = true;
                worksheet.View.ShowHeaders = true;
                worksheet.DefaultRowHeight = RowHeight;
                worksheet.DefaultColWidth = ColumnWidth;
                worksheet.PrinterSettings.ShowHeaders = false;
                worksheet.PrinterSettings.ShowGridLines = false;
                worksheet.PrinterSettings.LeftMargin = LeftMargin;
                worksheet.PrinterSettings.RightMargin = RightMargin;
                worksheet.PrinterSettings.TopMargin = TopMargin;
                worksheet.PrinterSettings.BottomMargin = BottomMarging;
                worksheet.PrinterSettings.HorizontalCentered = true;
                worksheet.PrinterSettings.VerticalCentered = true;
                worksheet.PrinterSettings.FitToPage = true;
                worksheet.HeaderFooter.AlignWithMargins = true;
                worksheet.HeaderFooter.ScaleWithDocument = true;
            }
        }

        /// <summary>
        /// Sets the worksheet header text.
        /// </summary>
        /// <param name = "headertext" >
        /// The headertext.
        /// </param>
        public void SetHeaderFooterText( string headertext )
        {
            if( Verify.Input( headertext ) )
            {
                try
                {
                    var header = Worksheet.HeaderFooter.FirstHeader;
                    header.CenteredText = headertext;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}