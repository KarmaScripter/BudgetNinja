// <copyright file = "ExcelBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
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
    public abstract class ExcelBase : ExcelSettings
    {
        /// <summary>
        /// Gets or sets the file information.
        /// </summary>
        /// <value>
        /// The file information.
        /// </value>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// Gets or sets the excel.
        /// </summary>
        /// <value>
        /// The excel.
        /// </value>
        public ExcelPackage Excel { get; set; }

        /// <summary>
        /// Gets or sets the workbook.
        /// </summary>
        /// <value>
        /// The workbook.
        /// </value>
        public ExcelWorkbook Workbook { get; set; }

        /// <summary>
        /// Gets or sets the workSheet.
        /// </summary>
        /// <value>
        /// The workSheet.
        /// </value>
        public ExcelWorksheet Worksheet { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public IEnumerable<ExcelComment> Comment { get; set; }

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public IEnumerable<DataRow> Data { get; set; }
        
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
                    using var _range = grid.GetRange();
                    _range.AutoFitColumns( width );
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( color );
                    _range.Style.HorizontalAlignment = Left;
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();
                    _range.Style.Font.SetFromFont( font );
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();
                    _range.Style.Font.Color.SetColor( color );
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();

                    switch( side )
                    {
                        case BorderSide.Top:
                        {
                            _range.Style.Border.Top.Style = style;
                            break;
                        }

                        case BorderSide.Bottom:
                        {
                            _range.Style.Border.Bottom.Style = style;
                            break;
                        }

                        case BorderSide.Right:
                        {
                            _range.Style.Border.Right.Style = style;
                            break;
                        }

                        case BorderSide.Left:
                        {
                            _range.Style.Border.Left.Style = style;
                            break;
                        }

                        default:
                        {
                            _range.Style.Border.BorderAround( ExcelBorderStyle.None );
                            break;
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
                    using var _range = grid.GetRange();
                    _range.Style.HorizontalAlignment = align;
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();
                    _range.Style.VerticalAlignment = align;
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
                    using var _range = grid.GetRange();
                    _range.Merge = true;
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
        public static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
