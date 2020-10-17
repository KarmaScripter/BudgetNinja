// <copyright file = "IGoal.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IGoal
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetCode();

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetName();

        /// <summary>
        /// Gets the goal.
        /// </summary>
        /// <returns>
        /// </returns>
        IGoal GetGoal();
    }
}
