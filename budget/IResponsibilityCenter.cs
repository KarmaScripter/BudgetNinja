// <copyright file = "IResponsibilityCenter.cs" company = "Terry D. Eppler">
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
    public interface IResponsibilityCenter
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the responsibility center identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the responsibility center code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetCode();

        /// <summary>
        /// Gets the name of the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetName();

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        IResponsibilityCenter GetResponsibilityCenter();
    }
}
