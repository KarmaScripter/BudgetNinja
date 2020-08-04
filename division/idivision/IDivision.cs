// <copyright file="IDivision.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    public interface IDivision
    {
        // ****************************************************************************************************************************
        // ************************************************  METHODS   ****************************************************************
        // ****************************************************************************************************************************

        /// <summary>
        /// Gets the name of the division.
        /// </summary>
        /// <returns></returns>
        IElement GetDivisionName();

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        IResponsibilityCenter GetResponsibilityCenter();

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> ToDictionary();

        /// <summary>
        /// Gets the control number data.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<IControlNumber> GetBudgetControlNumbers( IBudgetFiscalYear bfy );

        /// <summary>
        /// Gets the work code data.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<IWorkCode> GetWorkCodes( IBudgetFiscalYear bfy );

        /// <summary>
        /// Gets the hr org code data.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<IHumanResourceOrganization> GetHumanResourceOrganizations( IBudgetFiscalYear bfy );
    }
}