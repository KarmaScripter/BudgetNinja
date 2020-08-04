// <copyright file="SheetConfig.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public abstract class SheetConfig
    {
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The index
        /// </summary>
        private protected readonly int Index = 10;

        /// <summary>
        /// The file path
        /// </summary>
        private protected readonly string FilePath =
            ConfigurationManager.AppSettings[ Document.Budget.ToString() ];

        /// <summary>
        /// The file name
        /// </summary>
        private protected readonly string FileName = @"\<Source>\<name>";

        /// <summary>
        /// The background color
        /// </summary>
        private protected readonly Color PrimaryBackColor = Color.FromArgb( 255, 242, 242, 242 );

        /// <summary>
        /// The secondary back color
        /// </summary>
        private protected readonly Color SecondaryBackColor = Color.FromArgb( 255, 221, 235, 247 );

        /// <summary>
        /// The left
        /// </summary>
        private protected readonly ExcelHorizontalAlignment Left = ExcelHorizontalAlignment.Left;

        /// <summary>
        /// The center
        /// </summary>
        private protected readonly ExcelHorizontalAlignment Center =
            ExcelHorizontalAlignment.CenterContinuous;

        /// <summary>
        /// The right
        /// </summary>
        private protected readonly ExcelHorizontalAlignment Right = ExcelHorizontalAlignment.Right;

        /// <summary>
        /// The row height
        /// </summary>
        private protected readonly double RowHeight = 0.22;

        /// <summary>
        /// The column width
        /// </summary>
        private protected readonly double ColumnWidth = 0.75;

        /// <summary>
        /// The top margin
        /// </summary>
        private protected readonly int TopMargin = 1;

        /// <summary>
        /// The bottom marging
        /// </summary>
        private protected readonly int BottomMarging = 1;

        /// <summary>
        /// The left margin
        /// </summary>
        private protected readonly decimal LeftMargin = 0.25m;

        /// <summary>
        /// The right margin
        /// </summary>
        private protected readonly decimal RightMargin = 0.25m;

        /// <summary>
        /// The header margin
        /// </summary>
        private protected readonly decimal HeaderMargin = 0.25m;

        /// <summary>
        /// The footer margin
        /// </summary>
        private protected readonly decimal FooterMargin = 0.25m;

        /// <summary>
        /// The column count
        /// </summary>
        private protected readonly int ColumnCount = 12;

        /// <summary>
        /// The row count
        /// </summary>
        private protected readonly int RowCount = 55;

        /// <summary>
        /// The zoom level
        /// </summary>
        private protected readonly int ZoomLevel = 100;

        /// <summary>
        /// 
        /// </summary>
        public enum BorderSide
        {
            Top,

            Bottom,

            Left,

            Right
        };

        // **************************************************************************************************************************
        // ******************************************************   PROPERTIES   ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the file information.
        /// </summary>
        /// <value>
        /// The file information.
        /// </value>
        private protected FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets the excel.
        /// </summary>
        /// <value>
        /// The excel.
        /// </value>
        private protected ExcelPackage Excel { get; set; }

        /// <summary>
        /// Gets or sets the workbook.
        /// </summary>
        /// <value>
        /// The workbook.
        /// </value>
        private protected ExcelWorkbook Workbook { get; set; }

        /// <summary>
        /// Gets or sets the worksheet.
        /// </summary>
        /// <value>
        /// The worksheet.
        /// </value>
        private protected ExcelWorksheet Worksheet { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        private protected IEnumerable<ExcelComment> Comment { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected IEnumerable<DataRow> Data { get; set; }

        // **************************************************************************************************************************
        // ******************************************************     METHODS   *****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Sets the width of the column.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "width" >
        /// The width.
        /// </param>
        public void SetColumnWidth( Grid grid, double width )
        {
            if( grid?.GetWorksheet() != null
                && width > 0d )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.AutoFitColumns( width );
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the color of the backgroud.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "color" >
        /// The color.
        /// </param>
        public void SetBackgroudColor( Grid grid, Color color )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null
                && color != Color.Empty )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor( color );
                    range.Style.HorizontalAlignment = Left;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the range font.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "font" >
        /// The font.
        /// </param>
        public void SetRangeFont( Grid grid, Font font )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null
                && font != null )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Style.Font.SetFromFont( font );
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the color of the font.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "color" >
        /// The color.
        /// </param>
        public void SetFontColor( Grid grid, Color color )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null
                && color != Color.Empty )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Style.Font.Color.SetColor( color );
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the border style.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "side" >
        /// The side.
        /// </param>
        /// <param name = "style" >
        /// The style.
        /// </param>
        public void SetBorderStyle( Grid grid, BorderSide side, ExcelBorderStyle style )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null
                && Enum.IsDefined( typeof( ExcelBorderStyle ), style )
                && Enum.IsDefined( typeof( BorderSide ), side ) )
            {
                try
                {
                    using var range = grid.GetRange();

                    switch( side )
                    {
                        case BorderSide.Top:
                        {
                            range.Style.Border.Top.Style = style;
                            break;
                        }

                        case BorderSide.Bottom:
                        {
                            range.Style.Border.Bottom.Style = style;
                            break;
                        }

                        case BorderSide.Right:
                        {
                            range.Style.Border.Right.Style = style;
                            break;
                        }

                        case BorderSide.Left:
                        {
                            range.Style.Border.Left.Style = style;
                            break;
                        }

                        default:
                        {
                            range.Style.Border.BorderAround( ExcelBorderStyle.None );
                            break;
                        }
                    }
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the horizontal aligment.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "align" >
        /// The align.
        /// </param>
        public void SetHorizontalAligment( Grid grid, ExcelHorizontalAlignment align )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null
                && Enum.IsDefined( typeof( ExcelHorizontalAlignment ), align ) )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Style.HorizontalAlignment = align;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Sets the vertical aligment.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        /// <param name = "align" >
        /// The align.
        /// </param>
        public void SetVerticalAligment( Grid grid, ExcelVerticalAlignment align )
        {
            if( grid?.GetWorksheet() != null
                && Enum.IsDefined( typeof( ExcelVerticalAlignment ), align ) )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Style.VerticalAlignment = align;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Merges the cells.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void MergeCells( Grid grid )
        {
            if( grid?.GetWorksheet() != null
                && grid?.GetRange() != null )
            {
                try
                {
                    using var range = grid.GetRange();
                    range.Merge = true;
                }
                catch( Exception ex )
                {
                    using var error = new Error( ex );
                    error?.SetText();
                    error?.ShowDialog();
                }
            }
        }
    }
}