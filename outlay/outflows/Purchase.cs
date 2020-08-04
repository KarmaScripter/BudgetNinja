// <copyright file="Purchase.cs" company="Terry D. Eppler">
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
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "Obligation"/>
    public class Purchase : Obligation
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Purchase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Purchase( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PurchaseId );
            NpmCode = new Element( Record, Field.NpmCode );
            DocumentType = new Element( Record, Field.DocumentType );
            PurchaseRequest = new Element( Record, Field.PurchaseRequest );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DCN = new Element( Record, Field.DCN );
            ObligatingDocumentNumber = new Element( Record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( Record, Field.GrantNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            System = new Element( Record, Field.System );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            TransactionNumber = new Element( Record, Field.TransactionNumber );
            OriginalActionDate = new Time( Record, Date.OriginalActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The builder.
        /// </param>
        public Purchase( IBuilder db )
            : base( db )
        {
            Record = db?.GetRecord();
            ID = new Key( Record, PrimaryKey.PurchaseId );
            NpmCode = new Element( Record, Field.NpmCode );
            DocumentType = new Element( Record, Field.DocumentType );
            PurchaseRequest = new Element( Record, Field.PurchaseRequest );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DCN = new Element( Record, Field.DCN );
            ObligatingDocumentNumber = new Element( Record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( Record, Field.GrantNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            System = new Element( Record, Field.System );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            TransactionNumber = new Element( Record, Field.TransactionNumber );
            OriginalActionDate = new Time( Record, Date.OriginalActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Purchase( DataRow data )
            : base( data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.PurchaseId );
            NpmCode = new Element( Record, Field.NpmCode );
            DocumentType = new Element( Record, Field.DocumentType );
            PurchaseRequest = new Element( Record, Field.PurchaseRequest );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DCN = new Element( Record, Field.DCN );
            ObligatingDocumentNumber = new Element( Record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( Record, Field.GrantNumber );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( Record, Field.SiteProjectCode );
            System = new Element( Record, Field.System );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            TransactionNumber = new Element( Record, Field.TransactionNumber );
            OriginalActionDate = new Time( Record, Date.OriginalActionDate );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            Expenditures = new Amount( Record, Numeric.Expenditures );
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
        protected override Source Source { get; set; } = Source.Purchases;

        /// <summary>
        /// Gets the purchase identifier.
        /// </summary>
        /// <value>
        /// The purchase identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected override IDictionary<string, object> Data { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the purchase identifier.
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
    }
}