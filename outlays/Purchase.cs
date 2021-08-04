// <copyright file = "Purchase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "Obligation"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Purchase : Obligation
    {
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
            _record = new DataBuilder( query )?.GetRecord();
            _iD = new Key( _record, PrimaryKey.PurchaseId );
            NpmCode = new Element( _record, Field.NpmCode );
            DocumentType = new Element( _record, Field.DocumentType );
            PurchaseRequest = new Element( _record, Field.PurchaseRequest );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DCN = new Element( _record, Field.DCN );
            ObligatingDocumentNumber = new Element( _record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( _record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( _record, Field.GrantNumber );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( _record, Field.SiteProjectCode );
            System = new Element( _record, Field.System );
            FocCode = new Element( _record, Field.FocCode );
            FocName = new Element( _record, Field.FocName );
            TransactionNumber = new Element( _record, Field.TransactionNumber );
            OriginalActionDate = new Time( _record, EventDate.OriginalActionDate );
            Commitments = new Amount( _record, Numeric.Commitments );
            OpenCommitments = new Amount( _record, Numeric.OpenCommitments );
            Obligations = new Amount( _record, Numeric.Obligations );
            ULO = new Amount( _record, Numeric.ULO );
            Deobligations = new Amount( _record, Numeric.Deobligations );
            Expenditures = new Amount( _record, Numeric.Expenditures );
            _data = _record?.ToDictionary();
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
            _record = db?.GetRecord();
            _iD = new Key( _record, PrimaryKey.PurchaseId );
            NpmCode = new Element( _record, Field.NpmCode );
            DocumentType = new Element( _record, Field.DocumentType );
            PurchaseRequest = new Element( _record, Field.PurchaseRequest );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DCN = new Element( _record, Field.DCN );
            ObligatingDocumentNumber = new Element( _record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( _record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( _record, Field.GrantNumber );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( _record, Field.SiteProjectCode );
            System = new Element( _record, Field.System );
            FocCode = new Element( _record, Field.FocCode );
            FocName = new Element( _record, Field.FocName );
            TransactionNumber = new Element( _record, Field.TransactionNumber );
            OriginalActionDate = new Time( _record, EventDate.OriginalActionDate );
            Commitments = new Amount( _record, Numeric.Commitments );
            OpenCommitments = new Amount( _record, Numeric.OpenCommitments );
            Obligations = new Amount( _record, Numeric.Obligations );
            ULO = new Amount( _record, Numeric.ULO );
            Deobligations = new Amount( _record, Numeric.Deobligations );
            Expenditures = new Amount( _record, Numeric.Expenditures );
            _data = _record?.ToDictionary();
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
            _record = data;
            _iD = new Key( _record, PrimaryKey.PurchaseId );
            NpmCode = new Element( _record, Field.NpmCode );
            DocumentType = new Element( _record, Field.DocumentType );
            PurchaseRequest = new Element( _record, Field.PurchaseRequest );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DCN = new Element( _record, Field.DCN );
            ObligatingDocumentNumber = new Element( _record, Field.ObligatingDocumentNumber );
            AgreementNumber = new Element( _record, Field.ReimbursableAgreementNumber );
            GrantNumber = new Element( _record, Field.GrantNumber );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            SiteProjectCode = new Element( _record, Field.SiteProjectCode );
            System = new Element( _record, Field.System );
            FocCode = new Element( _record, Field.FocCode );
            FocName = new Element( _record, Field.FocName );
            TransactionNumber = new Element( _record, Field.TransactionNumber );
            OriginalActionDate = new Time( _record, EventDate.OriginalActionDate );
            Commitments = new Amount( _record, Numeric.Commitments );
            OpenCommitments = new Amount( _record, Numeric.OpenCommitments );
            Obligations = new Amount( _record, Numeric.Obligations );
            ULO = new Amount( _record, Numeric.ULO );
            Deobligations = new Amount( _record, Numeric.Deobligations );
            Expenditures = new Amount( _record, Numeric.Expenditures );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected new  Source _source = Source.Purchases;

        /// <summary>
        /// Gets the purchase identifier.
        /// </summary>
        /// <value>
        /// The purchase identifier.
        /// </value>
        private protected readonly IKey _iD;
        
        /// <summary>
        /// Gets the purchase identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _iD )
                    ? _iD
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
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
                return Verify.Map( _data )
                    ? _data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}
