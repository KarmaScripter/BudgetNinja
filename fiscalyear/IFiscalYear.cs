// <copyright file = "IFiscalYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    public interface IFiscalYear
    {
        /// <summary>
        /// Gets the fiscal year identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetFiscalYearId();

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <returns>
        /// </returns>
        BFY GetBFY();

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetStartDate();

        /// <summary>
        /// Gets the expiration date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetExpirationDate();

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
        /// Determines whether this instance is carryover.
        /// </summary>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if this instance is carryover; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        bool IsCarryover();

        /// <summary>
        /// Gets the cancellation date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetCancellationDate();

        /// <summary>
        /// Gets the work days.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetWorkDays();

        /// <summary>
        /// Gets the week days.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetWeekDays();

        /// <summary>
        /// Gets the week ends.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetWeekEnds();
    }
}
