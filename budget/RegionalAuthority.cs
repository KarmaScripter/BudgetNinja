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
        public new Source Source { get; } = Source.RegionAuthority;

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
            Record = new DataBuilder( query )?.GetRecord();
            BudgetFiscalYear = new BudgetFiscalYear( Record.GetField( Field.BFY ) );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The Data.
        /// </param>
        public RegionalAuthority( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            BudgetFiscalYear = new BudgetFiscalYear( Record.GetField( Field.BFY ) );
            Data = Record?.ToDictionary();
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
