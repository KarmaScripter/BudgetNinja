// <copyright file = "Grid.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OfficeOpenXml;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class Grid : ExcelCellBase, IGrid
    {
        /// <summary>
        /// The range
        /// </summary>
        private protected ExcelRange _range;

        /// <summary>
        /// The workSheet
        /// </summary>
        private protected ExcelWorksheet _worksheet;

        /// <summary>
        /// The address
        /// </summary>
        private protected ExcelAddress _address;

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        private protected (int Row, int Column) _from;

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        private protected (int Row, int Column) _to;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        public Grid()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "workSheet" >
        /// </param>
        /// <param name = "range" >
        /// The range.
        /// </param>
        public Grid( ExcelWorksheet workSheet, ExcelRange range )
        {
            _worksheet = workSheet;
            _range = range;

            _address = new ExcelAddress( _range.Start.Row, _range.Start.Column, 
                _range.End.Row, _range.End.Row );

            _from = ( _address.Start.Row, _address.Start.Column );
            _to = ( _address.End.Row, _address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "workSheet" >
        /// The workSheet.
        /// </param>
        /// <param name = "address" >
        /// The address.
        /// </param>
        public Grid( ExcelWorksheet workSheet, ExcelAddress address )
        {
            _worksheet = workSheet;
            _address = address;
            _from = ( _address.Start.Row, _address.Start.Column );
            _to = ( _address.End.Row, _address.End.Column );
            _range = _worksheet.Cells[ _from.Row, _from.Column, _to.Row, _to.Column ];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "workSheet" >
        /// </param>
        /// <param name = "fromRow" >
        /// The fromRow.
        /// </param>
        /// <param name = "fromColumn" >
        /// The fromColumn.
        /// </param>
        /// <param name = "toRow" >
        /// The toRow.
        /// </param>
        /// <param name = "toColumn" >
        /// The toColumn.
        /// </param>
        public Grid( ExcelWorksheet workSheet, int fromRow = 1, int fromColumn = 1,
            int toRow = 55, int toColumn = 12 )
        {
            _worksheet = workSheet;
            _range = _worksheet.Cells[ fromRow, fromColumn, toRow, toColumn ];
            _address = new ExcelAddress( _range.Start.Row, _range.Start.Column, _range.End.Row, _range.End.Row );
            _from = ( _address.Start.Row, _address.Start.Column );
            _to = ( _address.End.Row, _address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "workSheet" >
        /// </param>
        /// <param name = "cell" >
        /// The cell.
        /// </param>
        public Grid( ExcelWorksheet workSheet, IReadOnlyList<int> cell )
        {
            _worksheet = workSheet;
            _range = _worksheet.Cells[ cell[ 0 ], cell[ 1 ], cell[ 2 ], cell[ 3 ] ];

            _address = new ExcelAddress( _range.Start.Row, _range.Start.Column, _range.End.Row,
                _range.End.Column );

            _from = ( _address.Start.Row, _address.Start.Column );
            _to = ( _address.End.Row, _address.End.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Grid"/> class.
        /// </summary>
        /// <param name = "workSheet" >
        /// </param>
        /// <param name = "from" >
        /// From.
        /// </param>
        /// <param name = "to" >
        /// To.
        /// </param>
        public Grid( ExcelWorksheet workSheet, (int Row, int Column) from, (int Row, int Column) to )
        {
            _worksheet = workSheet;
            _range = _worksheet.Cells[ from.Row, from.Column, to.Row, to.Column ];
            _address = new ExcelAddress( _range.Start.Row, _range.Start.Column, _range.End.Row, _range.End.Row );
            _from = from;
            _to = to;
        }

        /// <summary>Initializes a new instance of the
        /// <see cref="Grid"/> class.
        /// </summary>
        /// <param name="workSheet">
        /// The work sheet.
        /// </param>
        /// <param name="from">
        /// From.
        /// </param>
        public Grid( ExcelWorksheet workSheet, (int Row, int Column) from )
        {
            _worksheet = workSheet;
            _range = _worksheet.Cells[ from.Row, from.Column ];

            _address = new ExcelAddress( _range.Start.Row, _range.Start.Column, _range.Start.Row,
                _range.Start.Column );

            _from = from;
            _to = _from;
        }
        
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelAddress GetAddress()
        {
            try
            {
                return _address.Columns > 0
                    ? _address
                    : default( ExcelAddress );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ExcelAddress );
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
                return _range.Columns > 0
                    ? _range
                    : default( ExcelRange );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ExcelRange );
            }
        }

        /// <summary>
        /// Gets from.
        /// </summary>
        /// <returns>
        /// </returns>
        public (int Row, int Column) GetFrom()
        {
            try
            {
                return _from.Row > 0 && _from.Column  > 0
                    ? ( _from.Row, _from.Column )
                    : default( (int, int) );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( (int, int) );
            }
        }

        /// <summary>
        /// Gets to.
        /// </summary>
        /// <returns>
        /// </returns>
        public (int Row, int Column) GetTo()
        {
            try
            {
                return _to.Row > 0 && _to.Column > 0
                    ? ( _to.Row, _to.Column )
                    : default( (int, int) );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( (int, int) );
            }
        }

        /// <summary>
        /// Gets the workSheet.
        /// </summary>
        /// <returns>
        /// </returns>
        public ExcelWorksheet GetWorksheet()
        {
            try
            {
                return Verify.Input( _worksheet.Name )
                    ? _worksheet
                    : default( ExcelWorksheet );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ExcelWorksheet );
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
                    : default( int );
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
                return _range.Rows > 0
                    ? _range.Rows
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
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
                return _range.Columns > 0
                    ? _range.Columns
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
