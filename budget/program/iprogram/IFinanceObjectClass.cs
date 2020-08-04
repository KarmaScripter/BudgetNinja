// <copyright file="IFinanceObjectClass.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
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
    public interface IFinanceObjectClass
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
        /// Gets the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        IFinanceObjectClass GetFinanceObjectClass();
    }
}