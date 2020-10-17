// <copyright file = "IBudgetLevel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

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
    public interface IBudgetLevel
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the level number.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetNumber();

        /// <summary>
        /// Gets the name of the level.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetName();

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns>
        /// </returns>
        Level GetLevel();

        /// <summary>
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        BudgetLevel GetBudgetLevel();
    }
}
