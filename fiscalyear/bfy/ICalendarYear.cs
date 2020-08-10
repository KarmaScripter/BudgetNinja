// <copyright file = "ICalendarYear.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "UnusedMemberInSuper.Global" ) ]
    public interface ICalendarYear
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the work days.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWorkDays();

        /// <summary>
        /// Gets the week days.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWeekDays();

        /// <summary>
        /// Gets the week ends.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWeekEnds();

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>
        /// </returns>
        DateTime GetCurrentDate();

        /// <summary>
        /// Gets the current month.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetCurrentMonth();

        /// <summary>
        /// Gets the current year.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetCurrentYear();

        /// <summary>
        /// Gets the current day.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetCurrentDay();
    }
}
