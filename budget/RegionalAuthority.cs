// <copyright file = "RegionalAuthority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "SuggestBaseTypeForParameter" ) ]
    public class RegionalAuthority : Authority
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
        /// The data.
        /// </param>
        public RegionalAuthority( IBuilder builder )
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
        protected override Source Source { get; set; } = Source.RegionAuthority;

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
