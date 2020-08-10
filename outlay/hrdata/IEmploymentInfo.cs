// // <copyright file = "IEmploymentInfo.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IEmploymentInfo
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

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
        /// Gets the name of the human resource organization.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetHrOrgName();

        /// <summary>
        /// Gets the hire date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetHireDate();

        /// <summary>
        /// Gets the service date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetServiceDate();

        /// <summary>
        /// Gets the grade entry date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetGradeEntryDate();

        /// <summary>
        /// Gets the step entry date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetStepEntryDate();

        /// <summary>
        /// Gets the wigi due date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetWigiDueDate();

        /// <summary>
        /// Gets the appointment authority.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetAppointmentAuthority();

        /// <summary>
        /// Gets the type of the appointment.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetAppointmentType();

        /// <summary>
        /// Gets the bargaining unit.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetBargainingUnit();

        /// <summary>
        /// Gets the retirement plan.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetRetirementPlan();
    }
}
