// // <copyright file = "Heading.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Heading : Grid
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The depth
        /// </summary>
        private readonly int Depth = 1;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Heading"/> class.
        /// </summary>
        public Heading()
        {
        }

        public Heading( IGrid grid )
        {
            Worksheet = grid.GetWorksheet();
            Range = grid.GetRange();
            Address = grid.GetAddress();
            From = ( Range.Start.Row, Range.Start.Column );
            To = ( Range.Start.Row, Range.End.Column );
            Anchor = ( From.Row, From.Column );
        }

        public Heading( IGrid grid, IDictionary<int, string> caption )
            : this( grid )
        {
            Caption = caption;
            Span = Range.Columns;
        }

        // ***************************************************************************************************************************
        // ****************************************************  PROPERTIES   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the span.
        /// </summary>
        /// <value>
        /// The span.
        /// </value>
        private int Span { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        private (int Row, int Column) Anchor { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        private IDictionary<int, string> Caption { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the span.
        /// </summary>
        /// <returns></returns>
        public int GetSpan()
        {
            try
            {
                return Span > 0
                    ? Span
                    : 0;
            }
            catch( Exception ex )
            {
                Heading.Fail( ex );
                return 0;
            }
        }

        /// <summary>
        /// Gets the anchor.
        /// </summary>
        /// <returns></returns>
        public ( int Row, int Column ) GetAnchor()
        {
            try
            {
                return Anchor.Row > 0 && Anchor.Column > 0
                    ? Anchor
                    : ( 0, 0 );
            }
            catch( Exception ex )
            {
                Heading.Fail( ex );
                return ( 0, 0 );
            }
        }

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, string> GetCaption()
        {
            try
            {
                return Caption?.Any() == true
                    ? Caption
                    : default;
            }
            catch( Exception ex )
            {
                Heading.Fail( ex );
                return default;
            }
        }
    }
}
