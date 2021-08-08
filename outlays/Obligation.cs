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
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected IAmount _amount;

        /// <summary>
        /// 
        /// </summary>
        private protected readonly Source _source = Source.Obligations;

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
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _records, Numeric.Obligations );
            _data = _records?.ToDictionary();
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
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _records, Numeric.Obligations );
            _data = _records?.ToDictionary();
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
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = new Amount( _records, Numeric.Obligations );
            _data = _records?.ToDictionary();
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

        /// <summary>
        /// Gets the data builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IBuilder GetBuilder()
        {
            try
            {
                return Validate.Source( _source )
                    ? new Builder( _source, _data )
                    : default( Builder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBuilder );
            }
        }
    }
}
