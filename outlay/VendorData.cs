// <copyright file = "VendorData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Threading;

    public class VendorData : Obligation
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorData"/> class.
        /// </summary>
        /// <inheritdoc />
        public VendorData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorData"/> class.
        /// </summary>
        /// <param name="query"></param>
        public VendorData( IQuery query )
            : base( query )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorData"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public VendorData( IBuilder builder )
            : base( builder )
        {
        }

        // ***************************************************************************************************************************
        // *************************************************   PROPERTIES   **********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected IElement Code { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected IElement Name { get; set; }

        /// <summary>
        /// Gets the duns number.
        /// </summary>
        /// <value>
        /// The duns number.
        /// </value>
        private protected IElement DunsNumber { get; set; }

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <value>
        /// The document number.
        /// </value>
        private protected IElement DocumentNumber { get; set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        private protected ITime StartDate { get; set; }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        private protected ITime EndDate { get; set; }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        private protected ITime ClosedDate { get; set; }

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <value>
        /// The expended.
        /// </value>
        private protected IAmount Expended { get; set; }
    }
}
