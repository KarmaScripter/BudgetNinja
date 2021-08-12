// <copyright file = "Section.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Section : Grid
    {
        /// <summary>
        /// The grid
        /// </summary>
        private readonly IGrid _grid;
        
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public (int Row, int Column) Anchor { get; set; }

        /// <summary>
        /// Gets the span.
        /// </summary>
        /// <value>
        /// The span.
        /// </value>
        public int Span { get; set; }

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; set; }

        /// <summary>
        /// Gets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        public ( int Depth, int Span ) Area { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "Heading"/> class.
        /// </summary>
        public Section()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class.
        /// </summary>
        /// <param name = "grid" > </param>
        public Section( IGrid grid )

        {
            _grid = grid;
            _worksheet = _grid.GetWorksheet();
            _range = _grid.GetRange();
            _address = _grid.GetAddress();
            _from = ( _range.Start.Row, _range.Start.Column );
            _to = ( _range.End.Row, _range.End.Column );
            Span = _range.Columns;
            Depth = _range.Rows;
            Area = ( Depth, Span );
        }

        /// <summary>
        /// Gets the anchor.
        /// </summary>
        /// <returns></returns>
        public ( int Row, int Column ) GetAnchor()
        {
            try
            {
                return default( (int Row, int Column) );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ( 0, 0 );
            }
        }

        /// <summary>
        /// Gets the span.
        /// </summary>
        /// <returns></returns>
        public int GetSpan()
        {
            try
            {
                return default( int );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <returns></returns>
        public int GetDepth()
        {
            try
            {
                return default( int );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns></returns>
        public ( int Depth, int Span ) GetArea()
        {
            try
            {
                return default( (int Depth, int Span) );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return ( 0, 0 );
            }
        }
    }
}
