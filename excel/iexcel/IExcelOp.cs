// <copyright file = "IExcelOp.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    using System;
    using System.IO;
    using System.Threading;
    using DocumentFormat.OpenXml.Spreadsheet;
    using OfficeOpenXml;

    /// <summary>
    /// Defines the <see cref = "IExcelOp"/>
    /// </summary>
    public interface IExcelOp
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The GetConnectionString
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/>
        /// </returns>
        string GetConnectionString();

        /// <summary>
        /// The GetFile
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/>
        /// </returns>
        string GetFilePath();

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns>
        /// </returns>
        string GetFileName();

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns>
        /// </returns>
        EXT GetExtension();

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name = "filepath" >
        /// The filepath.
        /// </param>
        /// <returns>
        /// </returns>
        FileInfo GetFileStream( string filepath );

        /// <summary>
        /// The GetApplication
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelPackage GetApplication();

        /// <summary>
        /// The GetWorkbook
        /// </summary>
        /// <dict name = "excel" >
        /// </dict>
        /// <dict name = "filepath" >
        /// The filepath <see cref = "string"/>
        /// </dict>
        /// <returns>
        /// The <see cref = "Workbook"/>
        /// </returns>
        ExcelWorkbook GetWorkbook();

        /// <summary>
        /// Gets the excel worksheet.
        /// </summary>
        /// <returns>
        /// </returns>
        ExcelWorksheet GetExcelWorksheet( FundCode fundcode );

        /// <summary>
        /// The SaveWorkBook
        /// </summary>
        /// <dict name = "wb" >
        /// The wb <see cref = "Workbook"/>
        /// </dict>
        void SaveWorkBook();
    }
}
