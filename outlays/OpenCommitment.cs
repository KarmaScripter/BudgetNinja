// <copyright file = "OpenCommitment.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "IOpenCommitment"/>
    public class OpenCommitment : Commitment
    {
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
            Type = OutlayType.OpenCommitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public OpenCommitment( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.OpenCommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = OutlayType.OpenCommitment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OpenCommitment"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public OpenCommitment( DataRow dataRow )
            : base( dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.OpenCommitmentId );
            OriginalActionDate = GetOriginalActionDate();
            Data = Record?.ToDictionary();
            Type = OutlayType.OpenCommitment;
        }
        
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
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
