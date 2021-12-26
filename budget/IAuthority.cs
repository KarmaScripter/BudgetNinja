// <copyright file = "IAuthority.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "ISource"/>
    public interface IAuthority : ISource
    {
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
        /// Gets the fund.
        /// </summary>
        /// <returns>
        /// </returns>
        IFund GetFund();

        /// <summary>
        /// Gets the allowance holder.
        /// </summary>
        /// <returns>
        /// </returns>
        IAllowanceHolder GetAllowanceHolder();

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <returns>
        /// </returns>
        IOrganization GetOrganization();

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        IResponsibilityCenter GetResponsibilityCenter();

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
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramResultsCode GetProgramResultsCode();

        /// <summary>
        /// Gets the dictionary that can be used arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> ToDictionary();

        /// <summary>
        /// Gets the dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<DataRow> GetData();

        /// <summary>
        /// Gets the metric.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        IDataMetric GetMetric( IEnumerable<DataRow> dataRow, Field field, Numeric numeric = Numeric.Amount );

        /// <summary>
        /// Gets the fiscal year availability of the authority.
        /// </summary>
        /// <returns>
        /// </returns>
        FundAvailability GetAvailability();

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetAmount();

        /// <summary>
        /// Gets the allocation.
        /// </summary>
        /// <returns>
        /// </returns>
        IAllocation GetAllocation();
    }
}
