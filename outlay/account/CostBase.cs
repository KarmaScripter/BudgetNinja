// // <copyright file = "CostBase.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// The Cost class is the abstract representation of appropriated resources used in
    /// the execution of the EPA's Strategtic Plan. It ties elements of the Agency's
    /// Account Code Structure to the Strategic Plan along with their corresponding
    /// outlays; Costs are implemented in conjunction with the actual expenses
    /// incurred.
    /// </summary>
    /// <seealso cref = "ExpenseBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public abstract class CostBase : ExpenseBase, ICostBase
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected virtual IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private protected IElement ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected IElement ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets or sets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        private protected IElement NpmCode { get; set; }

        /// <summary>
        /// Gets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private protected IElement FocCode { get; set; }

        /// <summary>
        /// Gets the name of the foc.
        /// </summary>
        /// <value>
        /// The name of the foc.
        /// </value>
        private protected IElement FocName { get; set; }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        private protected IElement DocumentType { get; set; }

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        private protected IElement DocumentPrefix { get; set; }

        /// <summary>
        /// Gets the DCN.
        /// </summary>
        /// <value>
        /// The DCN.
        /// </value>
        private protected IElement DCN { get; set; }

        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <value>
        /// The grant number.
        /// </value>
        private protected IElement GrantNumber { get; set; }

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <value>
        /// The obligating document number.
        /// </value>
        private protected IElement ObligatingDocumentNumber { get; set; }

        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <value>
        /// The reimbursable agreement number.
        /// </value>
        private protected IElement AgreementNumber { get; set; }

        /// <summary>
        /// Gets the site project code.
        /// </summary>
        /// <value>
        /// The site project code.
        /// </value>
        private protected IElement SiteProjectCode { get; set; }

        /// <summary>
        /// Gets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        private protected IElement System { get; set; }

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <value>
        /// The transaction number.
        /// </value>
        private protected IElement TransactionNumber { get; set; }

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <value>
        /// The purchase request.
        /// </value>
        private protected IElement PurchaseRequest { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( FocCode?.GetValue() )
                    ? FocCode
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( FocName?.GetValue() )
                    ? FocName
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( ProgramProjectCode?.GetValue() )
                    ? ProgramProjectCode
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( ProgramAreaCode?.GetValue() )
                    ? ProgramAreaCode
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( NpmCode?.GetValue() )
                    ? NpmCode
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( DocumentType?.GetValue() )
                    ? DocumentType
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( DocumentPrefix?.GetValue() )
                    ? DocumentPrefix
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( AgreementNumber?.GetValue() )
                    ? AgreementNumber
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( SiteProjectCode?.GetValue() )
                    ? SiteProjectCode
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( System?.GetValue() )
                    ? System
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( PurchaseRequest?.GetValue() )
                    ? PurchaseRequest
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( DCN?.GetValue() )
                    ? DCN
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( GrantNumber?.GetValue() )
                    ? GrantNumber
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( ObligatingDocumentNumber?.GetValue() )
                    ? ObligatingDocumentNumber
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
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
                return Verify.Input( TransactionNumber?.GetValue() )
                    ? TransactionNumber
                    : default;
            }
            catch( Exception ex )
            {
                CostBase.Fail( ex );
                return default;
            }
        }
    }
}
