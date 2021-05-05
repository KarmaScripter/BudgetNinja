// <copyright file = "IPayrollBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IPayrollBase
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the payroll hours identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetRpioCode();

        /// <summary>
        /// Gets the pay period.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPayPeriod();

        /// <summary>
        /// Gets the calendar date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetCalendarDate();

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetStartDate();

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetEndDate();

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmployeeNumber();

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetFirstName();

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetLastName();

        /// <summary>
        /// Gets the human resource organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetHrOrgCode();

        /// <summary>
        /// Gets the name of the Human Resource Organization.
        /// </summary>
        /// <returns>
        /// IElement
        /// </returns>
        IElement GetHrOrgName();

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWorkCode();

        /// <summary>
        /// Gets the reporting code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetReportingCode();

        /// <summary>
        /// Gets the reporting code description.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetReportingCodeName();

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetHours();
    }
}
