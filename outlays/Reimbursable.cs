// <copyright file = "Reimbursable.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// A reimbursable is a sum (1) that is received by an agency as a payment for
    /// commodities sold or services furnished either to the private or to another
    /// government account and (2) that is authorized by law to be credited directly to
    /// specific appropriation and fund accounts. Reimbursements between two accounts
    /// for goods or services are usually expenditure transactions/transfers.
    /// Anticipated reimbursements are, in the case of transactions with the public,
    /// estimated collections of expected advances to be received or expected
    /// reimbursements to be earned. In transactions between government accounts,
    /// anticipated reimbursements consist of orders expected to be received for which
    /// no orders have been accepted. Agencies cannot obligate against anticipated
    /// reimbursements without specific statutory authority.
    /// </summary>
    public class Reimbursable : Obligation
    {
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Reimbursables;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reimbursable"/> class.
        /// </summary>
        public Reimbursable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reimbursable"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Reimbursable( IQuery query )
            : base( query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.ReimbursableId );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _ulo = new Amount( _records, Numeric.ULO );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reimbursable"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Reimbursable( IBuilder builder )
            : base( builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.ReimbursableId );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _ulo = new Amount( _records, Numeric.ULO );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reimbursable"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Reimbursable( DataRow dataRow )
            : base( dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.ReimbursableId );
            _agreementNumber = new Element( _records, Field.ReimbursableAgreementNumber );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _ulo = new Amount( _records, Numeric.ULO );
            _expenditures = new Amount( _records, Numeric.Expenditures );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the reimbursable identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFiscalYear()
        {
            try
            {
                return Verify.Input( _bfy?.GetValue() )
                    ? _bfy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
