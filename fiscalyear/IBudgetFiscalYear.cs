// <copyright file = "IBudgetFiscalYear.cs" company = "Terry D. Eppler">
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

    public interface IBudgetFiscalYear
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the first year.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFirstYear();

        /// <summary>
        /// Gets the last year.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetLastYear();

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        IBudgetFiscalYear GetBudgetFiscalYear();

        /// <summary>
        /// Gets the availability.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetAvailability();

        /// <summary>
        /// Gets the fiscal year identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetFiscalYearId();

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        BFY GetBFY();

        /// <summary>
        /// Determines whether this instance is current.
        /// </summary>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if this instance is current; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        bool IsCurrent();

        /// <summary>
        /// Gets the federal holidays.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<Field, DateTime> GetFederalHolidays();
    }
}
