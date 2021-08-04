// <copyright file = "Section.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Section : Grid
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        private readonly IGrid _grid;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Heading"/> class.
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
            Worksheet = _grid.GetWorksheet();
            Range = _grid.GetRange();
            Address = _grid.GetAddress();
            From = ( Range.Start.Row, Range.Start.Column );
            To = ( Range.End.Row, Range.End.Column );
            Span = Range.Columns;
            Depth = Range.Rows;
            Area = ( Depth, Span );
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
        private (int Row, int Column) Anchor { get; set; }

        /// <summary>
        /// Gets the span.
        /// </summary>
        /// <value>
        /// The span.
        /// </value>
        private int Span { get; }

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        private int Depth { get; }

        /// <summary>
        /// Gets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        private ( int Depth, int Span ) Area { get; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
