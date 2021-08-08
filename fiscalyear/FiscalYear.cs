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
        public BFY BFY;

        /// <summary>
        /// Gets or sets the fiscal year identifier.
        /// </summary>
        /// <value>
        /// The fiscal year identifier.
        /// </value>
        private protected IKey _fiscalYearId;

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        private protected IElement _bbfy;

        /// <summary>
        /// Gets or sets the ebfy.
        /// </summary>
        /// <value>
        /// The ebfy.
        /// </value>
        private protected IElement _ebfy;

        /// <summary>
        /// Gets or sets the first year.
        /// </summary>
        /// <value>
        /// The first year.
        /// </value>
        private protected IElement _firstYear;

        /// <summary>
        /// Gets or sets the last year.
        /// </summary>
        /// <value>
        /// The last year.
        /// </value>
        private protected IElement _lastYear;

        /// <summary>
        /// Gets or sets the expiring year.
        /// </summary>
        /// <value>
        /// The expiring year.
        /// </value>
        private protected IElement _expiringYear;

        /// <summary>
        /// Gets or sets the input year.
        /// </summary>
        /// <value>
        /// The input year.
        /// </value>
        private protected IElement _inputYear;

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected IElement _startDate;

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected IElement _endDate;

        /// <summary>
        /// Gets or sets the cancellation date.
        /// </summary>
        /// <value>
        /// The cancellation date.
        /// </value>
        private protected IElement _cancellationDate;

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> _data;
        
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
                return Verify.Element( _startDate )
                    ? _startDate
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
                return Verify.Element( _expiringYear )
                    ? _expiringYear
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
                return Verify.Element( _cancellationDate )
                    ? _cancellationDate
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Sets the fiscal year.
        /// </summary>
        private protected void SetFiscalYear()
        {
            try
            {
                if( int.Parse( _startDate.GetValue() ) == GetCurrentYear() )
                {
                    BFY = BFY.Current;
                    _bbfy = new Element( Record, Field.BBFY );
                    _firstYear = new Element( Record, Field.FirstYear );
                    _lastYear = new Element( Record, Field.EBFY );
                    _expiringYear = new Element( Record, Field.ExpiringYear );
                }

                if( int.Parse( _startDate.GetValue() ) <= GetCurrentYear() - 1 )
                {
                    BFY = BFY.CarryOver;
                    _bbfy = new Element( Record, Field.BBFY );
                    _firstYear = new Element( Record, Field.FirstYear );
                    _lastYear = new Element( Record, Field.EBFY );
                    _expiringYear = new Element( Record, Field.ExpiringYear );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Map( _data )
                    ? _data
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
