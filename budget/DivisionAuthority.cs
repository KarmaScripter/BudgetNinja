// <copyright file = "DivisionAuthority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    public class DivisionAuthority : Authority
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } = Source.DivisionAuthority;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>
        /// The average.
        /// </value>
        public double Average { get; set; }

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public DivisionAuthority( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            BudgetFiscalYear = new BudgetFiscalYear( Record.GetField( Field.BFY ) );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name = "builder" >
        /// The Data.
        /// </param>
        public DivisionAuthority( IBuilder builder )
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
