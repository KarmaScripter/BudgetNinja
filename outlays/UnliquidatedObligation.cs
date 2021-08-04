// <copyright file = "UnliquidatedObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

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
            _record = new DataBuilder()?.GetRecord();
            _id = new Key( _record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( _record, Numeric.ULO );
            _data = _record?.ToDictionary();
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
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( _record, Numeric.ULO );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "UnliquidatedObligation"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public UnliquidatedObligation( DataRow datarow )
        {
            _record = datarow;
            _id = new Key( _record, PrimaryKey.UnliquidatedObligationId );
            OriginalActionDate = GetOriginalActionDate();
            ULO = new Amount( _record, Numeric.ULO );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected new Source _source = Source.ULO;
        
        /// <summary>
        /// Gets the unliquidated obligation identifier.
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
