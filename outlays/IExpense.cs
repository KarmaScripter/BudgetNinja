// <copyright file = "IExpense.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************

    /// <summary>
    /// 
    /// </summary>
    public interface IExpense
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the original action date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetOriginalActionDate();

        /// <summary>
        /// Gets the type of the expense.
        /// </summary>
        /// <returns>
        /// </returns>
        OutlayType GetExpenseType();

        /// <summary>
        /// Gets the pay period.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetPayPeriod();

        /// <summary>
        /// Gets the hr org code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetHrOrgCode();

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetWorkCode();

        /// <summary>
        /// Gets the commitments.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetCommitments();

        /// <summary>
        /// Gets the open commitments.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetOpenCommitments();

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetObligations();

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetDeobligations();

        /// <summary>
        /// Gets the unliquidated obligations.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetUnliquidatedObligations();

        /// <summary>
        /// Gets the expenditures.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetExpenditures();

        /// <summary>
        /// Gets the available balance.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetBalance();
    }
}
