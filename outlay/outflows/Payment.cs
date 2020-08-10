// // <copyright file = "Payment.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

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
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IProvider"/>
    /// <seealso cref = "IProgramElement"/>
    public class Payment : Obligation
    {
        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Payment"/> class.
        /// </summary>
        /// <inheritdoc/>
        public Payment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Payment"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Payment( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PaymentId );
            InvoiceNumber = new Element( Record, Field.InvoiceNumber );
            ContractNumber = new Element( Record, Field.ContractNumber );
            OrderNumber = new Element( Record, Field.OrderNumber );
            CheckDate = new Time( Record, Date.CheckDate );
            InvoiceDate = new Time( Record, Date.InvoiceDate );
            ModificationNumber = new Element( Record, Field.ModificationNumber );
            DocumentType = new Element( Record, Field.DocumentNumber );
            DCN = new Element( Record, Field.DCN );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            Amount = new Amount( Record, Numeric.Payment );
            Disbursed = new Amount( Record, Numeric.Disbursed );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Payment"/> class.
        /// </summary>
        /// <param name = "databuilder" >
        /// The builder.
        /// </param>
        public Payment( IBuilder databuilder )
            : base( databuilder )
        {
            Record = databuilder?.GetRecord();
            ID = new Key( Record, PrimaryKey.PaymentId );
            InvoiceNumber = new Element( Record, Field.InvoiceNumber );
            ContractNumber = new Element( Record, Field.ContractNumber );
            OrderNumber = new Element( Record, Field.OrderNumber );
            CheckDate = new Time( Record, Date.CheckDate );
            InvoiceDate = new Time( Record, Date.InvoiceDate );
            ModificationNumber = new Element( Record, Field.ModificationNumber );
            DocumentType = new Element( Record, Field.DocumentNumber );
            DCN = new Element( Record, Field.DCN );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            Amount = new Amount( Record, Numeric.Payment );
            Disbursed = new Amount( Record, Numeric.Disbursed );
            Data = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Payment"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        public Payment( DataRow datarow )
            : base( datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.PaymentId );
            InvoiceNumber = new Element( Record, Field.InvoiceNumber );
            ContractNumber = new Element( Record, Field.ContractNumber );
            OrderNumber = new Element( Record, Field.OrderNumber );
            CheckDate = new Time( Record, Date.CheckDate );
            InvoiceDate = new Time( Record, Date.InvoiceDate );
            ModificationNumber = new Element( Record, Field.ModificationNumber );
            DocumentType = new Element( Record, Field.DocumentNumber );
            DCN = new Element( Record, Field.DCN );
            ProjectCode = new Element( Record, Field.ProjectCode );
            FocCode = new Element( Record, Field.FocCode );
            CostOrgCode = new Element( Record, Field.CostOrgCode );
            Amount = new Amount( Record, Numeric.Payment );
            Disbursed = new Amount( Record, Numeric.Disbursed );
            Data = Record?.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ******************************************************   PROPERTIES   *****************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets the invoice number.
        /// </summary>
        /// <value>
        /// The invoice number.
        /// </value>
        private IElement InvoiceNumber { get; }

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        /// <value>
        /// The invoice date.
        /// </value>
        private ITime InvoiceDate { get; }

        /// <summary>
        /// Gets the contract number.
        /// </summary>
        /// <value>
        /// The contract number.
        /// </value>
        private IElement ContractNumber { get; }

        /// <summary>
        /// Gets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        private IElement OrderNumber { get; }

        /// <summary>
        /// Gets the check date.
        /// </summary>
        /// <value>
        /// The check date.
        /// </value>
        private ITime CheckDate { get; }

        /// <summary>
        /// Gets the modification number.
        /// </summary>
        /// <value>
        /// The modification number.
        /// </value>
        private IElement ModificationNumber { get; }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private IElement ProjectCode { get; }

        /// <summary>
        /// Gets the cost org code.
        /// </summary>
        /// <value>
        /// The cost org code.
        /// </value>
        private IElement CostOrgCode { get; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected override IAmount Amount { get; set; }

        /// <summary>
        /// Gets the disbursed.
        /// </summary>
        /// <value>
        /// The disbursed.
        /// </value>
        private IAmount Disbursed { get; }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the payment identifier.
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
                Payment.Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the name of the payment.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPaymentName()
        {
            try
            {
                return Verify.Element( FocName )
                    ? FocName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the invoice number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetInvoiceNumber()
        {
            try
            {
                return Verify.Element( InvoiceNumber )
                    ? InvoiceNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the invoice date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetInvoiceDate()
        {
            try
            {
                return Verify.Time( InvoiceDate )
                    ? InvoiceDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Time.Default;
            }
        }

        /// <summary>
        /// Gets the contract number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetContractNumber()
        {
            try
            {
                return Verify.Element( ContractNumber )
                    ? ContractNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the order number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetOrderNumber()
        {
            try
            {
                return Verify.Element( OrderNumber )
                    ? OrderNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the check date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetCheckDate()
        {
            try
            {
                return Verify.Time( CheckDate )
                    ? CheckDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Time.Default;
            }
        }

        /// <summary>
        /// Gets the modification number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetModificationNumber()
        {
            try
            {
                return Verify.Element( ModificationNumber )
                    ? ModificationNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
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
                return Verify.Element( ProjectCode )
                    ? ProjectCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the cost organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCostOrganizationCode()
        {
            try
            {
                return Verify.Element( CostOrgCode )
                    ? CostOrgCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Verify.Amount( Amount )
                    ? Amount
                    : default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the disbursement.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetDisbursement()
        {
            try
            {
                return Verify.Amount( Disbursed )
                    ? Disbursed
                    : default;
            }
            catch( Exception ex )
            {
                Payment.Fail( ex );
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
                Payment.Fail( ex );
                return default;
            }
        }
    }
}
