// <copyright file = "Procurement.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "Commitment"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Procurement : ProcurementData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "Procurement"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Procurement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Procurement"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Procurement( IQuery query )
            : base( query )
        {
            _record = new Builder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ProcurementId );
            _title = new Element( _record, Field.Title );
            _requestedBy = new Element( _record, Field.RequestedBy );
            _description = new Element( _record, Field.Description );
            _createdBy = new Element( _record, Field.CreatedBy );
            _modifiedBy = new Element( _record, Field.ModifiedBy );
            _lastActionDate = new Time( _record, EventDate.LastActionDate );
            _processedDate = new Time( _record, EventDate.ProcessedDate );
            _closedDate = new Time( _record, EventDate.ClosedDate );
            _securityOrg = new Element( _record, Field.SecurityOrg );
            _vendorCode = new Element( _record, Field.VendorCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DocumentType = new Element( _record, Field.DocumentType );
            _documentDate = new Time( _record, EventDate.DocumentDate );
            _documentControlNumber = new Element( _record, Field.DocumentControlNumber );
            _ordered = new Amount( _record, Numeric.Ordered );
            _closed = new Amount( _record, Numeric.Closed );
            _expended = new Amount( _record, Numeric.Expended );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Procurement"/> class.
        /// </summary>
        /// <param name = "databuilder" >
        /// The builder.
        /// </param>
        public Procurement( IBuilder databuilder )
            : base( databuilder )
        {
            _record = databuilder.GetRecord();
            _id = new Key( _record, PrimaryKey.ProcurementId );
            _title = new Element( _record, Field.Title );
            _requestedBy = new Element( _record, Field.RequestedBy );
            _description = new Element( _record, Field.Description );
            _createdBy = new Element( _record, Field.CreatedBy );
            _modifiedBy = new Element( _record, Field.ModifiedBy );
            _lastActionDate = new Time( _record, EventDate.LastActionDate );
            _processedDate = new Time( _record, EventDate.ProcessedDate );
            _closedDate = new Time( _record, EventDate.ClosedDate );
            _securityOrg = new Element( _record, Field.SecurityOrg );
            _vendorCode = new Element( _record, Field.VendorCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DocumentType = new Element( _record, Field.DocumentType );
            _documentDate = new Time( _record, EventDate.DocumentDate );
            _documentControlNumber = new Element( _record, Field.DocumentControlNumber );
            _ordered = new Amount( _record, Numeric.Ordered );
            _closed = new Amount( _record, Numeric.Closed );
            _expended = new Amount( _record, Numeric.Expended );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Procurement"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The data.
        /// </param>
        public Procurement( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.ProcurementId );
            _title = new Element( _record, Field.Title );
            _requestedBy = new Element( _record, Field.RequestedBy );
            _description = new Element( _record, Field.Description );
            _createdBy = new Element( _record, Field.CreatedBy );
            _modifiedBy = new Element( _record, Field.ModifiedBy );
            _lastActionDate = new Time( _record, EventDate.LastActionDate );
            _processedDate = new Time( _record, EventDate.ProcessedDate );
            _closedDate = new Time( _record, EventDate.ClosedDate );
            _securityOrg = new Element( _record, Field.SecurityOrg );
            _vendorCode = new Element( _record, Field.VendorCode );
            _projectCode = new Element( _record, Field.ProjectCode );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DocumentType = new Element( _record, Field.DocumentType );
            _documentDate = new Time( _record, EventDate.DocumentDate );
            _documentControlNumber = new Element( _record, Field.DocumentControlNumber );
            _ordered = new Amount( _record, Numeric.Ordered );
            _closed = new Amount( _record, Numeric.Closed );
            _expended = new Amount( _record, Numeric.Expended );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected Source _source = Source.TravelObligations;

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected readonly IKey _id;

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected  IAmount _amount;

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected readonly IDictionary<string, object> _data;
        
        /// <summary>
        /// Gets the procurement identifier.
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
        /// Gets the procument code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetDocumentControlNumber()
        {
            try
            {
                return Verify.Input( _documentControlNumber.GetValue() )
                    ? _documentControlNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the last activity date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetLastActivityDate()
        {
            try
            {
                return Verify.Input( _lastActionDate?.GetValue() )
                    ? _lastActionDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetClosedDate()
        {
            try
            {
                return Verify.Input( _closedDate?.GetValue() )
                    ? _closedDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the security organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSecurityOrganization()
        {
            try
            {
                return Verify.Input( _securityOrg?.GetValue() )
                    ? _securityOrg
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDescription()
        {
            try
            {
                return Verify.Input( _description?.GetValue() )
                    ? _description
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the ordered.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetOrdered()
        {
            try
            {
                return _ordered.GetFunding() > -1
                    ? _ordered
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the closed.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetClosed()
        {
            try
            {
                return _closed.GetFunding() > -1
                    ? _closed
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetExpended()
        {
            try
            {
                return _expended.GetFunding() > -1
                    ? _expended
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
