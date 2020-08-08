// // <copyright file = "ExcelSettings.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ******************************   ASSEMBLIES   ****************************************************************************
    // **************************************************************************************************************************

    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Threading;
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
    }
}