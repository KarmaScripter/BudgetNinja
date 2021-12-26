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
        public IDictionary<string, object> Data { get; set; } 

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        public IElement ProgramProjectCode { get; set; } 

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        public IElement ProgramAreaCode { get; set; } 

        /// <summary>
        /// Gets or sets the NPM code.
        /// </summary>
        /// <value>
        /// The NPM code.
        /// </value>
        public IElement NpmCode { get; set; } 

        /// <summary>
        /// Gets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        public IElement FocCode { get; set; } 

        /// <summary>
        /// Gets the name of the foc.
        /// </summary>
        /// <value>
        /// The name of the foc.
        /// </value>
        public IElement FocName { get; set; } 

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public IElement DocPrefix { get; set; } 

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <value>
        /// The document prefix.
        /// </value>
        public IElement DocType { get; set; } 

        /// <summary>
        /// Gets the DCN.
        /// </summary>
        /// <value>
        /// The DCN.
        /// </value>
        public IElement DCN { get; set; } 

        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <value>
        /// The grant number.
        /// </value>
        public IElement GrantNumber { get; set; } 

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <value>
        /// The obligating document number.
        /// </value>
        public IElement ObligatingDocumentNumber { get; set; } 

        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <value>
        /// The reimbursable agreement number.
        /// </value>
        public IElement AgreementNumber { get; set; } 

        /// <summary>
        /// Gets the site project code.
        /// </summary>
        /// <value>
        /// The site project code.
        /// </value>
        public IElement SiteProjectCode { get; set; } 

        /// <summary>
        /// Gets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        public IElement System { get; set; } 

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <value>
        /// The transaction number.
        /// </value>
        public IElement TransactionNumber { get; set; } 

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <value>
        /// The purchase request.
        /// </value>
        public IElement PurchaseRequest { get; set; } 
        
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
                return Verify.Input( FocCode?.GetValue() )
                    ? FocCode
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
                return Verify.Input( FocName?.GetValue() )
                    ? FocName
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
                return Verify.Input( ProgramProjectCode?.GetValue() )
                    ? ProgramProjectCode
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
                return Verify.Input( ProgramAreaCode?.GetValue() )
                    ? ProgramAreaCode
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
                return Verify.Input( NpmCode?.GetValue() )
                    ? NpmCode
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
                return Verify.Input( DocPrefix?.GetValue() )
                    ? DocPrefix
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
                return Verify.Input( DocType?.GetValue() )
                    ? DocType
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
                return Verify.Input( AgreementNumber?.GetValue() )
                    ? AgreementNumber
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
                return Verify.Input( SiteProjectCode?.GetValue() )
                    ? SiteProjectCode
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
                return Verify.Input( System?.GetValue() )
                    ? System
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
                return Verify.Input( PurchaseRequest?.GetValue() )
                    ? PurchaseRequest
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
                return Verify.Input( DCN?.GetValue() )
                    ? DCN
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
                return Verify.Input( GrantNumber?.GetValue() )
                    ? GrantNumber
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
                return Verify.Input( ObligatingDocumentNumber?.GetValue() )
                    ? ObligatingDocumentNumber
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
                return Verify.Input( TransactionNumber?.GetValue() )
                    ? TransactionNumber
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
