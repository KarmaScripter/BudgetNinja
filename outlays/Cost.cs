// <copyright file = "Cost.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

// ReSharper disable All
namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Cost class is the abstract representation of appropriated resources used in
    /// the execution of the EPA's Strategtic Plan. It ties elements of the Agency's
    /// Account Code Structure to the Strategic Plan along with their corresponding
    /// outlays; Costs are implemented in conjunction with the actual expenses
    /// incurred.
    /// </summary>
    /// <seealso cref = "Expense"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public abstract class Cost : Expense, ICostBase
    {
        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private protected IElement _programProjectCode;

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected IElement _programAreaCode;

        /// <summary>
        /// Gets or sets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        private protected IElement _npmCode;

        /// <summary>
        /// Gets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private protected IElement _focCode;

        /// <summary>
        /// Gets the name of the foc.
        /// </summary>
        /// <value>
        /// The name of the foc.
        /// </value>
        private protected IElement _focName;

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        private protected IElement _documentType;

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        private protected IElement _documentPrefix;

        /// <summary>
        /// Gets the _dcn.
        /// </summary>
        /// <value>
        /// The _dcn.
        /// </value>
        private protected IElement _dcn;

        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <value>
        /// The grant number.
        /// </value>
        private protected IElement _grantNumber;

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <value>
        /// The obligating document number.
        /// </value>
        private protected IElement _obligatingDocumentNumber;

        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <value>
        /// The reimbursable agreement number.
        /// </value>
        private protected IElement _agreementNumber;

        /// <summary>
        /// Gets the site project code.
        /// </summary>
        /// <value>
        /// The site project code.
        /// </value>
        private protected IElement _siteProjectCode;

        /// <summary>
        /// Gets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        private protected IElement _system;

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <value>
        /// The transaction number.
        /// </value>
        private protected IElement _transactionNumber;

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <value>
        /// The purchase request.
        /// </value>
        private protected IElement _purchaseRequest;
        
        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IDictionary<string, object> ToDictionary()
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

        /// <summary>
        /// Gets the foc code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFocCode()
        {
            try
            {
                return Verify.Input( _focCode?.GetValue() )
                    ? _focCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the name of the foc.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFocName()
        {
            try
            {
                return Verify.Input( _focName?.GetValue() )
                    ? _focName
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProgramProjectCode()
        {
            try
            {
                return Verify.Input( _programProjectCode?.GetValue() )
                    ? _programProjectCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProgramAreaCode()
        {
            try
            {
                return Verify.Input( _programAreaCode?.GetValue() )
                    ? _programAreaCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the national program code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNpmCode()
        {
            try
            {
                return Verify.Input( _npmCode?.GetValue() )
                    ? _npmCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentType()
        {
            try
            {
                return Verify.Input( _documentType?.GetValue() )
                    ? _documentType
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetDocumentPrefix()
        {
            try
            {
                return Verify.Input( _documentPrefix?.GetValue() )
                    ? _documentPrefix
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetAgreementNumber()
        {
            try
            {
                return Verify.Input( _agreementNumber?.GetValue() )
                    ? _agreementNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the site project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSiteProjectCode()
        {
            try
            {
                return Verify.Input( _siteProjectCode?.GetValue() )
                    ? _siteProjectCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the financial system.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFinancialSystem()
        {
            try
            {
                return Verify.Input( _system?.GetValue() )
                    ? _system
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPurchaseRequest()
        {
            try
            {
                return Verify.Input( _purchaseRequest?.GetValue() )
                    ? _purchaseRequest
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the document control number.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IElement GetDocumentControlNumber()
        {
            try
            {
                return Verify.Input( _dcn?.GetValue() )
                    ? _dcn
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetGrantNumber()
        {
            try
            {
                return Verify.Input( _grantNumber?.GetValue() )
                    ? _grantNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetObligatingDocumentNumber()
        {
            try
            {
                return Verify.Input( _obligatingDocumentNumber?.GetValue() )
                    ? _obligatingDocumentNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetTransactionNumber()
        {
            try
            {
                return Verify.Input( _transactionNumber?.GetValue() )
                    ? _transactionNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }
    }
}
