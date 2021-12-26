// <copyright file = "ExcelSettings.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
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
    public abstract class ExcelSettings
    {
        /// <summary>
        /// The index
        /// </summary>
        public int Index { get; set; } = 10;

        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; set; } =
            ConfigurationManager.AppSettings[ Document.Budget.ToString() ];

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; } = @"\<Source>\<name>";

        /// <summary>
        /// The background color
        /// </summary>
        public Color PrimaryBackColor { get; set; } = Color.FromArgb( 255, 242, 242, 242 );

        /// <summary>
        /// The secondary back color
        /// </summary>
        public Color SecondaryBackColor { get; set; } = Color.FromArgb( 255, 221, 235, 247 );

        /// <summary>
        /// The left
        /// </summary>
        public ExcelHorizontalAlignment Left { get; set; } = ExcelHorizontalAlignment.Left;

        /// <summary>
        /// The center
        /// </summary>
        public ExcelHorizontalAlignment Center { get; set; } =
            ExcelHorizontalAlignment.CenterContinuous;

        /// <summary>
        /// The right
        /// </summary>
        public ExcelHorizontalAlignment Right { get; set; } = ExcelHorizontalAlignment.Right;

        /// <summary>
        /// The row height
        /// </summary>
        public double RowHeight { get; set; } = 0.22;

        /// <summary>
        /// The column width
        /// </summary>
        public double ColumnWidth { get; set; } = 0.75;

        /// <summary>
        /// The top margin
        /// </summary>
        public int TopMargin { get; set; } = 1;

        /// <summary>
        /// The bottom marging
        /// </summary>
        public int BottomMargin { get; set; } = 1;

        /// <summary>
        /// The left margin
        /// </summary>
        public decimal LeftMargin { get; set; } = 0.25m;

        /// <summary>
        /// The right margin
        /// </summary>
        public decimal RightMargin { get; set; } = 0.25m;

        /// <summary>
        /// The header margin
        /// </summary>
        public decimal HeaderMargin { get; set; } = 0.25m;

        /// <summary>
        /// The footer margin
        /// </summary>
        public decimal FooterMargin { get; set; } = 0.25m;

        /// <summary>
        /// The column count
        /// </summary>
        public int ColumnCount { get; set; } = 12;

        /// <summary>
        /// The row count
        /// </summary>
        public int RowCount { get; set; } = 55;

        /// <summary>
        /// The zoom level
        /// </summary>
        public int ZoomLevel { get; set; } = 100;

        /// <summary>
        /// 
        /// </summary>
        public enum BorderSide
        {
            /// <summary>The top</summary>
            Top,

            /// <summary>The bottom</summary>
            Bottom,

            /// <summary>The left</summary>
            Left,

            /// <summary>The right</summary>
            Right
        };
    }
}
