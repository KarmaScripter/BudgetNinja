// <copyright file = "ICostAccount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    public interface ICostAccount
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        IFinanceObjectClass GetFinanceObjectClass();

        /// <summary>
        /// Gets the national program.
        /// </summary>
        /// <returns>
        /// </returns>
        INationalProgram GetNationalProgram();

        /// <summary>
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramResultsCode GetProgramResultsCode();

        /// <summary>
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramProject GetProgramProject();

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramArea GetProgramArea();
    }
}
