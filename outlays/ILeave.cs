// <copyright file = "ILeave.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface ILeave
    {
        /// <summary>
        /// The GetYearToDateEarned.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetYearToDateEarned();

        /// <summary>
        /// The GetYearToDateUsed.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetYearToDateUsed();

        /// <summary>
        /// The GetMaxLeaveCarryover.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetMaxLeaveCarryover();

        /// <summary>
        /// The GetUseOrLose.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetUseOrLose();

        /// <summary>
        /// The GetProjectedPayPeriod.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetProjectedPayPeriod();

        /// <summary>
        /// The GetProjectedAnnual.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetProjectedAnnual();

        /// <summary>
        /// The GetAnnualHours.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IAmount GetAvailableHours();

        /// <summary>
        /// Gets the annual hours.
        /// </summary>
        /// <returns></returns>
        IAmount GetAnnualHours();

        /// <summary>
        /// The GetHumanResourceOrganization.
        /// </summary>
        /// <returns>
        /// The <see cref = "IHumanResourceOrganization"/> .
        /// </returns>
        IHumanResourceOrganization GetHumanResourceOrganization();

        /// <summary>
        /// The GetWorkCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "IWorkCode"/> .
        /// </returns>
        IWorkCode GetWorkCode();

        /// <summary>
        /// The GetResourcePlanningOfficeCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/> .
        /// </returns>
        IElement GetRpioCode();

        /// <summary>
        /// The GetResourcePlanningOffice.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        IResourcePlanningOffice GetResourcePlanningOffice();

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        IDictionary<string, object> SetArgs( string code );

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
        /// Gets the employee identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetSection();

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmployeeNumber();

        /// <summary>
        /// Gets the office.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetOffice();

        /// <summary>
        /// Gets the phone.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPhoneNumber();

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetCellNumber();

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmail();

        /// <summary>
        /// Gets the employement status.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetEmployementStatus();

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> ToDictionary();

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        Source GetSource();
    }
}
