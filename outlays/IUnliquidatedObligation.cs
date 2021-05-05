// <copyright file = "IUnliquidatedObligation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IObligation"/>
    /// <seealso cref = "IObligation"/>
    public interface IUnliquidatedObligation : IObligation
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the unliquidated obligation amount.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetUnliquidatedObligationAmount();
    }
}
