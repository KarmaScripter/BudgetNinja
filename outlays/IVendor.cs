// <copyright file = "IVendor.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IVendor
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the duns number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDunsNumber();

        /// <summary>
        /// Gets the document number.
        /// </summary>
        /// <returns>
        /// </returns>
        IElement GetDocumentNumber();

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetStartDate();

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetEndDate();

        /// <summary>
        /// Gets the closed date.
        /// </summary>
        /// <returns>
        /// </returns>
        ITime GetClosedDate();

        /// <summary>
        /// Gets the expended.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetExpended();

        /// <summary>
        /// Gets the unliquidated obligation.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetUnliquidatedObligation();

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetAmount();

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<string, object> ToDictionary();
    }
}
