// <copyright file = "UnliquidatedObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    public class UnliquidatedObligation : Obligation
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <inheritdoc/>
        public UnliquidatedObligation()
        {
            Type = ExpenseType.ULO;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public UnliquidatedObligation( IQuery query )
            : base( query )
        {
            Record = new DataBuilder()?.GetRecord();
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public UnliquidatedObligation( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public UnliquidatedObligation( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.UnliquidatedObligations;

        /// <summary>
        /// Gets the unliquidated obligation identifier.
        /// </summary>
        /// <value>
        /// The unliquidated obligation identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected override IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the unliquidated obligation identifier.
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
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IDictionary<string, object> ToDictionary()
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

        /// <summary>
        /// Gets the unliquidated obligation amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return ULO.GetFunding() > -1.0
                    ? ULO
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
