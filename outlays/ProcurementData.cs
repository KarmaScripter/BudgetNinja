// <copyright file = "ProcurementData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Commitment" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ProcurementData : Commitment
    {
        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        private protected ITime _documentDate;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private protected IElement _title;

        /// <summary>
        /// Gets the requested by.
        /// </summary>
        /// <value>
        /// The requested by.
        /// </value>
        private protected IElement _requestedBy;

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        private protected IElement _createdBy;

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        private protected IElement _modifiedBy;

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        private protected ITime _requestDate;

        /// <summary>
        /// Gets the last action date.
        /// </summary>
        /// <value>
        /// The last action date.
        /// </value>
        private protected ITime _lastActionDate;

        /// <summary>
        /// Gets the processed date.
        /// </summary>
        /// <value>
        /// The processed date.
        /// </value>
        private protected ITime _processedDate;

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement _projectCode;

        /// <summary>
        /// Gets the document control number.
        /// </summary>
        /// <value>
        /// The document control number.
        /// </value>
        private protected IElement _documentControlNumber;

        /// <summary>
        /// Gets the security org.
        /// </summary>
        /// <value>
        /// The security org.
        /// </value>
        private protected IElement _securityOrg;

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        private protected ITime _closedDate;

        /// <summary>
        /// Gets the vendor code.
        /// </summary>
        /// <value>
        /// The vendor code.
        /// </value>
        private protected IElement _vendorCode;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        private protected IElement _description;

        /// <summary>
        /// Gets the ordered.
        /// </summary>
        /// <value>
        /// The ordered.
        /// </value>
        private protected IAmount _ordered;

        /// <summary>
        /// Gets the closed.
        /// </summary>
        /// <value>
        /// The closed.
        /// </value>
        private protected IAmount _closed;

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <value>
        /// The expended.
        /// </value>
        private protected IAmount _expended;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcurementData"/> class.
        /// </summary>
        /// <inheritdoc />
        public ProcurementData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcurementData"/> class.
        /// </summary>
        /// <param name="query"></param>
        public ProcurementData( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcurementData"/> class.
        /// </summary>
        /// <param name="databuilder">The databuilder.</param>
        public ProcurementData( IBuilder databuilder )
            : base( databuilder )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcurementData"/> class.
        /// </summary>
        /// <param name="dataRow">The dr.</param>
        public ProcurementData( DataRow dataRow )
            : base( dataRow )
        {
        }

        /// <summary>
        /// Gets the name of the procument.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentTitle()
        {
            try
            {
                return Verify.Input( _title.GetValue() )
                    ? _title
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
                return Verify.Input( _documentDate.GetValue() )
                    ? _documentDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the requested by.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRequestedBy()
        {
            try
            {
                return Verify.Input( _requestedBy.GetValue() )
                    ? _requestedBy
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Input( _createdBy?.GetValue() )
                    ? _requestedBy
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
                return Verify.Input( _modifiedBy?.GetValue() )
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
        /// Gets the processed date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetProcessedDate()
        {
            try
            {
                return Verify.Input( _processedDate?.GetValue() )
                    ? _processedDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
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
                return Verify.Input( _requestDate?.GetValue() )
                    ? _requestDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }
    }
}
