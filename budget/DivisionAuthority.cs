// <copyright file = "DivisionAuthority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    public class DivisionAuthority : Authority
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
        /// The data.
        /// </param>
        public DivisionAuthority( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            BudgetFiscalYear = new BudgetFiscalYear( Record.GetField( Field.BFY ) );
            Data = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.DivisionAuthority;

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
