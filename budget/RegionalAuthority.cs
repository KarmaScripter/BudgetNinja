// <copyright file = "RegionalAuthority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    public class RegionalAuthority : Authority
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.RegionAuthority;

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        public RegionalAuthority()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see>
        /// <cref>
        /// RegionalAuthority
        /// </cref>
        /// </see>
        /// class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public RegionalAuthority( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _budgetFiscalYear = new BudgetFiscalYear( _record.GetField( Field.BFY ) );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The data.
        /// </param>
        public RegionalAuthority( IBuilder builder )
            : base( builder )
        {
            _record = builder?.GetRecord();
            _budgetFiscalYear = new BudgetFiscalYear( _record.GetField( Field.BFY ) );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Calculates the percentage.
        /// </summary>
        /// <param name = "t1" >
        /// The t1.
        /// </param>
        /// <param name = "t2" >
        /// The t2.
        /// </param>
        /// <returns>
        /// </returns>
        public double CalculatePercentage( double t1, double t2 )
        {
            try
            {
                return t1 / t2;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1D;
            }
        }
    }
}
