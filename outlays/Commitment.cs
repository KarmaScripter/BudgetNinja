// <copyright file = "Commitment.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

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
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get;  } = Source.Commitments;
        
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        /// 
        public IAmount Amount { get; }

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
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = OutlayType.Commitment;
            Amount = new Amount( Record, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The database.
        /// </param>
        public Commitment( IBuilder builder )
        {
            Record = builder.GetRecord();
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = OutlayType.Commitment;
            Amount = new Amount( Record, Numeric.Amount );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Commitment"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Commitment( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.CommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = OutlayType.Commitment;
            Amount = new Amount( Record, Numeric.Amount );
        }
        
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
                return Verify.Map( Data )
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
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
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IBuilder GetBuilder()
        {
            return new Builder( Source, Data );
        }
    }
}
