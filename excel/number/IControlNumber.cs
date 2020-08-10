// // <copyright file = "IControlNumber.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public interface IControlNumber
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the budget control number.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetBudgetControlNumber();

        /// <summary>
        /// Gets the control number identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetFiscalYear GetBudgetFiscalYear();

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        IResourcePlanningOffice GetResourcePlanningOffice();

        /// <summary>
        /// Gets the fund control number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFundControlNumber();

        /// <summary>
        /// Gets the division control number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDivisionControlNumber();

        /// <summary>
        /// Gets the region control number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetRegionControlNumber();
    }
}
