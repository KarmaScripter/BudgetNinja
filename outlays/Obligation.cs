// <copyright file = "Obligation.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "T:BudgetExecution.Outlay"/>
    /// <seealso cref = "T:BudgetExecution.IObligation"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class Obligation : Outlay
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected new Source _source = Source.Obligations;

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected  IKey _id;
        
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected  IAmount _amount;

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.Obligation"/>
        /// class.
        /// </summary>
        public Obligation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Obligation"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Obligation( IQuery query )
            : base( query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _record, Numeric.Obligations );
            _data = _record?.ToDictionary();
            Type = OutlayType.Obligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Obligation"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Obligation( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _record, Numeric.Obligations );
            _data = _record?.ToDictionary();
            Type = OutlayType.Obligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.Obligation"/>
        /// class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Obligation( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _record, Numeric.Obligations );
            _data = _record?.ToDictionary();
            Type = OutlayType.Obligation;
        }
        
        /// <summary>
        /// Gets the outlay identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
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
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetAmount()
        {
            try
            {
                return Verify.Amount( _amount )
                    ? _amount
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
