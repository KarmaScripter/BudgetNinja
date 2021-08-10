// <copyright file = "RequisitionData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class RequisitionData : Commitment
    {
        /// <summary>
        /// Gets the request number.
        /// </summary>
        /// <value>
        /// The request number.
        /// </value>
        private protected IElement _requestNumber;

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        private protected IElement _modifiedBy;

        /// <summary>
        /// Gets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        private protected ITime _requestDate;

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        private protected IElement _createdBy;

        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        private protected ITime _documentDate;

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        private protected ITime _closedDate;

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement _projectCode;

        /// <summary>
        /// Gets the requested.
        /// </summary>
        /// <value>
        /// The requested.
        /// </value>
        private protected IAmount _requested;

        /// <summary>
        /// Gets the closed.
        /// </summary>
        /// <value>
        /// The closed.
        /// </value>
        private protected IAmount _closed;

        /// <summary>
        /// Gets or sets the outstanding.
        /// </summary>
        /// <value>
        /// The outstanding.
        /// </value>
        private protected IAmount _outstanding;

        /// <summary>
        /// Gets or sets the expended.
        /// </summary>
        /// <value>
        /// The expended.
        /// </value>
        private protected IAmount _expended;

        /// <summary>
        /// Gets or sets the reversed.
        /// </summary>
        /// <value>
        /// The reversed.
        /// </value>
        private protected IAmount _reversed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequisitionData"/> class.
        /// </summary>
        /// <inheritdoc />
        public RequisitionData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequisitionData"/> class.
        /// </summary>
        /// <param name="query"></param>
        public RequisitionData( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequisitionData"/> class.
        /// </summary>
        /// <param name="builder">The database.</param>
        public RequisitionData( IBuilder builder )
            : base( builder )
        {
        }
    }
}
