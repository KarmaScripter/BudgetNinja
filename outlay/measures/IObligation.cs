// // <copyright file = "IObligation.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    /// <summary>
    /// </summary>
    /// <seealso cref = "IOutlay"/>
    public interface IObligation : IOutlay
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the finance object class code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFinanceObjectClassCode();

        /// <summary>
        /// Gets the name of the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFinanceObjectClassName();

        /// <summary>
        /// Gets the document control number.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDocumentControlNumber();

        /// <summary>
        /// Gets the obligating document number.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetObligatingDocumentNumber();

        /// <summary>
        /// Gets the document prefix.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDocumentPrefix();

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDocumentType();

        /// <summary>
        /// Gets the financial system.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFinancialSystem();

        /// <summary>
        /// Gets the transaction number.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetTransactionNumber();

        /// <summary>
        /// Gets the obligation amount.
        /// </summary>
        /// <returns>
        /// </returns>
        double GetObligationAmount();
    }
}
