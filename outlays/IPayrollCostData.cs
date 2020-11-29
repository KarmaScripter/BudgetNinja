// <copyright file = "IPayrollCostData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public interface IPayrollCostData
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the approval date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetApprovalDate();

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetProjectCode();

        /// <summary>
        /// Gets the name of the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetProjectCodeName();

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetFiscalYear GetBudgetFiscalYear();

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        IFinanceObjectClass GetFinanceObjectClass();

        /// <summary>
        /// Gets the fund.
        /// </summary>
        /// <returns>
        /// </returns>
        IFund GetFund();

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>
        /// </returns>
        IOrganization GetOrganization();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        IAccount GetAccount();

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        IResponsibilityCenter GetResponsibilityCenter();

        /// <summary>
        /// Gets the work codes.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<WorkCode> GetWorkCodes();
    }
}
