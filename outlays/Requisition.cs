// <copyright file = "Requisition.cs" company = "Terry D. Eppler">
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
    public class Requisition : RequisitionData
    {
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly new Source _source = Source.Requisitions;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        public Requisition()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Requisition( IQuery query )
            : base( query )
        {
            _records = new Builder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.RequisitionId );
            _dcn = new Element( _records, Field.DCN );
            _requestNumber = new Element( _records, Field.RequestNumber );
            _modifiedBy = new Element( _records, Field.ModifiedBy );
            _createdBy = new Element( _records, Field.CreatedBy );
            _projectCode = new Element( _records, Field.ProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _requestDate = new Time( _records, EventDate.RequestDate );
            _documentDate = new Time( _records, EventDate.DocumentDate );
            _closedDate = new Time( _records, EventDate.ClosedDate );
            _requested = new Amount( _records, Numeric.Requested );
            _closed = new Amount( _records, Numeric.Closed );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "db" >
        /// The builder.
        /// </param>
        public Requisition( IBuilder db )
            : base( db )
        {
            _records = db.GetRecord();
            _id = new Key( _records, PrimaryKey.RequisitionId );
            _dcn = new Element( _records, Field.DCN );
            _requestNumber = new Element( _records, Field.RequestNumber );
            _modifiedBy = new Element( _records, Field.ModifiedBy );
            _createdBy = new Element( _records, Field.CreatedBy );
            _projectCode = new Element( _records, Field.ProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _requestDate = new Time( _records, EventDate.RequestDate );
            _documentDate = new Time( _records, EventDate.DocumentDate );
            _closedDate = new Time( _records, EventDate.ClosedDate );
            _requested = new Amount( _records, Numeric.Requested );
            _closed = new Amount( _records, Numeric.Closed );
            _data = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Requisition"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Requisition( DataRow data )
        {
            _records = data;
            _id = new Key( _records, PrimaryKey.RequisitionId );
            _dcn = new Element( _records, Field.DCN );
            _requestNumber = new Element( _records, Field.RequestNumber );
            _modifiedBy = new Element( _records, Field.ModifiedBy );
            _createdBy = new Element( _records, Field.CreatedBy );
            _projectCode = new Element( _records, Field.ProjectCode );
            _focCode = new Element( _records, Field.FocCode );
            _requestDate = new Time( _records, EventDate.RequestDate );
            _documentDate = new Time( _records, EventDate.DocumentDate );
            _closedDate = new Time( _records, EventDate.ClosedDate );
            _requested = new Amount( _records, Numeric.Requested );
            _closed = new Amount( _records, Numeric.Closed );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the requisition identifier.
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
        /// Gets the requisition code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRequisitionCode()
        {
            try
            {
                return Verify.Input( _accountCode.GetValue() )
                    ? _accountCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetModifiedBy()
        {
            try
            {
                return Verify.Input( _modifiedBy.GetValue() )
                    ? _modifiedBy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectCode()
        {
            try
            {
                return Verify.Input( _projectCode.GetValue() )
                    ? _projectCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the request date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetRequestDate()
        {
            try
            {
                return _requestDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCreatedBy()
        {
            try
            {
                return Verify.Input( _createdBy.GetValue() )
                    ? _createdBy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetDocumentDate()
        {
            try
            {
                return _documentDate;
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
                return _closedDate;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the requested amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetRequestedAmount()
        {
            try
            {
                return _requested.GetFunding() > -1
                    ? _requested
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the closed amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetClosedAmount()
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
        /// Gets the outstanding amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetOutstandingAmount()
        {
            try
            {
                return _outstanding.GetFunding() > -1
                    ? _outstanding
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the expended amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetExpendedAmount()
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
        /// Gets the reversal amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetReversalAmount()
        {
            try
            {
                return _reversed.GetFunding() > -1
                    ? _reversed
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
        public new IDictionary<string, object> ToDictionary()
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
