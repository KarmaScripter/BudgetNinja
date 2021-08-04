// <copyright file = "Payment.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Obligation"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IProvider"/>
    /// <seealso cref = "IProgramElement"/>
    public class Payment : Obligation
    {
        /// <summary>
        /// Gets the invoice number.
        /// </summary>
        /// <value>
        /// The invoice number.
        /// </value>
        private readonly IElement _invoiceNumber;

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        /// <value>
        /// The invoice date.
        /// </value>
        private readonly ITime _invoiceDate;

        /// <summary>
        /// Gets the contract number.
        /// </summary>
        /// <value>
        /// The contract number.
        /// </value>
        private readonly IElement _contractNumber;

        /// <summary>
        /// Gets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        private readonly IElement _orderNumber;

        /// <summary>
        /// Gets the check date.
        /// </summary>
        /// <value>
        /// The check date.
        /// </value>
        private readonly ITime _checkDate;

        /// <summary>
        /// Gets the modification number.
        /// </summary>
        /// <value>
        /// The modification number.
        /// </value>
        private readonly IElement _modificationNumber;

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private readonly IElement _projectCode;

        /// <summary>
        /// Gets the cost org code.
        /// </summary>
        /// <value>
        /// The cost org code.
        /// </value>
        private readonly IElement _costOrgCode;
        
        /// <summary>
        /// Gets the disbursed.
        /// </summary>
        /// <value>
        /// The disbursed.
        /// </value>
        private readonly IAmount _disbursed;

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
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PaymentId );
            _invoiceNumber = new Element( _record, Field.InvoiceNumber );
            _contractNumber = new Element( _record, Field.ContractNumber );
            _orderNumber = new Element( _record, Field.OrderNumber );
            _checkDate = new Time( _record, EventDate.CheckDate );
            _invoiceDate = new Time( _record, EventDate.InvoiceDate );
            _modificationNumber = new Element( _record, Field.ModificationNumber );
            DocumentType = new Element( _record, Field.DocumentNumber );
            DCN = new Element( _record, Field.DCN );
            _projectCode = new Element( _record, Field.ProjectCode );
            FocCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _amount = new Amount( _record, Numeric.Payment );
            _disbursed = new Amount( _record, Numeric.Disbursed );
            _data = _record?.ToDictionary();
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
            _record = databuilder?.GetRecord();
            _id = new Key( _record, PrimaryKey.PaymentId );
            _invoiceNumber = new Element( _record, Field.InvoiceNumber );
            _contractNumber = new Element( _record, Field.ContractNumber );
            _orderNumber = new Element( _record, Field.OrderNumber );
            _checkDate = new Time( _record, EventDate.CheckDate );
            _invoiceDate = new Time( _record, EventDate.InvoiceDate );
            _modificationNumber = new Element( _record, Field.ModificationNumber );
            DocumentType = new Element( _record, Field.DocumentNumber );
            DCN = new Element( _record, Field.DCN );
            _projectCode = new Element( _record, Field.ProjectCode );
            FocCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _amount = new Amount( _record, Numeric.Payment );
            _disbursed = new Amount( _record, Numeric.Disbursed );
            _data = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Payment"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The data.
        /// </param>
        public Payment( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.PaymentId );
            _invoiceNumber = new Element( _record, Field.InvoiceNumber );
            _contractNumber = new Element( _record, Field.ContractNumber );
            _orderNumber = new Element( _record, Field.OrderNumber );
            _checkDate = new Time( _record, EventDate.CheckDate );
            _invoiceDate = new Time( _record, EventDate.InvoiceDate );
            _modificationNumber = new Element( _record, Field.ModificationNumber );
            DocumentType = new Element( _record, Field.DocumentNumber );
            DCN = new Element( _record, Field.DCN );
            _projectCode = new Element( _record, Field.ProjectCode );
            FocCode = new Element( _record, Field.FocCode );
            _costOrgCode = new Element( _record, Field.CostOrgCode );
            _amount = new Amount( _record, Numeric.Payment );
            _disbursed = new Amount( _record, Numeric.Disbursed );
            _data = _record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the payment identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                Fail( ex );
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
                return Verify.Element( _invoiceNumber )
                    ? _invoiceNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Time( _invoiceDate )
                    ? _invoiceDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Element( _contractNumber )
                    ? _contractNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Element( _orderNumber )
                    ? _orderNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Time( _checkDate )
                    ? _checkDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Element( _modificationNumber )
                    ? _modificationNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Element( _projectCode )
                    ? _projectCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Element( _costOrgCode )
                    ? _costOrgCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
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
                return Verify.Amount( _amount )
                    ? _amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
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
                return Verify.Amount( _disbursed )
                    ? _disbursed
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
