// <copyright file="{ClassName}.cs" company="Terry D. Eppler">
// Copyright (c) Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Threading;

    public class RequisitionData : Commitment
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

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
        /// <param name="db">The database.</param>
        public RequisitionData( IBuilder db )
            : base( db )
        {
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the request number.
        /// </summary>
        /// <value>
        /// The request number.
        /// </value>
        private protected IElement RequestNumber { get; set; }

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        private protected IElement ModifiedBy { get; set; }

        /// <summary>
        /// Gets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        private protected ITime RequestDate { get; set; }

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        private protected IElement CreatedBy { get; set; }

        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        private protected ITime DocumentDate { get; set; }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        private protected ITime ClosedDate { get; set; }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement ProjectCode { get; set; }

        /// <summary>
        /// Gets the requested.
        /// </summary>
        /// <value>
        /// The requested.
        /// </value>
        private protected IAmount Requested { get; set; }

        /// <summary>
        /// Gets the closed.
        /// </summary>
        /// <value>
        /// The closed.
        /// </value>
        private protected IAmount Closed { get; set; }

        /// <summary>
        /// Gets or sets the outstanding.
        /// </summary>
        /// <value>
        /// The outstanding.
        /// </value>
        private protected IAmount Outstanding { get; set; }

        /// <summary>
        /// Gets or sets the expended.
        /// </summary>
        /// <value>
        /// The expended.
        /// </value>
        private protected IAmount Expended { get; set; }

        /// <summary>
        /// Gets or sets the reversed.
        /// </summary>
        /// <value>
        /// The reversed.
        /// </value>
        private protected IAmount Reversed { get; set; }
    }
}