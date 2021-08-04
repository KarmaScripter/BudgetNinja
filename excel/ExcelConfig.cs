// <copyright file = "ExcelConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

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
        // **************************************************************************************************************************
        // ******************************************************      FIELDS    ****************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The font color
        /// </summary>
        private protected readonly Color _fontColor = Color.Black;

        /// <summary>
        /// The data font
        /// </summary>
        private protected readonly Font _dataFont = new Font( "Consolas", 8, FontStyle.Regular );

        /// <summary>
        /// The header font
        /// </summary>
        private protected readonly Font _headerFont = new Font( "Consolas", 10, FontStyle.Bold );

        /// <summary>
        /// The title font
        /// </summary>
        private protected readonly Font _titleFont = new Font( "Consolas", 12, FontStyle.Bold );

        /// <summary>
        /// The header image width
        /// </summary>
        private protected readonly double _headerImageWidth = 1.75;

        /// <summary>
        /// The header image height
        /// </summary>
        private protected readonly double _headerImageHeight = 0.85;

        /// <summary>
        /// The footer image width
        /// </summary>
        private protected readonly double _footerImageWidth = 2.04;

        /// <summary>
        /// The footer image height
        /// </summary>
        private protected readonly double _footerImageHeight = 0.70;

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
                    using var font = _dataFont;
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
                    using var range = grid.GetRange();
                    range.Style.Font.Color.SetColor( Color.Black );
                    using var font = _dataFont;
                    range.Style.Font.SetFromFont( _dataFont );
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor( _primaryBackColor );
                    range.Style.HorizontalAlignment = _center;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
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
                    using var range = grid.GetRange();
                    range.Style.Font.Color.SetColor( _fontColor );
                    using var font = _dataFont;
                    range.Style.Font.SetFromFont( _dataFont );
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor( Color.White );
                    range.Style.HorizontalAlignment = _center;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
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
                    using var worksheet = grid.GetWorksheet();
                    using var range = grid.GetRange();

                    for( var i = range.Start.Row; i < range.End.Row; i++ )
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
                    using var range = grid.GetRange();
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Numberformat.Format = "#,###";
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
                    using var range = grid.GetRange();
                    SetCaptionFormat( grid );
                    using var titlefont = _headerFont;
                    range.Style.Font.SetFromFont( font );
                    range.Style.Border.BorderAround( borderstyle );
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
        /// <param name = "grid" >
        /// The grid.
        /// </param>
        public void SetTotalRowFormat( Grid grid )
        {
            if( Validate.Grid( grid ) )
            {
                try
                {
                    using var worksheet = grid.GetWorksheet();
                    using var range = grid.GetRange();

                    var total = worksheet.Cells[ range.Start.Row, range.Start.Column, range.Start.Row,
                        range.Start.Column + 6 ];

                    total.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    total?.Style?.Fill?.BackgroundColor?.SetColor( _primaryBackColor );

                    var data = worksheet.Cells[ range.Start.Row, range.Start.Column + 1, range.Start.Row,
                        range.Start.Column + 6 ];

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
