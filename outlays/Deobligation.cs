// <copyright file = "Deobligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;

    /// <summary>
    /// An agency’s cancellation or downward adjustment of previously incurred
    /// obligations. Deobligated funds may be reobligated within the period of
    /// availability of the appropriation. For example, annual appropriated funds may
    /// be reobligated in the fiscal year in which the funds were appropriated, while
    /// multiyear or no-year appropriated funds may be reobligated in the same or
    /// subsequent fiscal years. (See Reobligation.)
    /// </summary>
    /// <seealso cref = "Outlay"/>
    /// <seealso cref = "IDeobligation"/>
    public class Deobligation : Obligation
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected new Source _source = Source.Deobligations;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        public Deobligation()
        {
            Type = OutlayType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        public Deobligation( IQuery query )
            : base( query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = GetDeobligations();
            _data = _records?.ToDictionary();
            Type = OutlayType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The database.
        /// </param>
        public Deobligation( IBuilder db )
            : base( db )
        {
            _records = db.GetRecord();
            _id = new Key( _records, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = GetDeobligations();
            _data = _records?.ToDictionary();
            Type = OutlayType.Deobligation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Deobligation"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Deobligation( DataRow dataRow )
            : base( dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.DeobligationId );
            OriginalActionDate = GetOriginalActionDate();
            _amount = GetDeobligations();
            _data = _records?.ToDictionary();
            Type = OutlayType.Deobligation;
        }
        
        /// <summary>
        /// Gets the deobligation identifier.
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

        /// <inheritdoc/>
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Deobligations.GetFunding() > -1.0D
                    ? Deobligations
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
