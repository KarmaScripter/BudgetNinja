// <copyright file="ICostBase.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    public interface ICostBase
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the foc code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFocCode();

        /// <summary>
        /// Gets the name of the foc.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFocName();

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetProgramProjectCode();

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetProgramAreaCode();

        /// <summary>
        /// Gets the national program code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetNpmCode();

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDocumentType();

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDocumentPrefix();

        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetAgreementNumber();

        /// <summary>
        /// Gets the site project code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetSiteProjectCode();

        /// <summary>
        /// Gets the financial system.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFinancialSystem();

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPurchaseRequest();

        /// <summary>
        /// Gets the document control number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDocumentControlNumber();

        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetGrantNumber();

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetObligatingDocumentNumber();

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetTransactionNumber();
    }
}