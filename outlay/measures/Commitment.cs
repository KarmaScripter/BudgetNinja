// <copyright file="Commitment.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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

    /// <summary>
    /// An administrative reservation of allotted funds, or of other funds, in
    /// anticipation of their obligation. For federal proprietary accounting, a
    /// commitment may also manifest an intent to expend assets (e.g., to provide
    /// government social insurance benefits). See Statement of Federal Financial
    /// Accounting Standards (SFFAS) No. 25, Basis for Conclusions, para. 8, and SFFAS
    /// No. 17, Basis for Conclusions, paras. 65 and 94.
    /// </summary>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "IAmount"/>
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "ICommitment"/>
    public class Commitment : Outlay
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Commitment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Commitment( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Commitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The database.
        /// </param>
        public Commitment( IBuilder db )
            : base( db )
        {
            Record = db.GetRecord();
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Commitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Commitment( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.Commitment;
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
        protected override Source Source { get; set; } = Source.Commitments;

        /// <summary>
        /// Gets the commitment identifier.
        /// </summary>
        /// <value>
        /// The commitment identifier.
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
        private protected virtual IAmount Amount { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the Commitment identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
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
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetAmount()
        {
            try
            {
                return Commitments?.GetFunding() > -1
                    ? Commitments
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