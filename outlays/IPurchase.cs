// <copyright file = "IPurchase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IPurchase
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the purchase identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <inheritdoc/>
        /// <summary>
        /// Gets the grant number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetGrantNumber();

        /// <inheritdoc/>
        /// <summary>
        /// Gets the reimbursable agreement number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetReimbursableAgreementNumber();

        /// <inheritdoc/>
        /// <summary>
        /// Gets the system.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetSystem();

        /// <summary>
        /// Gets the purchase request.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPurchaseRequest();

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
        /// Gets the document control number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDocumentNumber();

        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetOriginalActionDate();

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetObligatingDocumentNumber();

        /// <summary>
        /// Gets the financial system.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFinancialSystem();

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetTransactionNumber();
    }
}
