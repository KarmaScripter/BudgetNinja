// // <copyright file = "IReprogramming.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Threading;

    /// <summary>
    /// </summary>
    public interface IReprogramming
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the transfer identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetTransferId();

        /// <summary>
        /// Gets the fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFiscalYear();

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetResourcePlanningOfficeCode();

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFundCode();

        /// <summary>
        /// Gets the allowance holder code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetAllowanceHolderCode();

        /// <summary>
        /// Gets the responsibility center code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetResponsibilityCenterCode();

        /// <summary>
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        Level GetBudgetLevel();

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetAccountCode();

        /// <summary>
        /// Gets the organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetOrganizationCode();

        /// <summary>
        /// Gets the budget object class code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetBudgetObjectClassCode();

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetDate();

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDocumentType();

        /// <summary>
        /// Gets from to.
        /// </summary>
        /// <returns>
        /// </returns>
        FromTo GetFromTo();

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetDocumentNumber();

        /// <summary>
        /// Gets the purpose.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetPurpose();
    }
}
