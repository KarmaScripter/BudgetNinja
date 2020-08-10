// // <copyright file = "Reimbursable.cs" company = "Terry D. Eppler">
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
        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ReimbursableId );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            ULO = new Amount( Record, Numeric.ULO );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
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
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.ReimbursableId );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            ULO = new Amount( Record, Numeric.ULO );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Reimbursable"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Reimbursable( DataRow data )
            : base( data )
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.ReimbursableId );
            AgreementNumber = new Element( Record, Field.ReimbursableAgreementNumber );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            ULO = new Amount( Record, Numeric.ULO );
            Expenditures = new Amount( Record, Numeric.Expenditures );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.Reimbursables;

        /// <summary>
        /// Gets the reimbursable identifier.
        /// </summary>
        /// <value>
        /// The reimbursable identifier.
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
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the reimbursable identifier.
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
        /// Gets the fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFiscalYear()
        {
            try
            {
                return Verify.Input( BFY?.GetValue() )
                    ? BFY
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
