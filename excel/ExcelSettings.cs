// <copyright file = "ExcelSettings.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

    using System;
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
        private protected readonly int _index = 10;

        /// <summary>
        /// The file path
        /// </summary>
        private protected readonly string _filePath =
            ConfigurationManager.AppSettings[ Document.Budget.ToString() ];

        /// <summary>
        /// The file name
        /// </summary>
        private protected readonly string _fileName = @"\<_source>\<name>";

        /// <summary>
        /// The background color
        /// </summary>
        private protected readonly Color _primaryBackColor = Color.FromArgb( 255, 242, 242, 242 );

        /// <summary>
        /// The secondary back color
        /// </summary>
        private protected readonly Color _secondaryBackColor = Color.FromArgb( 255, 221, 235, 247 );

        /// <summary>
        /// The left
        /// </summary>
        private protected readonly ExcelHorizontalAlignment _left = ExcelHorizontalAlignment.Left;

        /// <summary>
        /// The center
        /// </summary>
        private protected readonly ExcelHorizontalAlignment _center =
            ExcelHorizontalAlignment.CenterContinuous;

        /// <summary>
        /// The right
        /// </summary>
        private protected readonly ExcelHorizontalAlignment _right = ExcelHorizontalAlignment.Right;

        /// <summary>
        /// The row height
        /// </summary>
        private protected readonly double _rowHeight = 0.22;

        /// <summary>
        /// The column width
        /// </summary>
        private protected readonly double _columnWidth = 0.75;

        /// <summary>
        /// The top margin
        /// </summary>
        private protected readonly int _topMargin = 1;

        /// <summary>
        /// The bottom marging
        /// </summary>
        private protected readonly int _bottomMarging = 1;

        /// <summary>
        /// The left margin
        /// </summary>
        private protected readonly decimal _leftMargin = 0.25m;

        /// <summary>
        /// The right margin
        /// </summary>
        private protected readonly decimal _rightMargin = 0.25m;

        /// <summary>
        /// The header margin
        /// </summary>
        private protected readonly decimal _headerMargin = 0.25m;

        /// <summary>
        /// The footer margin
        /// </summary>
        private protected readonly decimal _footerMargin = 0.25m;

        /// <summary>
        /// The column count
        /// </summary>
        private protected readonly int _columnCount = 12;

        /// <summary>
        /// The row count
        /// </summary>
        private protected readonly int _rowCount = 55;

        /// <summary>
        /// The zoom level
        /// </summary>
        private protected readonly int _zoomLevel = 100;

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
