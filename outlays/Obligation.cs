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
        public IAmount Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Source Source { get; } = Source.Obligations;

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = new Amount( Record, Numeric.Obligations );
            Data = Record?.ToDictionary();
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
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = new Amount( Record, Numeric.Obligations );
            Data = Record?.ToDictionary();
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
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.ObligationId );
            OriginalActionDate = GetOriginalActionDate();
            Amount = new Amount( Record, Numeric.Obligations );
            Data = Record?.ToDictionary();
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
                return Verify.Key( ID )
                    ? ID
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
                return Verify.Amount( Amount )
                    ? Amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the Data builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IBuilder GetBuilder()
        {
            try
            {
                return Validate.Source( Source )
                    ? new Builder( Source, Data )
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
