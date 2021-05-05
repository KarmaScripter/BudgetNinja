// <copyright file = "IAccount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    public interface IAccount
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        IKey GetId();

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetCode();

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetName();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <returns>
        /// </returns>
        IAccount GetAccount();

        /// <summary>
        /// Gets the activity
        /// </summary>
        /// <returns>
        /// </returns>
        IActivity GetActivity();

        /// <summary>
        /// Gets the national program code.
        /// </summary>
        /// <returns>
        /// </returns>
        INationalProgram GetNationalProgram();

        /// <summary>
        /// Gets the goal code.
        /// </summary>
        /// <returns>
        /// </returns>
        IGoal GetGoal();

        /// <summary>
        /// Gets the objective code.
        /// </summary>
        /// <returns>
        /// </returns>
        IObjective GetObjective();

        /// <summary>
        /// Gets the program project code.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramProject GetProgramProject();

        /// <summary>
        /// Gets the program area code.
        /// </summary>
        /// <returns>
        /// </returns>
        IProgramArea GetProgramArea();

        /// <inheritdoc>
        /// <cref>
        /// </cref>
        /// </inheritdoc>
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:System.String"/> that represents this instance.
        /// </returns>
        string ToString();
    }
}
