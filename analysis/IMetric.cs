// <copyright file = "IMetric.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public interface IMetric
    {
        /// <summary>
        /// Calculates the totals.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        IDictionary<string, double> CalculateTotals( IEnumerable<DataRow> dataRow, Field field,
            Numeric numeric = Numeric.Amount );

        /// <summary>
        /// Calculates the averages.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "numeric" >
        /// The numeric.
        /// </param>
        /// <returns>
        /// </returns>
        IDictionary<string, double> CalculateAverages( IEnumerable<DataRow> dataRow, Field field,
            Numeric numeric = Numeric.Amount );
    }
}
