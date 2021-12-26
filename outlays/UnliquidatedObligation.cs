// <copyright file = "UnliquidatedObligation.cs" company = "Terry D. Eppler">
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
    /// <seealso cref="Obligation" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class UnliquidatedObligation : Obligation
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } = Source.ULO;

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <inheritdoc/>
        public UnliquidatedObligation()
        {
            Type = OutlayType.ULO;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public UnliquidatedObligation( IQuery query )
            : base( query )
        {
            Record = new DataBuilder()?.GetRecord();
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public UnliquidatedObligation( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public UnliquidatedObligation( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( Record, Numeric.ULO );
            Data = Record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the unliquidated obligation identifier.
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
        /// Gets the unliquidated obligation amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return ULO.GetFunding() > -1.0
                    ? ULO
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
