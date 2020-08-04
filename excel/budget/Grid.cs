// <copyright file="Grid.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using OfficeOpenXml;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Grid : ExcelCellBase, IGrid
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// The range
        /// </summary>
        private readonly ExcelRange Range;

        /// <summary>
        /// The worksheet
        /// </summary>
        private readonly ExcelWorksheet Worksheet;

        /// <summary>
        /// The address
        /// </summary>
        private readonly ExcelAddress Address;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        public Grid()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "worksheet" >
        /// </param>
        /// <param name = "range" >
        /// The range.
        /// </param>
        public Grid( ExcelWorksheet worksheet, ExcelRange range )
        {
            Worksheet = worksheet;
            Range = range;
            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row, Range.End.Row );
            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "worksheet" >
        /// The worksheet.
        /// </param>
        /// <param name = "address" >
        /// The address.
        /// </param>
        public Grid( ExcelWorksheet worksheet, ExcelAddress address )
        {
            Worksheet = worksheet;
            Address = address;
            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
            Range = Worksheet.Cells[ From.Row, From.Column, To.Row, To.Column ];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "worksheet" >
        /// </param>
        /// <param name = "fromrow" >
        /// The fromrow.
        /// </param>
        /// <param name = "fromcolumn" >
        /// The fromcolumn.
        /// </param>
        /// <param name = "torow" >
        /// The torow.
        /// </param>
        /// <param name = "tocolumn" >
        /// The tocolumn.
        /// </param>
        public Grid( ExcelWorksheet worksheet, int fromrow = 1, int fromcolumn = 1,
            int torow = 55, int tocolumn = 12 )
        {
            Worksheet = worksheet;
            Range = Worksheet.Cells[ fromrow, fromcolumn, torow, tocolumn ];
            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row, Range.End.Row );
            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "worksheet" >
        /// </param>
        /// <param name = "cell" >
        /// The cell.
        /// </param>
        public Grid( ExcelWorksheet worksheet, IReadOnlyList<int> cell )
        {
            Worksheet = worksheet;
            Range = Worksheet.Cells[ cell[ 0 ], cell[ 1 ], cell[ 2 ], cell[ 3 ] ];
            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row, Range.End.Row );
            From = ( Address.Start.Row, Address.Start.Column );
            To = ( Address.End.Row, Address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "worksheet" >
        /// </param>
        /// <param name = "from" >
        /// From.
        /// </param>
        /// <param name = "to" >
        /// To.
        /// </param>
        public Grid( ExcelWorksheet worksheet, (int Row, int Column) from, (int Row, int Column) to )
        {
            Worksheet = worksheet;
            Range = Worksheet.Cells[ from.Row, from.Column, to.Row, to.Column ];
            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.End.Row, Range.End.Row );
            From = from;
            To = to;
        }

        public Grid( ExcelWorksheet worksheet, (int Row, int Column) from )
        {
            Worksheet = worksheet;
            Range = Worksheet.Cells[ from.Row, from.Column ];

            Address = new ExcelAddress( Range.Start.Row, Range.Start.Column, Range.Start.Row,
                Range.Start.Column );

            From = from;
            To = From;
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public (int Row, int Column) From { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public (int Row, int Column) To { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelAddress GetAddress()
        {
            try
            {
                return Address.Columns > 0
                    ? Address
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelRange GetRange()
        {
            try
            {
                return Range.Columns > 0
                    ? Range
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetWorksheet()
        {
            try
            {
                return Verify.Input( Worksheet.Name )
                    ? Worksheet
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Counts the cells.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        /// <returns>
        /// </returns>
        public int CountCells( ExcelRange range )
        {
            try
            {
                return range != null
                    ? range.Rows * range.Columns
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1;
            }
        }

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetRowCount()
        {
            try
            {
                return Range.Rows > 0
                    ? Range.Rows
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetColumnCount()
        {
            try
            {
                return Range.Columns > 0
                    ? Range.Columns
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}