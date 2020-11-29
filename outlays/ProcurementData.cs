// <copyright file = "ProcurementData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Commitment" />
    public class ProcurementData : Commitment
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

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
        /// <param name="datarow">The dr.</param>
        public ProcurementData( DataRow datarow )
            : base( datarow )
        {
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the document date.
        /// </summary>
        /// <value>
        /// The document date.
        /// </value>
        private protected ITime DocumentDate { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        private protected IElement Title { get; set; }

        /// <summary>
        /// Gets the requested by.
        /// </summary>
        /// <value>
        /// The requested by.
        /// </value>
        private protected IElement RequestedBy { get; set; }

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        private protected IElement CreatedBy { get; set; }

        /// <summary>
        /// Gets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        private protected IElement ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        private protected ITime RequestDate { get; set; }

        /// <summary>
        /// Gets the last action date.
        /// </summary>
        /// <value>
        /// The last action date.
        /// </value>
        private protected ITime LastActionDate { get; set; }

        /// <summary>
        /// Gets the processed date.
        /// </summary>
        /// <value>
        /// The processed date.
        /// </value>
        private protected ITime ProcessedDate { get; set; }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement ProjectCode { get; set; }

        /// <summary>
        /// Gets the document control number.
        /// </summary>
        /// <value>
        /// The document control number.
        /// </value>
        private protected IElement DocumentControlNumber { get; set; }

        /// <summary>
        /// Gets the security org.
        /// </summary>
        /// <value>
        /// The security org.
        /// </value>
        private protected IElement SecurityOrg { get; set; }

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        private protected ITime ClosedDate { get; set; }

        /// <summary>
        /// Gets the vendor code.
        /// </summary>
        /// <value>
        /// The vendor code.
        /// </value>
        private protected IElement VendorCode { get; set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        private protected IElement Description { get; set; }

        /// <summary>
        /// Gets the ordered.
        /// </summary>
        /// <value>
        /// The ordered.
        /// </value>
        private protected IAmount Ordered { get; set; }

        /// <summary>
        /// Gets the closed.
        /// </summary>
        /// <value>
        /// The closed.
        /// </value>
        private protected IAmount Closed { get; set; }

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <value>
        /// The expended.
        /// </value>
        private protected IAmount Expended { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the name of the procument.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentTitle()
        {
            try
            {
                return Verify.Input( Title.GetValue() )
                    ? Title
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( DocumentDate.GetValue() )
                    ? DocumentDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( RequestedBy.GetValue() )
                    ? RequestedBy
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( CreatedBy?.GetValue() )
                    ? RequestedBy
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( ModifiedBy?.GetValue() )
                    ? ModifiedBy
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( ProcessedDate?.GetValue() )
                    ? ProcessedDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( RequestDate?.GetValue() )
                    ? RequestDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
