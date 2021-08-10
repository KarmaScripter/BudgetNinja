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
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Purchases;

        /// <summary>
        /// Gets the purchase identifier.
        /// </summary>
        /// <value>
        /// The purchase identifier.
        /// </value>
        private protected readonly IKey _iD;

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
            _records = new DataBuilder( query )?.GetRecord();
            _iD = new Key( _records, PrimaryKey.PurchaseId );
            _npmCode = new Element( _records, Field.NpmCode );
            _documentType = new Element( _records, Field.DocumentType );
            _purchaseRequest = new Element( _records, Field.PurchaseRequest );
            _documentPrefix = new Element( _records, Field.DocumentPrefix );
            _dcn = new Element( _records, Field.DCN );
            _obligatingDocumentNumber = new Element( _records, Field.ObligatingDocumentNumber );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _grantNumber = new Element( _records, Field.GrantNumber );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            _system = new Element( _records, Field.System );
            _focCode = new Element( _records, Field.FocCode );
            _focName = new Element( _records, Field.FocName );
            _transactionNumber = new Element( _records, Field.TransactionNumber );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Purchase( IBuilder builder )
            : base( builder )
        {
            _records = builder?.GetRecord();
            _iD = new Key( _records, PrimaryKey.PurchaseId );
            _npmCode = new Element( _records, Field.NpmCode );
            _documentType = new Element( _records, Field.DocumentType );
            _purchaseRequest = new Element( _records, Field.PurchaseRequest );
            _documentPrefix = new Element( _records, Field.DocumentPrefix );
            _dcn = new Element( _records, Field.DCN );
            _obligatingDocumentNumber = new Element( _records, Field.ObligatingDocumentNumber );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _grantNumber = new Element( _records, Field.GrantNumber );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            _system = new Element( _records, Field.System );
            _focCode = new Element( _records, Field.FocCode );
            _focName = new Element( _records, Field.FocName );
            _transactionNumber = new Element( _records, Field.TransactionNumber );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Purchase"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Purchase( DataRow dataRow )
            : base( dataRow )
        {
            _records = dataRow;
            _iD = new Key( _records, PrimaryKey.PurchaseId );
            _npmCode = new Element( _records, Field.NpmCode );
            _documentType = new Element( _records, Field.DocumentType );
            _purchaseRequest = new Element( _records, Field.PurchaseRequest );
            _documentPrefix = new Element( _records, Field.DocumentPrefix );
            _dcn = new Element( _records, Field.DCN );
            _obligatingDocumentNumber = new Element( _records, Field.ObligatingDocumentNumber );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _grantNumber = new Element( _records, Field.GrantNumber );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _siteProjectCode = new Element( _records, Field.SiteProjectCode );
            _system = new Element( _records, Field.System );
            _focCode = new Element( _records, Field.FocCode );
            _focName = new Element( _records, Field.FocName );
            _transactionNumber = new Element( _records, Field.TransactionNumber );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }
        
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
