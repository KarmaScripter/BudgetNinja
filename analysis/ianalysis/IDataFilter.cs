// <copyright file="IDataFilter.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ********************************************************************************************************************************
    // *********************************************************  ASSEMBLIES   ********************************************************
    // ********************************************************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;

    public interface IDataFilter
    {
        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// </returns>
        IEnumerable<DataRow> GetData();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "filter" >
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<DataRow> FilterData( Field field, string filter );
    }
}