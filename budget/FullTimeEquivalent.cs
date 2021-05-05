// <copyright file = "FullTimeEquivalent.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

using System;

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System.Data;

    /// <summary>
    /// Full-time equivalent (FTE) or whole time equivalent (WTE) is a
    /// unit that indicates the workload of an employed person (or student) in a way
    /// that makes workloads or class loads comparable across various contexts.
    /// FullTimeEquivalent is often used to measure a worker's or student's involvement
    /// in a project, or to track cost reductions in an organization. An
    /// FullTimeEquivalent of 1.0 is equivalent to a full-time worker or student, while
    /// an FullTimeEquivalent of 0.5 signals half of a full work or school load.
    /// </summary>
    /// <seealso cref = "ProgramResultsCode"/>
    public class FullTimeEquivalent : ProgramResultsCode, IFullTimeEquivalent
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.FullTimeEquivalent"/> class.
        /// </summary>
        public FullTimeEquivalent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public FullTimeEquivalent( IQuery query )
            : base( query )
        {
            ID = new Key( Record, PrimaryKey.PrcId );
            Amount = new Amount( Record, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The databuilder.
        /// </param>
        public FullTimeEquivalent( IBuilder builder )
            : base( builder )
        {
            ID = new Key( Record, PrimaryKey.PrcId );
            Amount = new Amount( Record, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "FullTimeEquivalent"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public FullTimeEquivalent( DataRow datarow )
            : base( datarow )
        {
            ID = new Key( Record, PrimaryKey.PrcId );
            Amount = new Amount( Record, Numeric.Amount );
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        protected override Source Source { get; set; } = Source.FTE;

        /// <summary>
        /// Gets the fte identifier.
        /// </summary>
        /// <value>
        /// The fte identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets the fte identifier.
        /// </summary>
        /// <value>
        /// The fte identifier.
        /// </value>
        protected override IAmount Amount { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Amount.GetFunding() > -1.0
                    ? Amount
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
