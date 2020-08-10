// // <copyright file = "Deobligation.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// An agency’s cancellation or downward adjustment of previously incurred
    /// obligations. Deobligated funds may be reobligated within the period of
    /// availability of the appropriation. For example, annual appropriated funds may
    /// be reobligated in the fiscal year in which the funds were appropriated, while
    /// multiyear or no-year appropriated funds may be reobligated in the same or
    /// subsequent fiscal years. (See Reobligation.)
    /// </summary>
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "IDeobligation"/>
    public class Deobligation : Obligation
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        public Deobligation()
        {
            Type = ExpenseType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        public Deobligation( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = GetDeobligations();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The database.
        /// </param>
        public Deobligation( IBuilder db )
            : base( db )
        {
            Record = db.GetRecord();
            ID = new Key( Record, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = GetDeobligations();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Deobligation( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = GetDeobligations();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Deobligation;
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
        protected override Source Source { get; set; } = Source.Deobligations;

        /// <summary>
        /// Gets the deobligation identifier.
        /// </summary>
        /// <value>
        /// The deobligation identifier.
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
        /// Gets the deobligation identifier.
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

        /// <inheritdoc/>
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Deobligations.GetFunding() > -1.0D
                    ? Deobligations
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
