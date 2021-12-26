// <copyright file = "FiscalYear.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "CalendarYear"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    public abstract class FiscalYear : CalendarYear
    {
        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected BFY BFY;

        /// <summary>
        /// Gets or sets the fiscal year identifier.
        /// </summary>
        /// <value>
        /// The fiscal year identifier.
        /// </value>
        private protected IKey FiscalYearId;

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        private protected IElement FirstYear;

        /// <summary>
        /// Gets or sets the ebfy.
        /// </summary>
        /// <value>
        /// The ebfy.
        /// </value>
        private protected IElement LastYear;
        
        /// <summary>
        /// Gets or sets the expiring year.
        /// </summary>
        /// <value>
        /// The expiring year.
        /// </value>
        private protected IElement ExpiringYear;

        /// <summary>
        /// Gets or sets the input year.
        /// </summary>
        /// <value>
        /// The input year.
        /// </value>
        private protected IElement InputYear;

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected IElement StartDate;

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected IElement EndDate;

        /// <summary>
        /// Gets or sets the cancellation date.
        /// </summary>
        /// <value>
        /// The cancellation date.
        /// </value>
        private protected IElement CancellationDate;

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Data;
        
        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        public BFY GetBFY()
        {
            try
            {
                return Validate.BFY( BFY )
                    ? BFY
                    : default( BFY );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( BFY );
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStartDate()
        {
            try
            {
                return Verify.Element( StartDate )
                    ? StartDate
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the expiration date.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetExpiratingYear()
        {
            try
            {
                return Verify.Element( ExpiringYear )
                    ? ExpiringYear
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the cancellation date.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCancellationDate()
        {
            try
            {
                return Verify.Element( CancellationDate )
                    ? CancellationDate
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
        
        /// <summary>
        /// Determines whether this instance is current.
        /// </summary>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if this instance is current; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public bool IsCurrent()
        {
            try
            {
                return BFY != 0 && BFY == BFY.Current;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( bool );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "year" >
        /// The year.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> SetArgs( string year )
        {
            if( Verify.Input( year )
                && year.Length == 4
                && int.Parse( year ) > 2018
                && int.Parse( year ) < 2040 )
            {
                try
                {
                    var bfy = new Dictionary<string, object>
                    {
                        [ $"{Field.BBFY}" ] = year
                    };

                    return bfy.Any()
                        ? bfy
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> SetArgs( BFY bfy )
        {
            if( Enum.IsDefined( typeof( BFY ), bfy ) )
            {
                try
                {
                    var _year = new Dictionary<string, object>();

                    switch( bfy )
                    {
                        case BFY.Current:
                        {
                            _year?.Add( $"{Field.BBFY}", GetCurrentYear().ToString() );
                            _year?.Add( $"{Field.EBFY}", ( GetCurrentYear() + 1 ).ToString() );

                            return _year.Any()
                                ? _year
                                : default( Dictionary<string, object> );
                        }

                        case BFY.CarryOver:
                        {
                            _year?.Add( $"{Field.BBFY}", ( GetCurrentYear() - 1 ).ToString() );
                            _year?.Add( $"{Field.EBFY}", GetCurrentYear().ToString() );

                            return _year?.Any() == true
                                ? _year
                                : default( Dictionary<string, object> );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}
