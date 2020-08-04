// <copyright file="OpenCommitment.cs" company="Terry D. Eppler">
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
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "IOpenCommitment"/>
    public class OpenCommitment : Commitment
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        public OpenCommitment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public OpenCommitment( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.OpenCommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.OpenCommitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The builder.
        /// </param>
        public OpenCommitment( IBuilder db )
            : base( db )
        {
            Record = db?.GetRecord();
            ID = new Key( Record, PrimaryKey.OpenCommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.OpenCommitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public OpenCommitment( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.OpenCommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = ExpenseType.OpenCommitment;
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
        protected override Source Source { get; set; } = Source.OpenCommitments;

        /// <summary>
        /// Gets the open commitment identifier.
        /// </summary>
        /// <value>
        /// The open commitment identifier.
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
        /// Gets the OpenCommitment identifier.
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
        /// Gets the commitment amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return OpenCommitments.GetFunding() > -1
                    ? OpenCommitments
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