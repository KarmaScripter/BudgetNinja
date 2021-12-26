// <copyright file = "ExcelConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OfficeOpenXml.Style;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ExcelBase"/>
    /// <seealso cref = "IDisposable"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedParameter.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class ExcelConfig : ExcelBase
    {
        /// <summary>
        /// The font color
        /// </summary>
        private protected Color _fontColor { get; set; } = Color.Black;

        /// <summary>
        /// The Data font
        /// </summary>
        public Font DataFont { get; set; } = new Font( "Consolas", 8, FontStyle.Regular );

        /// <summary>
        /// The header font
        /// </summary>
        public Font HeaderFont { get; set; } = new Font( "Consolas", 10, FontStyle.Bold );

        /// <summary>
        /// The title font
        /// </summary>
        public Font TitleFont { get; set; } = new Font( "Consolas", 12, FontStyle.Bold );

        /// <summary>
        /// The header image width
        /// </summary>
        public double HeaderImageWidth { get; set; } = 1.75;

        /// <summary>
        /// The header image height
        /// </summary>
        public double HeaderImageHeight { get; set; } = 0.85;

        /// <summary>
        /// The footer image width
        /// </summary>
        public double FooterImageWidth { get; set; } = 2.04;

        /// <summary>
        /// The footer image height
        /// </summary>
        public double FooterImageHeight { get; set; } = 0.70;
        
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
        
        /// <summary>
        /// Sets the table format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetTableFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _font = DataFont;
                    SetFontColor( grid, _fontColor );
                    SetBackgroudColor( grid, PrimaryBackColor );
                    SetHorizontalAligment( grid, Left );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the caption format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetCaptionFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    SetFontColor( grid, _fontColor );
                    SetBackgroudColor( grid, PrimaryBackColor );
                    SetHorizontalAligment( grid, Left );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the dark row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetDarkRowFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _range = grid.GetRange();
                    _range.Style.Font.Color.SetColor( Color.Black );
                    using var _font = DataFont;
                    _range.Style.Font.SetFromFont( DataFont );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );
                    _range.Style.HorizontalAlignment = Center;
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the light row format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetLightRowFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _range = grid.GetRange();
                    _range.Style.Font.Color.SetColor( _fontColor );
                    using var _font = DataFont;
                    _range.Style.Font.SetFromFont( DataFont );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( Color.White );
                    _range.Style.HorizontalAlignment = Center;
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// Sets the alternating color format.
        /// </summary>
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetAlternatingColorFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _excelWorksheet = grid.GetWorksheet();
                    using var _range = grid.GetRange();

                    for( var i = _range.Start.Row; i < _range.End.Row; i++ )
                    {
                        if( i % 2 == 0 )
                        {
                            SetLightRowFormat( grid );
                        }

                        if( i % 2 != 0 )
                        {
                            SetDarkRowFormat( grid );
                        }
                    }

                    SetNumericRowFormat( grid );
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
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetNumericRowFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _range = grid.GetRange();
                    _range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    _range.Style.Numberformat.Format = "#,###";
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
        /// <param name = "font" >
        /// The font.
        /// </param>
        /// <param name = "borderstyle" >
        /// The borderstyle.
        /// </param>
        public void SetTableFormat( Grid grid, Font font,
            ExcelBorderStyle borderstyle = ExcelBorderStyle.Thin )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _range = grid.GetRange();
                    SetCaptionFormat( grid );
                    using var _font = HeaderFont;
                    _range.Style.Font.SetFromFont( font );
                    _range.Style.Border.BorderAround( borderstyle );
                    _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _range.Style.Fill.BackgroundColor.SetColor( PrimaryBackColor );
                    _range.Style.HorizontalAlignment = Center;
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
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetTotalRowFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var _excelWorksheet = grid.GetWorksheet();
                    using var _range = grid.GetRange();

                    var _total = _excelWorksheet.Cells[ _range.Start.Row, _range.Start.Column, 
                        _range.Start.Row, _range.Start.Column + 6 ];

                    _total.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _total?.Style?.Fill?.BackgroundColor?.SetColor( PrimaryBackColor );

                    var data = _excelWorksheet.Cells[ _range.Start.Row, _range.Start.Column + 1, _range.Start.Row,
                        _range.Start.Column + 6 ];

                    data.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
    }
}
