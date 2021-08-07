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
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public DivisionAuthority( IQuery query )
            : base( query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _budgetFiscalYear = new BudgetFiscalYear( _records.GetField( Field.BFY ) );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name = "builder" >
        /// The data.
        /// </param>
        public DivisionAuthority( IBuilder builder )
            : base( builder )
        {
            _records = builder?.GetRecord();
            _budgetFiscalYear = new BudgetFiscalYear( _records.GetField( Field.BFY ) );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.DivisionAuthority;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public double _total;

        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>
        /// The average.
        /// </value>
        public double _average;

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
