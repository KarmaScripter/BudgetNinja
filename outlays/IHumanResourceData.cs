// <copyright file = "IHumanResourceData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IHumanResourceData
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the workforce Data identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

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
        /// Gets the job title.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetJobTitle();

        /// <summary>
        /// Gets the occupational series.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetOccupationalSeries();

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
        /// Gets the grade.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetGrade();

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetStep();

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
        /// Gets the compensation.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetCompensation();
    }
}
