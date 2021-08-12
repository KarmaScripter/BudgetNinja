// <copyright file = "Heading.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Local" ) ]
    public class Heading : Grid
    {
        /// <summary>
        /// Gets or sets the span.
        /// </summary>
        /// <value>
        /// The span.
        /// </value>
        private protected readonly int _span;

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        private protected (int Row, int Column) _anchor;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        private protected readonly IDictionary<int, string> _caption;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Heading"/> class.
        /// </summary>
        public Heading()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public Heading( IGrid grid )
        {
            _worksheet = grid.GetWorksheet();
            _range = grid.GetRange();
            _address = grid.GetAddress();
            _from = ( _range.Start.Row, _range.Start.Column );
            _to = ( _range.Start.Row, _range.End.Column );
            _anchor = ( _from.Row, _from.Column );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Heading"/> class.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="caption">The caption.</param>
        public Heading( IGrid grid, IDictionary<int, string> caption )
            : this( grid )
        {
            _caption = caption;
            _span = _range.Columns;
        }

        /// <summary>
        /// Gets the span.
        /// </summary>
        /// <returns></returns>
        public int GetSpan()
        {
            try
            {
                return _span > 0
                    ? _span
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return _anchor.Row > 0 
                    && _anchor.Column > 0
                        ? _anchor
                        : ( 0, 0 );
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return _caption?.Any() == true
                    ? _caption
                    : default( IDictionary<int, string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<int, string> );
            }
        }
    }
}
