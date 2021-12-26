// <copyright file = "IFullTimeEquivalent.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    public interface IFullTimeEquivalent
    {
        /// <summary>
        /// Gets the ProgramResultCodes identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramProject GetProgramProject();

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramArea GetProgramArea();

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetAmount();

        /// <summary>
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramResultsCode GetProgramResultsCode();

        /// <summary>
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetLevel GetBudgetLevel();

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetFiscalYear GetBudgetFiscalYear();

        /// <summary>
        /// Gets the resource planning office.
        /// </summary>
        /// <returns>
        /// </returns>
        IResourcePlanningOffice GetResourcePlanningOffice();

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        IAllowanceHolder GetAllowanceHolder();

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
    }
}
