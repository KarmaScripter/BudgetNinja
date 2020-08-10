// <copyright file = "Procurement.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Commitment"/>
    public class Procurement : ProcurementData
    {
        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

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
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ProcurementId );
            Title = new Element( Record, Field.Title );
            RequestedBy = new Element( Record, Field.RequestedBy );
            Description = new Element( Record, Field.Description );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            LastActionDate = new Time( Record, Date.LastActionDate );
            ProcessedDate = new Time( Record, Date.ProcessedDate );
            ClosedDate = new Time( Record, Date.ClosedDate );
            SecurityOrg = new Element( Record, Field.SecurityOrg );
            VendorCode = new Element( Record, Field.VendorCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DocumentType = new Element( Record, Field.DocumentType );
            DocumentDate = new Time( Record, Date.DocumentDate );
            DocumentControlNumber = new Element( Record, Field.DocumentControlNumber );
            Ordered = new Amount( Record, Numeric.Ordered );
            Closed = new Amount( Record, Numeric.Closed );
            Expended = new Amount( Record, Numeric.Expended );
            Data = Record?.ToDictionary();
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
            Record = databuilder.GetRecord();
            ID = new Key( Record, PrimaryKey.ProcurementId );
            Title = new Element( Record, Field.Title );
            RequestedBy = new Element( Record, Field.RequestedBy );
            Description = new Element( Record, Field.Description );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            LastActionDate = new Time( Record, Date.LastActionDate );
            ProcessedDate = new Time( Record, Date.ProcessedDate );
            ClosedDate = new Time( Record, Date.ClosedDate );
            SecurityOrg = new Element( Record, Field.SecurityOrg );
            VendorCode = new Element( Record, Field.VendorCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DocumentType = new Element( Record, Field.DocumentType );
            DocumentDate = new Time( Record, Date.DocumentDate );
            DocumentControlNumber = new Element( Record, Field.DocumentControlNumber );
            Ordered = new Amount( Record, Numeric.Ordered );
            Closed = new Amount( Record, Numeric.Closed );
            Expended = new Amount( Record, Numeric.Expended );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Procurement"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        public Procurement( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.ProcurementId );
            Title = new Element( Record, Field.Title );
            RequestedBy = new Element( Record, Field.RequestedBy );
            Description = new Element( Record, Field.Description );
            CreatedBy = new Element( Record, Field.CreatedBy );
            ModifiedBy = new Element( Record, Field.ModifiedBy );
            LastActionDate = new Time( Record, Date.LastActionDate );
            ProcessedDate = new Time( Record, Date.ProcessedDate );
            ClosedDate = new Time( Record, Date.ClosedDate );
            SecurityOrg = new Element( Record, Field.SecurityOrg );
            VendorCode = new Element( Record, Field.VendorCode );
            ProjectCode = new Element( Record, Field.ProjectCode );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DocumentType = new Element( Record, Field.DocumentType );
            DocumentDate = new Time( Record, Date.DocumentDate );
            DocumentControlNumber = new Element( Record, Field.DocumentControlNumber );
            Ordered = new Amount( Record, Numeric.Ordered );
            Closed = new Amount( Record, Numeric.Closed );
            Expended = new Amount( Record, Numeric.Expended );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        protected override Source Source { get; set; } = Source.TravelObligations;

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected override IDictionary<string, object> Data { get; set; }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the procurement identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( DocumentControlNumber.GetValue() )
                    ? DocumentControlNumber
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( LastActionDate?.GetValue() )
                    ? LastActionDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( ClosedDate?.GetValue() )
                    ? ClosedDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( SecurityOrg?.GetValue() )
                    ? SecurityOrg
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( Description?.GetValue() )
                    ? Description
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Ordered.GetFunding() > -1
                    ? Ordered
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Closed.GetFunding() > -1
                    ? Closed
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Expended.GetFunding() > -1
                    ? Expended
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
