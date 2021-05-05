// <copyright file = "FiscalYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

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
        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public BFY BFY { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year identifier.
        /// </summary>
        /// <value>
        /// The fiscal year identifier.
        /// </value>
        public IKey FiscalYearId { get; set; }

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        private protected IElement BBFY { get; set; }

        /// <summary>
        /// Gets or sets the ebfy.
        /// </summary>
        /// <value>
        /// The ebfy.
        /// </value>
        private protected IElement EBFY { get; set; }

        /// <summary>
        /// Gets or sets the first year.
        /// </summary>
        /// <value>
        /// The first year.
        /// </value>
        private protected IElement FirstYear { get; set; }

        /// <summary>
        /// Gets or sets the last year.
        /// </summary>
        /// <value>
        /// The last year.
        /// </value>
        private protected IElement LastYear { get; set; }

        /// <summary>
        /// Gets or sets the expiring year.
        /// </summary>
        /// <value>
        /// The expiring year.
        /// </value>
        private protected IElement ExpiringYear { get; set; }

        /// <summary>
        /// Gets or sets the input year.
        /// </summary>
        /// <value>
        /// The input year.
        /// </value>
        private protected IElement InputYear { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected IElement StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected IElement EndDate { get; set; }

        /// <summary>
        /// Gets or sets the cancellation date.
        /// </summary>
        /// <value>
        /// The cancellation date.
        /// </value>
        private protected IElement CancellationDate { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Data { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        public BFY GetBFY()
        {
            try
            {
                return Verify.BFY( BFY )
                    ? BFY
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return default;
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
                return default;
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
                return default;
            }
        }

        /// <summary>
        /// Sets the fiscal year.
        /// </summary>
        private protected void SetFiscalYear()
        {
            try
            {
                if( int.Parse( StartDate.GetValue() ) == GetCurrentYear() )
                {
                    BFY = BFY.Current;
                    BBFY = new Element( Record, Field.BBFY );
                    FirstYear = new Element( Record, Field.FirstYear );
                    LastYear = new Element( Record, Field.EBFY );
                    ExpiringYear = new Element( Record, Field.ExpiringYear );
                }

                if( int.Parse( StartDate.GetValue() ) <= GetCurrentYear() - 1 )
                {
                    BFY = BFY.CarryOver;
                    BBFY = new Element( Record, Field.BBFY );
                    FirstYear = new Element( Record, Field.FirstYear );
                    LastYear = new Element( Record, Field.EBFY );
                    ExpiringYear = new Element( Record, Field.ExpiringYear );
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
                return default;
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
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
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
                    var fiscalyear = new Dictionary<string, object>();

                    switch( bfy )
                    {
                        case BFY.Current:
                        {
                            fiscalyear?.Add( $"{Field.BBFY}", GetCurrentYear().ToString() );
                            fiscalyear?.Add( $"{Field.EBFY}", ( GetCurrentYear() + 1 ).ToString() );

                            return fiscalyear.Any()
                                ? fiscalyear
                                : default;
                        }

                        case BFY.CarryOver:
                        {
                            fiscalyear?.Add( $"{Field.BBFY}", ( GetCurrentYear() - 1 ).ToString() );
                            fiscalyear?.Add( $"{Field.EBFY}", GetCurrentYear().ToString() );

                            return fiscalyear?.Any() == true
                                ? fiscalyear
                                : default;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
