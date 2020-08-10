// <copyright file = "IGrid.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using OfficeOpenXml;

    public interface IGrid
    {
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelAddress GetAddress();

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelRange GetRange();

        /// <summary>
        /// Gets the worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelWorksheet GetWorksheet();

        /// <summary>
        /// Counts the cells.
        /// </summary>
        /// <param name = "range" >
        /// The range.
        /// </param>
        /// <returns>
        /// </returns>
        int CountCells( ExcelRange range );

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetRowCount();

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <returns>
        /// </returns>
        int GetColumnCount();
    }
}
