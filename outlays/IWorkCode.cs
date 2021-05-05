// <copyright file = "IWorkCode.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IWorkCode
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
        IEnumerable<IWorkCode> GetWorkCodes();

        /// <summary>
        /// Gets the division.
        /// </summary>
        /// <returns>
        /// </returns>
        IDivision GetDivision();

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> ToDictionary();

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
        IElement GetProjectCode();

        /// <summary>
        /// Gets the name of the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetProjectCodeName();

        /// <summary>
        /// Gets the work code identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWorkCode();

        /// <summary>
        /// Gets the name of the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWorkCodeName();

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetShortName();

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetStatus();

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetNotifications();

        /// <summary>
        /// Gets the pay period.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPayPeriod();
    }
}
